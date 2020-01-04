using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationWebapp.BusinessContext.BussinessData
{
    // table in database
    public class Member
    {
        public System.Guid id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool is_login { get; set; }
        public string email { get; set; }
    }

    // request from client
    public class MemberRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }


}
