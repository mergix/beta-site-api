using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace BookClubApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController :ControllerBase
{
    
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpPost]
    public IActionResult CreateClub([FromBody] Books book)
    {
        var newUser =  _bookService.CreateBook(book);
        return Ok(newUser);
    }
    
    [HttpPut]
    public IActionResult UpdateClub(Guid id, [FromBody] Books book)
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
        if (id != book.id)
        {
            return BadRequest();
        }
        _bookService.UpdateBook(book);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteClub(Guid id)
    {
        var userToDelete = await _bookService.GetBookById(id);
        if (userToDelete == null)
            return NotFound();
    
        _bookService.DeleteBook(userToDelete.id);
        return NoContent();
    }
}