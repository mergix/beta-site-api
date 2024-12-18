namespace Models;


public enum Gender
{
    male = 0,
    female =1
}
public class Users:BaseEntity
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string passwordHash  { get; set; } 
    
    public Gender? gender { get; set; }
    public byte? []? profileImage {get; set; }
    public string? address { get; set; }
    public Int64? phoneNo { get; set; }
}