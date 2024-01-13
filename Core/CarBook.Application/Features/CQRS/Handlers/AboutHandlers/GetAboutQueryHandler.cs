﻿using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class GetAboutQueryHandler
	{
		private readonly IRepository<About> _repository;

		public GetAboutQueryHandler(IRepository<About> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetAboutQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAboutQueryResult 
			{ 
				Title = x.Title,
				Description = x.Description,
				AboutID=x.AboutID,
				ImageUrl = x.ImageUrl,
			}).ToList();
		}
	}
}
