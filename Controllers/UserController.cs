using ISSAPI.Models.DTOs;
using ISSAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISSAPI.Controllers;

[ApiController] 
[Route("api/users/")]
public class UserController(UserService userService, ReviewService reviewService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult LoginUser([FromBody] UserDto request)
    {
        var user = userService.LoginUser(request.Username, request.Password);
        if (user != null)
        {
            var response = new UserLoginResponseDto(user.Id, request.Username, user.Role);
            return new OkObjectResult(response);
        }
        return new NotFoundResult();
    }
    
    [HttpGet("{userId}/reviews")]
    public IActionResult GetReviewsByUserId(int userId)
    {
        var userExists = userService.GetUserById(userId) != null;
        if (!userExists)
        {
            return NotFound();
        }

        var reviews = reviewService.GetReviewsByUserId(userId);
        return Ok(reviews);
    }
    
    [HttpPost]
    public IActionResult RegisterUser([FromBody] UserDto request)
    {
        try
        {
            userService.RegisterUser(request);
            return new OkResult();
        }
        catch (InvalidOperationException e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}