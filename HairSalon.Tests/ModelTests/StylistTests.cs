using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mark_strickland_test;";
    }

    public void Dispose()
    {
      Stylist.ClearAll();
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      //Arrange, Act
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);

      //Assert
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);

      //Act
      string result = newStylist.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetName_String()
    {
      //Arrange
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);

      //Act
      string updatedName = "Sharon Smith";
      newStylist.SetName(updatedName);
      string result = newStylist.GetName();

      //Assert
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void GetSpecialty_ReturnsSpecialty_String()
    {
      //Arrange
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);

      //Act
      string result = newStylist.GetSpecialty();

      //Assert
      Assert.AreEqual(specialty, result);
    }

    [TestMethod]
    public void SetSpecialty_SetSpecialty_String()
    {
      //Arrange
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);

      //Act
      string updatedSpecialty = "Barber";
      newStylist.SetSpecialty(updatedSpecialty);
      string result = newStylist.GetSpecialty();

      //Assert
      Assert.AreEqual(updatedSpecialty, result);
    }

    [TestMethod]
    public void GetHireDate_ReturnsHireDate_DateTime()
    {
      //Arrange
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);

      //Act
      DateTime result = newStylist.GetHireDate();

      //Assert
      Assert.AreEqual(hireDate, result);
    }

    [TestMethod]
    public void SetHireDate_SetHireDate_DateTime()
    {
      //Arrange
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);

      //Act
      DateTime updatedHireDate = new DateTime(2019, 02, 28);
      newStylist.SetHireDate(updatedHireDate);
      DateTime result = newStylist.GetHireDate();

      //Assert
      Assert.AreEqual(updatedHireDate, result);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      //Arrange
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);
      newStylist.Save();

      //Act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{newStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllStylistObjects_StylistList()
    {
      //Arrange
      string name1 = "Betty Clark";
      string specialty1 = "Colorist";
      DateTime hireDate1 = new DateTime(2019, 01, 01);
      Stylist newStylist1 = new Stylist(name1, specialty1, hireDate1);
      newStylist1.Save();

      string name2 = "Sharon Smith";
      string specialty2 = "Barber";
      DateTime hireDate2 = new DateTime(2019, 02, 28);
      Stylist newStylist2 = new Stylist(name2, specialty2, hireDate2);
      newStylist2.Save();

      List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2};

      //Act
      List<Stylist> result = Stylist.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsStylistInDatabase_Stylist()
    {
      //Arrange
      string name = "Betty Clark";
      string specialty = "Colorist";
      DateTime hireDate = new DateTime(2019, 01, 01);
      Stylist newStylist = new Stylist(name, specialty, hireDate);
      newStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(newStylist.GetId());

      //Assert
      Assert.AreEqual(newStylist, foundStylist);
    }

  }
}
