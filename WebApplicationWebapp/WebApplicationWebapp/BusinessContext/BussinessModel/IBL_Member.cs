using WebApplicationWebapp.BusinessContext.BussinessData;
using WebApplicationWebapp.Model;
using WebApplicationWebapp.Model.DBContext;

namespace WebApplicationWebapp.BusinessContext.BussinessModel
{
    public interface IBL_Member
    {
        RespondModel Login(MemberRequest user_member);
        RespondModel Logout(MemberRequest user_member);
        void updateIslogin(RespondModel resmodel, bool is_login);
    }
}