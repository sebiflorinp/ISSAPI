using ISSAPI.Models;
using ISSAPI.Models.DTOs;
using ISSAPI.Repositories.Interfaces;

namespace ISSAPI.Services;

public class ChannelService(IChannelRepository channelRepository, IShowRepository showRepository)
{
    public List<Channel> GetAllChannels()
    {
        return channelRepository.FindAllChannels();
    }
    
    public void AddChannel(ChannelDto channelDto)
    {
        // Check if there is already a channel with the same name
        var anotherChannel = channelRepository.FindChannelsByName(channelDto.Name);
        if (anotherChannel.Count > 0)
        {
            throw new InvalidOperationException($"There is already a channel with the given name.");
        }

        var channel = new Channel(channelDto.Name, channelDto.Description, channelDto.LaunchDate,
            channelDto.ClosureDate);
        channelRepository.AddChannel(channel);
    }
    
    public Channel UpdateChannel(int channelId, ChannelDto updatedChannelDto)
    {
        // Find the channel by ID
        var existingChannel = channelRepository.FindById(channelId);
        if (existingChannel == null)
        {
            throw new InvalidOperationException($"Channel with ID {channelId} does not exist.");
        }

        // Check if another channel already has the new name
        var channelsWithSameName = channelRepository.FindChannelsByName(updatedChannelDto.Name);
        if (channelsWithSameName.Any(c => c.Id != channelId))
        {
            throw new InvalidOperationException("There is already a channel with the given name.");
        }

        // Update properties of the existing channel
        existingChannel.Name = updatedChannelDto.Name;
        existingChannel.Description = updatedChannelDto.Description;
        existingChannel.LaunchDate = updatedChannelDto.LaunchDate;
        existingChannel.ClosureDate = updatedChannelDto.ClosureDate;

        // Save update in repository
        return channelRepository.Update(existingChannel);
    }

    public void DeleteChannel(int id)
    {
        var channel = channelRepository.GetChannelById(id);

        if (channel == null)
        {
            throw new InvalidOperationException("Nu există niciun canal cu ID-ul specificat.");
        }

        channelRepository.DeleteChannel(channel);
    }
    
    public Channel? GetChannelById(int id)
    {
        return channelRepository.GetChannelById(id);
    }

    public List<ShowGetDto> GetShowsByChannelId(int id)
    {
        return showRepository.FindShowsByChannelId(id)
            .Select(show => new ShowGetDto(
                show.Id,
                show.Name,
                show.Description,
                show.FirstAirDate,
                show.LastAirDate,
                show.ChannelId
            ))
            .ToList();
    }
}