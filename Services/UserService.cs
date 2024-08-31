namespace Services;

using Microsoft.EntityFrameworkCore;


public interface IUserService
{
    public  Task<> CreateUser(Users model);
    
    public void UpdateUser(Users user);

    public void DeleteUser(Guid id);
    
    public  Task<IEnumerable<User>> GetUserList();

    public  Task<User> GetUserById(Guid id);

    public  User emailExists(string email);

    public  Task<UserResponseDTO> Login(LoginRequestDTO user);
    //
    // public  Task<UserResponseDTO> LoginAdmin(LoginRequestDTO user);

    // public  Task<UserResponseDTO> CreateAdmin(RegisterRequestDTO model);

    
    // public dynamic CreateToken(LoginRequestDTO user);
    //
    // public JwtSecurityToken Verify(string jwt);
}

public class UserService :IUserService
{
    
}