namespace Models;

public class Genre:BaseEntity
{
    public string title { get; set; }
    
    public string? description { get; set; }
}