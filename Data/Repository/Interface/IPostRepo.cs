using Models;

namespace Data.Repository.Interface;

public interface IPostRepo
{
    void Add(Posts post);
    
    void Update(Posts post);
    
    void Delete(Guid id);
    
    IEnumerable<Posts> GetAllPosts();
    
    IEnumerable<Posts> GetAllPostsByDateCreated();
    
    
    IEnumerable<Posts> GetAllPostsByClub(Guid id);
    
    IEnumerable<Posts> GetAllPostsByBook(Guid id);
    
    IEnumerable<Posts> GetAllPostsByUser(Guid id);
    
    
}