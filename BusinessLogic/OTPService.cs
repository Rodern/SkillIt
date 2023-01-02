using BusinessLogic.Interfaces;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OTPService : IOTPService
    {
        public readonly skill_it_dbContext DatabaseContext;
        public OTPService(skill_it_dbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public ResponseModel AddOTP(Otp otp)
        {
            if (otp == null) return new(false, "OTPNull");
            if (DatabaseContext.Otps.Find(otp.OtpId) != null) return new(false, "OTPExist");
            try
            {
                otp.ExpiryDate = DateTime.Now.AddDays(1);
                DatabaseContext.Add<Otp>(otp);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ResetModel CreateOTP(Otp otp)
        {
            try
            {
                otp.ExpiryDate = DateTime.Now.AddDays(1);
                DatabaseContext.Add<Otp>(otp);
                DatabaseContext.SaveChanges();
                return new()
                {
                    Otp = otp.Code,
                    UserId = otp.UserId,
                    OtpId = otp.OtpId,
                    Password = "",
                };
            }
            catch (Exception ex)
            {
                return new();
            }
        }

        public ResponseModel DeleteOTP(long id)
        {
            throw new NotImplementedException();
        }

        public Otp GetOTP(long id, long userId)
        {
            return DatabaseContext.Otps.Where(o => o.OtpId == id && o.UserId == userId).FirstOrDefault();
        }

        public ObservableCollection<Otp> GetOTPs()
        {
            return new ObservableCollection<Otp>(DatabaseContext.Otps);
        }

        public ResponseModel UpdateOTP(Otp otp)
        {
            throw new NotImplementedException();
        }
    }
}
