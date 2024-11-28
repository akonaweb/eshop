using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain
{
    public class Category
    {
        public object Categories;

        public Category(int id, string name)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(id);

            ValidateParameters(name);

            Id = id;
            Name = name;
        }
                            
        public int Id { get; }
        public string Name { get; private set; }

        public int? ParentCategoryId { get; set; } 
        public Category? ParentCategory { get; set; }
        [NotMapped]
        public ICollection<Category> categories { get; set; } = new List<Category>();

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