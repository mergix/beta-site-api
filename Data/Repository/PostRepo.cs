using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class PostRepo: IPostRepo
{
    
    private readonly AppDbContext _db;
    
    public PostRepo(AppDbContext context) 
    { 
        _db = context;
    }
    
    public void Add(Posts post)
    {
        _db.Posts.Add(post);
        _db.SaveChanges();
    }

    public void Update(Posts post)
    {
        _db.Entry(post).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public void Delete(Guid id)
    {
        var deleteUser =  _db.Posts.Find(id);
        _db.Posts.Remove(deleteUser);
        _db.SaveChangesAsync();
    }

    public IEnumerable<Posts> GetAllPosts()
    {
        return _db.Posts
            .Include(b => b.userList)
            .OrderByDescending(u => u.lastModified)
            .ToList();
    }
    
    public Posts FindPostById(Guid id)
    {
        var userById = _db.Posts.Find(id);
        return userById ;
    }

    public IEnumerable<Posts> GetAllPostsByDateCreated()
    {
        return _db.Posts
            .Include(b => b.userList)
            .OrderByDescending(u => u.dateCreated)
            .ToList();
    }

    public IEnumerable<Posts> GetAllPostsByClub(Guid id)
    {
        var list = _db.Posts
            .Include(b => b.userList)
            .Where(b => b.clubList.id == id)
            .OrderByDescending(u => u.dateCreated)
            .ToList();
        
        return list ;
    }

    public IEnumerable<Posts> GetAllPostsByBook(Guid id)
    {
        // var list = _db.Posts
        //     .Where(b => b.bookList.id == id)
        //     .ToList();
        //
        return null ;
    }

    public IEnumerable<Posts> GetAllPostsByUser(Guid id)
    {
        var list = _db.Posts
            .Where(b => b.userList.id == id)
            .ToList();
        
        return list ;
    }
}