using System;
using System.Collections.Generic;
using System.IO;

namespace InfrastructureLibary.ETW
{
    class FileListener : BaseListener
    {
        
       
        StreamWriter sw;
        string st;
        public FileListener(IEnumerable<SourceConfig> sources, string outputFile)
            : base(sources)
        {
            
            FileInfo fileInfo = new FileInfo(outputFile);
            sw = fileInfo.AppendText();
            
        }

        protected override void WriteEvent(System.Diagnostics.Tracing.EventWrittenEventArgs eventData)
        {            
            DateTime time = DateTime.UtcNow.AddHours(8) ;
             st =st+ time.ToString("MM月dd日 HH:mm:ss:fff");            
            switch (eventData.EventId)
            {
                case Events.ProcessInformationalId:
                    st = st + "  记录  " + (string)eventData.Payload[0] + "\n";
                    break;
                case Events.ProcessingStartId:
                    st = st + "  开始  " + (string)eventData.Payload[0]+ "\n";                    
                    break;
                case Events.ProcessingFinishId:
                    st = st + "  结束  " + (string)eventData.Payload[0] + "\n";                   
                    break;
                case Events.ProcessErroId:
                    st = st + "  错误  " + (string)eventData.Payload[0] + "  错误：" + (string)eventData.Payload[1] + "\n";                    
                    break;
                case Events.NullStringId:
                    st = st + "  空值  " + (string)eventData.Payload[0] + "\n";                  
                    break;
                default:
                    throw new InvalidOperationException("Unknown event");
            }                
        }

        public override void Dispose()
        {
            sw.Write(st);
            sw.Close();         
            base.Dispose();
        }
    }
}
