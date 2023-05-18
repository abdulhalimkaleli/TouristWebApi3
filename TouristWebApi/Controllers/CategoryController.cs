using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouristAppAPI.Models.ORM;
using TouristWebApi.Models.Dto.Request;
using TouristWebApi.Models;
using TouristWebApi.Models.Dto.Response;
using TouristWebApi.Models.ORM;

namespace TouristWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var context = new AlohaContext();
            List<GetAllCategoryResponseDto> response = context.Categories.Select(x => new GetAllCategoryResponseDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var context = new AlohaContext();
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound(id + " idye sahip kategori bulunamadi");
            }
            else
            {
                GetAllCategoryResponseDto response = new GetAllCategoryResponseDto();
                response.CategoryId = category.Id;
                response.CategoryName = category.CategoryName;

                return Ok(response);
            }

        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryRequestDto request)
        {
            var context = new AlohaContext();

            if (context.Categories.Any(p => p.CategoryId == request.CategoryId))
            {
                return BadRequest("Aynı Id' ye sahip kategori bulunmaktadır. Lütfen başka Id değeri giriniz.");
            }

            var category = new Category();
            category.CategoryId = request.CategoryId;
            category.CategoryName = request.CategoryName;


            context.Categories.Add(category);
            context.SaveChanges();

            return Created("Kategori başarıyla eklenmiştir.", category);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = new AlohaContext();
            var category = context.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                context.Categories.Remove(category);
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
