using System.Reflection.Metadata;

namespace Eshop.Domain
{
    public class Category
    {
        private Category() { } // This constuctor is only for EF

        public Category(int id, string name)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            ValidateParameters(name);

            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; private set; }

        public void Udpate(string name)
        {
            ValidateParameters(name);

            Name = name;
        }

        private void ValidateParameters(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 50)
            {
                throw new ArgumentNullException("name");
            }
        }
    }
}