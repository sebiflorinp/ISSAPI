using ISSAPI.Models;
using ISSAPI.Models.DTOs;
using ISSAPI.Repositories.Interfaces;

namespace ISSAPI.Services;

public class ReviewService(IReviewRepository reviewRepository)
{
    public List<ReviewGetDto> GetReviewsByShowId(int showId)
    {
        var reviews = reviewRepository.GetByShowId(showId);

        return reviews.Select(r => new ReviewGetDto(
            r.Id,
            r.UserId,
            r.ShowId,
            r.Title ?? "" ,
            r.Rating,
            r.Content ?? ""
        )).ToList();
    }
    
    public List<ReviewGetDto> GetReviewsByUserId(int userId)
    {
        var reviews = reviewRepository.GetByUserId(userId);

        return reviews.Select(r => new ReviewGetDto(
            r.Id,
            r.UserId,
            r.ShowId,
            r.Title ?? "",
            r.Rating,
            r.Content ?? ""
        )).ToList();
    }


    public void AddReview(ReviewDto reviewDto)
    {
        var review = new Review(
            reviewDto.UserId,
            reviewDto.ShowId,
            reviewDto.Title,
            reviewDto.Content,
            reviewDto.Rating);

        reviewRepository.AddReview(review);
    }

    public Review UpdateReview(int id, ReviewDto reviewDto)
    {
        var review = reviewRepository.GetById(id);
        if (review == null)
        {
            throw new InvalidOperationException("Review with the specified ID does not exist.");
        }

        review.Title = reviewDto.Title;
        review.Rating = reviewDto.Rating;
        review.Content = reviewDto.Content;

        return reviewRepository.UpdateReview(review);
    }

    public void DeleteReview(int id)
    {
        var review = reviewRepository.GetById(id);
        if (review == null)
        {
            throw new InvalidOperationException("Review with the specified ID does not exist.");
        }

        reviewRepository.DeleteReview(review);
    }

    public List<ReviewGetDto> GetAllReviews()
    {
        var reviews = reviewRepository.GetAll();

        return reviews.Select(r => new ReviewGetDto(
            r.Id,
            r.UserId,
            r.ShowId,
            r.Title ?? "" ,
            r.Rating,
            r.Content ?? ""
        )).ToList(); 
    }
}