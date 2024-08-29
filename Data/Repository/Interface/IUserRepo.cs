using Models;

namespace Data.Repository.Interface;

public interface IUserRepo
{
    void Add(Users user);
    void Update(Users user);
    void Delete(Guid id);
    IEnumerable<Users> GetAllByDateCreated();
    
    IEnumerable<Users> GetAllByDateLastModified();
    Users FindUserById(Guid id);
    Users checkEmail(string email);
    
    Users LoginUser(string email,string password);

    // Users LoginAdmin(string email, string password);


}