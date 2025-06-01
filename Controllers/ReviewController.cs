using ISSAPI.Models.DTOs;
using ISSAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISSAPI.Controllers;

[ApiController]
[Route("api/reviews/")]
public class ReviewController(ReviewService reviewService) : ControllerBase
{
    
    [HttpPost]
    public IActionResult AddReview([FromBody] ReviewDto request)
    {
        Console.WriteLine(request.ShowId);
        Console.WriteLine(request.UserId);
        try
        {
            Console.WriteLine(request);
            reviewService.AddReview(request);
            return Ok();
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }
 
    [HttpGet]
    public IActionResult GetAllReviews()
    {
        try
        {
            Console.WriteLine("FDSFD");
            var reviews = reviewService.GetAllReviews();
            return Ok(reviews);
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while fetching reviews.");
        }
    }
    

    [HttpDelete("{id}")]
    public IActionResult DeleteReview(int id)
    {
        try
        {
            reviewService.DeleteReview(id);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateReview(int id, [FromBody] ReviewDto request)
    {
        try
        {
            reviewService.UpdateReview(id, request);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }
}