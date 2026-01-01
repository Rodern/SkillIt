class UserCredential {
	constructor(email, password, rememberMe = false, code = "") {
		this.email = email
		this.password = password
		this.rememberMe = rememberMe
		this.code = code
	}
}

class Authenticate {
	constructor(email, password, rememberMe = false, code = "") {
		this.email = email
		this.password = password
		this.rememberMe = rememberMe;
		this.code = code
	}
}

class ResponseModel {
	constructor(status, message) {
		this.status = status
		this.message = message
	}
}

class ResetModel {
	constructor(otpId, userId, guid, resetCode, password) {
		this.userId = userId
		this.otpId = otpId
		this.otp = resetCode
		this.guid = guid
		this.password = password
	}
}

class LoginInfo {
	constructor(longitude, latitude, dateTime, isOnline, isLoggedOut, ip) {
		this.longitude = longitude
		this.latitude = latitude
		this.dateTime = dateTime
		this.isOnline = isOnline
		this.isLoggedOut = isLoggedOut
		this.ip = ip
	}
}

class LoginAttemp {
	constructor(dateTime, reason, status) {
		this.dateTime = dateTime
		this.reason = reason
		this.status = status
	}
}

class User {
	constructor(userId, gender, firstname, lastname, email, username, password, dob, address, dateCreated, phone, image, loginInfos, loginAttemps) {
		this.userId = userId
		this.gender = gender
		this.firstName = firstname
		this.lastName = lastname
		this.email = email
		this.username = username
		this.password = password
		this.dob = dob
		this.address = address
		this.dateCreated = dateCreated
		this.phone = phone
		this.profileImage = image
		this.loginInfos = loginInfos
		this.loginAttemps = loginAttemps
	}
}

class AccountDetail {
	constructor(acId, userId, roleId, lastLogin, accountType, loginInfos, accountStatus, loginAttemps) {
		this.acId = acId
		this.userId = userId
		this.roleId = roleId
		this.lastLogin = lastLogin
		this.accountType = accountType
		this.loginInfo = loginInfos
		this.accountStatus = accountStatus
		this.loginAttemp = loginAttemps
		this.user = null
		this.role = null
		this.creators = []
	}
}

class Catalog {
	constructor(caption, description, image, data, catalogLink = 'not set') {
		this.catalogId = 0
		this.caption = caption
		this.description = description
		this.image = image
		this.data = data
		this.catalogLink = catalogLink
		this.userAchievements = []
		this.engagements = []
	}
}

const Level = [
	'Beginner',
	'Amateur',
	'Intermediate',
	'Professional',
	'GodLevel &#128516'
]

class Engagement {
	constructor(userId, catalogId) {
		this.engagementId = 0
		this.userId = userId
		this.catalogId = catalogId
		this.engagedDate = new Date()
		this.user = null
		this.catalog = null
	}
}

class Skill {
	constructor(skillId, name, level) {
		this.skillId = skillId
		this.name = name
		this.level = level
		this.userSkills = new Array()
	}
}

class UserSkill {
	constructor(userSkillId, skillId, userId, skill) {
		this.userSkillId = userSkillId
		this.skillId = skillId
		this.userId = userId
		this.skill = skill
		this.user = null
		this.userAchievements = []
	}
}

class Social {
	constructor(socialId, name, link) {
		this.socialId = socialId
		this.name = name
		this.link = link
		this.userSocials = []
	}
}

class UserSocial {
	constructor(userSocialId, socialId, userId, social) {
		this.userSocialId = userSocialId
		this.socialId = socialId
		this.userId = userId
		this.social = social
		this.user = null
	}
}

class Certificate {
	constructor(id, name, type, startDate, endDate, signedDate, platform, link) {
		this.cerficateId = id
		this.name = name
		this.type = name
		this.startDate = startDate
		this.endDate = endDate
		this.signedDate = signedDate
		this.platform = platform
		this.link = link
		this.userCertificates = []
	}
}

class ChapterQuiz {
	constructor(cqId, quizId, chapterId, authorId) {
		this.chapterQuizId = cqId
		this.quizId = quizId
		this.chapterId = chapterId
		this.dateCreated = Date.now()
		this.authorId = authorId
		this.author = null
		this.chapter = null
		this.quiz = null
	}
}

class Course {
	constructor(courseId, name, authorId, level) {
		this.courseId = courseId
		this.name = name
		this.dateCreated = Date.now()
		this.datePublished = Date.now()
		this.isPublished = false
		this.isOpen = false
		this.authorId = authorId
		this.level = level
		this.author = null
		this.enrollment = []
		this.courseChapters = []
		this.userCertificates = []
	}
}

class CourseChapter {
	constructor(cId, courseId, title, authorId, chapterNumber) {
		this.chapterId = cId
		this.courseId = courseId
		this.title = title
		this.author = authorId
		this.chapterNumber
		this.author = null
		this.course = null
		this.chapterQuizzes = []
		this.courseLessons = []
	}
}

