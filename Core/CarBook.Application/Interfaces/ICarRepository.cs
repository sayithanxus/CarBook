﻿using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
	public interface ICarRepository
	{ 

		List<Car> GetCarsListWithBrands();
		List<Car> GetLast5CarsWithBrands();
		Task<Car> GetCarByIdWithBrandAsync(int id);

    }
}
