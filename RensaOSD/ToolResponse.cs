using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RensaOSD
{
    public class ToolResponse
    {
        public ToolResponse(){}
        public ToolResponse (string input)
        {
            result = new List<string>() { input };
        }
        public List<object> errors { get; set; }
        public List<string> result { get; set; }
    }
}
