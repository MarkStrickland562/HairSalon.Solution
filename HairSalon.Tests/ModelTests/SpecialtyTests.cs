using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mark_strickland_test;";
    }

    public void Dispose()
    {
      Specialty.ClearAll();
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      //Arrange, Act
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);

      //Assert
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetSpecialty_ReturnsSpecialty_String()
    {
      //Arrange
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);

      //Act
      string result = newSpecialty.GetSpecialty();

      //Assert
      Assert.AreEqual(specialty, result);
    }

    [TestMethod]
    public void SetSpecialty_SetSpecialty_String()
    {
      //Arrange
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);

      //Act
      string updatedSpecialty = "Barber";
      newSpecialty.SetSpecialty(updatedSpecialty);
      string result = newSpecialty.GetSpecialty();

      //Assert
      Assert.AreEqual(updatedSpecialty, result);
    }

    [TestMethod]
    public void Save_SavesSpecialtyToDatabase_SpecialtyList()
    {
      //Arrange
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);
      newSpecialty.Save();

      //Act
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{newSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllSpecialtyObjects_SpecialtyList()
    {
      //Arrange
      string specialty1 = "Colorist";
      Specialty newSpecialty1 = new Specialty(specialty1);
      newSpecialty1.Save();

      string specialty2 = "Barber";
      Specialty newSpecialty2 = new Specialty(specialty2);
      newSpecialty2.Save();

      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2};

      //Act
      List<Specialty> result = Specialty.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsSpecialtyInDatabase_Specialty()
    {
      //Arrange
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);
      newSpecialty.Save();

      //Act
      Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());

      //Assert
      Assert.AreEqual(newSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void Delete_DeletesSpecialtyFromDatabase()
    {
      //Arrange
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);
      newSpecialty.Save();
      newSpecialty.Delete();

      //Act
      List<Specialty> newList = new List<Specialty> { newSpecialty };
      List<Specialty> resultList = Specialty.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllStylistsFromDatabase()
    {
      //Arrange
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);
      newSpecialty.Save();
      Specialty.DeleteAll();

      //Act
      List<Specialty> newList = new List<Specialty> { newSpecialty };
      List<Specialty> resultList = Specialty.GetAll();

      //Assert
      CollectionAssert.AreNotEqual(newList, resultList);
    }

    [TestMethod]
    public void Edit_UpdatesSpecialtyToDatabase()
    {
      //Arrange
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);
      newSpecialty.Save();

      //Act
      Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());
      string editSpecialty = "Barber";
      foundSpecialty.Edit(editSpecialty);
      Specialty updatedSpecialty = Specialty.Find(newSpecialty.GetId());

      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{foundSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_SavesStylistSpecialtyToDatabase_StylistList()
    {
      //Arrange
      string name = "Betty Clark";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, hireDate);
      newStylist.Save();
      string specialty = "Colorist";
      Specialty newSpecialty = new Specialty(specialty);
      newSpecialty.Save();

      //Act
      Stylist foundStylist = Stylist.Find(newStylist.GetId());
      Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());
      foundSpecialty.AddStylist(foundStylist);

      List<Stylist> result = newSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist>{foundStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
