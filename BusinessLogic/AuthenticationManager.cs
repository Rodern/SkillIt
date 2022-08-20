using BusinessLogic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BusinessLogic
{
	public class AuthenticationManager: IAuthenticationManager
	{
		private readonly skill_it_dbContext DatabaseContext;
		public AuthenticationManager(skill_it_dbContext skill_It_DbContext)
		{
			this.DatabaseContext = skill_It_DbContext;
		}
		public ResponseModel GenerateCode(string email)
		{
			User user = DatabaseContext.Users.Where(u => u.Email == email).FirstOrDefault();
			if (user == null) return new(false, "UserNotFound");
			string code = Convert.ToString(Guid.NewGuid());
			UserService userService = new UserService(DatabaseContext);
			userService.UpdateUser(user.UserId, new()
			{
				Username = user.Username,
				Address = user.Address,
				DateCreated = user.DateCreated,
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Password = code,
				Dob = user.Dob,
				Phone = user.Phone,
				UserSkillId = user.UserSkillId,
				UserSocialId = user.UserSocialId
			});
			return new(true, code);
		}
		public ResponseModel Reset(UserCredential userCredential)
		{
			User user = DatabaseContext.Users.Where(u => u.Email == userCredential.Email).FirstOrDefault();
			if (user == null) return new(false, "UserNotFound");
			if (user.Password != userCredential.Code) return new(false, "IncorrectCode");
			UserService userService = new UserService(DatabaseContext);
			userService.UpdateUser(user.UserId, new()
			{
				Username = user.Username,
				Address = user.Address,
				DateCreated = user.DateCreated,
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Password = Authentication.EncryptPassword(userCredential.Password),
				Dob = user.Dob,
				Phone = user.Phone,
				UserSkillId = user.UserSkillId,
				UserSocialId = user.UserSocialId
			});
			return new(true, "Success");
		}

		public ResponseModel Authenticate(UserCredential userCredential)
		{
			int days = 1;
			User user = DatabaseContext.Users.Where(u => u.Email == userCredential.Email).FirstOrDefault();
			if (user == null) return new(false, "UserNotFound");
			if (user.Password != Authentication.EncryptPassword(userCredential.Password)) return new(false, "Incorrect");// Convert.ToString(Guid.NewGuid()));
			
			JwtSecurityTokenHandler tokenHandler = new();
			byte[] tokenKey = Encoding.ASCII.GetBytes(Authentication.AuthenticationKey);
			if(userCredential.RememberMe == true) days = 365;
			SecurityTokenDescriptor tokenDescriptor = new()
			{
				Subject = new ClaimsIdentity( new Claim[]
				{
					new Claim(ClaimTypes.Email, userCredential.Email)
				}),
				Expires = DateTime.UtcNow.AddMinutes(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new(true, tokenHandler.WriteToken(token));
		}
	}
}
