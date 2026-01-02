using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models
{
	public class SubContent
	{
		public long ContentId { get; set; }
		public long LessonId { get; set; }
		public long ContentNumber { get; set; }
		public string Title { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
