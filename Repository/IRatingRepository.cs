using Entities;

namespace Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> CreateRating(Rating newRating);
    }
}