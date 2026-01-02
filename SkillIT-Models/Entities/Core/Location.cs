using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("city")]
public class City : BaseEntity
{
    [Column("cityId")]
    public override long Id { get; set; }

    [Required]
    [Column("countryId")]
    public long CountryId { get; set; }

    [Required]
    [MaxLength(36)]
    [Column("guid")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    [Required]
    [MaxLength(250)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("latitude")]
    public double Latitude { get; set; }

    [Required]
    [Column("longitude")]
    public double Longitude { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<UserCity> UserCities { get; set; } = new List<UserCity>();
}

[Table("region")]
public class Region : BaseEntity
{
    [Column("regionId")]
    public override long Id { get; set; }

    [Required]
    [Column("countryId")]
    public long CountryId { get; set; }

    [Required]
    [MaxLength(36)]
    [Column("guid")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(5)]
    [Column("short_code")]
    public string ShortCode { get; set; } = string.Empty;

    [Required]
    [Column("capital_city")]
    public long CapitalCityId { get; set; }

    [Required]
    [MaxLength(11)]
    [Column("latitude")]
    public string Latitude { get; set; } = string.Empty;

    [Required]
    [MaxLength(11)]
    [Column("longitude")]
    public string Longitude { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<UserRegion> UserRegions { get; set; } = new List<UserRegion>();
}

// Many-to-Many: User <-> City
[Table("user_city")]
public class UserCity : BaseEntity
{
    [Column("user_cityId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [Column("cityId")]
    public long CityId { get; set; }

    [Column("date_set")]
    public DateTime DateSet { get; set; } = DateTime.UtcNow;

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(CityId))]
    public virtual City City { get; set; } = null!;
}

// Many-to-Many: User <-> Country
[Table("user_country")]
public class UserCountry : BaseEntity
{
    [Column("user_countryId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [Column("countryId")]
    public long CountryId { get; set; }

    [Column("date_set")]
    public DateTime DateSet { get; set; } = DateTime.UtcNow;

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; } = null!;
}

// Many-to-Many: User <-> Region
[Table("user_region")]
public class UserRegion : BaseEntity
{
    [Column("user_regionId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [Column("regionId")]
    public long RegionId { get; set; }

    [Column("date_set")]
    public DateTime DateSet { get; set; } = DateTime.UtcNow;

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(RegionId))]
    public virtual Region Region { get; set; } = null!;
}

[Table("user_token")]
public class UserToken : BaseEntity
{
    [Column("user_tokenId")]
    public override long Id { get; set; }

    [Required]
    [Column("userId")]
    public long UserId { get; set; }

    [Required]
    [MaxLength(500)]
    [Column("token")]
    public string Token { get; set; } = string.Empty;

    [Required]
    [Column("expiry_date")]
    public DateTime ExpiryDate { get; set; }

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime? LastModified { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
