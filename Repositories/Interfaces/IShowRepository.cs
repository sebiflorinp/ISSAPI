using ISSAPI.Models;

namespace ISSAPI.Repositories.Interfaces;

public interface IShowRepository
{
    List<Show> FindAllShows();
    List<Show> FindByName(string name);
    Show? GetShowById(int id);
    void AddShow(Show show);
    Show UpdateShow(Show show);
    void DeleteShow(Show show);
    List<Show> FindShowsByChannelId(int channelId);
}