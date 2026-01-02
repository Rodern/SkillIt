using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Courses;

namespace SkillIT_Models.Entities.Learning;

[Table("quiz")]
public class Quiz : BaseEntity
{
    [Column("quizID")]
    public override long Id { get; set; }

    [Column("authorID")]
    public long? AuthorId { get; set; }

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Column("quiz_code")]
    public int? QuizCode { get; set; }

    // Navigation properties
    [ForeignKey(nameof(AuthorId))]
    public virtual Creator? Author { get; set; }

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
    public virtual ICollection<EnrollmentQuiz> EnrollmentQuizzes { get; set; } = new List<EnrollmentQuiz>();
    public virtual ICollection<ChapterQuiz> ChapterQuizzes { get; set; } = new List<ChapterQuiz>();
}

[Table("question")]
public class Question : BaseEntity
{
    [Column("questionID")]
    public override long Id { get; set; }

    [Column("authorID")]
    public long? AuthorId { get; set; }

    [Required]
    [Column("text", TypeName = "text")]
    public string Text { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey(nameof(AuthorId))]
    public virtual Creator? Author { get; set; }

    public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; } = new List<QuestionAnswer>();
    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
    public virtual ICollection<QuestionAnswerResponse> QuestionAnswerResponses { get; set; } = new List<QuestionAnswerResponse>();
}

[Table("question_answer")]
public class QuestionAnswer : BaseEntity
{
    [Column("question_answerID")]
    public override long Id { get; set; }

    [Required]
    [Column("questionID")]
    public long QuestionId { get; set; }

    [Required]
    [Column("answer", TypeName = "text")]
    public string Answer { get; set; } = string.Empty;

    [Column("is_correct")]
    public bool IsCorrect { get; set; } = false;

    // Navigation properties
    [ForeignKey(nameof(QuestionId))]
    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<QuestionAnswerResponse> QuestionAnswerResponses { get; set; } = new List<QuestionAnswerResponse>();
}

[Table("quiz_question")]
public class QuizQuestion : BaseEntity
{
    [Column("quiz_questionID")]
    public override long Id { get; set; }

    [Required]
    [Column("quizID")]
    public long QuizId { get; set; }

    [Required]
    [Column("questionID")]
    public long QuestionId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(QuizId))]
    public virtual Quiz Quiz { get; set; } = null!;

    [ForeignKey(nameof(QuestionId))]
    public virtual Question Question { get; set; } = null!;
}

[Table("chapter_quiz")]
public class ChapterQuiz : BaseEntity
{
    [Column("chapter_quizID")]
    public override long Id { get; set; }

    [Required]
    [Column("quizID")]
    public long QuizId { get; set; }

    [Required]
    [Column("chapterID")]
    public long ChapterId { get; set; }

    [Column("authorID")]
    public long? AuthorId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(QuizId))]
    public virtual Quiz Quiz { get; set; } = null!;

    [ForeignKey(nameof(ChapterId))]
    public virtual CourseChapter Chapter { get; set; } = null!;

    [ForeignKey(nameof(AuthorId))]
    public virtual Creator? Author { get; set; }
}

[Table("enrollment_quiz")]
public class EnrollmentQuiz : BaseEntity
{
    [Column("enrollment_quizID")]
    public override long Id { get; set; }

    [Required]
    [Column("enrollmentID")]
    public long EnrollmentId { get; set; }

    [Required]
    [Column("quizID")]
    public long QuizId { get; set; }

    [Column("date_taken")]
    public DateTime DateTaken { get; set; } = DateTime.UtcNow;

    [Column("passed")]
    public bool Passed { get; set; } = false;

    [Column("points")]
    public int Points { get; set; }

    [Column("time_taken")]
    public float TimeTaken { get; set; }

    // Navigation properties
    [ForeignKey(nameof(EnrollmentId))]
    public virtual Enrollment Enrollment { get; set; } = null!;

    [ForeignKey(nameof(QuizId))]
    public virtual Quiz Quiz { get; set; } = null!;
}

[Table("question_answer_response")]
public class QuestionAnswerResponse : BaseEntity
{
    [Column("question_answer_responseID")]
    public override long Id { get; set; }

    [Required]
    [Column("questionID")]
    public long QuestionId { get; set; }

    [Required]
    [Column("enrollmentID")]
    public long EnrollmentId { get; set; }

    [Required]
    [Column("question_answerID")]
    public long QuestionAnswerId { get; set; }

    [Column("time_answered")]
    public DateTime TimeAnswered { get; set; } = DateTime.UtcNow;

    // Navigation properties
    [ForeignKey(nameof(QuestionId))]
    public virtual Question Question { get; set; } = null!;

    [ForeignKey(nameof(EnrollmentId))]
    public virtual Enrollment Enrollment { get; set; } = null!;

    [ForeignKey(nameof(QuestionAnswerId))]
    public virtual QuestionAnswer QuestionAnswer { get; set; } = null!;
}

