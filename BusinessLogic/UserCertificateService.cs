using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserCertificateService : IUserCertificateService
    {
        private readonly skill_it_dbContext DatabaseContext;
        public UserCertificateService(skill_it_dbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        ObservableCollection<UserCertificate> addToCollection(ObservableCollection<UserCertificate> userCertificates)
        {
            int j = userCertificates.Count;
            for (int i = 0; i < j; i++)
            {
                userCertificates[i].Cert = new Certificate();
                userCertificates[i].Cert = DatabaseContext.Certificates.Where(s => s.CertId == userCertificates[i].CertId).FirstOrDefault();
            }
            return userCertificates;
        }

        public ResponseModel AddUserCerticate(UserCertificate certificate)
        {
            if (certificate == null) return new(false, "CertificateIsNull");
            try
            {
                DatabaseContext.UserCertificates.Add(certificate);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ObservableCollection<UserCertificate> GetCertificates()
        {
            return new ObservableCollection<UserCertificate>(addToCollection(new(DatabaseContext.UserCertificates)));
        }

        public ResponseModel RemoveUserCertificate(int ucId, long userId)
        {
            UserCertificate certificate = DatabaseContext.UserCertificates.Where(_ => _.UcId == ucId && _.UserId == userId).FirstOrDefault();
            if (certificate == null) return new(false, "CertificateIsNull");
            try
            {
                DatabaseContext.Entry<UserCertificate>(certificate).State = EntityState.Deleted;
                DatabaseContext.Entry<Certificate>(DatabaseContext.Find<Certificate>(certificate.CertId)).State = EntityState.Deleted;
                //DatabaseContext.UserCertificates.Update(certificate);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ResponseModel UpdateUserCertificate(UserCertificate certificate)
        {
            if (certificate == null) return new(false, "CertificateIsNull");
            try
            {
                DatabaseContext.Entry<UserCertificate>(certificate).State = EntityState.Detached;
                DatabaseContext.Entry<Certificate>(certificate.Cert).State = EntityState.Detached;
                DatabaseContext.UserCertificates.Update(certificate);
                DatabaseContext.Certificates.Update(certificate.Cert);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ObservableCollection<UserCertificate> GetUserCertificates(long userId)
        {
            return new ObservableCollection<UserCertificate>(addToCollection(new(DatabaseContext.UserCertificates.Where(_ => _.UserId == userId))));
        }
    }
}
