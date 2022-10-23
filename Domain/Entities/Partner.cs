using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Partner
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required, MaxLength(100)]
    public string? Description { get; set; }
}