using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class BookRepo: IBookRepo
{
    
    private readonly AppDbContext _db;
    
    public void Add(Books book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();
    }

    public void Update(Books book)
    {
        _db.Entry(book).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public void Delete(Guid id)
    {
        var delete =  _db.Books.Find(id);
        _db.Books.Remove(delete);
        _db.SaveChangesAsync();
    }
    
    public Books FindBookById(Guid id)
    {
        var userById = _db.Books.Find(id);
        return userById ;
    }

    public IEnumerable<Books> GetAllBooks()
    {
        return _db.Books.OrderByDescending(u => u.lastModified).ToList();
    }
}