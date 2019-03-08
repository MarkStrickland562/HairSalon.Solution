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
      Client.ClearAll();
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

    [TestMethod]
    public void GetStylistId_ReturnsStylistId_Int()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);

      //Act
      int result = newClient.GetStylistId();

      //Assert
      Assert.AreEqual(stylistId, result);
    }

    [TestMethod]
    public void SetStylistId_SetStylistId_Int()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);

      //Act
      int updatedStylistId = 2;
      newClient.SetStylistId(updatedStylistId);
      int result = newClient.GetStylistId();

      //Assert
      Assert.AreEqual(updatedStylistId, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      string name1 = "Tom Jones";
      string gender1 = "Male";
      int stylistId1 = 1;
      Client newClient1 = new Client(name1, gender1, stylistId1);
      newClient1.Save();

      string name2 = "Jane Doe";
      string gender2 = "Female";
      int stylistId2 = 1;
      Client newClient2 = new Client(name2, gender2, stylistId2);
      newClient2.Save();

      List<Client> newList = new List<Client> { newClient1, newClient2 };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);
      newClient.Save();

      //Act
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{newClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);
      newClient.Save();

      //Act
      Client foundClient = Client.Find(newClient.GetId());

      //Assert
      Assert.AreEqual(newClient, foundClient);
    }

    [TestMethod]
    public void Delete_DeletesClientFromDatabase()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);
      newClient.Save();
      newClient.Delete();

      //Act
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{newClient};

      //Assert
      CollectionAssert.AreNotEqual(testList, result);;
    }

    [TestMethod]
    public void DeleteAll_DeletesAllClientsFromDatabase()
    {
      //Arrange
      string name = "Tom Jones";
      string gender = "Male";
      int stylistId = 1;
      Client newClient = new Client(name, gender, stylistId);
      newClient.Save();
      Client.DeleteAll();

      //Act
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{newClient};

      //Assert
      CollectionAssert.AreNotEqual(testList, result);;
    }

  }
}
