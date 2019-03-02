using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
   public class StylistsControllerTest
   {
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
     public void Create_ReturnsCorrectActionType_ViewResult()
     {
       //Arrange
       StylistsController controller = new StylistsController();

       //Act
       DateTime hireDate = new DateTime(2019, 1, 1);
       IActionResult view = controller.Create("Jane Doe", "Colorist", hireDate);

       //Assert
       Assert.IsInstanceOfType(view, typeof(ViewResult));
     }

  }
}
