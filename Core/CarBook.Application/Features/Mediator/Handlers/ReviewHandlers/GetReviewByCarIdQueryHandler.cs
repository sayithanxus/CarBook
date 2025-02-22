﻿using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;
        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetReviewsByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                CarID = x.CarID,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RaytingValue = x.RaytingValue,
                ReviewDate = x.ReviewDate,
                ReviewID = x.ReviewID
            }).ToList();
        }
    }
}
