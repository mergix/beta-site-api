namespace Models;

public class Posts:BaseEntity
{
    public string subject { get; set; }
    public string body { get; set; }
    
    public Users userList { get; set; }
    
    public Clubs clubList { get; set; }
    
    public int? bookid { get; set; }
}