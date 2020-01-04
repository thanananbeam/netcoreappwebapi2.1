using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWebapp.BusinessContext.BussinessData;
using WebApplicationWebapp.Model;
using WebApplicationWebapp.Model.DBContext;

namespace WebApplicationWebapp.BusinessContext.BussinessModel
{
    public class BL_APIProvider : IBL_APIProvider
    {
        private readonly IConfiguration _configuration;
        public ApplicationDBContext _context;

        public BL_APIProvider(IConfiguration configuration, ApplicationDBContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public RespondModel getListProvider(Api_ProviderRequest user_provider)
        {
            RespondModel modelRespond = new RespondModel();

            try
            {
                if (string.IsNullOrEmpty(user_provider.username))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request username";
                    return modelRespond;
                }
                if (string.IsNullOrEmpty(user_provider.password))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request password";
                    return modelRespond;
                }
                if (string.IsNullOrEmpty(user_provider.type))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request type";
                    return modelRespond;
                }

                var model = _context.Api_Provider.Where(x => x.username == user_provider.username && x.password == user_provider.password && x.type == "pandasoft");

                if (model.Count() > 0)
                {
                    modelRespond.status = "success";
                    modelRespond.data = JsonConvert.SerializeObject(model.FirstOrDefault());
                }
                else
                {
                    modelRespond.status = "notfound";
                    modelRespond.message = "not found data";
                }

                return modelRespond;
            }
            catch (Exception ex)
            {

                modelRespond.status = "errortrycatch";
                modelRespond.message = ex.ToString();

            }
            
            return modelRespond;
        }

    }
}
