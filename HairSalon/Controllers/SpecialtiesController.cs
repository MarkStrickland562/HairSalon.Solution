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
      model.Add("specialty", selectedSpecialty);
      model.Add("stylists", SpecialtyStylists);
      return View(model);
     }
  }
}
