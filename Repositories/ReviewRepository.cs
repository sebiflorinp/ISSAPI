using ISSAPI.Data;
using ISSAPI.Models;
using ISSAPI.Repositories.Interfaces;

namespace ISSAPI.Repositories;

public class ReviewRepository(AppDbContext context) : IReviewRepository
{
    public List<Review> GetByShowId(int showId)
    {
        return context.Reviews
            .Where(r => r.ShowId == showId)
            .ToList();
    }

    public Review? GetById(int id)
    {
        return context.Reviews
            .FirstOrDefault(r => r.Id == id);
    }

    public void AddReview(Review review)
    {
        context.Reviews.Add(review);
        context.SaveChanges();
    }

    public Review UpdateReview(Review review)
    {
        context.Reviews.Update(review);
        context.SaveChanges();
        return review;
    }

    public void DeleteReview(Review review)
    {
        context.Reviews.Remove(review);
        context.SaveChanges();
    }

    public List<Review> GetByUserId(int userId)
    {
        return context.Reviews
            .Where(r => r.UserId == userId)
            .ToList();
    }

    public List<Review> GetAll()
    {
        return context.Reviews.ToList();
    }
}