using System.ComponentModel.DataAnnotations;

namespace Models;

public class BaseEntity
{
    [Key]
    
    public Guid id { get; set; }
    
    public DateTime lastModified { get; set; }
}