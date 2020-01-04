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
    public class BL_Member : IBL_Member
    {
        private readonly IConfiguration _configuration;
        public ApplicationDBContext _context;

        public BL_Member(IConfiguration configuration, ApplicationDBContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public RespondModel Login(MemberRequest user_member)
        {
            RespondModel modelRespond = new RespondModel();
            try
            {
                if (string.IsNullOrEmpty(user_member.username))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request username";
                    return modelRespond;
                }
                if (string.IsNullOrEmpty(user_member.password))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request password";
                    return modelRespond;
                }

                var model = _context.Member.Where(x => x.username == user_member.username && x.password == user_member.password);

                if (model.Count() > 0)
                {
                    var checklogin = model.Where(x => x.is_login == false);

                    if (checklogin.Count() > 0)
                    {
                        modelRespond.status = "success";
                        modelRespond.data = JsonConvert.SerializeObject(checklogin.FirstOrDefault());

                    }
                    else
                    {
                        modelRespond.status = "userisactive";
                        modelRespond.message = "user is active can't login please try again";
                    }
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


        public RespondModel Logout(MemberRequest user_member) {
            RespondModel modelRespond = new RespondModel();
            try
            {
                if (string.IsNullOrEmpty(user_member.username))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request username";
                    return modelRespond;
                }
                if (string.IsNullOrEmpty(user_member.password))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request password";
                    return modelRespond;
                }

                var model = _context.Member.Where(x => x.username == user_member.username && x.password == user_member.password).FirstOrDefault();

                if (model != null)
                {
                    modelRespond.status = "success";
                    modelRespond.data = JsonConvert.SerializeObject(model);
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

        public void updateIslogin(RespondModel resmodel, bool is_login)
        {
            var res = JsonConvert.DeserializeObject<Member>(resmodel.data.ToString());
            var login_update = _context.Member.AsQueryable().Where(x => x.id == res.id).FirstOrDefault();
            login_update.is_login = is_login;
            _context.SaveChanges();
        }
    }
}
