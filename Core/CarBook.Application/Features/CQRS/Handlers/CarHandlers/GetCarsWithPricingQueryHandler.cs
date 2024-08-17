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
    public class GetCarsWithPricingQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarsWithPricingQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarsWithPricingQueryResult>> Handle()
        {
            var values = _repository.GetCarsWithPricings();
            return values.Select(x => new GetCarsWithPricingQueryResult
            {
                CarID = x.Car.CarID,
                BigImageUrl = x.Car.BigImageUrl,
                BrandID = x.Car.BrandID,
                BrandName = x.Car.Brand.Name,
                Model = x.Car.Model,
                Km = x.Car.Km,
                CoverImgUrl = x.Car.CoverImgUrl,
                Fuel = x.Car.Fuel,
                Luggage = x.Car.Luggage,
                Seat = x.Car.Seat,
                Transmission = x.Car.Transmission,
                PricingName=x.Pricing.Name,
                PricingAmount=x.Amount
            }).ToList();
        }
    }
}
