using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace InfrastructureLibary.ETW
{
    class SourceConfig
    {
        public string Name { get; set; }
        public EventLevel Level { get; set; }
        public EventKeywords Keywords { get; set; }
    }

    abstract class BaseListener : EventListener
    {
        List<SourceConfig> configs = new List<SourceConfig>();
        protected BaseListener(IEnumerable<SourceConfig> sources)
        {
            this.configs.AddRange(sources);

            foreach (var source in this.configs)
            {
                var eventSource = FindEventSource(source.Name);
                if (eventSource != null)
                {
                    this.EnableEvents(eventSource, source.Level, source.Keywords);
                }
            }
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);

            foreach (var source in this.configs)
            {
                if (string.Equals(source.Name, eventSource.Name))
                {
                    this.EnableEvents(eventSource, source.Level, source.Keywords);
                }
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            this.WriteEvent(eventData);
        }

        private static EventSource FindEventSource(string name)
        {
            foreach (var eventSource in EventSource.GetSources())
            {
                if (string.Equals(eventSource.Name, name))
                {
                    return eventSource;
                }
            }
            return null;
        }

        protected abstract void WriteEvent(EventWrittenEventArgs eventData);
    }
}
