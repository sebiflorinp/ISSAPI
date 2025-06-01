namespace ISSAPI.Models;

public class Channel
{
    public Channel()
    {
    }
    
    public Channel(string name, string description, DateOnly launchDate, DateOnly? closureDate)
    {
        Name = name;
        Description = description;
        LaunchDate = launchDate;
        ClosureDate = closureDate;
    }
    
    public int Id { get; set; }
    public string? Name { get; set; } 
    public string? Description { get; set; }
    public DateOnly LaunchDate { get; set; }
    public DateOnly? ClosureDate { get; set; }
    public List<Show> Shows { get; set; } = new();
}