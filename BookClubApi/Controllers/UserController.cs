using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO_s;
using Services;

namespace BookClubApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;
    // private readonly IEmailService _emailService;
    private readonly IPasswordService _passwordHasher;

    public UserController(IUserService userService,IPasswordService passwordHasher)
    {
        _userService = userService;
        _passwordHasher = passwordHasher;
    }
    
    [HttpPost]
    public IActionResult CreateUser([FromBody] Users user)
    {
        var newUser =  _userService.CreateUser(user);
        return Ok(newUser);
    }
    
    [HttpPut]
    public IActionResult UpdateUser(Guid id, [FromBody] Users user)
    {
        if (id != user.id)
        {
            return BadRequest();
        }
        _userService.UpdateUser(user);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(Guid id)
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
        
        var userToDelete = await _userService.GetUserById(id);
        if (userToDelete == null)
            return NotFound();
    
        _userService.DeleteUser(userToDelete.id);
        return NoContent();
    }
    
    [HttpPost("/login")]
    public IActionResult LoginUser([FromBody] LoginDTO user)
    {
        var  UserLoginInfo =  _userService.Login(user);
    
        // _userService.CreateToken(user);
        //
        // var token = _userService.CreateToken(user);
    
        var UserLogin = new LoginDTO()
        {
            UserId = UserLoginInfo.Result.UserId,
            UserEmail = UserLoginInfo.Result.UserEmail,
        };
        return Ok(UserLogin);
    } 
    
    [HttpGet("{id}")]
    public IActionResult GetUserById(Guid id)
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
        // if (user.roleType != Role.user && user.roleType != Role.admin)
        // {
        //     return Unauthorized();
        // }
        
        return  Ok(_userService.GetUserById(id));
    }
    
    [HttpGet]
    public IActionResult GetUsersList()
    {
        
        return  Ok(_userService.GetUserList());
    }
}