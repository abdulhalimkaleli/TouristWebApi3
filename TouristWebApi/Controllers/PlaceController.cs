using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TouristAppAPI.Models.ORM;
using TouristWebApi.Models.Dto.Request;
using TouristWebApi.Models.Dto.Response;
using TouristWebApi.Models.ORM;

namespace TouristWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var context = new AlohaContext();
            List<GetAllPlaceResponseDto> response = context.Places
                .Include(p => p.Category)
                .Select(x => new GetAllPlaceResponseDto
                {
                    Id = x.Id,
                    PlaceName = x.PlaceName,
                    CategoryName = x.Category.CategoryName, 
                })
                .ToList();

            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var context = new AlohaContext();
            var place = context.Places
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Id == id);

            if (place == null)
            {
                return NotFound(id + " idye sahip mekan bulunamadi");
            }
            else
            {
                GetAllPlaceResponseDto response = new GetAllPlaceResponseDto();
                response.Id = place.Id;
                response.CategoryName = place.Category.CategoryName;

                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult AddPlace(AddPlaceRequestDto request)
        {
            var context = new AlohaContext();

            if (context.Places.Any(p => p.Id == request.CategoryId))
            {
                return BadRequest("Aynı Id' ye sahip yer bulunmaktadır. Lütfen başka Id değeri giriniz.");
            }
            
                var place = new Place();
                place.PlaceName = request.PlaceName;
            place.CategoryId = request.CategoryId;


            context.Places.Add(place);
                context.SaveChanges();

            return Created("Yer başarıyla eklenmiştir.",place);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = new AlohaContext();
            var place = context.Places.FirstOrDefault(x => x.Id == id);
            if (place != null)
            {
                context.Places.Remove(place);
                context.SaveChanges();
                return Ok("Silindi");
            }
            else
            {
                return NotFound();
            }

        }
    }
}
