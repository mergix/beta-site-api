using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace BookClubApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class GenreController:ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }
    [HttpPost]
    public IActionResult CreateGenre([FromBody] Genre club)
    {
        var newUser =  _genreService.CreateGenre(club);
        return Ok(newUser);
    }
    
    [HttpPut]
    public IActionResult UpdateGenre(Guid id, [FromBody] Genre club)
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
        _genreService.UpdateGenre(club);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGenre(Guid id)
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
        // var user = _userService.emailExists(userEmail);
        // if (user.roleType != Role.admin)
        // {
        //     return Unauthorized();
        // }
        
        var userToDelete = await _genreService.GetGenreById(id);
        if (userToDelete == null)
            return NotFound();
    
        _genreService.DeleteGenre(userToDelete.id);
        return NoContent();
    }
}