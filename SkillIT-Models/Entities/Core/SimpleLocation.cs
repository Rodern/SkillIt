using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("simple_location")]
public class SimpleLocation
{
    [Key]
    [Column("locationId")]
    public int LocationId { get; set; }

    [Required]
    [MaxLength(15)]
    [Column("longitude")]
    public string Longitude { get; set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    [Column("latitude")]
    public string Latitude { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("description")]
    public string Description { get; set; } = string.Empty;
}
