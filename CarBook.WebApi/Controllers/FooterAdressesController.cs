using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterAdressesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FooterAdressesController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> FooterAdressesList()
		{
			var values = await _mediator.Send(new GetFooterAdressQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFooterAdresses(int id)
		{
			var values = await _mediator.Send(new GetFooterAdressByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateFooterAdresses(CreateFooterAdressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveFooterAdresses(int id)
		{
			await _mediator.Send(new RemoveFooterAdressCommand(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFooterAdresses(UpdateFooterAdressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Başarıyla Güncellendi");
		}
	}
}
