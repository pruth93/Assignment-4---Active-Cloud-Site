using Microsoft.EntityFrameworkCore;
using Smithsonian.Models;

namespace Smithsonian.DataAccess
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


  }
}