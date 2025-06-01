using ISSAPI.Models;

namespace ISSAPI.Repositories.Interfaces;

public interface IChannelRepository
{
    List<Channel> FindAllChannels();
        
    List<Channel> FindChannelsByName(string name);
    
    void AddChannel(Channel channel);
    void DeleteChannel(Channel channel);
    Channel? GetChannelById(int id);
    Channel? FindById(int channelId);
    Channel Update(Channel existingChannel);
}