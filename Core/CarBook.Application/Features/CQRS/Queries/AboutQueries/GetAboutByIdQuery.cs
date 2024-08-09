using CarBook.Application.Features.CQRS.Results.AboutResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
	public class GetAboutByIdQuery: GetAboutByIdQueryResult
	{
		public GetAboutByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }

    }
}
