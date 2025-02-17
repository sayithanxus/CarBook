
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly CreateBrandCommandHandler _createBrandCommandHandler;
		private readonly GetBrandByIdQueryHandler _getBrandByIdCommandHandler;
		private readonly GetBrandQueryHandler _getBrandCommandHandler;
		private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
		private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

		public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdCommandHandler, GetBrandQueryHandler getBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
		{
			_createBrandCommandHandler = createBrandCommandHandler;
			_getBrandByIdCommandHandler = getBrandByIdCommandHandler;
			_getBrandCommandHandler = getBrandCommandHandler;
			_updateBrandCommandHandler = updateBrandCommandHandler;
			_removeBrandCommandHandler = removeBrandCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await _getBrandCommandHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrand(int id)
		{
			var value = await _getBrandByIdCommandHandler.Handle(new GetBrandByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
		{
			await _createBrandCommandHandler.Handle(command);
			return Ok("Bilgi Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveBrand(int id)
		{
			await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
			return Ok("Bilgi Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
		{
			await _updateBrandCommandHandler.Handle(command);
			return Ok("Bilgi Güncellendi");
		}
	}
}
