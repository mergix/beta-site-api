using Data.Repository.Interface;
using Models;
using Models.DTO_s;

namespace Services;


public interface IClubService
{
    public  Task<Clubs> CreateClubs(clubCreate model);
    
    public void UpdateClubs(Clubs user);

    public void DeleteClubs(Guid id);
    public  Task<Clubs> GetClubById(Guid id);
    
    public  Task<IEnumerable<Clubs>> GetAllClubs();
    
    public  Task<IEnumerable<Clubs>> SearchClubs(string param);
    
    public  List<Clubs> GetRandomClubs();
    
    public  Task<ClubMembers> AddClubMember(createMember mem);
    
    public void UpdateClubMemeber(ClubMembers mem);

    public void DeleteClubMember(Guid userid , Guid clubid);
    
    public  Task<IEnumerable<ClubMembers>> GetAllUsersByClubId(Guid id);
    
    public  Task<IEnumerable<ClubMembers>> GetAllClubsByUserId(Guid id);
    

    

    
}
public class ClubService :IClubService
{
    
    private readonly IClubRepo _clubRepository;
    private readonly IUserRepo _userRepository;
    private IClubService _clubServiceImplementation;

    public ClubService(IClubRepo clubRepository, IUserRepo userRepository) 
    { 
        
        _clubRepository = clubRepository;
        _userRepository = userRepository;

    }
    public async Task<Clubs> CreateClubs(clubCreate model)
    {
        var newClub = new Clubs()
        {
            id = Guid.NewGuid(),
            name = model.name,
            description = model.description,
            status = clubState.Open,
            Image = null,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow,
        };
        _clubRepository.Add(newClub);
        return newClub ;
    }

    public void UpdateClubs(Clubs model)
    {
        
        var newClub = new Clubs()
        {
            id = Guid.NewGuid(),
            name = model.name,
            description = model.description,
            status = model.status,
            Image = model.Image,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow,
        };
        _clubRepository.Update(newClub);
    }

    public void DeleteClubs(Guid id)
    {
        _clubRepository.Delete(id);
    }

    public async Task<IEnumerable<Clubs>> GetAllClubs()
    {
        return _clubRepository.GetAllClubs();
    }

    public Task<IEnumerable<Clubs>> SearchClubs(string param)
    {
        throw new NotImplementedException();
    }


    public List<Clubs> GetRandomClubs()
    {

        var clubs = _clubRepository.GetAllClubs();
        
            List<Clubs> clubsList = new List<Clubs>();
            List<int> intList = new List<int>();

            if (clubs.Count() == 0)
            {
                return null;
            }
                var r = new Random();
            for (int i = 0; i < 3; i++)
            {
                var g = r.Next(0, clubs.Count());
                if (!intList.Contains(g))
                {
                    intList.Add(g);
                    clubsList.Add(clubs.ElementAt(g));
                }else if (intList.Contains(g))
                {
                    i--;
                }
            }

            return clubsList;
    }

    public async Task<ClubMembers> AddClubMember(createMember mem)
    {
        var newClub = new ClubMembers()
        {
            id = Guid.NewGuid(),
            club = _clubRepository.FindClubById(mem.clubId),
            user = _userRepository.FindUserById(mem.userId),
            isAdmin = true,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow,
        };
        _clubRepository.AddUserToClub(newClub);
        return newClub ;    
    }
    

    public void UpdateClubMemeber(ClubMembers mem)
    {
               
        var newClub = new ClubMembers()
        {
            id = Guid.NewGuid(),
            club = _clubRepository.FindClubById(mem.club.id),
            user = _userRepository.FindUserById(mem.user.id),
            isAdmin = true,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow,
        };

        _clubRepository.UpdateClubMember(newClub);
    }

    public void DeleteClubMember(Guid userid, Guid clubid)
    {
        _clubRepository.DeleteClubMemeber(userid, clubid);
    }

    public async Task<IEnumerable<ClubMembers>> GetAllUsersByClubId(Guid id)
    {
        return _clubRepository.GetAllUsersByClubId(id);
    }

    public async Task<IEnumerable<ClubMembers>> GetAllClubsByUserId(Guid id)
    {
        return _clubRepository.GetAllClubsByUserId(id);
    }
    

    public async Task<Clubs> GetClubById(Guid id)
    {
        return _clubRepository.FindClubById(id);
    }
}