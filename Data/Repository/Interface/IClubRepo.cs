using Models;

namespace Data.Repository.Interface;

public interface IClubRepo
{
    void Add(Clubs club);
    
    void Update(Clubs club);
    
    void Delete(Guid id);
    
    IEnumerable<Clubs> GetAllClubs();
}