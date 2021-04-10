using InfrastructureLibary.Models;
using Prism.Events;

namespace InfrastructureLibary.Events
{
    public class LandInformationEvent : PubSubEvent<LandInformation>
    {
        public void IsChange()
        {

        }
    }
}
