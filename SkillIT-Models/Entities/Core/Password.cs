using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("password")]
public class Password
{
    [Key]
    [Column("passwordId")]
    public int PasswordId { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [MaxLength(1000)]
    [Column("hashed")]
    public string Hashed { get; set; } = string.Empty;

    [Required]
    [Column("salt", TypeName = "varbinary(128)")]
    public byte[] Salt { get; set; } = Array.Empty<byte>();

    [Required]
    [Column("last_changed")]
    public DateTime LastChanged { get; set; }

    [Required]
    [Column("past_passwords", TypeName = "longtext")]
    public string PastPasswords { get; set; } = "[]"; // JSON array of {Hashed, Salt, DateRemoved}

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
