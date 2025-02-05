using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Dbcon : DbContext
    {
        public Dbcon (): base("ConnectionString"){ 
        }
        public DbSet<Post>Posts { get; set; }
    }
}








