using Data.Repository.Interface;
using Models;

namespace Services;


public interface IBookService
{
    public  Task<Books> CreateBook(Books model);
    
    public void UpdateBook(Books user);

    public void DeleteBook(Guid id);
    
    public  Task<IEnumerable<Books>> GetAllBooks();
    
    
    public  Task<Books> GetBookById(Guid id);
    
}
public class BookService :IBookService
{
    
    private readonly IBookRepo _bookRepository;
    
    public BookService(IBookRepo bookRepository) 
    { 
        
        _bookRepository = bookRepository;

    }
    public async Task<Books> CreateBook(Books model)
    {
        var newBook = new Books()
        {
            id = Guid.NewGuid(),
            title = model.title,
            description = model.description,
            genreList = model.genreList,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow
        };
        _bookRepository.Add(newBook);
        return newBook ;
    }

    public void UpdateBook(Books user)
    {
        _bookRepository.Update(user);
    }

    public void DeleteBook(Guid id)
    {
        _bookRepository.Delete(id);
    }

    public async Task<IEnumerable<Books>> GetAllBooks()
    {
        return _bookRepository.GetAllBooks();
    }

    public async Task<Books> GetBookById(Guid id)
    {
        return _bookRepository.FindBookById(id);
    }
}