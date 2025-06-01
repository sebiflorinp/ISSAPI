namespace ISSAPI.Models.DTOs;
public class ReviewDto
{
    public ReviewDto() { }

    public ReviewDto(int userId, int showId, string title, int rating, string content)
    {
        UserId = userId;
        ShowId = showId;
        Title = title;
        Rating = rating;
        Content = content;
    }
    
    public int UserId { get; set; }
    public int ShowId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Rating { get; set; }    
    public string Content { get; set; } = string.Empty;

}
