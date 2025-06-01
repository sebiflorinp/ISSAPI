using System.ComponentModel.DataAnnotations;

namespace ISSAPI.Models.DTOs;

public class ShowDto
{
    public ShowDto(string name, string description, DateOnly firstAirDate, DateOnly lastAirDate, int channelId)
    {
        Name = name;
        Description = description;
        FirstAirDate = firstAirDate;
        LastAirDate = lastAirDate;
        ChannelId = channelId;
    }
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public DateOnly FirstAirDate { get; set; }

    public DateOnly LastAirDate { get; set; }

    public int ChannelId { get; set; }
}
