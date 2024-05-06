using ClothesShopApi.Models;
using ClothesShopApi.Services.IServices;
using ClothesShopDomain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var category = await _categoryService.Get(id);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _categoryService.GetAll());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _categoryService.Delete(id);
			if (result)
			{
				return NoContent();
			}
			return NotFound("Category Not Found");
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CategoryModel model)
		{
			var createdCategory = await _categoryService.Create(model);
			var routeValues = new { id = createdCategory.Id };
			return CreatedAtRoute(routeValues, createdCategory);
		}

		//[HttpPut]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] CategoryModel model)
		{
			var updatedCategory = await _categoryService.Update(id, model);
			return Ok(updatedCategory);
		}
	}
}
