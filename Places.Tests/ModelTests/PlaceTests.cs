using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Places.Models;
using System;
using MySql.Data.MySqlClient;

namespace Places.Tests
{
    [TestClass]
    public class PlaceTest : IDisposable
    {
        public void Dispose()
        {
            Place.ClearAll();
        }

    public PlaceTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=places_test;";
    }


    // [TestMethod]
    // public void PlaceConstructor_CreatesInstanceOfPlace_Place()
    // {
    //   Place newPlace = new Place("test");
    //   Assert.AreEqual(typeof(Place), newPlace.GetType());
    // }

    // [TestMethod]
    // public void GetDescription_ReturnsDescription_String()
    // {
    //   //Arrange
    //   string description = "test";

    //   //Act
    //   Place newPlace = new Place(description);
    //   string result = newPlace.Description;

    //   //Assert
    //   Assert.AreEqual(description, result);
    // }

    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //   //Arrange
    //   string description = "test";
    //   Place newPlace = new Place(description);

    //   //Act
    //   string updatedDescription = "test";
    //   newPlace.Description = updatedDescription;
    //   string result = newPlace.Description;

    //   //Assert
    //   Assert.AreEqual(updatedDescription, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_PlaceList()
    {
      // Arrange
      List<Place> newList = new List<Place> { };

      // Act
      List<Place> result = Place.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsPlaces_PlaceList()
    {
      //Arrange
      string description01 = "test1";
      string description02 = "test2";
      Place newPlace1 = new Place(description01);
      newPlace1.Save();
      Place newPlace2 = new Place(description02);
      newPlace2.Save();
      List<Place> newList = new List<Place> { newPlace1, newPlace2 };

      //Act
      List<Place> result = Place.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetId_PlacesInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string description = "test";
    //   Place newPlace = new Place(description);

    //   //Act
    //   int result = newPlace.Id;

    //   //Assert
    //   Assert.AreEqual(1, result);
    // }

    [TestMethod]
    public void Find_ReturnsCorrectPlaceFromDatabase_Place()
    {
      //Arrange
      
      Place newPlace1 = new Place("Tokyo");
      newPlace1.Save();
      Place newPlace2 = new Place("Kyoto");
      newPlace2.Save(); 

      //Act
      Place foundPlace = Place.Find(newPlace.Id);
      //Assert
      Assert.AreEqual(newPlace, foundPlace);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Place()
    {
      // Arrange, Act
      Place firstPlace = new Place("Mow the lawn");
      Place secondPlace = new Place("Mow the lawn");

      // Assert
      Assert.AreEqual(firstPlace, secondPlace);
    }

    [TestMethod]
    public void Save_SavesToDatabase_PlaceList()
    {
      //Arrange
      Place testPlace = new Place("Mow the lawn");

      //Act
      testPlace.Save();
      List<Place> result = Place.GetAll();
      List<Place> testList = new List<Place>{testPlace};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
    }
}