using Eshop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private static List<Product> Products = new List<Product>
        {
            new Product(1, "Notebook Acer 16", "Best notebook out there", 399.99m),
            new Product(2, "Mouse Razor 123", "Best Mouse", 14.50m),
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
        public Product CreateProduct(string title, string description, decimal price)
        {
            var newId = Products.Max(x => x.Id) + 1;
            var newProduct = new Product(newId, title, description, price);
            
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
        public Product UpdateProduct(int id, string title, string description, decimal price)
        {
            var productToBeUpdated = Products.First(x => x.Id == id);
            productToBeUpdated.Update(title, description, price);

            return productToBeUpdated;
        }
    }
}
