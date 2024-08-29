namespace Models;


public enum clubState
{
    Available = 0, 
    Booked = 1
}
public class Clubs:BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Users userList { get; set; }
    
    public Users adminUserList { get; set; }
    
    public  clubState Status { get; set; }
}