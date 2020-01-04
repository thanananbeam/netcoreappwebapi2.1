using System.Collections.Generic;
using WebApplicationWebapp.BusinessContext.BussinessData;
using WebApplicationWebapp.Model;

namespace WebApplicationWebapp.BusinessContext.BussinessModel
{
    public interface IBL_APIProvider
    {
        RespondModel getListProvider(Api_ProviderRequest user_provider);
    }
}