using Eshop.Domain;
using Eshop.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly EshopDbContext dbContext;

        public ProductController(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private static List<Product> Products = new List<Product>
        {
            new Product(1, "Notebook Acer 16", "Best notebook out there", 399.99m, CategoryController.Categories[0]),
            new Product(2, "Mouse Razor 123", "Best Mouse", 14.50m, CategoryController.Categories[1]),
        };

        [HttpGet]
        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return dbContext.Products.First(x => x.Id == id);
        }

        [HttpPost]
        public Product CreateProduct(string title, string description, decimal price, int categoryId)
        {
            var category = CategoryController.Categories.First(x => x.Id == categoryId);
            var newId = dbContext.Products.Max(x => x.Id) + 1;
            var newProduct = new Product(newId, title, description, price, category);
            
            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();

            return newProduct;
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            var productToBeDeleted = dbContext.Products.First(x => x.Id == id);
            dbContext.Products.Remove(productToBeDeleted);

            dbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public Product UpdateProduct(int id, string title, string description, decimal price, int categoryId)
        {
            var category = CategoryController.Categories.First(x => x.Id == categoryId);
            var productToBeUpdated = dbContext.Products.First(x => x.Id == id);
            productToBeUpdated.Update(title, description, price, category);

            dbContext.SaveChanges();

            return productToBeUpdated;
        }
    }
}
