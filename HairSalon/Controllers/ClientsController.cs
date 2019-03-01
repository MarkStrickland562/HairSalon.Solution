using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allclients);
    }

    [HttpGet("/clients/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/clients")]
    public ActionResult Create(string clientName, clientGender)
    {
      Client newClient = new Client(clientName, clientGender);
      newClient.Save();
      List<Client> allclients = Client.GetAll();
      return View("Index", allclients);
    }

  }
}
