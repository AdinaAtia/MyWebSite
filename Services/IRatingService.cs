using Entities;

namespace Services
{
    public interface IRatingService
    {
        Task<Rating> CreateRating(Rating rating);
    }
}