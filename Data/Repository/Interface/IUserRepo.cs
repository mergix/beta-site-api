using Models;

namespace Data.Repository.Interface;

public interface IUserRepo
{
    void Add(Users user);
    void Update(Users user);
    IEnumerable<Users> GetAllByDateModified();
    Users FindUserById(Guid id);
    Users checkEmail(string email);
    
    Users LoginUser(string email,string password);

    Users LoginAdmin(string email, string password);

    void Delete(Guid id);
}