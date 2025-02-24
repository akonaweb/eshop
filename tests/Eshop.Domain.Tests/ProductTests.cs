using Eshop.Domain.Tests.Utils;

namespace Eshop.Domain.Tests
{
    public class ProductTests
    {
        [Test]
        public void Product_WithValidParams_SetCorrectlyProperties()
        {
            // arrange
            var id = 0; // Zero is valid for a new object (EF)
            var title = StringUtils.GenerateRandomString(50);
            var description = StringUtils.GenerateRandomString(500);
            var price = 0; // Zero is allowed
            var category = new Category(0, "Notebooks");

            // act
            var sut = new Product(id, title, description, price, category);

            // assert
            Assert.That(sut.Id, Is.EqualTo(id));
            Assert.That(sut.Title, Is.EqualTo(title));
            Assert.That(sut.Description, Is.EqualTo(description));
            Assert.That(sut.Price, Is.EqualTo(price));
            Assert.That(sut.Category, Is.EqualTo(category));
        }

        [Test]
        public void Product_WithInvalidIdParam_ThrowsException()
        {
            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(-1, "Title", "Description", 1200, null));
        }

        [Test]
        public void Product_WithNullTitleParam_ThrowsException()
        {
            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(0, null!, "Description", 1200, null));
        }

        [Test]
        public void Product_WithEmptyTitleParam_ThrowsException()
        {
            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(0, " ", "Description", 1200, null));
        }

        [Test]
        public void Product_WithLongTitleParam_ThrowsException()
        {
            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(0, StringUtils.GenerateRandomString(51), "Description", 1200, null));
        }

        [Test]
        public void Product_WithNullDesriptionParam_ThrowsException()
        {
            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(0, "Title", null!, 1200, null));
        }

        [Test]
        public void Product_WithEmptyDescriptionParam_ThrowsException()
        {
            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(0, "Title", " ", 1200, null));
        }

        [Test]
        public void Product_WithLongDescriptionParam_ThrowsException()
        {
            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(0, "Title", StringUtils.GenerateRandomString(501), 1200, null));
        }

        [Test]
        public void Product_WithNegativePriceParam_ThrowsException()
        {
            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Product(0, "Title", "Description", -1, null));
        }

        [Test]
        public void ProductUpdate_WithValidParams_SetCorrectlyProperties()
        {
            // arrange
            var id = 0; // Zero is valid for a new object (EF)
            var title = StringUtils.GenerateRandomString(50);
            var description = StringUtils.GenerateRandomString(500);
            var price = 0; // Zero is allowed
            var category = new Category(0, "Notebooks");

            var newTitle = StringUtils.GenerateRandomString(50);
            var newDescription = StringUtils.GenerateRandomString(500);
            var newPrice = 1;
            var newCategory = new Category(1, "Mouses");

            // act
            var sut = new Product(id, title, description, price, category);
            sut.Update(newTitle, newDescription, newPrice, newCategory);

            // assert
            Assert.That(sut.Title, Is.EqualTo(newTitle));
            Assert.That(sut.Description, Is.EqualTo(newDescription));
            Assert.That(sut.Price, Is.EqualTo(newPrice));
            Assert.That(sut.Category, Is.EqualTo(newCategory));
        }

        [Test]
        public void ProductUpdate_WithNullTitleParam_ThrowsException()
        {
            // arrange
            var sut = new Product(0, "Title", "Description", 1200, null);

            // act/assert
            Assert.Throws<ArgumentNullException>(() => sut.Update(null!, "Description", 1200, null));
        }

        [Test]
        public void ProductUpdate_WithEmptyTitleParam_ThrowsException()
        {
            // arrange
            var sut = new Product(0, "Title", "Description", 1200, null);

            // act/assert
            Assert.Throws<ArgumentNullException>(() => sut.Update(" ", "Description", 1200, null));
        }

        [Test]
        public void ProductUpdate_WithLongTitleParam_ThrowsException()
        {
            // arrange
            var sut = new Product(0, "Title", "Description", 1200, null);

            // act/assert
            Assert.Throws<ArgumentNullException>(() => sut.Update(StringUtils.GenerateRandomString(51), "Description", 1200, null));
        }

        [Test]
        public void ProductUpdate_WithNullDesriptionParam_ThrowsException()
        {
            // arrange
            var sut = new Product(0, "Title", "Description", 1200, null);

            // act/assert
            Assert.Throws<ArgumentNullException>(() => sut.Update("Title", null!, 1200, null));
        }

        [Test]
        public void ProductUpdate_WithEmptyDescriptionParam_ThrowsException()
        {
            // arrange
            var sut = new Product(0, "Title", "Description", 1200, null);

            // act/assert
            Assert.Throws<ArgumentNullException>(() => sut.Update("Title", " ", 1200, null));
        }

        [Test]
        public void ProductUpdate_WithLongDescriptionParam_ThrowsException()
        {
            // arrange
            var sut = new Product(0, "Title", "Description", 1200, null);

            // act/assert
            Assert.Throws<ArgumentNullException>(() => sut.Update("Title", StringUtils.GenerateRandomString(501), 1200, null));
        }

        [Test]
        public void ProductUpdate_WithNegativePriceParam_ThrowsException()
        {
            // arrange
            var sut = new Product(0, "Title", "Description", 1200, null);

            // act/assert
            Assert.Throws<ArgumentNullException>(() => sut.Update("Title", "Description", -1, null));
        }
    }
}
