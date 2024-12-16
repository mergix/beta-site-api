using Models;

namespace Data.Repository.Interface;

public interface IClubRepo
{
    void Add(Clubs club);
    
    void Update(Clubs club);
    
    void Delete(Guid id);
    
    Clubs FindClubById(Guid id);
    
    IEnumerable<Clubs> GetAllClubs();

    IEnumerable<Clubs> SearchClubs(string param);

    void AddUserToClub(ClubMembers mem);

    void UpdateClubMember(ClubMembers mem);

    void DeleteClubMemeber(Guid userid, Guid clubid);
    
    IEnumerable<ClubMembers> GetAllUsersByClubId(Guid id);
    
    IEnumerable<ClubMembers> GetAllClubsByUserId(Guid id);
}