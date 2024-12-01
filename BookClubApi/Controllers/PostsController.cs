using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace BookClubApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PostsController: ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpPost]
    public IActionResult CreatePost([FromBody] Posts club)
    {
        var newUser =  _postService.CreatePost(club);
        return Ok(newUser);
    }
    
    [HttpPut]
    public IActionResult UpdatePost(Guid id, [FromBody] Posts club)
    {
    
    
        // var jwt = Request.Cookies["token"];
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var cust = _userService.emailExists(userEmail);
        // if (cust.roleType != Role.admin)
        // {
        //     return Unauthorized();
        // }
        if (id != club.id)
        {
            return BadRequest();
        }
        _postService.UpdatePost(club);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(Guid id)
    {
        var userToDelete = await _postService.GetPostById(id);
        if (userToDelete == null)
            return NotFound();
    
        _postService.DeletePost(userToDelete.id);
        return NoContent();
    }
}