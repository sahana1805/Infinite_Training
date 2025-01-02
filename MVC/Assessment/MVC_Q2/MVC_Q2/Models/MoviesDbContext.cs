
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MVC_Q2.Models
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
    }
}
