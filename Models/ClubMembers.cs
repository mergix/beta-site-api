namespace Models;

public class ClubMembers:BaseEntity
{
    public bool isAdmin { get; set; }
    public Clubs club { get; set; }
    public Users user { get; set; }
    
}