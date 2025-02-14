﻿using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _context;

        public TagCloudRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogID(int id)
        {
            var values = _context.TagClouds.Where(x=> x.BlogID== id).ToList();
            return values;
        }
    }
}
