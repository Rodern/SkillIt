using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("role")]
public class Role : BaseEntity
{
    [Column("roleID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<Creator> Creators { get; set; } = new List<Creator>();
}
