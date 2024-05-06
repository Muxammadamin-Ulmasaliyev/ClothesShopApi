using ClothesShopApi.Models;
using ClothesShopApi.Services;
using ClothesShopApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColorController : ControllerBase
	{
		private readonly IColorService _colorService;
		private readonly ILogger<ColorController> _logger;
		public ColorController(IColorService colorService, ILogger<ColorController> logger)
		{
			_colorService = colorService;
			_logger = logger;
		}
		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll()
		{
			//_logger.LogInformation("Product/Get-all executing . . .");
			return Ok(await _colorService.GetAll());
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var color = await _colorService.Get(id);
			if (color == null)
			{
				return NotFound("Color Not Found");
			}
			return Ok(color);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _colorService.Delete(id);
			if (result)
			{
				return NoContent();
			}
			return NotFound("Color Not Found");
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ColorModel model)
		{
			var createdColor = await _colorService.Create(model);
			var routeValues = new { id = createdColor.Id };
			return CreatedAtRoute(routeValues, createdColor);
		}

		//[HttpPut]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] ColorModel model)
		{
			var updatedColor = await _colorService.Update(id, model);
			return Ok(updatedColor);
		}



	}
}
