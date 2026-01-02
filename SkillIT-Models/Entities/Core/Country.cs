using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("country")]
public class Country : BaseEntity
{
    [Column("countryId")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(2)]
    [Column("iso2")]
    public string Iso2 { get; set; } = string.Empty;

    [Column("phoneCode")]
    public int PhoneCode { get; set; }

    [MaxLength(5)]
    [Column("currency_symbol")]
    public string CurrencySymbol { get; set; } = string.Empty;

    [MaxLength(100)]
    [Column("capital")]
    public string Capital { get; set; } = string.Empty;

    [MaxLength(3)]
    [Column("currency")]
    public string Currency { get; set; } = string.Empty;

    [MaxLength(50)]
    [Column("region")]
    public string Region { get; set; } = string.Empty;

    [MaxLength(2)]
    [Column("subregion")]
    public string Subregion { get; set; } = string.Empty;

    [MaxLength(3)]
    [Column("iso3")]
    public string Iso3 { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();
}

[Table("language")]
public class Language : BaseEntity
{
    [Column("languageId")]
    public override long Id { get; set; }

    [Column("countryId")]
    public long? CountryId { get; set; }  // Changed from int? to long?

    [Required]
    [MaxLength(15)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey(nameof(CountryId))]
    public virtual Country? Country { get; set; }
}
