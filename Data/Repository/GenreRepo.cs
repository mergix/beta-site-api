using Data.Repository.Interface;
using Models;

namespace Data.Repository;

public class GenreRepo :IGenreRepo
{
    
    private readonly AppDbContext _db;
    
    public void Add(Genre genre)
    {
        throw new NotImplementedException();
    }

    public void Update(Genre genre)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        throw new NotImplementedException();
    }
}