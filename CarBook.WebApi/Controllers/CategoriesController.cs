
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
		private readonly GetCategoryByIdQueryHandler _getCategoryByIdCommandHandler;
		private readonly GetCategoryQueryHandler _getCategoryCommandHandler;
		private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
		private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

		public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdCommandHandler, GetCategoryQueryHandler getCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
		{
			_createCategoryCommandHandler = createCategoryCommandHandler;
			_getCategoryByIdCommandHandler = getCategoryByIdCommandHandler;
			_getCategoryCommandHandler = getCategoryCommandHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await _getCategoryCommandHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _getCategoryByIdCommandHandler.Handle(new GetCategoryByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCategoryCommand command)
		{
			await _createCategoryCommandHandler.Handle(command);
			return Ok("Bilgi Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
			return Ok("Bilgi Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCategoryCommand command)
		{
			await _updateCategoryCommandHandler.Handle(command);
			return Ok("Bilgi Güncellendi");
		}
	}
}
