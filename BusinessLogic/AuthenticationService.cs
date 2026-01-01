using BusinessLogic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Helpers;
using static System.Net.WebRequestMethods;

namespace BusinessLogic
{
	public class AuthenticationService: IAuthenticationService
	{
		private readonly skill_it_dbContext DatabaseContext;
		private readonly IOTPService OTPService;
		private readonly IEntityService EntityService;

		public AuthenticationService(skill_it_dbContext skill_It_DbContext, IOTPService oTPService, IEntityService entityService)
		{
			this.DatabaseContext = skill_It_DbContext;
			OTPService = oTPService;
			EntityService = entityService;
		}
		public AuthenticationService(skill_it_dbContext skill_It_DbContext)
		{
			this.DatabaseContext = skill_It_DbContext;
		}
		public ResponseModel GenerateCode(string email)
		{
			User user = DatabaseContext.Users.Where(u => u.Email == email).FirstOrDefault();
			if (user == null) return new(false, "UserNotFound");
			ResponseModel resetModel = OTPService.CreateOTP(new()
			{
				UserId = user.UserId,
				Code = AuthenticationHelper.GenerateOTP(),
				OtpId = 0,
				Guid = AuthenticationHelper.GenerateGuid(),
				ExpiryDate = DateTime.UtcNow.AddDays(1),
			});
			
			return new(true, $"{resetModel.Message}");
		}
		public ResponseModel Reset(ResetModel resetModel)
		{
			int resetCode = DatabaseContext.Otps.Where(o => o.OtpId == resetModel.OtpId && o.UserId == resetModel.UserId && o.Guid == resetModel.Guid).Select(o => o.Code).FirstOrDefault();
			if (resetCode != resetModel.Otp) return new(false, "OTPIncorrect");
			User user = DatabaseContext.Users.Where(u => u.UserId == resetModel.UserId).FirstOrDefault();
			if (user == null) return new(false, "UserNotFound");
			UserService userService = new(DatabaseContext);
			userService.UpdatePassword(user.UserId, AuthenticationHelper.EncryptPassword(resetModel.Password));
			EntityService.DeleteEntity<Otp>(resetModel.OtpId);
			return new(true, "ResetSuccess");
		}

		public ResponseModel _isEmptyOrInvalid(string token)
		{
			try
			{
				if (token == null || ("").Equals(token))
				{
					return new(true, "IsEmpty");
				}

				/***
				 * Make string valid for FromBase64String
				 * FromBase64String cannot accept '.' characters and only accepts stringth whose length is a multitude of 4
				 * If the string doesn't have the correct length trailing padding '=' characters should be added.
				 */
				int indexOfFirstPoint = token.IndexOf('.') + 1;
				String toDecode = token.Substring(indexOfFirstPoint, token.LastIndexOf('.') - indexOfFirstPoint);
				while (toDecode.Length % 4 != 0)
				{
					toDecode += '=';
				}

				//Decode the string
				string decodedString = Encoding.ASCII.GetString(Convert.FromBase64String(toDecode));

				//Get the "exp" part of the string
				Regex regex = new Regex("(\"exp\":)([0-9]{1,})");
				Match match = regex.Match(decodedString);
				long timestamp = Convert.ToInt64(match.Groups[2].Value);

				DateTime date = new DateTime(1970, 1, 1).AddSeconds(timestamp);
				DateTime compareTo = DateTime.UtcNow;

				int result = DateTime.Compare(date, compareTo);

				return new(result > 0, Convert.ToString(result));
			}
			catch(Exception ex)
			{
				return new(false, $"IncorrectToken: {ex.Message}");
			}
		}

		public ResponseModel Authenticate(UserCredential userCredential)
		{
			try {

				int days = 1;
				User user = DatabaseContext.Users.Where(u => u.Email == userCredential.Email).FirstOrDefault();
				
				if (user == null) return new(false, "UserNotFound");
				Account account = DatabaseContext.Accounts.FirstOrDefault(a => a.UserId == user.UserId);

				if (account.AccountStatus == "Banned" || account.AccountStatus == "Suspended") return new(false, $"This account is currently {account.AccountStatus}. Please contact our support team via for futher info.");
				if (Crypto.VerifyHashedPassword(user.Password, userCredential.Password) != true) return new(false, "Incorrect");

				var role = DatabaseContext.Roles.FirstOrDefault(r => r.RoleId == account.RoleId);

				JwtSecurityTokenHandler tokenHandler = new();
				byte[] tokenKey = Encoding.ASCII.GetBytes(AuthenticationHelper.AuthenticationKey);

				if (userCredential.RememberMe == true) days = 365;

				SecurityTokenDescriptor tokenDescriptor = new()
				{
					Subject = new ClaimsIdentity(new Claim[]
					{
						new Claim("UserId", $"{user.UserId}"),
						new Claim("AccountId", $"{account.AccountId}"),
						new Claim(ClaimTypes.Email, userCredential.Email),
						new Claim("Password", userCredential.Password),
						new Claim("Role", role.Name)
                    }),
					Expires = DateTime.UtcNow.AddDays(days),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
				};

				var token = tokenHandler.CreateToken(tokenDescriptor);
				return new(true, JsonConvert.SerializeObject(new AuthenticatedModel(user.UserId, tokenHandler.WriteToken(token))));
			}
			catch (Exception ex)
			{
				return new(false, $"Check database connections: {ex.Message}");
			}
		}
	}

}
