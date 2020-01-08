using System.Collections.Generic;

namespace Places.Models
{
  public class Place
  {
    public string Description { get; set; }
    private static List<Place> _instances = new List<Place> {};

    public Place (string description)
    {
      Description = description;
      _instances.Add(this);
    }

    public static List<Place> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

  }
}