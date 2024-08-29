using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class ClubRepo: IClubRepo
{
    
    private readonly AppDbContext _db;
    
    public void Add(Clubs club)
    {
        _db.Clubs.Add(club);
        _db.SaveChanges();
    }

    public void Update(Clubs club)
    {
        _db.Entry(club).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public void Delete(Guid id)
    {
        var delete =  _db.Clubs.Find(id);
        _db.Clubs.Remove(delete);
        _db.SaveChangesAsync();
    }

    public IEnumerable<Clubs> GetAllClubs()
    {
        return _db.Clubs.OrderByDescending(u => u.lastModified).ToList();
    }
}