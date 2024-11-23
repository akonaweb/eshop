namespace Eshop.Domain
{
    public class Category
    {
        public Category(int id, string name)
        {
            ValidateParameters(name);

            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; private set; }

        public void Udpate(string name)
        {
            ValidateParameters(name);

            Name = name;
        }

        private static void ValidateParameters(string name)
        {
            if (string.IsNullOrEmpty(name?.Trim()) || name.Length > 50)
            {
                throw new ArgumentNullException(nameof(name));
            }
        }
    }
}