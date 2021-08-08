using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace companyservice.Model
{
    public class Status
    {
        public string Result { set; get; }
        public string Message { set; get; }
    }
    public class LoggedinUser
    {
        public string access_token { set; get; }
    }
}
