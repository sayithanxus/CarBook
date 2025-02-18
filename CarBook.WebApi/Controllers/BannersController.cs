
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{
		private readonly CreateBannerCommandHandler _createBannerCommandHandler;
		private readonly GetBannerByIdQueryHandler _getBannerCommandHandler;
		private readonly GetBannerQueryHandler _geBannerCommandHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

		public BannersController(CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQueryHandler getBannerCommandHandler, GetBannerQueryHandler geBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
		{
			_createBannerCommandHandler = createBannerCommandHandler;
			_getBannerCommandHandler = getBannerCommandHandler;
			_geBannerCommandHandler = geBannerCommandHandler;
			_updateBannerCommandHandler = updateBannerCommandHandler;
			_removeBannerCommandHandler = removeBannerCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> BannerList()
		{
			var values = await _geBannerCommandHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBanner(int id)
		{
			var value = await _getBannerCommandHandler.Handle(new GetBannerByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
		{
			await _createBannerCommandHandler.Handle(command);
			return Ok("Bilgi Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
			return Ok("Bilgi Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
		{
			await _updateBannerCommandHandler.Handle(command);
			return Ok("Bilgi Güncellendi");
		}
	}
}
