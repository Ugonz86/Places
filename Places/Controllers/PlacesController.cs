using Microsoft.AspNetCore.Mvc;
using Places.Models;
using System.Collections.Generic;

namespace Places.Controllers
{
  public class PlacesController : Controller
  {

    [HttpGet("/places")]
    public ActionResult Index()
    {
      List<Place> allPlaces = Place.GetAll();
      return View(allPlaces);
    }

    [HttpGet("/places/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/places")]
    public ActionResult Create(string cityName)
    {
      Place myPlace = new Place(cityName);
      return RedirectToAction("Index");
    }

    [HttpGet("/places/{id}")]
    public ActionResult Show(int id)
    {
      Place foundPlace = Place.Find(id);
      return View(foundPlace);
    }

    [HttpPost("/places/delete")]
    public ActionResult DeleteAll()
    {
      Place.ClearAll();
      return View();
    }

  }
}