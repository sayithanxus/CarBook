using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Features.Queries.StatisticsQueries;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<BrandNameByMaxCarQuery, BrandNameByMaxCarQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandNameByMaxCarQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<BrandNameByMaxCarQueryResult> Handle(BrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.BrandNameByMaxCar();
            return new BrandNameByMaxCarQueryResult
            {
                BrandNameByMaxCar = value
            };
        }
    }
}
