using Eshop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private static List<Category> Categories = new List<Category>
        {
            new Category(1, "Computers"),
            new Category(2, "Mouses")
        };

        private static List<Product> Products = new List<Product>
        {
            new Product(1, "Notebook Acer 16", "Best notebook out there", 399.99m, Categories[0]),
            new Product(2, "Mouse Razor 123", "Best Mouse", 14.50m, Categories[1]),
        };

        [HttpGet]
        public List<Product> GetProducts()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return Products.First(x => x.Id == id);
        }

        [HttpPost]
        public Product CreateProduct(string title, string description, decimal price, int categoryId)
        {
            var category = Categories.First(x => x.Id == categoryId);
            var newId = Products.Max(x => x.Id) + 1;
            var newProduct = new Product(newId, title, description, price, category);
            
            Products.Add(newProduct);

            return newProduct;
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            var productToBeDeleted = Products.First(x => x.Id == id);
            Products.Remove(productToBeDeleted);
        }

        [HttpPut("{id}")]
        public Product UpdateProduct(int id, string title, string description, decimal price, int categoryId)
        {
            var category = Categories.First(x => x.Id == categoryId);
            var productToBeUpdated = Products.First(x => x.Id == id);
            productToBeUpdated.Update(title, description, price, category);

            return productToBeUpdated;
        }
    }
}
