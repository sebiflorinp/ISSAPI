namespace ISSAPI.Models.DTOs;

public class ChannelDto(string name, string description, DateOnly launchDate, DateOnly? closureDate)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public DateOnly LaunchDate { get; set; } = launchDate;
    public DateOnly? ClosureDate { get; set; } = closureDate;
}