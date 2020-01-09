using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Places.Models;

namespace Places.Controllers
{
  public class CategoriesController : Controller
  {

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Place> categoryPlaces = selectedCategory.Places;
      model.Add("category", selectedCategory);
      model.Add("places", categoryPlaces);
      return View(model);
    }

    // This one creates new Places within a given Category, not new Categories:
    [HttpPost("/categories/{categoryId}/places")]
    public ActionResult Create(int categoryId, string placeDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Place newPlace = new Place(placeDescription);
      foundCategory.AddPlace(newPlace);
      List<Place> categoryPlaces = foundCategory.Places;
      model.Add("places", categoryPlaces);
      model.Add("category", foundCategory);
      return View("Show", model);
    }

  }
}