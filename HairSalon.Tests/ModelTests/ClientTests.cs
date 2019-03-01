using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mark_strickland_test;";
    }

    public void Dispose()
    {
    //   Stylist.ClearAll();
    //   Client.ClearAll();
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      //Arrange, Act
      string name = "Sharon Smith";
      string gender = "Female";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);

      //Assert
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);

      //Act
      string result = newClient.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetName_String()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);

      //Act
      string updatedName = "John Doe";
      newClient.SetName(updatedName);
      string result = newClient.GetName();

      //Assert
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void GetGender_ReturnsGender_String()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);

      //Act
      string result = newClient.GetGender();

      //Assert
      Assert.AreEqual(gender, result);
    }

    [TestMethod]
    public void SetGender_SetGender_String()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);

      //Act
      string updatedGender = "Tom Jones";
      newClient.SetGender(updatedGender);
      string result = newClient.GetGender();

      //Assert
      Assert.AreEqual(updatedGender, result);
    }
    
  }
}
