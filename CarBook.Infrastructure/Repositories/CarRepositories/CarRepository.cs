using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).Include(y=> y.CarPricings).ThenInclude(y => y.Pricing).ToList();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars
                                 .Include(x => x.Brand) // Brand ilişkisini dahil et
                                 .Include(x => x.CarPricings) // CarPricings ilişkisini dahil et
                                 .ThenInclude(x => x.Pricing) 
                                 .OrderByDescending(x => x.CarID)
                                 .Take(5)
                                 .ToList();
            return values;
        }
        public async Task<Car> GetCarByIdWithBrandAsync(int id)
        {
            var values = await _context.Cars
                         .Where(x=> x.CarID==id)
                         .Include(x => x.Brand)                         
                         .FirstOrDefaultAsync();
            return values;
        }

    }
}
