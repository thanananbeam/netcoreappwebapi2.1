using Microsoft.EntityFrameworkCore;
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
    public class BL_Product : IBL_Product
    {
        private readonly IConfiguration _configuration;
        public ApplicationDBContext _context;

        public BL_Product(IConfiguration configuration, ApplicationDBContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public RespondModel GetList()
        {
            RespondModel modelRespond = new RespondModel();
            try
            {
                var model = _context.Product_List.ToList();

                if (model.Count() > 0)
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

        public RespondModel AddProduct(ProductAddRequest productadd)
        {
            RespondModel modelRespond = new RespondModel();

            try
            {
                if (productadd.p_price.GetType() != typeof(int) || productadd.p_price <= 0)
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request product price";
                    return modelRespond;
                }

                if (string.IsNullOrEmpty(productadd.p_name))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request product name";
                    return modelRespond;
                }

                if (string.IsNullOrEmpty(productadd.p_desc))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request product desc";
                    return modelRespond;
                }

                Insert(productadd);

                modelRespond.status = "success";
                modelRespond.message = "insert product success";

            }
            catch (Exception ex)
            {

                modelRespond.status = "errortrycatch";
                modelRespond.message = ex.ToString();
            }

            return modelRespond;
        }

        public RespondModel UpdateProduct(ProductUpdateRequest productupdate) {
            RespondModel modelRespond = new RespondModel();

            try
            {
                if (productupdate.p_id.GetType() != typeof(int) || productupdate.p_id <= 0)
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request product id";
                    return modelRespond;
                }

                if (productupdate.p_price.GetType() != typeof(int) || productupdate.p_price <= 0)
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request product price";
                    return modelRespond;
                }

                if (string.IsNullOrEmpty(productupdate.p_name))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request product name";
                    return modelRespond;
                }

                if (string.IsNullOrEmpty(productupdate.p_desc))
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request product desc";
                    return modelRespond;
                }
                var model = _context.Product_List.Where(x => x.p_id == productupdate.p_id).FirstOrDefault();

                if (model != null)
                {
                    Update(model, productupdate);

                    modelRespond.status = "success";
                    modelRespond.message = "update product success";
                }
                else
                {
                    modelRespond.status = "notfound";
                    modelRespond.message = "not found data";
                }
            }
            catch (Exception ex)
            {
                modelRespond.status = "errortrycatch";
                modelRespond.message = ex.ToString();
            }

            return modelRespond;
        }

        public RespondModel DeleteProduct(ProductDeleteRequest productdelete)
        {
            RespondModel modelRespond = new RespondModel();

            try
            {
                if (productdelete.p_id.GetType() != typeof(int) || productdelete.p_id <= 0)
                {
                    modelRespond.status = "validate";
                    modelRespond.message = "request product id";
                    return modelRespond;
                }

                var model = _context.Product_List.Where(x => x.p_id == productdelete.p_id).SingleOrDefault();

                if (model != null)
                {
                    Delete(model);

                    modelRespond.status = "success";
                    modelRespond.message = "Delete product success";
                }
                else
                {
                    modelRespond.status = "notfound";
                    modelRespond.message = "not found data";
                }
            }
            catch (Exception ex)
            {
                modelRespond.status = "errortrycatch";
                modelRespond.message = ex.ToString();
            }

            return modelRespond;
        }

        private void Insert(ProductAddRequest productAdd) {

            var product = _context.Set<Product_List>();
            product.Add(new Product_List { p_name = productAdd.p_name, p_price = productAdd.p_price, p_desc = productAdd.p_desc });
            _context.SaveChanges();

        }

        private void Update(Product_List productlist ,ProductUpdateRequest productupdate)
        {
            productlist.p_name = productupdate.p_name;
            productlist.p_price = productupdate.p_price;
            productlist.p_desc = productupdate.p_desc;
            _context.SaveChanges();
        }

        private void Delete(Product_List productdelete)
        {

            _context.Product_List.Remove(productdelete);
            _context.SaveChanges();
        }
    }
}
