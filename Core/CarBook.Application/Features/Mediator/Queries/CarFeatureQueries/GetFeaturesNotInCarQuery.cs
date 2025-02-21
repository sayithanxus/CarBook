using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetFeaturesNotInCarQuery : IRequest<List<GetFeaturesNotInCarQueryResult>>
    {
        public int Id { get; set; }

        public GetFeaturesNotInCarQuery(int id)
        {
            Id = id;
        }
    }
}