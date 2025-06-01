namespace ISSAPI.Models.DTOs;

public class ChannelUpdateDto
{
    public string? OldName { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateOnly LaunchDate { get; set; }
    public DateOnly? ClosureDate { get; set; }
}