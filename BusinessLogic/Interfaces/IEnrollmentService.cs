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
    public interface IEnrollmentService
    {
        int CountAllUserEnrollments(int enrollmentId, long userId);
        int CountCompletedUserEnrollments(int enrollmentId, long userId);
        int CountUnCompletedUserEnrollments(int enrollmentId, long userId);
        ResponseModel CreateEnrollment(Enrollment enrollment);
        ResponseModel DeleteEnrollment(int enrollmentId);
        Enrollment GetEnrollment(int enrollmentId);
        ObservableCollection<Enrollment> GetEnrollments();
        ObservableCollection<Enrollment> GetUserEnrollments(int enrollmentId, long userId);
        ResponseModel UpdateEnrollment(Enrollment enrollment);
    }
}
