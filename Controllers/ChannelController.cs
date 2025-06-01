using ISSAPI.Models.DTOs;
using ISSAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISSAPI.Controllers;

[ApiController]
[Route("api/channels/")]
public class ChannelController(ChannelService channelService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllChannels()
    {
        var channels = channelService.GetAllChannels();
        return new OkObjectResult(channels);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetChannelById(int id)
    {
        var channel = channelService.GetChannelById(id);
        if (channel != null)
        {
            return new OkObjectResult(channel);
        }
        return new NotFoundResult();
    }
    
    [HttpGet("{id}/shows")]
    public IActionResult GetShowsByChannelId(int id)
    {
        var channel = channelService.GetChannelById(id);
        if (channel == null)
        {
            return NotFound();
        }

        var shows = channelService.GetShowsByChannelId(id);
        return Ok(shows);
    }
    
    
    [HttpPost]
    public IActionResult AddChannel([FromBody] ChannelDto request)
    {
        try
        {
            channelService.AddChannel(request);
            return new OkResult();
        }
        catch (InvalidOperationException e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateChannel(int id, [FromBody] ChannelDto request)
    {
        try
        {
            Console.WriteLine("FDFDS");
            var updatedChannel = channelService.UpdateChannel(id, request);
            return Ok(updatedChannel);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    
    [HttpDelete("{id}")]
    public IActionResult DeleteChannel(int id)
    {
        try
        {
            channelService.DeleteChannel(id);
            return new OkResult();
        }
        catch (InvalidOperationException e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}