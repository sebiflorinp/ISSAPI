namespace ISSAPI.Models;

public class Review
{
    public Review() { }

    public Review(string title, string content, int rating)
    {
        Title = title;
        Content = content;
        Rating = rating;
    }
    
    public Review(int userId, int showId,string title, string content, int rating)
    {
        UserId = userId;
        ShowId = showId;
        Title = title;
        Content = content;
        Rating = rating;
    }
    
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int ShowId { get; set; }
    public Show? Show { get; set; }
}