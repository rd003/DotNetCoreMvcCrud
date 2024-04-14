using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreMvcCrud.Data.Models;

[Table("Person")]
public class Person
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Address { get; set; }
}
