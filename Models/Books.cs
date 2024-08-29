namespace Models;

public class Books:BaseEntity
{
    public int title { get; set; }
    
    public string description { get; set; }
    
    public Genre genreList { get; set; }
    
    public byte? [] Image {get; set; }
}