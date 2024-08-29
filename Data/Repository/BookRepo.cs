using Data.Repository.Interface;
using Models;

namespace Data.Repository;

public class BookRepo: IBookRepo
{
    
    private readonly AppDbContext _db;
    
    public void Add(Books post)
    {
        throw new NotImplementedException();
    }

    public void Update(Books post)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Books> GetAllBooks()
    {
        throw new NotImplementedException();
    }
}