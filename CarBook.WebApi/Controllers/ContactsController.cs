
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly CreateContactCommandHandler _createContactCommandHandler;
		private readonly GetContactByIdQueryHandler _getContactByIdCommandHandler;
		private readonly GetContactQueryHandler _getContactCommandHandler;
		private readonly UpdateContactCommandHandler _updateContactCommandHandler;
		private readonly RemoveContactCommandHandler _removeContactCommandHandler;

		public ContactsController(CreateContactCommandHandler createContactCommandHandler, GetContactByIdQueryHandler getContactByIdCommandHandler, GetContactQueryHandler getContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
		{
			_createContactCommandHandler = createContactCommandHandler;
			_getContactByIdCommandHandler = getContactByIdCommandHandler;
			_getContactCommandHandler = getContactCommandHandler;
			_updateContactCommandHandler = updateContactCommandHandler;
			_removeContactCommandHandler = removeContactCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> ContactList()
		{
			var values = await _getContactCommandHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _getContactByIdCommandHandler.Handle(new GetContactByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateContactCommand command)
		{
			await _createContactCommandHandler.Handle(command);
			return Ok("Bilgi Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
			return Ok("Bilgi Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateContactCommand command)
		{
			await _updateContactCommandHandler.Handle(command);
			return Ok("Bilgi Güncellendi");
		}
	}
}
