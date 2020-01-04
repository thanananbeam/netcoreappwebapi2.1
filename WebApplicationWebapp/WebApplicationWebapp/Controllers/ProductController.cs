using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplicationWebapp.BusinessContext.BussinessData;
using WebApplicationWebapp.BusinessContext.BussinessModel;

namespace WebApplicationWebapp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IConfiguration _configuration;
        private IBL_Product _BLProduct;

        public ProductController(IConfiguration configuration, IBL_Product BL_Product)
        {
            _configuration = configuration;
            _BLProduct = BL_Product;
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            return Ok(_BLProduct.GetList());
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody]ProductAddRequest productadd)
        {
            var respond = _BLProduct.AddProduct(productadd);

            return Ok(respond);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody]ProductUpdateRequest productupdate)
        {
            var respond = _BLProduct.UpdateProduct(productupdate);

            return Ok(respond);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody]ProductDeleteRequest productdelete)
        {
            var respond = _BLProduct.DeleteProduct(productdelete);

            return Ok(respond);
        }
    }
}