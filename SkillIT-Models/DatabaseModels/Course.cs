using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Course
    {
        public Course()
        {
            CourseChapters = new HashSet<CourseChapter>();
            Enrollments = new HashSet<Enrollment>();
            UserCertificates = new HashSet<UserCertificate>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public int DateCreated { get; set; }
        public int DatePublish { get; set; }
        public bool IsPublished { get; set; }
        public bool? IsOpen { get; set; }
        public long AuthorId { get; set; }
        public string Level { get; set; }

        public virtual Creator Author { get; set; }
        public virtual ICollection<CourseChapter> CourseChapters { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<UserCertificate> UserCertificates { get; set; }
    }
}
