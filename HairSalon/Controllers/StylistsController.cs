using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName, string stylistSpecialty, DateTime stylistHireDate)
    {
      Stylist newStylist = new Stylist(stylistName, stylistSpecialty, stylistHireDate);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> StylistClients = selectedStylist.GetClients();
      model.Add("stylist", selectedStylist);
      model.Add("clients", StylistClients);
      return View(model);
     }

     [HttpPost("/stylists/{stylistId}/Clients/new")]
     public ActionResult AddClient(int stylistId, int clientId)
     {
       stylist stylist = stylist.Find(stylistId);
       Client client = client.Find(clientId);
       stylist.AddClient(client);
       return RedirectToAction("Show",  new { id = stylistId });
     }
  }
}
