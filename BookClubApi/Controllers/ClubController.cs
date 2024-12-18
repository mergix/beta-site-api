using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO_s;
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
    public IActionResult CreateClub([FromBody] clubCreate club)
    {
        var newUser =  _clubService.CreateClubs(club);
        return Ok(newUser);
    }
    
    [HttpPut("/{id}")]
    public IActionResult UpdateClub(Guid id, [FromBody] Clubs club)
    {
        if (id != club.id)
        {
            return BadRequest();
        }
        _clubService.UpdateClubs(club);
        return NoContent();
    }
    
    [HttpDelete("/{id}")]
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
        
        var userToDelete = await _clubService.GetClubById(id);
        if (userToDelete == null)
            return NotFound();
    
        _clubService.DeleteClubs(userToDelete.id);
        return NoContent();
    }
    
    [HttpGet("/club/{id}")]
    public IActionResult GetClubById(Guid id)
    {
        var clublist =  _clubService.GetClubById(id);
        return Ok(clublist);
    }    
    [HttpGet("/clublist")]
    public IActionResult GetAllClubs()
    {
        var clublist =  _clubService.GetAllClubs();
        return Ok(clublist);
    }    
    
    [HttpGet("/clublist/{id}")]
    public IActionResult GetAllClubsByUserId(Guid id)
    {
        var clublist =  _clubService.GetAllClubsByUserId(id);
        return Ok(clublist);
    }    
    
    [HttpGet("/userlist/{id}")]
    public IActionResult GetAllUsersByClubId(Guid id)
    {
        var clublist =  _clubService.GetAllUsersByClubId(id);
        return Ok(clublist);
    }    
    
    [HttpPost("/members")]
    public IActionResult CreateClubMemeber([FromBody] createMember mem)
    {
        var newUser =  _clubService.AddClubMember(mem);
        return Ok(newUser);
    }
    
    [HttpPut("/members/{id}")]
    public IActionResult UpdateClubMember(Guid id, [FromBody] ClubMembers mem)
    {
        if (id != mem.id)
        {
            return BadRequest();
        }
        _clubService.UpdateClubMemeber(mem);
        return NoContent();
    }
    
    [HttpDelete("/members/{id}")]
    public  Task<ActionResult> DeleteClubMemeber(Guid userid , Guid clubid)
    {
        
        
        // var userToDelete = await _clubService.GetClubById(id);
        // if (userToDelete == null)
        //     return NotFound();
        
        _clubService.DeleteClubMember(userid , clubid);
        return Task.FromResult<ActionResult>(Ok());
    }
    
    [HttpGet("/randomlist")]
    public IActionResult GetRandomClubs()
    {
        var clublist =  _clubService.GetRandomClubs();
        return Ok(clublist);
    }    
}