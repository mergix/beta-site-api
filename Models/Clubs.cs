namespace Models;


public enum clubState
{
    Open = 0, 
    Request = 1
}
public class Clubs:BaseEntity
{
    public string name { get; set; }
    
    public string description { get; set; }
    
    public Genre genreList { get; set; }
    
    public byte? [] Image {get; set; }
    
    public  clubState status { get; set; }
}