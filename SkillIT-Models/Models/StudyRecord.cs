using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
    public class StudyRecord
    {
        public StudyRecord(int chapterId, int lessonId, int contentId, bool isDone, DateTime date)
        {
            ChapterId = chapterId;
            LessonId = lessonId;
            ContentId = contentId;
            IsDone = isDone;
            Date = date;
        }
        public StudyRecord()
        {

        }
        public int ChapterId { get; set; }
        public int LessonId { get; set; }
        public int ContentId { get; set; }
        public bool IsDone { get; set; }
        public DateTime Date { get; set; }
    }
}
