
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly CreateCarCommandHandler _createCarCommandHandler;
		private readonly GetCarByIdQueryHandler _getCarByIdCommandHandler;
		private readonly GetCarQueryHandler _getCarCommandHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;
		private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
		private readonly GetLast5CarsWithBrandQureyHandler _getLast5CarsWithBrandQureyHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdCommandHandler, GetCarQueryHandler getCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarsWithBrandQureyHandler getLast5CarsWithBrandQureyHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdCommandHandler = getCarByIdCommandHandler;
            _getCarCommandHandler = getCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarsWithBrandQureyHandler = getLast5CarsWithBrandQureyHandler;
        }
        [HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await _getCarCommandHandler.Handle();
			return Ok(values);
		}
		[HttpGet("GetCarWithBrand")]
		public async Task<IActionResult> GetCarWithBrandList()
		{
			var values = await _getCarWithBrandQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("GetLast5CarsWithBrand")]
		public async Task<IActionResult> GetLast5CarsWithBrandList()
		{
			var values = await _getLast5CarsWithBrandQureyHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _getCarByIdCommandHandler.Handle(new GetCarByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand command)
		{
			await _createCarCommandHandler.Handle(command);
			return Ok("Bilgi Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok("Bilgi Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
		{
			await _updateCarCommandHandler.Handle(command);
			return Ok("Bilgi Güncellendi");
		}
	}
}
