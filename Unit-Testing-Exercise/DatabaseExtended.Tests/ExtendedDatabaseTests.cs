namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void Test_Add_With_Valid_Username()
        {
            //Arrange
            
            Database database=new Database();

            //Act
            database.Add(new Person(3,"Goshko"));
            Person result = database.FindById(3);
            //Assert
            Assert.That(database.Count, Is.EqualTo(1));
            Assert.AreEqual(3, result.Id);
            Assert.AreEqual("Goshko", result.UserName);
        }
        [Test]
        public void Test_Add_With_Invalid_Username()
        {
            //Arrange
            Person person = new Person(1, "Pesho");
            Person person2 = new Person(2, "Ivan");
            Person[] persons = new Person[] { person, person2 };
            Database database = new Database(persons);
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(3, "Ivan")));
        }
        [Test]
        public void Test_Add_With_Invalid_Id()
        {
            //Arrange
            Person person = new Person(1, "Pesho");
            Person person2 = new Person(2, "Ivan");
            Person[] persons = new Person[] { person, person2 };
            Database database = new Database(persons);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Gosheto")));
        }
        [Test]
        public void TestAddOperationWithInvalidInput()
        {
            //Arrange
            Person person1 = new Person(1,"I");
            Person person2 = new Person(2, "T");
            Person person3 = new Person(3, "F");
            Person person4 = new Person(4, "G");
            Person person5 = new Person(5, "K");
            Person person6 = new Person(6, "L");
            Person person7 = new Person(7, "M");
            Person person8 = new Person(8, "N");
            Person person9 = new Person(9,"O");
            Person person10 = new Person(10, "U");
            Person person11= new Person(11, "W");
            Person person12= new Person(12, "Q");
            Person person13 = new Person(13, "E");
            Person person14= new Person(14, "R");
            Person person15= new Person(15, "S");
            Person person16= new Person(16, "A");
            Person[] persons = new Person[16] {person1, person2, person3, person4, person5, person6, person7, person8, person9, person10, person11, person12, person13, person14, person15, person16 };
            Database database = new Database(persons);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1,"Pesho")));
        }
        [Test]
        public void TestAddOperationWithValidInput()
        {
            //Arrange
            Database database = new Database(new Person(1,"Pesho"));
            //Act
            database.Add(new Person(2,"Ivan"));
            //Assert
            Assert.AreEqual(database.Count, 2);
        }
        [Test]
        public void TestRemoveOperationWithValidInput()
        {
            Database database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            database.Remove();
            Person first = database.FindById(1);
            Assert.AreEqual(1,database.Count);
            Assert.AreEqual("Pesho", first.UserName);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));
        }
        [Test]
        public void TestTheRemoveOperationWithInvalidInput()
        {
            //Arrange
            Database database = new Database();

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void Test_FindByUserName_With_Correct_Input()
        {
            Database database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person person = database.FindByUsername("Gosho");
            Assert.AreEqual("Gosho", person.UserName);
            Assert.AreEqual(2, person.Id);
        }
        [Test]
        public void Test_FindByUserName_With_Incorrect_Input()
        {
            //Arrange
            Person person = new Person(1, "Ivan");
            Database database = new Database(person);
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Goshko"));
        }
        [Test]
        public void Test_FindByUserName_WithNullOrEmpty_Input()
        {
            Database database = new Database();
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(string.Empty));
        }
        [Test]
        public void Test_FindById_With_Incorrect_Input()
        {
            //Arrange
            Person person = new Person(1, "Ivan");
            Database database = new Database(person);
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindById(2));
        }
        [Test]
        public void Test_FindByyId_With_Correct_Input()
        {
            Database database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person person = database.FindById(2);
            Assert.AreEqual("Gosho", person.UserName);
            Assert.AreEqual(2, person.Id);
        }
        [Test]
        public void Test_FindById_With_NEgative_Input()
        {
            Database database = new Database();
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }
        [Test]
        public void ConstructorDatabase_Shoud_Create_Data_With_ValidInput()
        {
            Person person = new Person(1, "Pesho");
            Person person2 = new Person(2, "Gosho");
            Person[] persons = new Person[] { person,person2 };
            Database database = new Database(persons);
            Person first=database.FindById(1);
            Person second=database.FindById(2);
            Assert.AreEqual(2, database.Count);
            Assert.AreEqual("Pesho", first.UserName);
            Assert.AreEqual("Gosho", second.UserName);
        }
    }
}