using Entities;

using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        CatagoryContext _dbcontext;
        public RatingRepository(CatagoryContext context)
        {
            _dbcontext = context;
        }
        public async Task<Rating> CreateRating(Rating newRating)
        {
            await _dbcontext.Ratings.AddAsync(newRating);
            await _dbcontext.SaveChangesAsync();
            return newRating;
        }
    }
}
