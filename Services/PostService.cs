using Data.Repository.Interface;
using Models;

namespace Services;




public interface IPostService
{
    public  Task<Posts> CreatePost(Posts model);
    
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
    
    public PostService(IPostRepo postRepository) 
    { 
        
        _postRepository = postRepository;

    }
    public async Task<Posts> CreatePost(Posts model)
    {
        var newPost = new Posts()
        {
            id = Guid.NewGuid(),
            body = model.body,
            userList = model.userList,
            clubList = model.clubList,
            bookList = model.bookList ,
            dateCreated = DateTime.UtcNow,
            lastModified = DateTime.UtcNow
        };
        _postRepository.Add(newPost);
        return newPost ;
    }

    public void UpdatePost(Posts obj)
    {
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