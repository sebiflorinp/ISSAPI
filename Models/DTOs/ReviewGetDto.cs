namespace ISSAPI.Models.DTOs;

public class ReviewGetDto
{
    public ReviewGetDto() { }

    public ReviewGetDto(int reviewId, int userId, int showId, string title, int rating, string content)
    {
        ReviewId = reviewId;
        UserId = userId;
        ShowId = showId;
        Title = title;
        Rating = rating;
        Content = content;
    }

    public int ReviewId { get; set; }
    public int UserId { get; set; }
    public int ShowId { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Rating { get; set; }    
    public string Content { get; set; } = string.Empty;
 
}