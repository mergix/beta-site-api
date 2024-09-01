using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class GenreRepo :IGenreRepo
{
    
    private readonly AppDbContext _db;
    
    public void Add(Genre genre)
    {
        _db.Genres.Add(genre);
        _db.SaveChanges();
    }

    public void Update(Genre genre)
    {
        _db.Entry(genre).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public void Delete(Guid id)
    {
        var delete =  _db.Genres.Find(id);
        _db.Genres.Remove(delete);
        _db.SaveChangesAsync();
    }
    
    public Genre FindGenreById(Guid id)
    {
        var userById = _db.Genres.Find(id);
        return userById ;
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        return _db.Genres.OrderByDescending(u => u.lastModified).ToList();
    }
}