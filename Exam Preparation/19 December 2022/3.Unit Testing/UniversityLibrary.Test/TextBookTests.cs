namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class TextBookTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Constructor_Is_Creating_Properly()
        {
            TextBook textBook = new TextBook("Game of thrones", "Shekspir", "Funny");
            string expectecTitle = "Game of thrones";
            string expectedAuthor = "Shekspir";
            string expectedCategory = "Funny";
            Assert.IsNotNull(textBook);
            Assert.AreEqual(expectecTitle, textBook.Title);
            Assert.AreEqual(expectedAuthor, textBook.Author);
            Assert.AreEqual(expectedCategory, textBook.Category);
            Assert.AreEqual(0, textBook.InventoryNumber);
            Assert.AreEqual(null, textBook.Holder);
        }
        [Test]
        public void Test_To_String_Method_Properly()
        {
            TextBook textBook = new TextBook("Game of thrones", "Shekspir", "Funny");
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: Game of thrones - 0");
            sb.AppendLine($"Category: Funny");
            sb.AppendLine($"Author: Shekspir");
            Assert.AreEqual(sb.ToString().TrimEnd(), textBook.ToString());
        }

    }
}