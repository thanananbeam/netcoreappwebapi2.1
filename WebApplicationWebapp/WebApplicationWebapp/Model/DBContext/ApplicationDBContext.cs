using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWebapp.BusinessContext.BussinessData;

namespace WebApplicationWebapp.Model.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<Api_Provider> Api_Provider { get; set;}
        public DbSet<Member> Member { get; set; }
        public DbSet<Product_List> Product_List { get; set; }
    }
}
