using Models;

namespace Data.Repository.Interface;

public interface IBookRepo
{
    void Add(Books post);
    
    void Update(Books post);
    
    void Delete(Guid id);
    
    Books FindBookById(Guid id);
    
    IEnumerable<Books> GetAllBooks();
}