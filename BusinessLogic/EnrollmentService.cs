using BusinessLogic.Interfaces;
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

        public ObservableCollection<Enrollment> GetUserEnrollments(int enrollmentId, long userId)
        {
            return new(DatabaseContext.Enrollments.Where(e => e.EnrollmentId == enrollmentId && e.UserId == userId).ToList());
        }

        public int CountAllUserEnrollments(int enrollmentId, long userId)
        {
            return DatabaseContext.Enrollments.Where(e => e.EnrollmentId == enrollmentId && e.UserId == userId).Count();
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
    }
}
