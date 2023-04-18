namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestCapacityOfArray()
        {
            //Arrange
            int[] array= new int[16];
            Database database= new Database(array);

            //Act
            //Assert
            Assert.That(database.Count, Is.EqualTo(16), "Array lentgh must be exactly 16 integers");
        }
        [Test]
        public void TestAddOperationWithInvalidInput()
        {
            //Arrange
            int[] array= new int[16] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 };
            Database database = new Database(array);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(5));
        }
        [Test]
        public void TestAddOperationWithValidInput()
        {
            //Arrange
            int[] array = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Database database= new Database(array);
            //Act
            database.Add(16);
            //Assert
            Assert.AreEqual(database.Count, 16);
        }
        [Test]
        public void TestRemoveOperationWithValidInput()
        {
            //Arrange
            int[] array = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Database database = new Database(array);
            //Act
            database.Remove();
            //Assert
            Assert.AreEqual(database.Count, 14);
        }
        [Test]
        public void TestTheRemoveOperation()
        {
            //Arrange
            int[] array = new int[0];
            Database database= new Database(array);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        [TestCase(new int[] { 1})]
        [TestCase(new int[] { 5,20,6 })]
        [TestCase(new int[] { int.MinValue,int.MaxValue })]
        [TestCase(new int[0])]
        public void Constructor_Shuld_Create_Data_With_ValidInput(int[] parameters)
        {
            Database database = new Database(parameters);
            Assert.AreEqual(parameters.Length, database.Count);
        }
        [Test]
        public void Fetch_Method_Shoud_Return_Array()
        {
            int[] array = new int[16];
            Database database = new Database(array);
            int[] copy=database.Fetch();
            Assert.AreEqual(array, copy);
        }
    }
}
