using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLibary.ETW
{
    public interface IETWService
    {
        public void ProcessingStart(string pName);
        public void ProcessingFinish(string pName);
        public void ProcessErro(string pName,string erroMessage);
        public void NullString(string pName);
        public void ProcessInformational(string pName, string pMessage);
    }
}
