using Eshop.Domain;

var products = new List<Product>
{
    new Product("Notebook Acer 15", "Best notebook out there", 399.99m),
    new Product("Mouse Razor 123", "Best Mouse", 14.50m),
    new Product("Title", "Description", 123)
};

foreach (var product in products)
{
    Console.WriteLine($"{product.Title} | {product.Description} | {product.Price}");
}