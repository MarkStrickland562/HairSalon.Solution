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

    [HttpGet("/clients/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client selectedClient = Client.Find(id);
      Stylist clientStylist = Stylist.Find(selectedClient.GetStylistId());
      model.Add("client", selectedClient);
      model.Add("clientStylist", clientStylist);
      return View(model);
     }

    [HttpGet("/clients/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Client client = Client.Find(id);
      client.Delete();
      return RedirectToAction("Index");
    }
  }
}
