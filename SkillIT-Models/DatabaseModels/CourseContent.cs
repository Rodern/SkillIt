using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class CourseContent
    {
        public int ContentId { get; set; }
        public int LessonId { get; set; }
        public long AuthorId { get; set; }
        public int ContentNumber { get; set; }
        public string Title { get; set; }
        public string VideoLink { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string Note { get; set; }

        public virtual Creator Author { get; set; }
        public virtual CourseLesson Lesson { get; set; }
    }
}
