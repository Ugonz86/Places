using Microsoft.AspNetCore.Mvc;
using Places.Models;

namespace Places.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Index()
    {
      Place starterPlace = new Place("Add first place to the list");
      return View(starterPlace);
    }

    [Route("/places/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [Route("/places")]
    public ActionResult Create(string description)
    {
      Place myPlace = new Place(description);
      return View("Index", myPlace);
    }

  }
}