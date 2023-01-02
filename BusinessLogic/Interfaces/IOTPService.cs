using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IOTPService
    {
        ObservableCollection<Otp> GetOTPs();
        ResponseModel DeleteOTP(long id);
        Otp GetOTP(long id, long userId);
        ResponseModel AddOTP(Otp otp);
        ResponseModel UpdateOTP(Otp otp);
    }
}
