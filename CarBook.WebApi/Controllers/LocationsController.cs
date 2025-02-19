using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LocationsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> LocationsList()
		{
			var values = await _mediator.Send(new GetLocationQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetLocations(int id)
		{
			var values = await _mediator.Send(new GetLocationByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateLocations(CreateLocationCommand command)
		{
			await _mediator.Send(command);
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveLocations(int id)
		{
			await _mediator.Send(new RemoveLocationCommand(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateLocations(UpdateLocationCommand command)
		{
			await _mediator.Send(command);
			return Ok("Başarıyla Güncellendi");
		}
	}
}
