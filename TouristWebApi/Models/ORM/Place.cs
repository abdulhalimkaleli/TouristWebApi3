using System.ComponentModel.DataAnnotations.Schema;

namespace TouristWebApi.Models.ORM
{
    public class Place : BaseModel
    {
        public string PlaceName { get; set; }
        public string? Address { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

