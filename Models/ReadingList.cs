namespace Models;


public enum status
{
    reading = 0,
    completed =1,
    planning=2,
    dropped=3
}
public class ReadingList:BaseEntity
{
    public status? status { get; set; }
    
    public int bookid { get; set; }
    
    public Users user { get; set; }
}