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
      return View(allClients);
    }

    [HttpGet("/clients/new")]
    public ActionResult New()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpPost("/clients")]
    public ActionResult Create(string clientName, string clientGender, int clientStylistId)
    {
      Client newClient = new Client(clientName, clientGender, clientStylistId);

      if (!(string.IsNullOrEmpty(newClient.GetName())) && !(string.IsNullOrEmpty(newClient.GetGender())) && !(string.IsNullOrEmpty(newClient.GetStylistId().ToString())))
      {
        newClient.Save();
        List<Client> allClients = Client.GetAll();
        return View("Index", allClients);
      }
      else
      {
        List<Client> allClients = Client.GetAll();
        return View("New", allClients);
      }
    }
  }
}
