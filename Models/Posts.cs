namespace Models;

public class Posts:BaseEntity
{
    public string body { get; set; }
    
    public Users userList { get; set; }
    
    public Clubs clubList { get; set; }
    
    public int bookid { get; set; }
}