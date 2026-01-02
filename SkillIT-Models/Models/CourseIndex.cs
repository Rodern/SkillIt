using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
	public class CourseIndex
	{
		public CourseIndex(long courseIndexId, long courseId, long chapterId, long lessonId, long contentId)
		{
			this.CourseIndexId = courseIndexId;
			this.CourseId = courseId;
			this.ChapterId = chapterId;
			this.LessonId = lessonId;
			this.ContentId = contentId;
		}

		public CourseIndex()
		{

		}

		public long CourseIndexId { get; set; }
		public long CourseId { get; set; }
		public long ChapterId { get; set; }
		public long LessonId { get; set; }
		public long ContentId { get; set; }
		public long ChapterNumber { get; set; }
		public long LessonNumber { get; set; }
		public long ContentNumber { get; set; }
		public string ChapterGuid { get; set; }
		public string LessonGuid { get; set; }
		public string ContentGuid { get; set; }
		public bool IsDone { get; set; } = false;
		public bool IsUnlocked { get; set; } = false;
		public bool IsDeleted { get; set; } = false;
		public bool HasQuiz { get; set; } = false;
		public bool IsLastChapter { get;  set; } = false;
		public bool IsLastLesson { get;  set; } = false;
		public bool IsLastContent { get;  set; } = false;
		public DateTime DateUnlocked { get; set; } = DateTime.Now;
		public DateTime DateDone { get; set; } = DateTime.Now;
	}
}
