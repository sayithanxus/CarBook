using CarBook.Application.Interfaces;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string BlogTitleByMaxBlogComment()
        {
            var blogIdWithMaxComments = _context.Comments
                .GroupBy(c => c.BlogID)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var blogTitle = _context.Blogs
                .Where(b => b.BlogID == blogIdWithMaxComments)
                .Select(b => b.Title)
                .FirstOrDefault();

            return blogTitle;
        }

        public string BrandNameByMaxCar()
        {
            var values = _context.Cars.GroupBy(x => x.BrandID).
                            Select(y => new
                            {
                                BrandID = y.Key,
                                Count = y.Count()
                            }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            var value = _context.CarPricings.Where(y=>y.Pricing.Name=="Günlük").Average(x=>x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            var value = _context.CarPricings.Where(y => y.Pricing.Name == "Aylık").Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            var value = _context.CarPricings.Where(y => y.Pricing.Name == "Haftalık").Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            var maxDailyPrice = _context.CarPricings
                .Where(cp => cp.Pricing.Name == "Günlük")
                .OrderByDescending(cp => cp.Amount)
                .FirstOrDefault();

            var car = _context.Cars
                .Include(c => c.Brand)
                .FirstOrDefault(c => c.CarID == maxDailyPrice.CarID);

            return $"{car.Brand.Name} {car.Model}";
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            var minDailyPrice = _context.CarPricings
                .Where(cp => cp.Pricing.Name == "Günlük")
                .OrderBy(cp => cp.Amount)
                .FirstOrDefault();

            var car = _context.Cars
                .Include(c => c.Brand)
                .FirstOrDefault(c => c.CarID == minDailyPrice.CarID);

            return $"{car.Brand.Name} {car.Model}";
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public double GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Count(c => c.Fuel == "Elektrik");
            return value;
        }

        public double GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Count(c => c.Fuel == "Benzin" || c.Fuel == "Dizel");
            return value;
        }

        public double GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Count(c => c.Km < 1000);
            return value;
        }

        public double GetCarCountByTranmissionIsAuto()
        {
            var value = _context.Cars.Count(c => c.Transmission == "Otomatik");
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
