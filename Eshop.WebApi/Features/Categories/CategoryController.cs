using Eshop.Domain;
using Eshop.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Features.Categories
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly EshopDbContext dbContext;

        public CategoryController(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<Category> GetCategories()
        {
            return dbContext.CategoriesViews.ToList();
        }

        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            return dbContext.CategoriesViews.First(x => x.Id == id);
        }

        [HttpPost]
        public Category AddCategory(string name)
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
