using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetFeaturesNotInCarQueryHandler : IRequestHandler<GetFeaturesNotInCarQuery, List<GetFeaturesNotInCarQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        public GetFeaturesNotInCarQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeaturesNotInCarQueryResult>> Handle(GetFeaturesNotInCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetFeaturesNotInCar(request.Id);
            return values.Select(x => new GetFeaturesNotInCarQueryResult
            {
                FeatureID = x.FeatureID,
                Name=x.Name                
            }).ToList();
        }
    }
}
