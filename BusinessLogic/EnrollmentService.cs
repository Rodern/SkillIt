using BusinessLogic.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using SkillIT_Models.CRUD;
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
    public class EnrollmentService: IEnrollmentService
    {
        private readonly skill_it_dbContext DatabaseContext;
        public EnrollmentService(skill_it_dbContext skill_It_DbContext) {
            DatabaseContext = skill_It_DbContext;
        }

        public ResponseModel CreateEnrollment(Enrollment enrollment)
        {
            return Crud.Create(enrollment.EnrollmentId, enrollment, DatabaseContext);
        }

        //public Enrollment CreateUserEnrollment(Enrollment enrollment)
        //{
        //    string name = typeof(Enrollment).Name;
        //    if (enrollment == null) return new(false, $"{name}Null");
        //    try
        //    {
        //        if (DatabaseContext.Find<Enrollment>(enrollment.EnrollmentId) != null) return new(false, $"{name}Exists");
        //        DatabaseContext.Add<Enrollment>(enrollment);
        //        DatabaseContext.SaveChanges();
        //        return new(true, "Success");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new(false, $"Failed: {ex}");
        //    }
        //}

        public ResponseModel DeleteEnrollment(int enrollmentId)
        {
            return Crud.Delete<Enrollment>(enrollmentId, DatabaseContext);
        }

        public ResponseModel UpdateEnrollment(Enrollment enrollment)
        {
            return Crud.Update(enrollment.EnrollmentId, enrollment, DatabaseContext);
        }

        public Enrollment GetEnrollment(int enrollmentId)
        {
            return Crud.Read<Enrollment>(enrollmentId, DatabaseContext);
        }

        public ObservableCollection<Enrollment> GetEnrollments()
        {
            return new(DatabaseContext.Enrollments.ToList());
        }

        public ObservableCollection<Enrollment> GetCourseEnrollments(int enrollmentId)
        {
            return new(DatabaseContext.Enrollments.Where(e => e.EnrollmentId == enrollmentId));
        }

        public int CountCourseEnrollments(int enrollmentId)
        {
            return DatabaseContext.Enrollments.Where(e => e.CourseId == enrollmentId).Count();
        }

        public ObservableCollection<Enrollment> GetUserEnrollments(int enrollmentId, long userId)
        {
            return new(DatabaseContext.Enrollments.Where(e => e.EnrollmentId == enrollmentId && e.UserId == userId).ToList());
        }

        public int CountAllUserEnrollments(int enrollmentId, long userId)
        {
            return DatabaseContext.Enrollments.Where(e => e.EnrollmentId == enrollmentId && e.UserId == userId).Count();
        }

        public int CountAllUserEnrollments(long userId)
        {
            return DatabaseContext.Enrollments.Where(e => e.UserId == userId).Count();
        }

        public int CountCompletedUserEnrollments(int enrollmentId, long userId)
        {
            ObservableCollection<Enrollment> enrollments = new(DatabaseContext.Enrollments.Where(e => e.EnrollmentId == enrollmentId && e.UserId == userId));
            return enrollments.Where(e => e.IsCompleted == true).Count();
        }

        public int CountUnCompletedUserEnrollments(int enrollmentId, long userId)
        {
            ObservableCollection<Enrollment> enrollments = new(DatabaseContext.Enrollments.Where(e => e.EnrollmentId == enrollmentId && e.UserId == userId));
            return enrollments.Where(e => e.IsCompleted == false).Count();
        }

		public ObservableCollection<Enrollment> GetEnrollments(long userId)
		{
			return new(DatabaseContext.Enrollments.Where(e => e.UserId == userId).ToList());
		}

		public Enrollment GetEnrollmentByUserId(long userId)
		{
			return DatabaseContext.Enrollments.FirstOrDefault(e => e.UserId == userId);
		}

		public Enrollment GetEnrollmentByCourseId(int courseId)
		{
			return DatabaseContext.Enrollments.FirstOrDefault(e => e.CourseId == courseId);
		}

		public Enrollment GetEnrollment(long userId, int courseId)
		{
			return DatabaseContext.Enrollments.FirstOrDefault(e => e.UserId == userId && e.CourseId == courseId);
		}

		public ObservableCollection<Enrollment> GetCompletedEnrollments(long userId)
		{
			ObservableCollection<Enrollment> enrollments = new(DatabaseContext.Enrollments.Where(e => e.UserId == userId));
			return new(enrollments.Where(e => e.IsCompleted == true));
		}

		public ObservableCollection<Enrollment> GetUncompletedEnrollments(long userId)
		{
			return new(DatabaseContext.Enrollments.Where(e => e.UserId == userId).Where(e => e.IsCompleted == false));
		}
	}
}
