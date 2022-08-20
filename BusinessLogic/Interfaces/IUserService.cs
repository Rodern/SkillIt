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
		User GetUser(int id);
		ResponseModel UpdateUser(int id, UserModel user);
	}
}
