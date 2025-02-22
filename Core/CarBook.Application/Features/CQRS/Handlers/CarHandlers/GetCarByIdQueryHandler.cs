
using CarBook.Application.Features.CQRS.Queries.CarQueries;
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
	public class GetCarByIdQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetCarByIdQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}
		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
		{
			var values = await _repository.GetCarByIdWithBrandAsync(query.Id);
			return new GetCarByIdQueryResult
			{
				CarID= values.CarID,
				BigImageUrl = values.BigImageUrl,
				BrandID = values.BrandID,
                BrandName=values.Brand.Name,
                Model = values.Model,
				Km = values.Km,
				CoverImgUrl = values.CoverImgUrl,
				Fuel = values.Fuel,
				Luggage = values.Luggage,
				Seat = values.Seat,
				Transmission = values.Transmission,
			};
		}
	}
}
