using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillIT_Models.Entities.Core;

[Table("news_letter")]
public class NewsLetter
{
    [Key]
    [Column("news_letterId")]
    public long NewsLetterId { get; set; }

    [Required]
    [MaxLength(36)]
    [Column("guid")]
    public string Guid { get; set; } = string.Empty;

    [Required]
    [Column("letter_body", TypeName = "longtext")]
    public string LetterBody { get; set; } = string.Empty;

    [Required]
    [Column("letter_type")]
    public NewsLetterType LetterType { get; set; }

    [Required]
    [Column("schedule_date")]
    public DateTime ScheduleDate { get; set; }

    [Required]
    [Column("status")]
    public NewsLetterStatus Status { get; set; }

    [Required]
    [Column("date_created")]
    public DateTime DateCreated { get; set; }

    // Navigation properties
    public virtual ICollection<NewsLetterSubscriber> Subscribers { get; set; } = new List<NewsLetterSubscriber>();
}

public enum NewsLetterType
{
    Informational,
    Updates,
    Promotional,
    Social
}

public enum NewsLetterStatus
{
    Cancelled,
    NotSent,
    Sent,
    Pending
}

[Table("news_letter_subscriber")]
public class NewsLetterSubscriber
{
    [Key]
    [Column("news_letter_subscriberId")]
    public int NewsLetterSubscriberId { get; set; }

    [Required]
    [Column("emailId")]
    public long EmailId { get; set; }

    [Required]
    [MaxLength(8)]
    [Column("subscriber_code")]
    public string SubscriberCode { get; set; } = string.Empty;

    [Required]
    [Column("date_subscribed")]
    public DateTime DateSubscribed { get; set; }

    // Navigation properties
    [ForeignKey(nameof(EmailId))]
    public virtual Email Email { get; set; } = null!;
}
