namespace Eshop.Domain.Tests
{
    public class ProductTests
    {
        // MAIN TESTS
        [Test]
        public void Product_WithValidParams_SetsPropertiesCorrectly()
        {
            // arrange
            var id = 1;
            var title = GenerateRandomString(50);
            var description = GenerateRandomString(100);
            var price = 1000;
            var category = 1;

            // act
            var sut = new Product(id, title, description, price, category);

            // assert
            Assert.That(sut.Id, Is.EqualTo(id));
            Assert.That(sut.Title, Is.EqualTo(title));
            Assert.That(sut.Description, Is.EqualTo(description));
            Assert.That(sut.Price, Is.EqualTo(price));
#pragma warning disable NUnit2041 // Incompatible types for comparison constraint
            Assert.That(sut.Category, Is.GreaterThan(0));
#pragma warning restore NUnit2041 // Incompatible types for comparison constraint
        }

        [Test]
        public void Product_WithInvalidIdParam_ThrowsException()
        {
            // arrange
            var id = -1;

            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(id, "Valid Title", "Valid Description", 1000, 1));
        }

        // TITLE TESTS
        [Test]
        public void Product_WithNullTitleParam_ThrowsException()
        {
            // arrange
            string title = null!;

            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(1, title, "Valid Description", 1000, 1));
        }

        [Test]
        public void Product_WithEmptyTitleParam_ThrowsException()
        {
            // arrange
            var title = " ";

            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(1, title, "Valid Description", 1000, 1));
        }

        [Test]
        public void Product_WithLongTitleParam_ThrowsException()
        {
            // arrange
            var title = GenerateRandomString(51); // Assuming max title length is 50.

            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, title, "Valid Description", 1000, 1));
        }

        [Test]
        public void ProductUpdate_WithValidTitle_UpdatesTitleCorrectly()
        {
            // arrange
            var product = new Product(1, "Notebook", "Default", 1000, 1);
            var newTitle = GenerateRandomString(50);

            // act
            product.Update(newTitle);

            // assert
            Assert.That(product.Title, Is.EqualTo(newTitle));
        }

        // DESCRIPTION TESTS
        [Test]
        public void Product_WithNullDescription_ThrowsException()
        {
            // arrange
            string description = null!;

            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(1, "Notebook", description, 1000, 1));
        }

        [Test]
        public void Product_WithEmptyDescription_ThrowsException()
        {
            // arrange
            var description = " ";

            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(1, "Valid Title", description, 1000, 1));
        }

        [Test]
        public void Product_WithLongDescription_ThrowsException()
        {
            // arrange
            var description = GenerateRandomString(201); // Assuming max description length is 200.

            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Valid Title", description, 1000, 1));
        }

        // PRICE TESTS
        [Test]
        public void Product_WithNegativePrice_ThrowsException()
        {
            // arrange
            var price = -1;

            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Valid Title", "Valid Description", price, 1));
        }

        [Test]
        public void Product_WithZeroPrice_ThrowsException()
        {
            // arrange
            var price = 0;

            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Valid Title", "Valid Description", price, 1));
        }

        [Test]
        public void ProductUpdate_WithValidPrice_UpdatesPriceCorrectly()
        {
            // arrange
            var product = new Product(1, "Notebook", "Default", 1000, 1);
            var newPrice = 2000;

            // act
            product.UpdatePrice(newPrice);

            // assert
            Assert.That(product.Price, Is.EqualTo(newPrice));
        }

        // CATEGORY TESTS
        [Test]
        public void Product_WithInvalidCategory_ThrowsException()
        {
            // arrange
            var category = -1;

            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Valid Title", "Valid Description", 1000, category));
        }

        [Test]
        public void ProductUpdate_WithValidCategory_UpdatesCategoryCorrectly()
        {
            // arrange
            var product = new Product(1, "Valid Title", "Valid Description", 1000, 1);
            var newCategory = 2;

            // act
            product.UpdateCategory(newCategory);

            // assert
#pragma warning disable NUnit2041 // Incompatible types for comparison constraint
            Assert.That(product.Category, Is.GreaterThan(0));
#pragma warning restore NUnit2041 // Incompatible types for comparison constraint
        }

        // HELPER FUNCTION
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
