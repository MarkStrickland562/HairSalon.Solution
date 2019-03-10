using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistsControllerTest : IDisposable
  {
    public StylistsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mark_strickland_test;";
    }

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      Specialty.ClearAll();
    }
    
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      ActionResult newView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      ActionResult newView = controller.New();

      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_ViewResult()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      DateTime hireDate = new DateTime(2019, 1, 1);
      IActionResult view = controller.Create("Jane Doe", hireDate);

      //Assert
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      ActionResult newView = controller.Show(1);

      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void NewSpecialty_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      IActionResult view = controller.AddSpecialty(1, 1);

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Delete_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      IActionResult view = controller.Delete(1);

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      IActionResult view = controller.Delete();

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      ActionResult newView = controller.Edit(1);

      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      DateTime hireDate = new DateTime(2019, 1, 1);
      IActionResult view = controller.EditPost(1, "Jane Doe", hireDate);

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }
  }
}
