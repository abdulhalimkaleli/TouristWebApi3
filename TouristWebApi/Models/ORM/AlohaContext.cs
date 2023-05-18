using Microsoft.EntityFrameworkCore;
using TouristWebApi.Models.ORM;

namespace TouristAppAPI.Models.ORM
{
    public class AlohaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=TouristicAppDB; Trusted_Connection=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
