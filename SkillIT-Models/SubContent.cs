using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models
{
	public class SubContent
	{
		public int ContentId { get; set; }
		public int LessonId { get; set; }
		public int ContentNumber { get; set; }
		public string Title { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
