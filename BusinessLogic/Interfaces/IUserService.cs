using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
		ObservableCollection<User> GetAllUsers();
		ResponseModel CheckEmailExistence(string email);
		ResponseModel AddUser(UserModel user);
		User GetUser(long id);
		ResponseModel UpdateUser(long id, UserModel user);
	}
}
