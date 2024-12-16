using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;


public static class EnumerableExtensions
{
    public static T Random<T>(this IEnumerable<T> enumerable)
    {
        var r = new Random();
        var list = enumerable as IList<T> ?? enumerable.ToList();
        return list.ElementAt(r.Next(0, list.Count()));
    }
}
public class ClubRepo: IClubRepo
{
    private readonly AppDbContext _db;
    
    public ClubRepo(AppDbContext context) 
    { 
        _db = context;
    }
    
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
    
    public Clubs FindClubById(Guid id)
    {
        var userById = _db.Clubs.Find(id);
        return userById ;
    }

    public IEnumerable<Clubs> GetAllClubs()
    {
        return _db.Clubs.OrderByDescending(u => u.lastModified).ToList();
    }
    
    public IEnumerable<Clubs> SearchClubs( string param)
    {
        return null;
    }
    
    public void AddUserToClub(ClubMembers mem)
    {
        // var tt =  _db.Clubs.Find(clubid);
        // var uu = _db.Users.Find(userid);
        
        // var newBooking = new ClubMembers()
        // {
        //     id = Guid.NewGuid(),
        //     user = us.FindByUserId(model.Userid),
        //     club = _roomRepository.getRoomById(model.Roomid),
        //     isAdmin = true,
        //     dateCreated = DateTime.Now,
        //     lastModified = DateTime.UtcNow
        // };

        _db.ClubMembers.Add(mem);
        _db.SaveChanges();
    }

    public void UpdateClubMember(ClubMembers mem)
    {
        _db.Entry(mem).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public void DeleteClubMemeber(Guid userid , Guid clubid)
    {


        var delete = _db.ClubMembers
            .Where(c => c.club.id == clubid)
            .Where(c => c.user.id == userid)
            .FirstOrDefault()
            ;
        _db.ClubMembers.Remove(delete);
        _db.SaveChangesAsync();
    }
    
    public IEnumerable<ClubMembers> GetAllUsersByClubId(Guid clubid)
    {
        
        var club = _db.ClubMembers
            .Include(c => c.user)
            .Where(b => b.club.id == clubid)
            .ToList();
        
        return club;
    }
    
    public IEnumerable<ClubMembers> GetAllClubsByUserId(Guid userid)
    {
        
        var club = _db.ClubMembers
            .Include(c => c.club)
            .Where(b => b.user.id == userid)
            .ToList();
        
        return club;
    }
    

}