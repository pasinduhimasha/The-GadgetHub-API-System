using ElectroComAPI.Models;
namespace ElectroComAPI.Data
{
    //This class will be used to work with product data
    public class ProductRepo
    {
        private AppDBContext dBContext;

        public ProductRepo(AppDBContext appDBContext)
        {
            dBContext = appDBContext;
        }
        public bool Save()
        {
            int count=dBContext.SaveChanges();
            if(count>0)
                return true;
            return false;
        }
        public bool Create(Product product)
        {
            if (product != null)
            {
                dBContext.Products.Add(product);
                return Save();
            }
            return false;
        }
        public bool Update(Product product)
        {
            if (product != null)
            {
                dBContext.Products.Update(product);
                return Save();
            }
            return false;
        }
        public bool Remove(Product product)
        {
            if (product != null)
            {
                dBContext.Products.Remove(product);
                return Save();
            }
            return false;
        }
        public List<Product> GetProducts()
        {
            return dBContext.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return dBContext.Products.FirstOrDefault(p=>p.Id==id);
        }

        public Product? GetProductByName(string productName)
        {
            return dBContext.Products.FirstOrDefault(p => p.Name == productName);
        }
    }
}
