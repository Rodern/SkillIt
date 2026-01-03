using SkillIT_Models.Entities.Learning;
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
        long CountAllUserEnrollments(long enrollmentId, long userId);
        long CountCompletedUserEnrollments(long enrollmentId, long userId);
        long CountUnCompletedUserEnrollments(long enrollmentId, long userId);
        ResponseModel CreateEnrollment(Enrollment enrollment);
        ResponseModel DeleteEnrollment(long enrollmentId);
        ObservableCollection<Enrollment> GetCourseEnrollments(long enrollmentId);
        Enrollment GetEnrollment(long enrollmentId);
        ObservableCollection<Enrollment> GetEnrollments();
        ObservableCollection<Enrollment> GetEnrollments(long userId);
        ObservableCollection<Enrollment> GetCompletedEnrollments(long userId);
        ObservableCollection<Enrollment> GetUncompletedEnrollments(long userId);
        ObservableCollection<Enrollment> GetUserEnrollments(long enrollmentId, long userId);
        ResponseModel UpdateEnrollment(Enrollment enrollment);
        long CountAllUserEnrollments(long userId);
		Enrollment GetEnrollmentByCourseId(long courseId);
		Enrollment GetEnrollmentByUserId(long userId);
        Enrollment GetEnrollment(long userId, long courseId);
		long CountCourseEnrollments(long enrollmentId);
        ObservableCollection<Enrollment> GetEnrollmentsByUserId(long userId);
    }
}
