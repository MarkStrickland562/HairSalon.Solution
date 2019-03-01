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
  }
}
