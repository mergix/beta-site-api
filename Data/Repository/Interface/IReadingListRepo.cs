using Models;

namespace Data.Repository.Interface;

public interface IReadingListRepo 
{
    void Add(ReadingList read);
    
    void Update(ReadingList read);
    
    void Delete(Guid id);
    
    ReadingList GetReadingListByUserId(Guid id);

    void AddBookToList(Guid id,int bookid);
    
    void ChangeStatus();

}