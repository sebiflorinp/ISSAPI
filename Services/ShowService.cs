using ISSAPI.Models;
using ISSAPI.Models.DTOs;
using ISSAPI.Repositories.Interfaces;

namespace ISSAPI.Services;

public class ShowService(IShowRepository showRepository)
{
    public List<Show> GetAllShows()
    {
        return showRepository.FindAllShows();
    }

    public void AddShow(ShowDto showDto)
    {
        var existingShows = showRepository.FindByName(showDto.Name);
        if (existingShows.Count > 0)
        {
            throw new InvalidOperationException("A show with the same name already exists.");
        }

        var show = new Show(showDto.Name, showDto.Description, showDto.FirstAirDate, showDto.LastAirDate,
            showDto.ChannelId);

        showRepository.AddShow(show);
    }

    public Show UpdateShow(int id, ShowDto showDto)
    {
        var show = showRepository.GetShowById(id);
        if (show == null)
        {
            throw new InvalidOperationException("The show with the specified ID does not exist.");
        }

        show.Name = showDto.Name;
        show.Description = showDto.Description;
        show.FirstAirDate = showDto.FirstAirDate;
        show.LastAirDate = showDto.LastAirDate;
        return showRepository.UpdateShow(show);
    }

    public void DeleteShow(int id)
    {
        var show = showRepository.GetShowById(id);
        if (show == null)
        {
            throw new InvalidOperationException("The show with the specified ID does not exist.");
        }

        showRepository.DeleteShow(show);
    }

    public Show? GetShowById(int id)
    {
        return showRepository.GetShowById(id);
    }
}