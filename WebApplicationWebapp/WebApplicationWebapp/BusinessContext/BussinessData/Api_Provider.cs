using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationWebapp.BusinessContext.BussinessData
{
    // table in database
    public class Api_Provider
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public string email { get; set; }
    }

    // request from client
    public class Api_ProviderRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
    }
}
