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
        var userById = _db.ReadingList
            .Where(c => c.user.id == id).First();
        return userById ;
    }



    public void AddBookToList(Guid id,int bookid)
    {
        var tt =  _db.ReadingList.Find(id);
        // var gg =_db..FirstOrDefault(x => x.Id == deleteBooking.room.Id);
        
        // tt.bookList = status.completed;
        // _db.ReadingList.Remove(deleteBooking);
        _db.SaveChanges();
    }

    public void ChangeStatus()
    {
        throw new NotImplementedException();
    }
}