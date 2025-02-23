namespace Eshop.Domain.Tests
{
    public class ProductTests
    {
        [Test]
        public void Product_WithValidParams_SetCorrectlyProperties()
        {
            // Arrange
            var id = 1;
            var title = "Default";
            var description = "Default description";
            var price = 1200;
            var category = new Category(1, "Notebooks");

            // Act
            var sut = new Product(id, title, description, price, category);

            // Assert
            Assert.AreEqual(id, sut.Id);
            Assert.AreEqual(title, sut.Title);
            Assert.AreEqual(description, sut.Description);
            Assert.AreEqual(price, sut.Price);
            Assert.AreEqual(category, sut.Category);
        }

        [Test]
        public void Product_WithNullCategoryParam_AllowsNullCategory()
        {
            // Arrange
            Category category = null!;

            // Act
            var product = new Product(1, "Laptop", "A great laptop", 1200, category);

            // Assert
            Assert.IsNull(product.Category, "Product category should allow null values.");
        }

        [Test]
        public void ProductUpdate_WithValidParams_UpdatesSuccessfully()
        {
            // Arrange
            var newTitle = "Updated Title";
            var newDescription = "Updated Description";
            var newPrice = 1500;
            var newCategory = new Category(2, "Gaming Laptops");
            var product = new Product(1, "Notebook", "Default Description", 1000, new Category(1, "Notebooks"));

            // Act
            product.Update(newTitle, newDescription, newPrice, newCategory);

            // Assert
            Assert.AreEqual(newTitle, product.Title);
            Assert.AreEqual(newDescription, product.Description);
            Assert.AreEqual(newPrice, product.Price);
            Assert.AreEqual(newCategory, product.Category);
        }

        [Test]
        public void ProductUpdate_WithNullCategoryParam_AllowsNullCategory()
        {
            // Arrange
            var product = new Product(1, "Notebook", "Default Description", 1000, new Category(1, "Notebooks"));
            Category newCategory = null!;

            // Act
            product.Update("Updated Title", "Updated Description", 1500, newCategory);

            // Assert
            Assert.IsNull(product.Category, "Product update should allow setting category to null.");
        }

        [Test]
        public void ProductUpdate_WithEmptyTitleParam_DoesNotThrowException()
        {
            // Arrange
            var newProductTitle = " ";
            var product = new Product(0, "Notebook", "Default", 1000, new Category(1, "Notebooks"));

            // Act
            product.Update(newProductTitle, "Updated Description", 1200, new Category(2, "Gaming Laptops"));

            // Assert
            Assert.AreEqual(" ", product.Title, "Title should be updated even if empty.");
        }

        [Test]
        public void ProductUpdate_WithLongTitleParam_ThrowsException()
        {
            // Arrange
            var newProductTitle = GenerateRandomString(51);
            var product = new Product(0, "Notebook", "Default", 1000, new Category(1, "Notebooks"));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => product.Update(newProductTitle, "Updated Description", 1200, new Category(2, "Gaming Laptops")));
        }

        [Test]
        public void ProductUpdate_WithLongDescriptionParam_ThrowsException()
        {
            // Arrange
            var newDescription = GenerateRandomString(501); // Assuming description max length is 500
            var product = new Product(0, "Notebook", "Default", 1000, new Category(1, "Notebooks"));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => product.Update("Updated Title", newDescription, 1200, new Category(2, "Gaming Laptops")));
        }

        [Test]
        public void ProductUpdate_WithNegativePrice_ThrowsArgumentNullException()
        {
            // Arrange
            var product = new Product(0, "Notebook", "Default", 1000, new Category(1, "Notebooks"));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => product.Update("Updated Title", "Updated Description", -50, new Category(2, "Gaming Laptops")));
        }

        [Test]
        public void Product_WithInvalidPrice_ThrowsArgumentNullException()
        {
            // Arrange
            decimal invalidPrice = -100;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Product(1, "Laptop", "A great laptop", invalidPrice, new Category(1, "Notebooks")));
        }

        [Test]
        public void ProductUpdate_WithNullDescription_ThrowsException()
        {
            // Arrange
            var product = new Product(1, "Notebook", "Default Description", 1000, new Category(1, "Notebooks"));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => product.Update("Updated Title", null!, 1200, new Category(2, "Gaming Laptops")));
        }

        [Test]
        public void Product_WithNullDescription_ThrowsException()
        {
            // Arrange
            string description = null!;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Product(1, "Laptop", description, 1200, new Category(1, "Notebooks")));
        }

        static string GenerateRandomString(int length)
        {
            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
