using ClothesShopApi.Models;
using ClothesShopApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly ILogger<ProductController> _logger;
		public ProductController(IProductService productService, ILogger<ProductController> logger)
		{
			_productService = productService;
			_logger = logger;
		}


		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll()
		{
			//_logger.LogInformation("Product/Get-all executing . . .");
			return Ok(await _productService.GetAll());
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var product = await _productService.Get(id);
			if (product == null)
			{
				return NotFound("Product Not Found");
			}
			return Ok(product);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _productService.Delete(id);
			if (result)
			{
				return NoContent();
			}
			return NotFound("Product Not Found");
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ProductModel model)
		{
			//var existingColors = await _colorService.GetAll();
			var createdProduct = await _productService.Create(model);
			var routeValues = new { id = createdProduct.Id };
			return CreatedAtRoute(routeValues, createdProduct);
		}

		//[HttpPut]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] ProductModel model)
		{
			var updatedProduct = await _productService.Update(id, model);
			return Ok(updatedProduct);
		}


	}
}
