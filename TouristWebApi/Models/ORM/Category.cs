using System.ComponentModel.DataAnnotations.Schema;

namespace TouristWebApi.Models.ORM
{
    public class Category : BaseModel
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
