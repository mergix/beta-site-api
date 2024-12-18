using Data.Repository.Interface;
using Models;
using Models.DTO_s;

namespace Services;




public interface IPostService
{
    public  Task<Posts> CreatePost(createPost model);
    
    public void UpdatePost(Posts user);

    public void DeletePost(Guid id);
    
    public  Task<IEnumerable<Posts>> GetAllPosts();
    
    public  Task<IEnumerable<Posts>> GetAllPostByClub(Guid id);
    public  Task<IEnumerable<Posts>> GetAllPostByBook(Guid id);
    
    public  Task<IEnumerable<Posts>> GetAllPostByUser(Guid id);

    public  Task<Posts> GetPostById(Guid id);
    
}
public class PostService :IPostService
{
    private readonly IPostRepo _postRepository;
    private readonly IClubRepo _clubRepository;
    private readonly IUserRepo _userRepository;
    
    public PostService(IPostRepo postRepository,IClubRepo clubRepository, IUserRepo userRepository) 
    { 
        
        _postRepository = postRepository;
        _clubRepository = clubRepository;
        _userRepository = userRepository;

    }
    public async Task<Posts> CreatePost(createPost model)
    {
        var newPost = new Posts()
        {
            id = Guid.NewGuid(),
            subject = model.subject,
            body = model.body,
            clubList = _clubRepository.FindClubById(model.clubid),
            userList = _userRepository.FindUserById(model.userid),
            bookid = model.bookid ,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow
        };
        _postRepository.Add(newPost);
        return newPost ;
    }

    public void UpdatePost(Posts obj)
    {
        var newPost = new Posts()
        {
            id = Guid.NewGuid(),
            body = obj.body,
            userList = obj.userList,
            clubList = obj.clubList,
            bookid = obj.bookid ,
            dateCreated = obj.dateCreated,
            lastModified = DateTime.UtcNow
        };
        
        _postRepository.Update(obj);
    }

    public void DeletePost(Guid id)
    {
        _postRepository.Delete(id);
    }

    public async Task<IEnumerable<Posts>> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public async Task<IEnumerable<Posts>> GetAllPostByClub(Guid id)
    {
        return _postRepository.GetAllPostsByClub(id);
    }

    public async Task<IEnumerable<Posts>> GetAllPostByBook(Guid id)
    {
         return _postRepository.GetAllPostsByBook(id);
    }
    
    public async Task<IEnumerable<Posts>> GetAllPostByUser(Guid id)
    {
        return _postRepository.GetAllPostsByUser(id);
    }

    public async Task<Posts> GetPostById(Guid id)
    {
        return _postRepository.FindPostById(id);
    }
}