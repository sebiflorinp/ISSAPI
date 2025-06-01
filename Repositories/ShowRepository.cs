using ISSAPI.Data;
using ISSAPI.Models;
using ISSAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISSAPI.Repositories;

public class ShowRepository(AppDbContext context) : IShowRepository
{
    public List<Show> FindAllShows()
    {
        return context.Shows.ToList();
    }

    public List<Show> FindByName(string name)
    {
        return context.Shows
            .Where(s => s.Name.Equals(name))
            .ToList();
    }

    public Show? GetShowById(int id)
    {
        return context.Shows.FirstOrDefault(s => s.Id == id);
    }

    public void AddShow(Show show)
    {
        context.Shows.Add(show);
        context.SaveChanges();
    }

    public Show UpdateShow(Show updatedShow)
    {
        var existingShow = context.Shows.FirstOrDefault(s => s.Id == updatedShow.Id);
        if (existingShow == null)
        {
            throw new InvalidOperationException("Show not found.");
        }

        existingShow.Name = updatedShow.Name;
        existingShow.Description = updatedShow.Description;
        existingShow.FirstAirDate = updatedShow.FirstAirDate;
        existingShow.LastAirDate = updatedShow.LastAirDate;

        context.SaveChanges();
        return existingShow;
    }

    public void DeleteShow(Show show)
    {
        context.Shows.Remove(show);
        context.SaveChanges();
    }

    public List<Show> FindShowsByChannelId(int channelId)
    {
        return context.Shows
            .Where(s => s.ChannelId == channelId)
            .ToList();
    }
}