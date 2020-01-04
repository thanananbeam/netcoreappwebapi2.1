using WebApplicationWebapp.BusinessContext.BussinessData;
using WebApplicationWebapp.Model;

namespace WebApplicationWebapp.BusinessContext.BussinessModel
{
    public interface IBL_Product
    {
        RespondModel GetList();
        RespondModel AddProduct(ProductAddRequest productadd);
        RespondModel UpdateProduct(ProductUpdateRequest productupdate);
        RespondModel DeleteProduct(ProductDeleteRequest productdelete);
    }
}