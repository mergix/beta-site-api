namespace Models;

public class ClubMembers:BaseEntity
{
    public bool isAdmin { get; set; }
    public Guid clubId { get; set; }
    public Guid userId { get; set; }
    
}