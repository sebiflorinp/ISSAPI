using ISSAPI.Models.DTOs;
using ISSAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISSAPI.Controllers;

[ApiController]
[Route("api/shows")]
public class ShowController(ShowService showService, ReviewService reviewService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllShows()
    {
        var shows = showService.GetAllShows();
        return Ok(shows);
    }

    [HttpGet("{id}")]
    public IActionResult GetShowById(int id)
    {
        var show = showService.GetShowById(id);
        return show != null ? Ok(show) : NotFound();
    }
    
    [HttpGet("{id}/reviews")]
    public IActionResult GetReviewsByShowId(int id)
    {
        try
        {
            var reviews = reviewService.GetReviewsByShowId(id);
            return Ok(reviews);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult AddShow([FromBody] ShowDto request)
    {
        try
        {
            showService.AddShow(request);
            return Ok();
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateShow(int id, [FromBody] ShowDto request)
    {
        try
        {
            Console.WriteLine("FDSFDSDFS");
            var updated = showService.UpdateShow(id, request);
            return Ok(updated);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteShow(int id)
    {
        try
        {
            showService.DeleteShow(id);
            return Ok();
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }
}