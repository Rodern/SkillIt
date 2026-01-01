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
        ObservableCollection<Enrollment> GetCourseEnrollments(int enrollmentId);
        Enrollment GetEnrollment(int enrollmentId);
        ObservableCollection<Enrollment> GetEnrollments();
        ObservableCollection<Enrollment> GetEnrollments(long userId);
        ObservableCollection<Enrollment> GetCompletedEnrollments(long userId);
        ObservableCollection<Enrollment> GetUncompletedEnrollments(long userId);
        ObservableCollection<Enrollment> GetUserEnrollments(int enrollmentId, long userId);
        ResponseModel UpdateEnrollment(Enrollment enrollment);
        int CountAllUserEnrollments(long userId);
		Enrollment GetEnrollmentByCourseId(int courseId);
		Enrollment GetEnrollmentByUserId(long userId);
        Enrollment GetEnrollment(long userId, int courseId);
		int CountCourseEnrollments(int enrollmentId);
	}
}
