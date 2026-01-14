using Microsoft.EntityFrameworkCore;
using GadgetCentralAPI.Models;
namespace GadgetCentralAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }
        //List down all the models like below
        public DbSet<Product> Products { get; set; }
        public DbSet<Quotation> Quotations { get; set; }

        public DbSet<QuotaionItem> QuotationItems { get; set; }


        //This method will create tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //If we are allowing EF to select the SQl data types then
            //can do like below option 1

            //In case of asking EF to select a specific data type then do as option 2
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuotaionItem>()
                .Property(q => q.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<QuotaionItem>()
                .Property(q => q.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Quotation>()
                .Property(q => q.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>().Property(p => p.Price).
                HasColumnType("decimal(18,2)");



        }


    }
}