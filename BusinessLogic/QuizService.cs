using BusinessLogic.Interfaces;
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
    public class QuizService: IQuizService
    {
        private readonly skill_it_dbContext DatabaseContext;

        public QuizService(skill_it_dbContext quizbaseContext)
        {
            DatabaseContext = quizbaseContext;
        }

        #region EnrollmentQuiz
        public ResponseModel CreateEnrollmentQuiz(EnrollmentQuiz enrollmentQuiz)
        {
            return Crud.Create(enrollmentQuiz.EnrollmentQuizId, enrollmentQuiz, DatabaseContext);
        }

        public ResponseModel DeleteEnrollmentQuiz(int enrollmentQuizId)
        {
            return Crud.Delete<EnrollmentQuiz>(enrollmentQuizId, DatabaseContext);
        }

        public ResponseModel UpdateEnrollmentQuiz(EnrollmentQuiz enrollmentQuiz)
        {
            return Crud.Update(enrollmentQuiz.EnrollmentQuizId, enrollmentQuiz, DatabaseContext);
        }

        public EnrollmentQuiz GetEnrollmentQuiz(int enrollmentQuizId)
        {
            return Crud.Read<EnrollmentQuiz>(enrollmentQuizId, DatabaseContext);
        }

        public ObservableCollection<EnrollmentQuiz> GetEnrollmentQuizzes()
        {
            return new(DatabaseContext.EnrollmentQuizzes.ToList());
        }

        public ObservableCollection<EnrollmentQuiz> GetCourseEnrollmentQuizzes(int enrollmentQuizId, int enrollmentId)
        {
            return new(DatabaseContext.EnrollmentQuizzes.Where(e => e.EnrollmentQuizId == enrollmentQuizId && e.EnrollmentQuizId == enrollmentId).ToList());
        }

        public EnrollmentQuiz GetCourseEnrollmentQuiz(int enrollmentQuizId, int enrollmentId)
        {
            return DatabaseContext.EnrollmentQuizzes.Where(predicate: e => e.EnrollmentQuizId == enrollmentQuizId && e.EnrollmentQuizId == enrollmentId).FirstOrDefault();
        }

        public int CountAllCourseEnrollmentQuizzes(int enrollmentQuizId, int enrollmentId)
        {
            return DatabaseContext.EnrollmentQuizzes.Where(e => e.EnrollmentQuizId == enrollmentQuizId && e.EnrollmentId == enrollmentId).Count();
        }

        public int CountCompletedCourseEnrollmentQuizzes(int enrollmentQuizId, int enrollmentId)
        {
            ObservableCollection<EnrollmentQuiz> enrollmentQuizzes = new(DatabaseContext.EnrollmentQuizzes.Where(e => e.EnrollmentQuizId == enrollmentQuizId && e.EnrollmentId == enrollmentId));
            return enrollmentQuizzes.Where(e => e.Passed == true).Count();
        }

        public int CountUnCompletedCourseEnrollmentQuizzes(int enrollmentQuizId, int enrollmentId)
        {
            ObservableCollection<EnrollmentQuiz> enrollmentQuizzes = new(DatabaseContext.EnrollmentQuizzes.Where(e => e.EnrollmentQuizId == enrollmentQuizId && e.EnrollmentId == enrollmentId));
            return enrollmentQuizzes.Where(e => e.Passed == false).Count();
        }
        #endregion

        #region Quiz
        public ResponseModel CreateQuiz(Quiz quiz)
        {
            return Crud.Create(quiz.QuizId, quiz, DatabaseContext);
        }

        public ResponseModel DeleteQuiz(int quizId)
        {
            return Crud.Delete<Quiz>(quizId, DatabaseContext);
        }

        public ResponseModel UpdateQuiz(Quiz quiz)
        {
            return Crud.Update(quiz.QuizId, quiz, DatabaseContext);
        }

        public Quiz GetQuiz(int quizId)
        {
            //Quiz quiz = DatabaseContext.Quizzes.Where(e => e.QuizId == quizId).Include(nameof(QuizQuestion)).Include(nameof(QuizQuestion)).SingleOrDefault();
            return Crud.Read<Quiz>(quizId, DatabaseContext);
        }

        public ObservableCollection<Quiz> GetCourseQuizzes()
        {
            return new(DatabaseContext.Quizzes.ToList());
        }
        #endregion

        #region ChapterQuiz
        public ResponseModel CreateChapterQuiz(ChapterQuiz chapterQuiz)
        {
            return Crud.Create(chapterQuiz.ChapterQuizId, chapterQuiz, DatabaseContext);
        }

        public ResponseModel DeleteChapterQuiz(int chapterQuizId)
        {
            return Crud.Delete<ChapterQuiz>(chapterQuizId, DatabaseContext);
        }

        public ResponseModel UpdateChapterQuiz(ChapterQuiz chapterQuiz)
        {
            return Crud.Update(chapterQuiz.ChapterQuizId, chapterQuiz, DatabaseContext);
        }

        public ChapterQuiz GetChapterQuiz(int chapterQuizId)
        {
            return Crud.Read<ChapterQuiz>(chapterQuizId, DatabaseContext);
        }

        public ObservableCollection<ChapterQuiz> GetChapterQuizzes()
        {
            return new(DatabaseContext.ChapterQuizzes.ToList());
        }
        #endregion

        #region QuizQuestion
        public ResponseModel CreateQuizQuestion(QuizQuestion quizQuestion)
        {
            return Crud.Create(quizQuestion.QuizQuestionId, quizQuestion, DatabaseContext);
        }

        public ResponseModel DeleteQuizQuestion(int quizQuestionId)
        {
            return Crud.Delete<QuizQuestion>(quizQuestionId, DatabaseContext);
        }

        public ResponseModel UpdateQuizQuestion(QuizQuestion quizQuestion)
        {
            return Crud.Update(quizQuestion.QuizQuestionId, quizQuestion, DatabaseContext);
        }

        public QuizQuestion GetQuizQuestion(int quizQuestionId)
        {
            return Crud.Read<QuizQuestion>(quizQuestionId, DatabaseContext);
        }

        public ObservableCollection<QuizQuestion> GetCourseQuizQuestions()
        {
            return new(DatabaseContext.QuizQuestions.ToList());
        }
        #endregion

        #region Question
        public ResponseModel CreateQuestion(Question question)
        {
            return Crud.Create(question.QuestionId, question, DatabaseContext);
        }

        public ResponseModel DeleteQuestion(int questionId)
        {
            return Crud.Delete<Question>(questionId, DatabaseContext);
        }

        public ResponseModel UpdateQuestion(Question question)
        {
            return Crud.Update(question.QuestionId, question, DatabaseContext);
        }

        public Question GetQuestion(int questionId)
        {
            return Crud.Read<Question>(questionId, DatabaseContext);
        }

        public ObservableCollection<Question> GetCourseQuestions()
        {
            return new(DatabaseContext.Questions.ToList());
        }
        #endregion

        #region QuestionAnswer
        public ResponseModel CreateQuestionAnswer(QuestionAnswer questionAnswer)
        {
            return Crud.Create(questionAnswer.QuestionAnswerId, questionAnswer, DatabaseContext);
        }

        public ResponseModel DeleteQuestionAnswer(int questionAnswerId)
        {
            return Crud.Delete<QuestionAnswer>(questionAnswerId, DatabaseContext);
        }

        public ResponseModel UpdateQuestionAnswer(QuestionAnswer questionAnswer)
        {
            return Crud.Update(questionAnswer.QuestionAnswerId, questionAnswer, DatabaseContext);
        }

        public QuestionAnswer GetQuestionAnswer(int questionAnswerId)
        {
            return Crud.Read<QuestionAnswer>(questionAnswerId, DatabaseContext);
        }

        public ObservableCollection<QuestionAnswer> GetCourseQuestionAnswers()
        {
            return new(DatabaseContext.QuestionAnswers.ToList());
        }
        #endregion

        #region QuestionAnswerResponse
        public ResponseModel CreateQuestionAnswerResponse(QuestionAnswerResponse questionAnswerResponse)
        {
            return Crud.Create(questionAnswerResponse.QuestionAnswerResponseId, questionAnswerResponse, DatabaseContext);
        }

        public ResponseModel DeletequestionAnswer(int questionAnswerResponseId)
        {
            return Crud.Delete<QuestionAnswerResponse>(questionAnswerResponseId, DatabaseContext);
        }

        public ResponseModel UpdatequestionAnswer(QuestionAnswerResponse questionAnswerResponse)
        {
            return Crud.Update(questionAnswerResponse.QuestionAnswerResponseId, questionAnswerResponse, DatabaseContext);
        }

        public QuestionAnswerResponse GetQuestionAnswerResponse(int questionAnswerResponseId)
        {
            return Crud.Read<QuestionAnswerResponse>(questionAnswerResponseId, DatabaseContext);
        }

        public ObservableCollection<QuestionAnswerResponse> GetCourseQuestionAnswerResponses()
        {
            return new(DatabaseContext.QuestionAnswerResponses.ToList());
        }
        #endregion

    }
}
