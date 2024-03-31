namespace Eshop.Domain
{
    public class Product
    {
        public Product(int id, string title, string description, decimal price, Category category)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            ValidateParameters(title, description, price, category);

            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Category = category;
        }

        public int Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; private set; }

        public void Update(string title, string description, decimal price, Category category)
        {
            ValidateParameters(title, description, price, category);

            Title = title;
            Description = description;
            Price = price;
            Category = category;
        }

        private static void ValidateParameters(string title, string description, decimal price, Category category)
        {
            if (string.IsNullOrEmpty(title) || title.Length > 50)
            {
                throw new ArgumentNullException("title");
            }

            if (string.IsNullOrEmpty(description) || description.Length > 500)
            {
                throw new ArgumentNullException("description");
            }

            if (price < 0)
            {
                throw new ArgumentNullException("price");
            }

            if (category == null) 
            {
                throw new ArgumentNullException("category");    
            }
        }
    }
}