using Eshop.Domain;

var categories = new List<Category>
{
    new Category(1, "Computers"),
    new Category(2, "Mouses")
};

var products = new List<Product>
{
    new Product(1, "Notebook Acer 15", "Best notebook out there", 399.99m, categories[0]),
    new Product(2, "Mouse Razor 123", "Best Mouse", 14.50m, categories[1])
};

foreach (var category in categories)
{
    Console.WriteLine(category.Name);
}

foreach (var product in products)
{
    Console.WriteLine($"{product.Title} | {product.Description} | {product.Price} | {product.Category?.Name}");
}