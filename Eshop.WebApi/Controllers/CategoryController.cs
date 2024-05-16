using Eshop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category(1, "Computers"),
            new Category(2, "Mouses")
        };

        [HttpGet]
        public List<Category> GetCategories()
        {
            return Categories;
        }

        [HttpGet("{id}")]
        public Category GetCategory(int id) 
        { 
            return Categories.First(x => x.Id == id);
        }

        [HttpPost]
        public Category CreateCategory(string name) 
        { 
            var newId = Categories.Max(x => x.Id) + 1;
            var newCategory = new Category(newId, name);

            Categories.Add(newCategory);

            return newCategory;
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id) 
        { 
            var categoryToBeDeleted = Categories.First(x => x.Id == id);
            Categories.Remove(categoryToBeDeleted);
        }

        [HttpPut("{id}")]
        public Category UpdateCategory(int id, string Name) 
        {
            var categoryToBeUpdated = Categories.First(x => x.Id == id);
            categoryToBeUpdated.Udpate(Name);   

            return categoryToBeUpdated;
        }
    }
}
