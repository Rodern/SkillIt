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

        public ResponseModel AddEmailOTP(Otp otp)
        {
            if (otp == null) return new(false, "OTPNull");
            if (DatabaseContext.Otps.Find(otp.OtpId) != null) return new(false, "OTPExist");
            try
            {
                //otp.ExpiryDate = DateTime.Now.AddDays(1);
                DatabaseContext.Add<Otp>(otp);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ResponseModel CreateOTP(Otp otp)
        {
            try
            {
                DatabaseContext.Add<Otp>(otp);
                DatabaseContext.SaveChanges();
                return new(false, $"Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ResponseModel DeleteOTP(long id)
        {
            throw new NotImplementedException();
        }

        public Otp GetOTP(long id)
        {
            return DatabaseContext.Otps.Where(o => o.UserId == id).FirstOrDefault();
        }

        public Otp GetOTP(long id, long userId)
        {
            return DatabaseContext.Otps.Where(o => o.OtpId == id && o.UserId == userId).FirstOrDefault();
        }

        public Otp GetOTP(long userId, string guid)
        {
            return DatabaseContext.Otps.Where(o => o.Guid == guid && o.UserId == userId).FirstOrDefault();
        }

        public Otp GetUserOTP(long userId)
        {
            return DatabaseContext.Otps.Where(o => o.UserId == userId).FirstOrDefault();
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
