namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestIfConstructorInializetheTextBooks()
        {
            UniversityLibrary universityLibrary=new UniversityLibrary();
            Assert.That(universityLibrary.Catalogue, Is.Not.Null);
        }
        [Test]
        public void Test_If_Add_Text_Book_Increase_The_Inventory_Number()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Game of thrones", "Shekspir", "Funny");
            universityLibrary.AddTextBookToLibrary(textBook);
            Assert.That(textBook.InventoryNumber, Is.EqualTo(1));
        }
        [Test]
        public void Test_If_Add_Text_Book_Increase_The_Count_Of_UniversityLibrary()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Game of thrones", "Shekspir", "Funny");
            universityLibrary.AddTextBookToLibrary(textBook);
            Assert.That(universityLibrary.Catalogue.Count, Is.EqualTo(1));
        }
        [Test]
        public void Test_If_Add_Text_Book_Return_The_Correct_Think()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Game of thrones", "Shekspir", "Funny");
            string result=universityLibrary.AddTextBookToLibrary(textBook);
            Assert.That(textBook.ToString(),Is.EqualTo(result));
        }
        [Test]
        public void Test_If_Loan_Text_Book_Hasnt_Returned_The_Book()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Game of thrones", "Shekspir", "Funny");
            textBook.Holder = "Pesho";
            universityLibrary.AddTextBookToLibrary(textBook);
            string realOutput=universityLibrary.LoanTextBook(1, "Pesho");
            string expectedOutPut = $"Pesho still hasn't returned {textBook.Title}!";
            Assert.AreEqual(expectedOutPut, realOutput);
        }
        [Test]
        public void Test_If_Someone_Loan_Text_Book()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Game of thrones", "Shekspir", "Funny");
            universityLibrary.AddTextBookToLibrary(textBook);
            string realOutput = universityLibrary.LoanTextBook(1, "Pesho");
            string expectedOutPut = $"{textBook.Title} loaned to Pesho.";
            Assert.AreEqual(expectedOutPut, realOutput);
            Assert.That(textBook.Holder, Is.EqualTo("Pesho"));
        }
        [Test]
        public void Test_If_Returned_Text_Book_Method_Works_Correctly()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Game of thrones", "Shekspir", "Funny");
            universityLibrary.AddTextBookToLibrary(textBook);
            string realOutput = universityLibrary.ReturnTextBook(1);
            string expectedOutPut = $"{textBook.Title} is returned to the library.";
            Assert.AreEqual(expectedOutPut, realOutput);
            Assert.That(textBook.Holder, Is.EqualTo(string.Empty));
        }
    }
}