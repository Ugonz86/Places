using Microsoft.AspNetCore.Mvc;
using Places.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Places.Controllers
{
  public class PlacesController : Controller
  {
    private readonly PlacesContext _db;

    public PlacesController(PlacesContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Place> model = _db.Places.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Place place)
    {
      _db.Places.Add(place);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Place thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
      return View(thisPlace);
    }

    public ActionResult Edit(int id)
    {
        var thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
        return View(thisPlace);
    }

    [HttpPost]
    public ActionResult Edit(Place place)
    {
        _db.Entry(place).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
        return View(thisPlace);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
        _db.Places.Remove(thisPlace);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

  }
}