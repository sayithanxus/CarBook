using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQureyHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQureyHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarID = x.CarID,
                DailyAmount = x.CarPricings.FirstOrDefault(p => p.Pricing.Name == "Günlük")?.Amount ?? 0, // Günlük fiyatı al
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
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
