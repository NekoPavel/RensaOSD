using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RensaOSD
{
    class RequestBody
    {
        public string computerName { get; set; }
        public string userName { get; set; }
        public string mobileDeviceName { get; set; }
        public string[] customParameters { get; set; }
        public RequestBody(string computerName)
        {
            this.computerName = computerName;
        }
    }
}
