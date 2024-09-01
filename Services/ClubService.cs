using Data.Repository.Interface;
using Models;

namespace Services;


public interface IClubService
{
    public  Task<Clubs> CreateClubs(Clubs model);
    
    public void UpdateClubs(Clubs user);

    public void DeleteClubs(Guid id);
    
    public  Task<IEnumerable<Clubs>> GetAllClubs();
    
    
    public  Task<Clubs> GetClubsById(Guid id);
    
}
public class ClubService :IClubService
{
    
    private readonly IClubRepo _clubRepository;
    
    public ClubService(IClubRepo clubRepository) 
    { 
        
        _clubRepository = clubRepository;

    }
    public async Task<Clubs> CreateClubs(Clubs model)
    {
        var newClub = new Clubs()
        {
            id = Guid.NewGuid(),
            name = model.name,
            description = model.description,
            status = model.status,
            Image = model.Image,
            userList = model.userList,
            genreList = model.genreList,
            adminUserList = model.adminUserList,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow,
        };
        _clubRepository.Add(newClub);
        return newClub ;
    }

    public void UpdateClubs(Clubs user)
    {
        _clubRepository.Update(user);
    }

    public void DeleteClubs(Guid id)
    {
        _clubRepository.Delete(id);
    }

    public async Task<IEnumerable<Clubs>> GetAllClubs()
    {
        return _clubRepository.GetAllClubs();
    }

    public async Task<Clubs> GetClubsById(Guid id)
    {
        return _clubRepository.FindClubById(id);
    }
}