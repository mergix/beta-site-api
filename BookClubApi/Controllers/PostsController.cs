using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO_s;
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
    public IActionResult CreatePost([FromBody] createPost club)
    {
        var newUser =  _postService.CreatePost(club);
        return Ok(newUser);
    }
    
    [HttpPut]
    public IActionResult UpdatePost(Guid id, [FromBody] Posts club)
    {

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
    
    [HttpGet("club")]
    public IActionResult GetPostByClub(Guid id)
    {
        var newUser =  _postService.GetAllPostByClub(id);
        return Ok(newUser);
    }
    
    [HttpGet("user")]
    public IActionResult GetPostByUser(Guid id)
    {
        var newUser =  _postService.GetAllPostByUser(id);
        return Ok(newUser);
    }
    
    [HttpGet("book")]
    public IActionResult GetPostByBook(Guid id)
    {
        var newUser =  _postService.GetAllPostByBook(id);
        return Ok(newUser);
    }
    
    [HttpGet]
    public IActionResult GetAllPosts()
    {
        var newUser =  _postService.GetAllPosts();
        return Ok(newUser);
    }
}