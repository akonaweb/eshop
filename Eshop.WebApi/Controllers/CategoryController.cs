using Eshop.Domain;
using Eshop.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly EshopDbContext dbContext;

        public CategoryController(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public static List<Category> Categories = new List<Category>
        {
            new Category(1, "Computers"),
            new Category(2, "Mouses")
        };

        [HttpGet]
        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList(); ;
        }

        [HttpGet("{id}")]
        public Category GetCategory(int id) 
        {
            return dbContext.Categories.First(x => x.Id == id);
        }

        [HttpPost]
        public Category CreateCategory(string name) 
        { 
            var newCategory = new Category(0, name);

            dbContext.Categories.Add(newCategory);
            dbContext.SaveChanges();

            return newCategory;
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id) 
        { 
            var categoryToBeDeleted = dbContext.Categories.First(x => x.Id == id);
            dbContext.Categories.Remove(categoryToBeDeleted);

            dbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public Category UpdateCategory(int id, string name) 
        {
            var categoryToBeUpdated = dbContext.Categories.First(x => x.Id == id);
            categoryToBeUpdated.Udpate(name);

            dbContext.SaveChanges();

            return categoryToBeUpdated;
        }
    }
}
