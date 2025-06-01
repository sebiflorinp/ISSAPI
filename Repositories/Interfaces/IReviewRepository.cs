using ISSAPI.Models;
using System.Collections.Generic;
using ISSAPI.Models.DTOs;

namespace ISSAPI.Repositories.Interfaces;

public interface IReviewRepository
{
    List<Review> GetByShowId(int showId);
    Review? GetById(int id);
    void AddReview(Review review);
    Review UpdateReview(Review review);
    void DeleteReview(Review review);
    List<Review> GetByUserId(int userId);
    List<Review> GetAll();
}