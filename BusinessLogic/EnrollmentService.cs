using BusinessLogic.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using SkillIT_Models.CRUD;
using SkillIT_Models.Data;
using SkillIT_Models.Entities.Learning;
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
        private readonly ApplicationDbContext DatabaseContext;
        public EnrollmentService(ApplicationDbContext skill_It_DbContext) {
            DatabaseContext = skill_It_DbContext;
        }

        public ResponseModel CreateEnrollment(Enrollment enrollment)
        {
            return Crud.Create(enrollment.Id, enrollment, DatabaseContext);
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

        public ResponseModel DeleteEnrollment(long enrollmentId)
        {
            return Crud.Delete<Enrollment>(enrollmentId, DatabaseContext);
        }

        public ResponseModel UpdateEnrollment(Enrollment enrollment)
        {
            return Crud.Update(enrollment.Id, enrollment, DatabaseContext);
        }

        public Enrollment GetEnrollment(long enrollmentId)
        {
            return Crud.Read<Enrollment>(enrollmentId, DatabaseContext);
        }

        public ObservableCollection<Enrollment> GetEnrollments()
        {
            return new(DatabaseContext.Enrollments.ToList());
        }

        public ObservableCollection<Enrollment> GetCourseEnrollments(long enrollmentId)
        {
            return new(DatabaseContext.Enrollments.Where(e => e.Id == enrollmentId));
        }

        public long CountCourseEnrollments(long enrollmentId)
        {
            return DatabaseContext.Enrollments.Where(e => e.CourseId == enrollmentId).Count();
        }

        public ObservableCollection<Enrollment> GetUserEnrollments(long enrollmentId, long userId)
        {
            return new(DatabaseContext.Enrollments.Where(e => e.Id == enrollmentId && e.UserId == userId).ToList());
        }

        public long CountAllUserEnrollments(long enrollmentId, long userId)
        {
            return DatabaseContext.Enrollments.Where(e => e.Id == enrollmentId && e.UserId == userId).Count();
        }

        public long CountAllUserEnrollments(long userId)
        {
            return DatabaseContext.Enrollments.Where(e => e.UserId == userId).Count();
        }

        public long CountCompletedUserEnrollments(long enrollmentId, long userId)
        {
            ObservableCollection<Enrollment> enrollments = new(DatabaseContext.Enrollments.Where(e => e.Id == enrollmentId && e.UserId == userId));
            return enrollments.Where(e => e.IsCompleted == true).Count();
        }

        public long CountUnCompletedUserEnrollments(long enrollmentId, long userId)
        {
            ObservableCollection<Enrollment> enrollments = new(DatabaseContext.Enrollments.Where(e => e.Id == enrollmentId && e.UserId == userId));
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

		public Enrollment GetEnrollmentByCourseId(long courseId)
		{
			return DatabaseContext.Enrollments.FirstOrDefault(e => e.CourseId == courseId);
		}

		public Enrollment GetEnrollment(long userId, long courseId)
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
