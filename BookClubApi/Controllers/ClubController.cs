using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace BookClubApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClubController:ControllerBase
{
    private readonly IClubService _clubService;

    public ClubController(IClubService clubService)
    {
        _clubService = clubService;
    }
    
    [HttpPost]
    public IActionResult CreateClub([FromBody] Clubs club)
    {
        var newUser =  _clubService.CreateClubs(club);
        return Ok(newUser);
    }
    
    [HttpPut]
    public IActionResult UpdateClub(Guid id, [FromBody] Clubs club)
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
        _clubService.UpdateClubs(club);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteClub(Guid id)
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
        
        var userToDelete = await _clubService.GetClubsById(id);
        if (userToDelete == null)
            return NotFound();
    
        _clubService.DeleteClubs(userToDelete.id);
        return NoContent();
    }
    
    
    [HttpPost]
    public IActionResult AddClubUser([FromBody] Clubs club)
    {
        // var newUser =  _clubService.CreateClubs(club);
        return Ok();
    }
    
    [HttpPost]
    public IActionResult AddClubAdmin([FromBody] Clubs club)
    {
        // var newUser =  _clubService.CreateClubs(club);
        return Ok();
    }
}