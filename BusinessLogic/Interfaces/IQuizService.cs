using SkillIT_Models.Entities.Learning;
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
	public interface IQuizService
	{
		int CountAllCourseEnrollmentQuizzes(int enrollmentQuizId, int enrollmentId);
		int CountCompletedCourseEnrollmentQuizzes(int enrollmentQuizId, int enrollmentId);
		int CountUnCompletedCourseEnrollmentQuizzes(int enrollmentQuizId, int enrollmentId);
		ResponseModel CreateChapterQuiz(ChapterQuiz chapterQuiz);
		ResponseModel CreateEnrollmentQuiz(EnrollmentQuiz enrollmentQuiz);
		ResponseModel CreateQuestion(Question question);
		ResponseModel CreateQuestionAnswer(QuestionAnswer questionAnswer);
		ResponseModel CreateQuestionAnswerResponse(QuestionAnswerResponse questionAnswerResponse);
		ResponseModel CreateQuiz(Quiz quiz);
		ResponseModel CreateQuizQuestion(QuizQuestion quizQuestion);
		ResponseModel DeleteChapterQuiz(int chapterQuizId);
		ResponseModel DeleteEnrollmentQuiz(int enrollmentQuizId);
		ResponseModel DeleteQuestion(int questionId);
		ResponseModel DeletequestionAnswer(int questionAnswerResponseId);
		ResponseModel DeleteQuestionAnswer(int questionAnswerId);
		ResponseModel DeleteQuiz(int quizId);
		ResponseModel DeleteQuizQuestion(int quizQuestionId);
		ObservableCollection<ChapterQuiz> GetAllChapterQuizzes();
		ChapterQuiz GetChapterQuiz(int chapterQuizId);
		ObservableCollection<ChapterQuiz> GetChapterQuizzes(int chapterId);
		ObservableCollection<ChapterQuiz> GetChapterQuizzes();
		ObservableCollection<ChapterQuiz> GetChapterQuizzesByQuizId(int quizId);
		EnrollmentQuiz GetCourseEnrollmentQuiz(int enrollmentQuizId, int enrollmentId);
		ObservableCollection<EnrollmentQuiz> GetCourseEnrollmentQuizzes(int enrollmentQuizId, int enrollmentId);
		ObservableCollection<QuestionAnswerResponse> GetCourseQuestionAnswerResponses();
		ObservableCollection<QuestionAnswer> GetCourseQuestionAnswers();
		ObservableCollection<Question> GetCourseQuestions();
		ObservableCollection<QuizQuestion> GetCourseQuizQuestions();
		ObservableCollection<Quiz> GetCourseQuizzes();
		EnrollmentQuiz GetEnrollmentQuiz(int enrollmentQuizId);
		ObservableCollection<EnrollmentQuiz> GetEnrollmentQuizzes();
		Question GetQuestion(int questionId);
		QuestionAnswer GetQuestionAnswer(int questionAnswerId);
		QuestionAnswerResponse GetQuestionAnswerResponse(int questionAnswerResponseId);
		Quiz GetQuiz(int quizId);
		QuizQuestion GetQuizQuestion(int quizQuestionId);
		ResponseModel UpdateChapterQuiz(ChapterQuiz chapterQuiz);
		ResponseModel UpdateEnrollmentQuiz(EnrollmentQuiz enrollmentQuiz);
		ResponseModel UpdateQuestion(Question question);
		ResponseModel UpdateQuestionAnswer(QuestionAnswer questionAnswer);
		ResponseModel UpdatequestionAnswer(QuestionAnswerResponse questionAnswerResponse);
		ResponseModel UpdateQuiz(Quiz quiz);
		ResponseModel UpdateQuizQuestion(QuizQuestion quizQuestion);
	}
}
