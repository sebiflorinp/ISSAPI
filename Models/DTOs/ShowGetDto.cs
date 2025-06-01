namespace ISSAPI.Models.DTOs;

public class ShowGetDto
{
    public ShowGetDto(int id, string name, string description, DateOnly firstAirDate, DateOnly lastAirDate, int channelId)
    {
        Id = id;
        Name = name;
        Description = description;
        FirstAirDate = firstAirDate;
        LastAirDate = lastAirDate;
        ChannelId = channelId;
    }
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public DateOnly FirstAirDate { get; set; }

    public DateOnly LastAirDate { get; set; }

    public int ChannelId { get; set; } 
}