using Microsoft.Extensions.Configuration;
using Models;
using Data.Repository.Interface;
using Models.DTO_s;

namespace Services;


public interface IUserService
{
    public  Task<Users> CreateUser(Users model);
    
    public void UpdateUser(Users user);

    public void DeleteUser(Guid id);
    
    public  Task<IEnumerable<Users>> GetUserList();
    


    public  Task<Users> GetUserById(Guid id);

    public  Users emailExists(string email);

    public  Task<LoginDTO> Login(LoginDTO user);
    
    
    // public  Task<UserResponseDTO> LoginAdmin(LoginRequestDTO user);

    // public  Task<UserResponseDTO> CreateAdmin(RegisterRequestDTO model);

    
    // public dynamic CreateToken(LoginRequestDTO user);
    //
    // public JwtSecurityToken Verify(string jwt);
}

public class UserService :IUserService
{
    private readonly IUserRepo _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IPasswordService _passwordHasher;
    public UserService(IUserRepo userRepository,IConfiguration configuration,IPasswordService passwordHasher)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
    }
    public async Task<Users> CreateUser(Users model)
    {
        var existingUser = _userRepository.checkEmail(model.email);
        
        var passwordhash = _passwordHasher.Hash(model.passwordHash);

        var ms = "fff";

        var newUser = new Users()
        {
            id = Guid.NewGuid(),
            firstName = model.firstName,
            lastName = model.lastName,
            email = model.email,
            passwordHash = passwordhash,
            profileImage = model.profileImage,
            address = model.address,
            phoneNo = model.phoneNo,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow
        };
        
        if (existingUser != null)
        {
            return null;
        }
        
        _userRepository.Add(newUser); 
        


        var viewModel = new LoginDTO()
        {
            UserId = newUser.id,
            UserEmail = newUser.email
        };

        return newUser;
    }

    public void UpdateUser(Users user)
    {
        _userRepository.Update(user);
    }

    public void DeleteUser(Guid id)
    {
        _userRepository.Delete(id);
    }

    public async Task<IEnumerable<Users>> GetUserList()
    {
        var userlist =  _userRepository.GetAllByDateCreated();
        
        
        return userlist;
    }



    public async Task<Users> GetUserById(Guid id)
    {
        return _userRepository.FindUserById(id);
    }

    public Users emailExists(string email)
    {
        return _userRepository.checkEmail(email);
    }

    public async Task<LoginDTO> Login(LoginDTO user)
    {
        var existingUser =  _userRepository.checkEmail(user.UserEmail);
        var result = _passwordHasher.Verify(existingUser.passwordHash,user.UserPassword);


        if (existingUser == null)
        {
            var noUser = new LoginDTO()
            {
                UserEmail = "No User"
            };

            return noUser;
        }

        if (result == false)
        {
            var wrongpwd = new LoginDTO()
            {
                UserEmail = "Invalid password"
            };

            return wrongpwd;
        }
        
        
        var viewModel = new LoginDTO()
        {
            UserId = existingUser.id,
            UserEmail = existingUser.email,
        };
        

        return viewModel;
    }
}