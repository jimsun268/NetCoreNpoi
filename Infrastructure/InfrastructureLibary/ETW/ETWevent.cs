using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;

namespace InfrastructureLibary.ETW
{
    [EventSource (Name ="NetCoreNpoi")]
    internal sealed class Events : EventSource
    {
        public static readonly Events Log = new Events();

        public class Keywords
        {
            public const EventKeywords General = (EventKeywords)1;
            public const EventKeywords PrimeOutput = (EventKeywords)2;
        }

        internal const int ProcessingStartId = 1;  
        internal const int ProcessingFinishId = 2;
        internal const int ProcessErroId = 3;
        internal const int NullStringId = 4;

        [Event(ProcessingStartId, Level = EventLevel.Informational, Keywords = Keywords.General)]
        public void ProcessingStart(string pName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(ProcessingStartId, pName);
                
            }
        }

        [Event(ProcessingFinishId, Level = EventLevel.Informational, Keywords = Keywords.General)]
        public void ProcessingFinish(string pName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(ProcessingFinishId,pName );
            }
        }

        [Event(ProcessErroId, Level = EventLevel.Error, Keywords = Keywords.PrimeOutput)]
        public void ProcessErro(string pName,string erroMessage)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(ProcessErroId, pName, erroMessage);
            }
        }

        [Event(NullStringId, Level = EventLevel.Informational, Keywords = Keywords.General)]
        public void NullString(string id)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(NullStringId, (string)null);
            }
        }

    }
}
