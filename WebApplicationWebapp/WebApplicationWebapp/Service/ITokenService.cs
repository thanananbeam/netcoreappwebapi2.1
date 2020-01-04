using WebApplicationWebapp.BusinessContext.BussinessData;
using WebApplicationWebapp.Model;

namespace WebApplicationWebapp.Service
{
    public interface ITokenService
    {
        string GenToken(RespondModel user_provider);
    }
}