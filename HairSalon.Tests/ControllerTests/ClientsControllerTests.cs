using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTest
  {
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult newView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult newView = controller.New();

      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_ViewResult()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      IActionResult view = controller.Create("Jane Doe", "Female", 1);

      //Assert
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult newView = controller.Show(1);

      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Delete_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      IActionResult view = controller.Delete(1);

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      IActionResult view = controller.Delete();

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult newView = controller.Edit(1);

      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      IActionResult view = controller.EditPost(1, "Jane Doe", "Female", 1);

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }
  }
}
