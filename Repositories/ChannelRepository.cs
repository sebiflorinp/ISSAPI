using ISSAPI.Data;
using ISSAPI.Models;
using ISSAPI.Repositories.Interfaces;

namespace ISSAPI.Repositories;

public class ChannelRepository(AppDbContext context) : IChannelRepository
{
    public List<Channel> FindAllChannels()
    {
        return context.Channels.ToList();
    }

    public List<Channel> FindChannelsByName(string name)
    {
        return context.Channels
            .Where(c => c.Name != null && c.Name.Equals(name))
            .ToList();
    }

    public void AddChannel(Channel channel)
    {
        context.Channels.Add(channel);
        context.SaveChanges();
    }

    public Channel UpdateChannel(string oldChannelName, Channel updatedChannel)
    {
        var existingChannel = context.Channels
            .FirstOrDefault(c => c.Name != null && c.Name.Equals(oldChannelName));

        existingChannel!.Name = updatedChannel.Name;
        existingChannel.Description = updatedChannel.Description;
        existingChannel.LaunchDate = updatedChannel.LaunchDate;
        existingChannel.ClosureDate = updatedChannel.ClosureDate;
        
        context.SaveChanges();
        return existingChannel;
    }

    public void DeleteChannel(Channel channel)
    {
        context.Channels.Remove(channel);
        context.SaveChanges();
    }

    public Channel? GetChannelById(int id)
    {
        return context.Channels
            .FirstOrDefault(c => c.Id == id);
    }

    public Channel? FindById(int channelId)
    {
        return context.Channels.FirstOrDefault(c => c.Id == channelId);
    }

    public Channel Update(Channel existingChannel)
    {
        var channel = context.Channels.Find(existingChannel.Id);
        if (channel == null)
        {
            throw new InvalidOperationException("Channel not found.");
        }

        channel.Name = existingChannel.Name;
        channel.Description = existingChannel.Description;
        channel.LaunchDate = existingChannel.LaunchDate;
        channel.ClosureDate = existingChannel.ClosureDate;

        context.SaveChanges();
        return channel;
    }
}