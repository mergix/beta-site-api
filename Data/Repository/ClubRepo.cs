using Data.Repository.Interface;
using Models;

namespace Data.Repository;

public class ClubRepo: IClubRepo
{
    
    private readonly AppDbContext _db;
    
    public void Add(Clubs club)
    {
        throw new NotImplementedException();
    }

    public void Update(Clubs club)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Clubs> GetAllClubs()
    {
        throw new NotImplementedException();
    }
}