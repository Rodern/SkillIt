using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Learning;

namespace SkillIT_Models.Entities.Courses;

[Table("course_chapter")]
public class CourseChapter : AuditableEntity
{
    [Column("chapterID")]
    public override long Id { get; set; }

    [Required]
    [Column("courseID")]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(36)]
    [Column("guid")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    [Required]
    [MaxLength(250)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    [Column("authorID")]
    public long? AuthorId { get; set; }

    [Required]
    [Column("chapter_number")]
    public int ChapterNumber { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey(nameof(AuthorId))]
    public virtual Creator? Author { get; set; }

    public virtual ICollection<CourseLesson> Lessons { get; set; } = new List<CourseLesson>();
    public virtual ICollection<ChapterQuiz> ChapterQuizzes { get; set; } = new List<ChapterQuiz>();
}

[Table("course_lesson")]
public class CourseLesson : AuditableEntity
{
    [Column("lessonID")]
    public override long Id { get; set; }

    [Required]
    [MaxLength(250)]
    [Column("topic")]
    public string Topic { get; set; } = string.Empty;

    [Required]
    [Column("chapterID")]
    public int ChapterId { get; set; }

    [Required]
    [MaxLength(36)]
    [Column("guid")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    [Column("authorID")]
    public long? AuthorId { get; set; }

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    [Required]
    [Column("lesson_number")]
    public int LessonNumber { get; set; }

    // Navigation properties
    [ForeignKey(nameof(ChapterId))]
    public virtual CourseChapter Chapter { get; set; } = null!;

    [ForeignKey(nameof(AuthorId))]
    public virtual Creator? Author { get; set; }

    public virtual ICollection<CourseContent> Contents { get; set; } = new List<CourseContent>();
}

[Table("course_content")]
public class CourseContent : AuditableEntity
{
    [Column("contentID")]
    public override long Id { get; set; }

    [Required]
    [Column("lessonID")]
    public int LessonId { get; set; }

    [Required]
    [MaxLength(36)]
    [Column("guid")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    [Column("authorID")]
    public long? AuthorId { get; set; }

    [Required]
    [Column("content_number")]
    public int ContentNumber { get; set; }

    [Required]
    [MaxLength(250)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [MaxLength(2083)] // Max URL length
    [Column("video_link")]
    public string VideoLink { get; set; } = string.Empty;

    [Column("content", TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("last_modified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    [MaxLength(250)]
    [Column("note")]
    public string Note { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey(nameof(LessonId))]
    public virtual CourseLesson Lesson { get; set; } = null!;

    [ForeignKey(nameof(AuthorId))]
    public virtual Creator? Author { get; set; }
}
