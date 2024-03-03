namespace Eshop.Domain
{
    public class Product
    {
        public Product(string title, string description, decimal price)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description");
            }

            if (price < 0)
            {
                throw new ArgumentNullException("price");
            }

            Title = title;
            Description = description;
            Price = price;
        }

        public string Title { get; }
        public string Description { get; }
        public decimal Price { get; }
    }
}