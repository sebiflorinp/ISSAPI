using System.Diagnostics.CodeAnalysis;

namespace ISSAPI.Models;

public class Show
{
    public Show(Channel channel)
    {
        Channel = channel;
    }

    [SetsRequiredMembers]
    public Show(string name, string description, DateOnly firstAirDate, DateOnly lastAirDate, int channelId)
    {
        Name = name;
        Description = description;
        FirstAirDate = firstAirDate;
        LastAirDate = lastAirDate;
        ChannelId = channelId;
    }

    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateOnly FirstAirDate { get; set; }
    public DateOnly LastAirDate { get; set; }
    public int ChannelId { get; set; }
    public Channel? Channel { get; set; }
    public List<Review> Reviews { get; set; } = new();
}