namespace Eshop.Domain.Tests
{
    public class CategoryTests
    {
        [Test]
        public void Category_WithValidParams_SetCorrectlyProperties()
        {
            // arrange
            var id = 1;
            var name = GenerateRandomString(50);

            // act
            var sut = new Category(id, name);

            // assert
            Assert.That(sut.Id, Is.EqualTo(id));
            Assert.That(sut.Name, Is.EqualTo(name));
        }

        [Test]
        public void Category_WithInvalidIdParam_ThrowsException()
        {
            // arrange
            var id = -1;

            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Category(id, null!));
        }

        [Test]
        public void Category_WithNullNameParam_ThrowsException()
        {
            // arrange
            var id = 0;
            string name = null!;

            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Category(id, name));
        }

        [Test]
        public void Category_WithEmptyNameParam_ThrowsException()
        {
            // arrange
            var id = 0;
            var name = " ";

            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Category(id, name));
        }

        [Test]
        public void Category_WithLongNameParam_ThrowsException()
        {
            // arrange
            var id = 0;
            var name = GenerateRandomString(51);

            // act/assert
            Assert.Throws<ArgumentNullException>(() => new Category(id, name));
        }

        [Test]
        public void CategoryUpdate_WithValidParams_SetsPropertiesCorreclty()
        {
            // arrange
            var newCategoryName = GenerateRandomString(50);
            var category = new Category(0, "Notebook");

            // act
            category.Udpate(newCategoryName);

            // assert
            Assert.That(category.Name, Is.EqualTo(newCategoryName));
        }

        [Test]
        public void CategoryUpdate_WithNullNameParam_ThrowsException()
        {
            // arrange
            string newCategoryName = null!;
            var category = new Category(0, "Notebook");

            // act/assert
            Assert.Throws<ArgumentNullException>(() => category.Udpate(newCategoryName));
        }

        [Test]
        public void CategoryUpdate_WithEmptyNameParam_ThrowsException()
        {
            // arrange
            var newCategoryName = " ";
            var category = new Category(0, "Notebook");

            // act/assert
            Assert.Throws<ArgumentNullException>(() => category.Udpate(newCategoryName));
        }

        [Test]
        public void CategoryUpdate_WithLongNameParam_ThrowsException()
        {
            // arrange
            var newCategoryName = GenerateRandomString(51);
            var category = new Category(0, "Notebook");

            // act/assert
            Assert.Throws<ArgumentNullException>(() => category.Udpate(newCategoryName));
        }

        static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";  // Can be expanded if needed
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}