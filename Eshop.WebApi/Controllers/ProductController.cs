﻿using Eshop.Domain;
using Eshop.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public List<Product> GetProducts()
        {
            return dbContext.ProductsViews.Include(x => x.Category).ToList();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return dbContext.ProductsViews.Include(x => x.Category).First(x => x.Id == id);
        }

        [HttpPost]
        // TODO: create request dto for body instead of query params
        public Product CreateProduct(string title, string description, decimal price, int categoryId)
        {
            var category = dbContext.Categories.FirstOrDefault(x => x.Id == categoryId);
            var newProduct = new Product(0, title, description, price, category);
            
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
        // TODO: create request dto for body instead of query params
        public Product UpdateProduct(int id, string title, string description, decimal price, int categoryId)
        {
            var category = dbContext.Categories.First(x => x.Id == categoryId);
            var productToBeUpdated = dbContext.Products.First(x => x.Id == id);
            productToBeUpdated.Update(title, description, price, category);
            dbContext.SaveChanges();

            return productToBeUpdated;
        }
    }
}
