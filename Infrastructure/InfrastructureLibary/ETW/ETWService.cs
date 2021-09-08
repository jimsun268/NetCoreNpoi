using System.Diagnostics.Tracing;

namespace InfrastructureLibary.ETW
{
    public class ETWService : IETWService
    {
        public void NullString(string pName)
        {
            var consoleListener = new ConsoleListener(
                new SourceConfig[]
                {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Informational,
                        Keywords = Events.Keywords.General}
                });
            Events.Log.NullString("This won't be logged");
            consoleListener.Dispose();
        }
        public void ProcessInformational(string pName, string pMessage)
        {
            var fileListener = new FileListener(
               new SourceConfig[]
               {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Informational,
                        Keywords = Events.Keywords.General}
               },
               "PrimeOutput.txt");

            var consoleListener = new ConsoleListener(
                new SourceConfig[]
                {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Informational,
                        Keywords = Events.Keywords.General}
                });
            Events.Log.ProcessInformational(pName, pMessage);
            consoleListener.Dispose();
            fileListener.Dispose();
        }
        public void ProcessErro(string pName, string erroMessage)
        {
            var fileListener = new FileListener(
               new SourceConfig[]
               {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Error,
                        Keywords = Events.Keywords.PrimeOutput}
               },
               "PrimeOutput.txt");

            var consoleListener = new ConsoleListener(
                new SourceConfig[]
                {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Error,
                        Keywords = Events.Keywords.PrimeOutput}
                });
            Events.Log.ProcessErro(pName, erroMessage);
            consoleListener.Dispose();
            fileListener.Dispose();
        }
        public void ProcessingFinish(string pName)
        {
            var fileListener = new FileListener(
               new SourceConfig[]
               {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Informational,
                        Keywords = Events.Keywords.General}
               },
               "PrimeOutput.txt");
            var consoleListener = new ConsoleListener(
                new SourceConfig[]
                {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Informational,
                        Keywords = Events.Keywords.General}
                });
            Events.Log.ProcessingFinish(pName);
            consoleListener.Dispose();
            fileListener.Dispose();
        }
        public void ProcessingStart(string pName)
        {
            var fileListener = new FileListener(
               new SourceConfig[]
               {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Informational,
                        Keywords = Events.Keywords.General}
               },
               "PrimeOutput.txt");
            var consoleListener = new ConsoleListener(
                new SourceConfig[]
                {
                    new SourceConfig(){
                        Name = "NetCoreNpoi",
                        Level = EventLevel.Informational,
                        Keywords = Events.Keywords.General}
                });
            Events.Log.ProcessingStart(pName);
            consoleListener.Dispose();
            fileListener.Dispose();
        }
    }
}
