using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialties")]
    public ActionResult Create(string specialty)
    {
      Specialty newSpecialty = new Specialty(specialty);

      if (!(string.IsNullOrEmpty(newSpecialty.GetSpecialty())))
      {
        newSpecialty.Save();
        List<Specialty> allSpecialties = Specialty.GetAll();
        return View("Index", allSpecialties);
      }
      else
      {
        return View("New");
      }
    }

    [HttpGet("/specialties/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> SpecialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> AllStylists = Stylist.GetAll();
      model.Add("specialty", selectedSpecialty);
      model.Add("stylists", SpecialtyStylists);
      model.Add("allStylists", AllStylists);
      return View(model);
     }

     [HttpPost("/specialties/{id}/stylists/new")]
     public ActionResult AddStylist(int id, int stylistId)
     {
       Stylist stylist = Stylist.Find(stylistId);
       Specialty specialty = Specialty.Find(id);
       specialty.AddStylist(stylist);
       return RedirectToAction("Show", new {id = id});
     }

     [HttpGet("/specialties/{id}/delete")]
     public ActionResult Delete(int id)
     {
       Specialty specialty = Specialty.Find(id);
       specialty.Delete();
       return RedirectToAction("Index");
     }

     [HttpGet("/specialties/delete")]
     public ActionResult Delete()
     {
       Specialty.DeleteAll();
       List<Specialty> allSpecialties = Specialty.GetAll();
       return RedirectToAction("Index", allSpecialties);
     }

     [HttpGet("/specialties/{id}/edit")]
     public ActionResult Edit(int id)
     {
       Specialty newSpecialty = Specialty.Find(id);
       return View(newSpecialty);
     }

     [HttpPost("/specialties/{id}/edit")]
     public ActionResult EditPost(int id, string specialty)
     {
       Specialty newSpecialty = Specialty.Find(id);
       newSpecialty.Edit(specialty);
       return RedirectToAction("Index");
     }
   }
}
