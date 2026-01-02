using BusinessLogic.Interfaces;
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
    public class QuizService: IQuizService
    {
        private readonly ApplicationDbContext DatabaseContext;

        public QuizService(ApplicationDbContext quizbaseContext)
        {
            DatabaseContext = quizbaseContext;
        }

        #region EnrollmentQuiz
        public ResponseModel CreateEnrollmentQuiz(EnrollmentQuiz enrollmentQuiz)
        {
            return Crud.Create(enrollmentQuiz.Id, enrollmentQuiz, DatabaseContext);
        }

        public ResponseModel DeleteEnrollmentQuiz(long enrollmentQuizId)
        {
            return Crud.Delete<EnrollmentQuiz>(enrollmentQuizId, DatabaseContext);
        }

        public ResponseModel UpdateEnrollmentQuiz(EnrollmentQuiz enrollmentQuiz)
        {
            return Crud.Update(enrollmentQuiz.Id, enrollmentQuiz, DatabaseContext);
        }

        public EnrollmentQuiz GetEnrollmentQuiz(long enrollmentQuizId)
        {
            return Crud.Read<EnrollmentQuiz>(enrollmentQuizId, DatabaseContext);
        }

        public ObservableCollection<EnrollmentQuiz> GetEnrollmentQuizzes()
        {
            return new(DatabaseContext.EnrollmentQuizzes.ToList());
        }

        public ObservableCollection<EnrollmentQuiz> GetCourseEnrollmentQuizzes(long enrollmentQuizId, long enrollmentId)
        {
            return new(DatabaseContext.EnrollmentQuizzes.Where(e => e.Id == enrollmentQuizId && e.Id == enrollmentId).ToList());
        }

        public EnrollmentQuiz GetCourseEnrollmentQuiz(long enrollmentQuizId, long enrollmentId)
        {
            return DatabaseContext.EnrollmentQuizzes.Where(predicate: e => e.Id == enrollmentQuizId && e.Id == enrollmentId).FirstOrDefault();
        }

        public long CountAllCourseEnrollmentQuizzes(long enrollmentQuizId, long enrollmentId)
        {
            return DatabaseContext.EnrollmentQuizzes.Where(e => e.Id == enrollmentQuizId && e.EnrollmentId == enrollmentId).Count();
        }

        public long CountCompletedCourseEnrollmentQuizzes(long enrollmentQuizId, long enrollmentId)
        {
            ObservableCollection<EnrollmentQuiz> enrollmentQuizzes = new(DatabaseContext.EnrollmentQuizzes.Where(e => e.Id == enrollmentQuizId && e.EnrollmentId == enrollmentId));
            return enrollmentQuizzes.Where(e => e.Passed == true).Count();
        }

        public long CountUnCompletedCourseEnrollmentQuizzes(long enrollmentQuizId, long enrollmentId)
        {
            ObservableCollection<EnrollmentQuiz> enrollmentQuizzes = new(DatabaseContext.EnrollmentQuizzes.Where(e => e.Id == enrollmentQuizId && e.EnrollmentId == enrollmentId));
            return enrollmentQuizzes.Where(e => e.Passed == false).Count();
        }
        #endregion

        #region Quiz
        public ResponseModel CreateQuiz(Quiz quiz)
        {
            return Crud.Create(quiz.Id, quiz, DatabaseContext);
        }

        public ResponseModel DeleteQuiz(long quizId)
        {
            return Crud.Delete<Quiz>(quizId, DatabaseContext);
        }

        public ResponseModel UpdateQuiz(Quiz quiz)
        {
            return Crud.Update(quiz.Id, quiz, DatabaseContext);
        }

        public Quiz GetQuiz(long quizId)
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
            return Crud.Create(chapterQuiz.Id, chapterQuiz, DatabaseContext);
        }

        public ResponseModel DeleteChapterQuiz(long chapterQuizId)
        {
            return Crud.Delete<ChapterQuiz>(chapterQuizId, DatabaseContext);
        }

        public ResponseModel UpdateChapterQuiz(ChapterQuiz chapterQuiz)
        {
            return Crud.Update(chapterQuiz.Id, chapterQuiz, DatabaseContext);
        }

        public ChapterQuiz GetChapterQuiz(long chapterQuizId)
        {
            return Crud.Read<ChapterQuiz>(chapterQuizId, DatabaseContext);
        }

        public ObservableCollection<ChapterQuiz> GetAllChapterQuizzes()
        {
            return new(DatabaseContext.ChapterQuizzes.ToList());
        }

        public ObservableCollection<ChapterQuiz> GetChapterQuizzes()
        {
            return new(DatabaseContext.ChapterQuizzes.ToList());
        }

        public ObservableCollection<ChapterQuiz> GetChapterQuizzes(long chapterId)
        {
            return new(DatabaseContext.ChapterQuizzes.Where(cq => cq.ChapterId == chapterId).ToList());
        }

        public ObservableCollection<ChapterQuiz> GetChapterQuizzesByQuizId(long quizId)
		{
            return new(DatabaseContext.ChapterQuizzes.Where(cq => cq.QuizId == quizId).ToList());
        }


        #endregion

        #region QuizQuestion
        public ResponseModel CreateQuizQuestion(QuizQuestion quizQuestion)
        {
            return Crud.Create(quizQuestion.Id, quizQuestion, DatabaseContext);
        }

        public ResponseModel DeleteQuizQuestion(long quizQuestionId)
        {
            return Crud.Delete<QuizQuestion>(quizQuestionId, DatabaseContext);
        }

        public ResponseModel UpdateQuizQuestion(QuizQuestion quizQuestion)
        {
            return Crud.Update(quizQuestion.Id, quizQuestion, DatabaseContext);
        }

        public QuizQuestion GetQuizQuestion(long quizQuestionId)
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
            return Crud.Create(question.Id, question, DatabaseContext);
        }

        public ResponseModel DeleteQuestion(long questionId)
        {
            return Crud.Delete<Question>(questionId, DatabaseContext);
        }

        public ResponseModel UpdateQuestion(Question question)
        {
            return Crud.Update(question.Id, question, DatabaseContext);
        }

        public Question GetQuestion(long questionId)
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
            return Crud.Create(questionAnswer.Id, questionAnswer, DatabaseContext);
        }

        public ResponseModel DeleteQuestionAnswer(long questionAnswerId)
        {
            return Crud.Delete<QuestionAnswer>(questionAnswerId, DatabaseContext);
        }

        public ResponseModel UpdateQuestionAnswer(QuestionAnswer questionAnswer)
        {
            return Crud.Update(questionAnswer.Id, questionAnswer, DatabaseContext);
        }

        public QuestionAnswer GetQuestionAnswer(long questionAnswerId)
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
            return Crud.Create(questionAnswerResponse.Id, questionAnswerResponse, DatabaseContext);
        }

        public ResponseModel DeletequestionAnswer(long questionAnswerResponseId)
        {
            return Crud.Delete<QuestionAnswerResponse>(questionAnswerResponseId, DatabaseContext);
        }

        public ResponseModel UpdatequestionAnswer(QuestionAnswerResponse questionAnswerResponse)
        {
            return Crud.Update(questionAnswerResponse.Id, questionAnswerResponse, DatabaseContext);
        }

        public QuestionAnswerResponse GetQuestionAnswerResponse(long questionAnswerResponseId)
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
