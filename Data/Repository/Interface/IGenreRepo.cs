using Models;

namespace Data.Repository.Interface;

public interface IGenreRepo
{
    void Add(Genre genre);
    
    void Update(Genre genre);
    
    void Delete(Guid id);
    
    Genre FindGenreById(Guid id);
    
    IEnumerable<Genre> GetAllGenres();
}