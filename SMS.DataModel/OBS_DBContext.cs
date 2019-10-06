using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DataModel
{
    public class OBS_DBContext : DbContext
    {
        public OBS_DBContext()
            : base("OBS_DBConnectionString")
        {
            Database.SetInitializer<OBS_DBContext>(null);
        }
        public DbSet<CategoryDM> CategoryDMs { get; set; }
        public DbSet<UserDM> UserDMs { get; set; }
        public DbSet<BookDM> BookDMs { get; set; }
        public DbSet<CartDM> CartDMs { get; set; }
        public DbSet<OrderDM> OrderDMs { get; set; }
        public DbSet<PositionDM> PositionDMs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryDM>().ToTable("Category");
            modelBuilder.Entity<UserDM>().ToTable("User");
            modelBuilder.Entity<BookDM>().ToTable("Book");
           modelBuilder.Entity<CartDM>().ToTable("Cart");
            modelBuilder.Entity<OrderDM>().ToTable("Order");
            modelBuilder.Entity<PositionDM>().ToTable("Position");


        }
    }
}
