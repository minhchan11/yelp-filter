using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace YelpMvp.Models
{
    public class YelpMvpContext : DbContext
    {
        public YelpMvpContext()
        {

        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Cuisine> Cuisines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=YelpMvp;integrated security=True");
        }

        public YelpMvpContext(DbContextOptions<YelpMvpContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
