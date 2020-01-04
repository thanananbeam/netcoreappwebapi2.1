using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWebapp.Model.DBContext;

namespace WebApplicationWebapp.BusinessContext.BussinessData
{
    //
    public class Product_List
    {
        [Key]
        public int p_id { get; set; }
        public string p_name { get; set; }
        public int? p_price { get; set; }
        public string p_desc { get; set; }
    }

    // request from client
    public class ProductAddRequest
    {
        public string p_name { get; set; }
        public int p_price { get; set; }
        public string p_desc { get; set; }
    }

    // request from client
    public class ProductUpdateRequest
    {
        [Key]
        public int p_id { get; set; }
        public string p_name { get; set; }
        public int p_price { get; set; }
        public string p_desc { get; set; }
    }

    public class ProductDeleteRequest
    {
        [Key]
        public int p_id { get; set; }
    }
}
