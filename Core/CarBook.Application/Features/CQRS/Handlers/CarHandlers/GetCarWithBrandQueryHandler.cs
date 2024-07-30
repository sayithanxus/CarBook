using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetCarWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCarWithBrandQueryResult>> Handle()
		{
			var values =  _repository.GetCarsListWithBrands();
			return values.Select(x => new GetCarWithBrandQueryResult
			{
				CarID = x.CarID,
				BigImageUrl = x.BigImageUrl,
				BrandID = x.BrandID,
				BrandName=x.Brand.Name,
				Model = x.Model,
				Km = x.Km,
				CoverImgUrl = x.CoverImgUrl,
				Fuel = x.Fuel,
				Luggage = x.Luggage,
				Seat = x.Seat,
				Transmission = x.Transmission,
			}).ToList();
		}
	}
}
