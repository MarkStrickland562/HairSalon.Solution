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
    public ActionResult Create(string stylistName, DateTime stylistHireDate)
    {
      Stylist newStylist = new Stylist(stylistName, stylistHireDate);

      if (!(string.IsNullOrEmpty(newStylist.GetName())) && !(newStylist.GetHireDate() == DateTime.MinValue))
      {
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View("Index", allStylists);
      }
      else
      {
        return View("New");
      }
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> StylistClients = selectedStylist.GetClients();
      List<Specialty> StylistSpecialties = selectedStylist.GetSpecialties();
      List<Specialty> AllSpecialties = Specialty.GetAll();
      model.Add("stylist", selectedStylist);
      model.Add("clients", StylistClients);
      model.Add("specialties", StylistSpecialties);
      model.Add("allSpecialties", AllSpecialties);
      return View(model);
     }

     [HttpPost("/stylists/{id}/specialties/new")]
     public ActionResult AddSpecialty(int id, int specialtyId)
     {
       Stylist stylist = Stylist.Find(id);
       Specialty specialty = Specialty.Find(specialtyId);
       stylist.AddSpecialty(specialty);
       return RedirectToAction("Show", new {id = id});
     }

     [HttpGet("/stylists/{id}/delete")]
     public ActionResult Delete(int id)
     {
       Stylist stylist = Stylist.Find(id);
       stylist.Delete();
       return RedirectToAction("Index");
     }

     [HttpGet("/stylists/delete")]
     public ActionResult Delete()
     {
       Stylist.DeleteAll();
       List<Stylist> allStylists = Stylist.GetAll();
       return RedirectToAction("Index", allStylists);
     }
  }
}
