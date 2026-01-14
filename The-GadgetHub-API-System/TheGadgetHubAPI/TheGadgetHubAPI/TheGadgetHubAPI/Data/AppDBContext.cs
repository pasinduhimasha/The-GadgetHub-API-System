using Microsoft.EntityFrameworkCore;
using TheGadgetHubAPI.Models;
namespace TheGadgetHubAPI.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        { 
        }
        //List down all the models like below
        public DbSet<Product> Products { get; set; }
        

        //This method will create tables
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //If we are allowing EF to select the SQl data types then
            //can do like below option 1
            
           
           
           
        
        }

        
    }
}
