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
    public interface IUserCertificateService
    {
        ObservableCollection<UserCertificate> GetCertificates();
        ObservableCollection<UserCertificate> GetUserCertificates(long userId);
        ResponseModel AddUserCerticate(UserCertificate certificate);
        ResponseModel RemoveUserCertificate(int ucId, long userId);
        ResponseModel UpdateUserCertificate(UserCertificate certificate);
    }
}
