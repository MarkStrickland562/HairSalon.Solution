using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class HairSalonTest : IDisposable
  {

    public HairSalonTest()
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
  }
}