class CourseContent {
	constructor(contentId, lessonId, authorId, num, title, content, note, link) {
		this.contentId = contentId
		this.lessonId = lessonId
		this.authorId = authorId
		this.contentNumber = num
		this.title = title
		this.content = content
		this.dateCreated = Date.now()
		this.note = note
		this.link = link
	}
}

class CourseDatum {
	constructor(dataId, enId, record) {
		this.dataId = dataId
		this.enrollmentId = enId
		this.startDate = Date.now()
		this.lastModified = Date.now()
		this.studyRecord = record
		this.enrollment = null
	}
}

class CourseLesson {
	constructor(lessonId, chapterId, authorId, topic, num) {
		this.lessonId = lessonId
		this.chapterId = chapterId
		this.authorId = authorId
		this.topic = topic
		this.dateCreated = dateCreated
		this.lessonNumber = num
		this.author = null
		this.chapter = null
		this.courseContents = []
	}
}

class Creator {
	constructor(authorId, accountId, roleId, status) {
		this.authorId = authorId
		this.accountId = accountId
		this.roleId = roleId
		this.status = status
		this.account = null
		this.role = null
		this.courseContents = []
		this.courseLessons = []
		this.courseChapters = []
		this.chapterQuizzes = []
		this.courses = []
		this.questions = []
		this.quizzes = []
	}
}

class Enrollment {
	constructor(enId, userId, courseId) {
		this.enrollmentId = enId
		this.userId = userId
		this.courseId = courseId
		this.course = null
		this.user = null
		this.courseData = []
		this.enrollmentQuizzes = []
		this.questionAnswerResponses = []
		this.userAchievements = []
	}
}

class EnrollmentQuiz {
	constructor(enrollmentQuizId, enrollmentId, quizId, dateTaken, passed, points, timeTaken) {
		this.enrollmentQuizId = enrollmentQuizId
		this.enrollmentId = enrollmentId
		this.quizId = quizId
		this.dateTaken = dateTaken
		this.passed = passed
		this.points = points
		this.timeTaken = timeTaken
		this.enrollmet = null
		this.quiz = null
	}
}

class Otp {
	constructor(otpId, userId, code, expiryDate) {
		this.otpId = otpId
		this.userId = userId
		this.code = code
		this.expiryDate = expiryDate
	}
}

class Project {
	constructor(projectId, userId, name, owner, desc, link, skillSet) {
		this.projectId = projectId
		this.userId = userId
		this.name = name
		this.owner = owner
		this.description = desc
		this.sourceLink = link
		this.skillSet = skillSet
	}
}

class Question {
	constructor(questionId, authorId, qusetion) {
		this.questionId = questionId
		this.authorId = authorId
		this.text = text
		this.author = null
		this.questionAnswerResponses = []
		this.questionAnswers = []
		this.quizQuestions = []
	}
}

class QuestionAnswer {
	constructor(questionAnswerId, questionId, answer, isCorrect = false) {
		this.questionAnswerId = questionAnswerId
		this.questionId = questionId
		this.answer = answer
		this.isCorrect = isCorrect
		this.question = question
		this.questionAnswerResponses = []
	}
}

class QuestionAnswerResponse {
	constructor(qarId, questionId, enrollmentId, questionAnswerId, timeAnswered) {
		this.questionAnswerResponseId = qarId
		this.questionId = questionId
		this.enrollmentId = enrollmentId
		this.questionAnswerId = questionAnswerId
		this.timeAnswered = timeAnswered
	}
}

class Quiz {
	constructor(quizId, authorId, dateCreated, quizCode = 0) {
		this.quizId = quizId
		this.authorId = authorId
		this.dateCreated = dateCreated
		this.quizCode = quizCode
		this.author = null
		this.chapterQuizzes = []
		this.enrollmentQuizzes = []
		this.quizQuestions = []
	}
}

class QuizQuestion {
	constructor(quizQuestionId, quizId, questionId) {
		this.quizQuestionId = quizQuestionId
		this.quizId = quizId
		this.questionId = questionId
		this.question = null
		this.quiz = null
	}
}

class Role {
	constructor(roleId, name, desc) {
		this.roleId = roleId
		this.name = name
		this.description = desc
		this.account = null
		this.creators = []
	}
}

class UserAchievement {
	constructor(uaId, achievementId, userId) {
		this.userAchievementId = uaId
		this.achievementId = achievementId
		this.userId = userId
		this.enrollmentId = null
		this.catalogId = null
		this.userSkillId = null
		this.languageId = null
		this.achievement = null
		this.catalog = null
		this.enrollment = null
		this.user = null
		this.userSkill = null
	}
}

class UserCertificate {
	constructor(userCertificateId, certId, userId, courseId = null) {
		this.userCertificateId = userCertificateId
		this.cerficateId = certId
		this.courseId = courseId
		this.userId = userId
		this.certificate = null
		this.course = null
		this.user = null
	}
}