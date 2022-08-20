using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillItModels.Models
{
	public class ResponseModel
	{
		public ResponseModel()
		{

		}
		public ResponseModel(bool s, string msg)
		{
			Success = s;
			Message = msg;
		}
		public bool Success { get; set; }
		public string Message { get; set; }
	}
}
