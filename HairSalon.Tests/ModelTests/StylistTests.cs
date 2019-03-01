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
    //   Stylist.ClearAll();
    //   Client.ClearAll();
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

  }
}
