using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IAuthenticationManager
	{
		ResponseModel Authenticate(UserCredential userCredential);
		ResponseModel GenerateCode(string email, long otpId);
		ResponseModel Reset(ResetModel resetModel);
		ResponseModel _isEmptyOrInvalid(string token);
	}
}
