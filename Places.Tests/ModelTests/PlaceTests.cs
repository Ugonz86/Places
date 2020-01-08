using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Places.Models;
using System;

namespace Places.Tests
{
    [TestClass]
    public class PlaceTest : IDisposable
    {
        public void Dispose()
        {
            Place.ClearAll();
        }


    [TestMethod]
    public void PlaceConstructor_CreatesInstanceOfPlace_Place()
    {
      Place newPlace = new Place("test");
      Assert.AreEqual(typeof(Place), newPlace.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "test";

      //Act
      Place newPlace = new Place(description);
      string result = newPlace.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "test";
      Place newPlace = new Place(description);

      //Act
      string updatedDescription = "test";
      newPlace.Description = updatedDescription;
      string result = newPlace.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_PlaceList()
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
      Place newPlace2 = new Place(description02);
      List<Place> newList = new List<Place> { newPlace1, newPlace2 };

      //Act
      List<Place> result = Place.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_PlacesInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string description = "test";
      Place newPlace = new Place(description);

      //Act
      int result = newPlace.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectPlace_Place()
    {
      //Arrange
      string description01 = "test1";
      string description02 = "test2";
      Place newPlace1 = new Place(description01);
      Place newPlace2 = new Place(description02);

      //Act
      Place result = Place.Find(2);

      //Assert
      Assert.AreEqual(newPlace2, result);
    }
    }
}