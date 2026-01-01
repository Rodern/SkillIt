using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
	public class CourseIndex
	{
		public CourseIndex(int courseIndexId, int courseId, int chapterId, int lessonId, int contentId)
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

		public int CourseIndexId { get; set; }
		public int CourseId { get; set; }
		public int ChapterId { get; set; }
		public int LessonId { get; set; }
		public int ContentId { get; set; }
		public int ChapterNumber { get; set; }
		public int LessonNumber { get; set; }
		public int ContentNumber { get; set; }
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
