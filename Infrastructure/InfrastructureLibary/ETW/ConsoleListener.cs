using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLibary.ETW
{
    class ConsoleListener : BaseListener
    {
        public ConsoleListener(IEnumerable<SourceConfig> sources)
            : base(sources)
        {
        }

        protected override void WriteEvent(System.Diagnostics.Tracing.EventWrittenEventArgs eventData)
        {
            string outputString;
            switch (eventData.EventId)
            {
                case Events.ProcessingStartId:
                    outputString = string.Format("开始 ({0}): {1}", eventData.EventId, (string)eventData.Payload[0]);
                    break;
                case Events.ProcessingFinishId:
                    outputString = string.Format("结束 ({0}): {1}", eventData.EventId, (string)eventData.Payload[0]);
                    break;
                case Events.ProcessErroId:
                    outputString = string.Format("错误 ({0}): {1}: {2}", eventData.EventId, (string)eventData.Payload[0], (string)eventData.Payload[1]);
                    break;
                case Events.NullStringId:
                    outputString = string.Format("空值 ({0}): {1}", eventData.EventId, (string)eventData.Payload[0]);
                    break;
                default:
                    //throw new InvalidOperationException("Unknown event");
                    outputString = "Unknown event";
                    System.Diagnostics.Debug.WriteLine(outputString);
                    break;
            }            
            System.Diagnostics.Debug.WriteLine(outputString);
        }
    }
}
