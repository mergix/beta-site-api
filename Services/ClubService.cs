using Data.Repository.Interface;
using Models;

namespace Services;


public interface IClubService
{
    public  Task<Clubs> CreateClubs(Clubs model);
    
    public void UpdateClubs(Clubs user);

    public void DeleteClubs(Guid id);
    
    public  Task<IEnumerable<Clubs>> GetAllClubs();
    
    public  Task<IEnumerable<Clubs>> GetRandomClubs();
    
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

    public Task<IEnumerable<Clubs>> GetRandomClubs()
    {

        var clubs = _clubRepository.GetAllClubs();
        
            List<Clubs> clubsList = new List<Clubs>();

        
            for (int i = 0; i < 5; i++)
            {
                var r = new Random();
                clubsList.Add(clubs.ElementAt(r.Next(0, clubs.Count())));
            
            }

            return clubsList;
    }

    public Task<Clubs> GetClubsById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Clubs>> GetAllClubsByUserId(Users user)
    {
        return _clubRepository.GetAllClubs();
    }

    public async Task<Clubs> GetClubById(Guid id)
    {
        return _clubRepository.FindClubById(id);
    }
}