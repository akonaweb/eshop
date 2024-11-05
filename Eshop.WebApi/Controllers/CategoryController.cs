using Eshop.Domain;
using Eshop.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        // TODO: we should return always DTO instead of domain entity
        public List<Category> GetCategories()
        {
            return dbContext.CategoriesViews.ToList(); ;
        }

        [HttpGet("{id}")]
        public Category GetCategory(int id) 
        {
            return dbContext.CategoriesViews.First(x => x.Id == id);
        }

        [HttpPost]
        // TODO: create request dto for body instead of query params
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
        // TODO: create request dto for body instead of query params
        public Category UpdateCategory(int id, string name) 
        {
            var categoryToBeUpdated = dbContext.Categories.First(x => x.Id == id);
            categoryToBeUpdated.Udpate(name);
            // dbContext.Categories.Update(categoryToBeUpdated);
            // NOTE: we are not using here dbContext.Update or dbContext.Categories.Update and it works
            // dbContext.ChangeTracker.DetectChanges();

            dbContext.SaveChanges();

            return categoryToBeUpdated;
        }
    }
}
