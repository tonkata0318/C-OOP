namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        [Test]
        public void TestIFConstructorWorksFine()
        {
            Book book = new Book("Grenlandiq", "Greta");
            Assert.IsNotNull(book);
            Assert.That(book.BookName, Is.EqualTo("Grenlandiq"));
            Assert.That(book.Author, Is.EqualTo("Greta"));
            Assert.That(book.FootnoteCount,Is.EqualTo(0));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestTheBookNamePropWithIncorrectValue(string name)
        {
            Book book = null;
            Assert.Throws<ArgumentException>(() => book = new Book(name, "Greta"));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestTheAuthorNamePropWithIncorrectValue(string author)
        {
            Book book = null;
            Assert.Throws<ArgumentException>(() => book = new Book("Nesho", author));
        }
        [Test]
        public void AddFootnotWithAlreayExisting()
        {
            Book book = new Book("Grenlandiq", "Greta");
            book.AddFootnote(1, "durawduwaduwd");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "neawhdwa"));
        }
        [Test]
        public void AddFootnotWithUnExisting()
        {
            Book book = new Book("Grenlandiq", "Greta");
            book.AddFootnote(1, "durawduwaduwd");
            Assert.That(book.FootnoteCount, Is.EqualTo(1));
        }
        [Test]
        public void TestFindFootNodeWhichNotExist()
        {
            Book book = new Book("Grenlandiq", "Greta");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1));
        }
        [Test]
        public void TestFindFootNodeWhichExist()
        {
            Book book = new Book("Grenlandiq", "Greta");
            book.AddFootnote(1, "durawduwaduwd");
            Assert.AreEqual(book.FindFootnote(1), $"Footnote #1: durawduwaduwd");
        }
        [Test]
        public void TestAlterFootNoteWhichDontExist()
        {
            Book book = new Book("Grenlandiq", "Greta");
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, "dawdwad"));
        }
        [Test]
        public void TestAlterFootNoteWhichExist()
        {
            Book book = new Book("Grenlandiq", "Greta");
            book.AddFootnote(1, "durawduwaduwd");
            book.AlterFootnote(1, "Test");
            string result = book.FindFootnote(1);
            Assert.AreEqual(result, "Footnote #1: Test");
        }
    }
}