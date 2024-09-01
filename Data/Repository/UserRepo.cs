using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class UserRepo : IUserRepo

{
  private readonly AppDbContext _db;


  public void Add(Users user)
  {
    _db.Users.Add(user);
    _db.SaveChanges();
  }

  public void Update(Users user)
  {
    _db.Entry(user).State = EntityState.Modified;
    _db.SaveChangesAsync();
  }

  public void Delete(Guid id)
  {
    var deleteUser =  _db.Users.Find(id);
    _db.Users.Remove(deleteUser);
    _db.SaveChangesAsync();
  }

  public Users LoginUser(string email, string password)
  {
    return _db.Users.FirstOrDefault(m => m.email == email && m.passwordHash == password);
  }
  public IEnumerable<Users> GetAllByDateCreated()
  {
    return _db.Users.OrderByDescending(u => u.dateCreated).ToList();
  }
  
  public IEnumerable<Users> GetAllByDateLastModified()
  {
    return _db.Users.OrderByDescending(u => u.lastModified).ToList();
  }

  
  public Users FindUserById(Guid id)
  {
    var userById = _db.Users.Find(id);
    return userById ;
  }

  public Users checkEmail(string email)
  {
    return _db.Users.FirstOrDefault(m => m.email == email);
  }

}