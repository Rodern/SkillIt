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
	public interface IQuizService
	{
		long CountAllCourseEnrollmentQuizzes(long enrollmentQuizId, long enrollmentId);
		long CountCompletedCourseEnrollmentQuizzes(long enrollmentQuizId, long enrollmentId);
		long CountUnCompletedCourseEnrollmentQuizzes(long enrollmentQuizId, long enrollmentId);
		ResponseModel CreateChapterQuiz(ChapterQuiz chapterQuiz);
		ResponseModel CreateEnrollmentQuiz(EnrollmentQuiz enrollmentQuiz);
		ResponseModel CreateQuestion(Question question);
		ResponseModel CreateQuestionAnswer(QuestionAnswer questionAnswer);
		ResponseModel CreateQuestionAnswerResponse(QuestionAnswerResponse questionAnswerResponse);
		ResponseModel CreateQuiz(Quiz quiz);
		ResponseModel CreateQuizQuestion(QuizQuestion quizQuestion);
		ResponseModel DeleteChapterQuiz(long chapterQuizId);
		ResponseModel DeleteEnrollmentQuiz(long enrollmentQuizId);
		ResponseModel DeleteQuestion(long questionId);
		ResponseModel DeletequestionAnswer(long questionAnswerResponseId);
		ResponseModel DeleteQuestionAnswer(long questionAnswerId);
		ResponseModel DeleteQuiz(long quizId);
		ResponseModel DeleteQuizQuestion(long quizQuestionId);
		ObservableCollection<ChapterQuiz> GetAllChapterQuizzes();
		ChapterQuiz GetChapterQuiz(long chapterQuizId);
		ObservableCollection<ChapterQuiz> GetChapterQuizzes(long chapterId);
		ObservableCollection<ChapterQuiz> GetChapterQuizzes();
		ObservableCollection<ChapterQuiz> GetChapterQuizzesByQuizId(long quizId);
		EnrollmentQuiz GetCourseEnrollmentQuiz(long enrollmentQuizId, long enrollmentId);
		ObservableCollection<EnrollmentQuiz> GetCourseEnrollmentQuizzes(long enrollmentQuizId, long enrollmentId);
		ObservableCollection<QuestionAnswerResponse> GetCourseQuestionAnswerResponses();
		ObservableCollection<QuestionAnswer> GetCourseQuestionAnswers();
		ObservableCollection<Question> GetCourseQuestions();
		ObservableCollection<QuizQuestion> GetCourseQuizQuestions();
		ObservableCollection<Quiz> GetCourseQuizzes();
		EnrollmentQuiz GetEnrollmentQuiz(long enrollmentQuizId);
		ObservableCollection<EnrollmentQuiz> GetEnrollmentQuizzes();
		Question GetQuestion(long questionId);
		QuestionAnswer GetQuestionAnswer(long questionAnswerId);
		QuestionAnswerResponse GetQuestionAnswerResponse(long questionAnswerResponseId);
		Quiz GetQuiz(long quizId);
		QuizQuestion GetQuizQuestion(long quizQuestionId);
		ResponseModel UpdateChapterQuiz(ChapterQuiz chapterQuiz);
		ResponseModel UpdateEnrollmentQuiz(EnrollmentQuiz enrollmentQuiz);
		ResponseModel UpdateQuestion(Question question);
		ResponseModel UpdateQuestionAnswer(QuestionAnswer questionAnswer);
		ResponseModel UpdatequestionAnswer(QuestionAnswerResponse questionAnswerResponse);
		ResponseModel UpdateQuiz(Quiz quiz);
		ResponseModel UpdateQuizQuestion(QuizQuestion quizQuestion);
	}
}
