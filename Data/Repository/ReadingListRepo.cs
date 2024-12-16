using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class ReadingListRepo: IReadingListRepo
{
    
    private readonly AppDbContext _db;
    
    public ReadingListRepo(AppDbContext context) 
    { 
        _db = context;
    }
    public void Add(ReadingList read)
    {
        _db.ReadingList.Add(read);
        _db.SaveChanges();
    }

    public void Update(ReadingList read)
    {
        _db.Entry(read).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public void Delete(Guid id)
    {
        var delete =  _db.ReadingList.Find(id);
        _db.ReadingList.Remove(delete);
        _db.SaveChangesAsync();
    }

    public ReadingList GetReadingListByUserId(Guid id)
    {
        throw new NotImplementedException();
    }

    public void AddBookToList()
    {
        throw new NotImplementedException();
    }

    public void ChangeStatus()
    {
        throw new NotImplementedException();
    }
}