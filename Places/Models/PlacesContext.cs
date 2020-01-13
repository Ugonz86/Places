using Microsoft.EntityFrameworkCore;

namespace Places.Models
{
  public class PlacesContext : DbContext
  {
    public DbSet<Place> Places { get; set; }

    public PlacesContext(DbContextOptions options) : base(options) { }
  }
}