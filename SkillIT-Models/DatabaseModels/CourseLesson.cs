using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class CourseLesson
    {
        public CourseLesson()
        {
            CourseContents = new HashSet<CourseContent>();
        }

        public int LessonId { get; set; }
        public string Topic { get; set; }
        public int ChapterId { get; set; }
        public long AuthorId { get; set; }
        public DateTime DateCreated { get; set; }
        public int LessonNumber { get; set; }

        public virtual Creator Author { get; set; }
        public virtual CourseChapter Chapter { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }
    }
}
