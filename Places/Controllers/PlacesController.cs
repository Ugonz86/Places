using Microsoft.AspNetCore.Mvc;
using Places.Models;
using System.Collections.Generic;

namespace Places.Controllers
{
  public class PlacesController : Controller
  {

    [HttpGet("/categories/{categoryId}/places/new")]
    public ActionResult New(int categoryId)
    {
       Category category = Category.Find(categoryId);
       return View(category);
    }

    [HttpGet("/categories/{categoryId}/places/{placeId}")]
    public ActionResult Show(int categoryId, int placeId)
    {
      Place place = Place.Find(placeId);
      Category category = Category.Find(categoryId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("place", place);
      model.Add("category", category);
      return View(model);
    }

    [HttpPost("/places/delete")]
    public ActionResult DeleteAll()
    {
      Place.ClearAll();
      return View();
    }

  }
}