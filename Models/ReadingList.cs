namespace Models;


public enum status
{
    reading = 0,
    completed =1,
    planning=2
}
public class ReadingList:BaseEntity
{
    public status? status { get; set; }
    
    public Books bookList { get; set; }
    
    public Users user { get; set; }
}