using Data.Repository.Interface;
using Models;

namespace Services;




public interface IGenreService
{
    public  Task<Genre> CreateGenre(Genre model);
    
    public void UpdateGenre(Genre user);

    public void DeleteGenre(Guid id);
    
    public  Task<IEnumerable<Genre>> GetAllGenres();
    
    
    public  Task<Genre> GetGenreById(Guid id);
    
}
public class GenreService :IGenreService
{
    
    private readonly IGenreRepo _genreRepository;
    
    public GenreService(IGenreRepo genreRepository) 
    { 
        
        _genreRepository = genreRepository;

    }

    public  async Task<Genre> CreateGenre(Genre model)
    {
        
        var newGenre = new Genre()
        {
            id = Guid.NewGuid(),
            title = model.title,
            description = model.description,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow
        };
        _genreRepository.Add(newGenre);
        return newGenre ;
        
    }

    public void UpdateGenre(Genre obj)
    {
        _genreRepository.Update(obj);
    }

    public void DeleteGenre(Guid id)
    {
        _genreRepository.Delete(id);
    }

    public async Task<IEnumerable<Genre>> GetAllGenres()
    {
        return _genreRepository.GetAllGenres();
    }

    public async Task<Genre> GetGenreById(Guid id)
    {
        return _genreRepository.FindGenreById(id);
    }
}