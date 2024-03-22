using Eshop.Domain;

var products = new List<Product>
{
    new Product(1, "Notebook Acer 15", "Best notebook out there", 399.99m),
    new Product(2, "Mouse Razor 123", "Best Mouse", 14.50m),
};

var categories = new List<Category>
{
    new Category(1, "Computers"),
    new Category(2, "Mouses")
};

foreach (var category in categories)
{
    Console.WriteLine(category.Name);
}

foreach (var product in products)
{
    Console.WriteLine($"{product.Title} | {product.Description} | {product.Price}");
}