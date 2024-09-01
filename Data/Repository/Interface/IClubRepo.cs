using Models;

namespace Data.Repository.Interface;

public interface IClubRepo
{
    void Add(Clubs club);
    
    void Update(Clubs club);
    
    void Delete(Guid id);
    
    Clubs FindClubById(Guid id);
    
    IEnumerable<Clubs> GetAllClubs();
    
    IEnumerable<Clubs> GetAllUsersByClub(Guid id);
}