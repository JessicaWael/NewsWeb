using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewsWebsite.Models
{
    public class NewsDBcontext : DbContext
    {
        public NewsDBcontext(DbContextOptions<NewsDBcontext> options) : base(options)
        {
        }

        public DbSet<News> News { get; set; }
       public DbSet<Category> Categories{ get; set; }
        public DbSet<users> users { get; set; }
       // public DbSet<AppHash>AppHash{get; set; }
    }
    

    }

