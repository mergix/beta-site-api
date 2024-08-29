namespace Models;


public enum Role
{
    user = 0,
    admin = 1
}

public enum Gender
{
    male = 0,
    female =1
}
public class Users:BaseEntity
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash  { get; set; } 
    public Gender? gender { get; set; }
    public byte? [] profileImage {get; set; }
    public string? address { get; set; }
    public Int64? phoneNo { get; set; }
}