﻿using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.StatisticsQueries
{
    public class BrandNameByMaxCarQuery : IRequest<BrandNameByMaxCarQueryResult>
    {
    }
}
