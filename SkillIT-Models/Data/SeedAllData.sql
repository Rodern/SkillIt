-- =============================================
-- Comprehensive Data Seeding Script for SkillIT
-- Source: skill_it_db (16).sql
-- Target: skillit database (Code-First schema)
-- =============================================

USE skillit;

-- Disable foreign key checks temporarily
SET FOREIGN_KEY_CHECKS = 0;

-- =============================================
-- 1. SEED USERS (8 records)
-- =============================================
INSERT INTO `user` (`userID`, `gender`, `first_name`, `last_name`, `email`, `username`, `password`, `dob`, `address`, `date_created`, `phone`, `profile_image`)
VALUES
(1661689094366, 0, 'Alain', 'Kimbu', 'k.n.alain@gmail.com', 'Aprilman', 'AE1t3CWEYAqaIE0ISiCol6N8m+YsEvPO1Dq3WRn+G7pkYvMEjp3vOe/dOutAcQr84g==', '2022-08-28', 'Bambui, NorthWest Cameroon', '2022-08-28 12:18:14', '651008132', '1661689094366_k.n.alain@gmail.com_profileImage.png'),
(1661689919349, 0, 'Alain', 'Kimbu', 'i.am@mail.com', 'ak2000', 'AOEEDhsuyl6lTjWbPvo5VhArqeGuOrrv8CQdgBQNlHkzQTjeJMAow1xCBE+kwSwUqg==', '2022-08-28', 'Address', '2022-08-28 12:31:59', '623012523', ''),
(1663957971467, 0, 'Bradon', 'Ted', 'ted.bradon@mail.com', 'bradon', 'AAbhkMr741DvERk3DOG5S31cOQN/DUdbp5WJ4OQIQG42z0+FoNhyFqRBK6XG41Yq9w==', '0001-01-01', 'Bambui, NorthWest Cameroon', '2022-09-23 18:32:51', '623948023', ''),
(1668679350122, 0, 'Alain', 'Kimbu', 'nik.alain@gmail.com', 'kan23', 'AP/aIdz5B3LmJ3WhsLsGIlTI0cnYr28/X3mZ43Q8NUm4oNB0Qmgigqy6P008JYlEjw==', '2000-04-29', 'Bambui, Mile 10 mattam quarter', '2022-11-17 10:02:30', '651008132', ''),
(1671885852119, 1, 'Rousanne', 'Ngam', 'rousy@gmail.com', 'Rousy', 'AH8WYbZYe3Vrs8twBnFYW3Yz5nrRdls+rCKprTJ8NOrFfZNn6TuvqMU76ewtEAkzCw==', '2001-04-09', 'Bambui, Mile 10 mattam quarter', '2022-12-24 12:44:12', '670312417', '1671885852119_rousy@gmail.com_profileImage.png'),
(1677925925595, 0, 'Randy', 'King', 'randy.king@email.com', 'King_R', 'AFveUqywGJGRUy6qINcpdHlZ4kolQxsYubNOQX8jhQHq5Ehjk8QsZK928aqJOhqcSQ==', '1993-04-14', 'Bamenda Cameroon', '2023-03-04 10:32:05', '651008132', '1677925925595_randy.king@email.com_profileImage.png'),
(1678544061950, 0, 'Lord', 'Kimbu', 'lordkimbu@gmail.com', 'Lord_K', 'AI5F6F59KvyQUnGmKUA/OverOK465h/P8jiFFRpAC5EtXvIHd7Yt/A487/QfejqulA==', '2000-02-16', 'Bambui, NorthWest Cameroon', '2023-03-11 14:14:22', '651008132', '1678544061950_lordkimbu@gmail.com_profileImage.png'),
(1681811805905, 0, 'The', 'Name', 'test@gmail.com', 'test_guy', 'AEGdiiEK0i1hb1h18J9rLIfabiZLdRbDjF4ooiFHtQjSN4r3ox3gx9nLVXpFVq8Ujg==', '2023-04-18', 'Address', '2023-04-18 09:56:46', '673801740', '');

-- =============================================
-- 2. SEED ACCOUNTS (8 records)
-- Note: status enum: 0=ACTIVE, 1=PASSIVE, 2=VERIFIED, 3=NOT_VERIFIED
-- accountType enum: 0=admin, 1=user
-- =============================================
INSERT INTO `account` (`accountID`, `userID`, `accountType`, `roleID`, `last_login`, `login_info`, `status`, `login_attemp`)
VALUES
(1, 1661689094366, 0, 2, '2022-08-28 13:18:14', '[{\"Longitude\":\"1661689094366\",\"Latitude\":\"1661689094366\",\"DateTime\":\"2022-08-28T12:18:14.366Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"154.72.169.139\"}]', 3, '[{\"DateTime\":\"2022-08-28T12:18:14.366Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]'),
(3, 1661689919349, 1, 1, '2022-08-28 13:31:59', '[{\"Longitude\":\"1661689919349\",\"Latitude\":\"1661689919349\",\"DateTime\":\"2022-08-28T12:31:59.349Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"154.72.169.139\"}]', 3, '[{\"DateTime\":\"2022-08-28T12:31:59.349Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]'),
(4, 1663957971467, 1, 3, '2022-09-23 18:32:53', '[{\"Longitude\":\"10.1667\",\"Latitude\":\"5.9333\",\"DateTime\":\"2022-09-23T18:32:51.467Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.253\"}]', 3, '[{\"DateTime\":\"2022-09-23T18:32:51.467Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]'),
(6, 1668679350122, 1, 1, '2022-11-17 11:02:30', '[{\"Longitude\":\"1668679350122\",\"Latitude\":\"1668679350122\",\"DateTime\":\"2022-11-17T10:02:30.122Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.184\"}]', 3, '[{\"DateTime\":\"2022-11-17T10:02:30.122Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]'),
(7, 1671885852119, 1, 2, '2022-12-24 13:44:24', '[{\"Longitude\":\"1671885852119\",\"Latitude\":\"1671885852119\",\"DateTime\":\"2022-12-24T12:44:12.119Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.245\"}]', 3, '[{\"DateTime\":\"2022-12-24T12:44:12.119Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]'),
(9, 1677925925595, 1, 1, '2023-03-04 11:32:06', '[{\"Longitude\":\"1677925925595\",\"Latitude\":\"1677925925595\",\"DateTime\":\"2023-03-04T10:32:05.595Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.157\"}]', 3, '[{\"DateTime\":\"2023-03-04T10:32:05.595Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]'),
(15, 1678544061950, 1, 1, '2023-03-11 14:14:22', '[{\"Longitude\":\"4.6628\",\"Latitude\":\"52.3952\",\"DateTime\":\"2023-03-11T14:14:21.95Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"51.15.5.5\"}]', 3, '[{\"DateTime\":\"2023-03-11T14:14:21.95Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]'),
(18, 1681811805905, 1, 1, '2023-04-18 09:56:46', '[{\"Longitude\":\"10.146\",\"Latitude\":\"5.9597\",\"DateTime\":\"2023-04-18T09:56:45.906Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.239\"}]', 3, '[{\"DateTime\":\"2023-04-18T09:56:45.906Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]');

-- =============================================
-- 3. SEED CREATOR (1 record)
-- =============================================
INSERT INTO `creator` (`authorID`, `accountID`, `roleID`, `status`)
VALUES
(1661689919349, 1, 2, 0);

-- =============================================
-- 4. SEED COURSES (3 records)
-- =============================================
INSERT INTO `course` (`courseID`, `guid`, `name`, `description`, `date_created`, `last_modified`, `date_publish`, `is_published`, `is_open`, `authorID`, `level`, `cover_image`)
VALUES
(1, '3024u5nirjt04io5w0etiokqt03o', '.NET MAUI for beginners', 'Overview of ASP.NET Core - ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps.', '2023-01-13 15:20:10', '2023-02-13 12:55:21', '2023-01-13 15:20:10', 0, 1, 1661689919349, 0, 'default.png'),
(2, 'lk8403riojd90ol0sd9goiwtlsd80to', 'Java SE - Springboot Advanced', 'Spring Boot is one of the Java-based application development platforms, particularly known for creating microservices and online programs.', '2023-02-23 19:32:53', '2023-02-23 19:32:53', '2023-02-23 19:32:53', 0, 1, 1661689919349, 1, 'default.png'),
(3, 'eowirio0i23orj90sj23or0aow3r3', 'E-Commerce with NodeJs and MongoDB', 'MongoDB and Node.js work seamlessly together in modern tech stacks. Learn how to set up Node.js and MongoDB.', '2023-02-23 19:32:53', '2023-02-23 19:32:53', '2023-02-23 19:32:53', 0, 1, 1661689919349, 0, 'default.png');

-- =============================================
-- 5. SEED COURSE CHAPTERS (5 records)
-- =============================================
INSERT INTO `course_chapter` (`chapterID`, `courseID`, `guid`, `title`, `date_created`, `last_modified`, `authorID`, `chapter_number`)
VALUES
(1, 1, '69e32b1b-5105-45e7-a1a4-858927b2ierwt1e', 'Introduction', '2023-01-13 15:22:05', '2023-02-13 12:55:21', 1661689919349, 1),
(2, 1, '69e32b1ri-5105-45e7-a1a4-858927b2ea1e', 'Building Apps', '2023-01-13 15:22:05', '2023-02-13 12:55:21', 1661689919349, 2),
(3, 1, '69e32b1b-5105-45e7-a1a4-858927b2ea1e343', 'Platform Configurations', '2023-04-05 09:50:50', '2023-04-05 09:50:50', 1661689919349, 3),
(4, 1, '64e32b1b-5105-45e7-a1a4-858927b2ea1e', 'MAUI Widgets', '2023-04-05 09:50:50', '2023-04-05 09:50:50', 1661689919349, 4),
(6, 1, 'lkjdhafs;klniniaonrgkh043', 'Testing Your MAUI App', '2023-04-05 17:10:03', '2023-04-05 17:10:03', 1661689919349, 5);

-- =============================================
-- 6. SEED COURSE LESSONS (11 records)
-- =============================================
INSERT INTO `course_lesson` (`lessonID`, `topic`, `chapterID`, `guid`, `authorID`, `date_created`, `last_modified`, `lesson_number`)
VALUES
(1, '.NET MAUI and History', 1, '69e32b1b-5105-45e7-a1a4-858927b2ea1p', 1661689919349, '2023-01-13 15:24:30', '2023-02-13 12:55:21', 1),
(2, 'Getting started with .NET MAUI', 1, '69e32b1b-5105-45e7-g1a4-858927b2ea1e', 1661689919349, '2023-02-03 22:04:48', '2023-02-13 12:55:21', 2),
(3, 'Configuring .NET MAUI for Android', 3, '69e32b1b-5105-45er7-a1a4-858927b2ea1e', 1661689919349, '2023-04-05 09:53:43', '2023-04-05 09:53:43', 1),
(4, 'Configuring .NET MAUI for IOS', 3, '69e32b1b-5195-45e7-a1a4-858927b2ea1e', 1661689919349, '2023-04-05 09:53:43', '2023-04-05 09:53:43', 2),
(5, 'Configuring .NET MAUI for Windows', 3, '69e32b1u-5105-45e7-a1a4-856927b2ea1e', 1661689919349, '2023-04-05 09:53:43', '2023-04-05 09:53:43', 3),
(6, 'Configuring .NET MAUI for Mac', 3, '69e32b1b-5105-45uo7-a1a4-858927b2ea1e', 1661689919349, '2023-04-05 09:53:43', '2023-04-05 09:53:43', 4),
(7, 'Build A Todo App', 2, '69e32b1b-9805-45e7-a1a4-858927b2ea1e', 1661689919349, '2023-04-05 09:56:43', '2023-04-05 09:56:43', 1),
(8, 'Build A Phone Book App', 2, '63e32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, '2023-04-05 09:56:43', '2023-04-05 09:56:43', 2),
(9, 'ListView and CollectionView', 4, '69e32b1b-5105-45e7-a1a4-858927b2ea1k', 1661689919349, '2023-04-05 09:58:18', '2023-04-05 09:58:18', 1),
(10, 'Buttons and Click controls', 4, '69e32b1b-5105-45e7-a1a4-858927b2ea1j', 1661689919349, '2023-04-05 09:58:18', '2023-04-05 09:58:18', 2),
(12, 'Unit Test a .NET MAUI App', 6, 'afod9orhk0sdtiowejf90aetkweiu0', 1661689919349, '2023-04-05 17:11:16', '2023-04-05 17:11:16', 1);

-- =============================================
-- 7. SEED COURSE CONTENT (17 records - truncated descriptions for readability)
-- =============================================
INSERT INTO `course_content` (`contentID`, `lessonID`, `guid`, `authorID`, `content_number`, `title`, `video_link`, `content_text`, `date_created`, `last_modified`, `note`)
VALUES
(1, 1, '69e32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'History', '', 'HISTORY OF XAMARIN - Xamarin is an open-source development platform that extends .NET capability...', '2023-02-09 11:49:26', '2023-02-13 12:55:21', ''),
(2, 1, '69a32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'The Evolution', '', '.NET MAUI is more or less a rewrite of Xamarin.Forms...', '2023-02-09 11:49:26', '2023-02-13 12:55:21', ''),
(3, 2, '69c32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'Your first MAUI App', '', 'Choose an ASP.NET Core web UI - ASP.NET Core is a complete UI framework...', '2023-02-12 07:42:27', '2023-02-13 12:55:21', ''),
(4, 2, '69b32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Debug on an Android emulator', 'https://www.youtube.com/watch?v=hVrwuMnCtok', 'The Android Emulator can be run in various configurations...', '2023-04-05 10:04:38', '2023-04-05 10:04:38', ''),
(5, 2, '69e32b1mn-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 3, 'Launching the Emulator', '', 'Near the top of Visual Studio, there is the Solution Configurations drop-down menu...', '2023-04-05 10:04:38', '2023-04-05 10:04:38', ''),
(6, 3, '69e32b1b-5105-45e7-a1x4-858927b2ea1e', 1661689919349, 1, 'How to enable hardware acceleration with Android emulators', '', 'This article explains how to use your computers hardware acceleration features...', '2023-04-05 10:23:38', '2023-04-05 10:23:38', ''),
(7, 3, '69e32b1b-5105-45e7-a1a4-858927b2oi1e', 1661689919349, 2, 'Accelerating Android emulators on Windows', '', 'The following virtualization technologies are available...', '2023-04-05 10:23:38', '2023-04-05 10:23:38', ''),
(8, 4, '69e32b1b-5105-45e7-r1a4-858927b2ea1e', 1661689919349, 1, 'Build an iOS app with .NET CLI', '', 'In this tutorial, you will learn how to create and run a .NET MAUI app on iOS...', '2023-04-05 10:28:26', '2023-04-05 10:28:26', ''),
(9, 4, '69z32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Launch the app on a specific simulator', '', 'A .NET MAUI iOS app can be launched on a specific iOS simulator...', '2023-04-05 10:28:27', '2023-04-05 10:28:27', ''),
(10, 5, '69e32b1b-5105-45w7-a1a4-858927b2ea1e', 1661689919349, 1, 'Deploy and debug your .NET MAUI app on Windows', '', 'You can use your local Windows development computer to deploy and debug...', '2023-04-05 10:32:19', '2023-04-05 10:32:19', ''),
(11, 6, '69e78b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Build a Mac Catalyst app with .NET CLI', '', 'In this tutorial, you will learn how to create and run a .NET MAUI app on Mac Catalyst...', '2023-04-05 10:32:19', '2023-04-05 10:32:19', ''),
(12, 10, '69e32q1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'Create a custom control using handlers', '', 'A standard requirement for apps is the ability to play videos...', '2023-04-05 10:35:41', '2023-04-05 10:35:41', ''),
(13, 9, '69e32b1b-5105-45e7-a1a4-858427b2ea1v', 1661689919349, 1, 'ListView', '', 'The .NET MAUI ListView displays a scrollable vertical list of selectable data items...', '2023-04-05 10:35:41', '2023-04-05 10:35:41', ''),
(14, 7, '69b32b1b-5105-45e7-a1a4-258927b2ea1e', 1661689919349, 1, 'Building app', 'https://www.youtube.com/watch?v=66tfvFeALBQ', '', '2023-04-05 10:41:52', '2023-04-05 10:41:52', ''),
(15, 8, '69e32b1b-5105-45e7-a1a4-858927b2rt1e', 1661689919349, 1, 'Creating App', 'https://www.youtube.com/playlist?list=PLPLcAzuCoR98L2Md7PiFtLhiz9PSURTPo', '', '2023-04-05 10:41:52', '2023-04-05 10:41:52', ''),
(16, 2, '69e92b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 4, 'Resources for learning .NET MAUI', '', 'There are many different resources available for you to use to learn .NET MAUI...', '2023-04-05 12:15:16', '2023-04-05 12:15:16', ''),
(17, 9, '69e32b1b-5105-45e7-a1a4-858927b2tx1e', 1661689919349, 2, 'ContentView', '', 'The .NET MAUI ContentView is a control that enables the creation of custom, reusable controls...', '2023-04-05 12:15:16', '2023-04-05 12:15:16', ''),
(19, 12, 'a98slkdgitkdsa-234pewjgpjdkww234as', 1661689919349, 1, 'Taking first steps', 'https://www.youtube.com/watch?v=s1bk-68aB1U', '', '2023-04-05 17:12:13', '2023-04-05 17:12:13', '');

-- =============================================
-- 8. SEED ENROLLMENTS (4 records)
-- =============================================
INSERT INTO `enrollment` (`enrollmentID`, `userID`, `courseID`, `date_enrolled`, `is_completed`, `date_completed`)
VALUES
(37, 1681811805905, 1, '2023-04-20 08:25:57', 0, '2023-04-20 08:25:57'),
(38, 1661689094366, 3, '2023-04-22 07:56:08', 0, '2023-04-22 07:56:08'),
(39, 1661689094366, 1, '2023-04-22 13:01:38', 0, '2023-04-22 13:01:38'),
(40, 1661689094366, 2, '2023-04-24 06:29:56', 0, '2023-04-24 06:29:56');

-- =============================================
-- 9. SEED ENGAGEMENTS (3 records)
-- =============================================
INSERT INTO `engagement` (`engagementID`, `userID`, `catalogID`, `engagedDate`, `completed`)
VALUES
(24, 1661689094366, 2, '2023-03-30', 0),
(25, 1661689094366, 6, '2023-04-04', 0),
(26, 1661689094366, 3, '2025-05-15', 0);

-- =============================================
-- 10. SEED USER SKILLS (18 records)
-- =============================================
INSERT INTO `user_skill` (`user_skillID`, `skillID`, `userID`)
VALUES
(1, 1, 1661689919349),
(2, 2, 1661689919349),
(3, 3, 1661689919349),
(4, 4, 1661689094366),
(5, 5, 1663957971467),
(7, 7, 1663957971467),
(9, 9, 1661689094366),
(11, 11, 1671885852119),
(12, 12, 1671885852119),
(13, 1, 1671885852119),
(14, 2, 1678544061950),
(15, 3, 1678544061950),
(16, 4, 1678544061950),
(17, 5, 1661689094366),
(18, 6, 1661689094366);

-- =============================================
-- 11. SEED USER SOCIALS (15 records)
-- =============================================
INSERT INTO `user_social` (`user_socialID`, `socialID`, `userID`)
VALUES
(1, 1, 1661689919349),
(5, 5, 1661689919349),
(6, 6, 1661689094366),
(7, 1, 1663957971467),
(8, 2, 1671885852119),
(9, 3, 1661689094366),
(10, 4, 1678544061950),
(11, 5, 1678544061950),
(12, 6, 1678544061950),
(13, 1, 1678544061950),
(14, 2, 1661689094366),
(15, 3, 1661689094366);

-- =============================================
-- 12. SEED OTPs (8 records)
-- =============================================
INSERT INTO `otp` (`otpID`, `code`, `expiryDate`, `userId`, `guid`)
VALUES
(17, 122886, '2023-03-07', 1671885852119, '6d1e0444-7bd5-4494-8245-2093bb56633f'),
(18, 265709, '2023-03-07', 1671885852119, '51fb9e86-ee5b-475d-a28c-d33dac5cff1a'),
(19, 444858, '2023-03-07', 1671885852119, 'c4ccd274-d78f-4eb2-851c-a92181c201cc'),
(20, 687774, '2023-03-07', 1671885852119, '9ad93627-6078-4bf7-9a78-fb24d50e695a'),
(22, 75251, '2023-05-11', 1661689094366, '3c29411d-3bc9-4845-9771-96df4e3fdf06'),
(23, 366145, '2023-05-11', 1678544061950, '2ea966eb-548f-48b7-81d3-e43dec75fb49'),
(24, 523017, '2023-03-12', 1678544061950, 'd50b2ee1-f281-45a7-9bb9-08604ceafdfd'),
(27, 904757, '2023-06-18', 1681811805905, 'd0d37f06-8785-43ff-a173-40e049a2f0fe'),
(28, 915756, '2026-02-28', 1677925925595, '4ab5b9c3-7ae0-4e92-a3d0-33f3254c2ae8');

-- =============================================
-- 13. SEED NOTIFICATIONS (18 records - truncated text for readability)
-- =============================================
INSERT INTO `notification` (`notificationId`, `notification_guid`, `accountId`, `caption`, `details`, `actions`, `icon`, `marked_as_read`, `date_created`, `date_read`)
VALUES
(1, 'ndsaieowrh0ionlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis...', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52', '2025-05-15 14:35:02'),
(4, 'ndsaieowrh0i23nlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum...', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52', '2023-04-15 22:51:46'),
(5, 'n56saieowrh0i23nlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At...', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2021-12-15 00:00:00', '2023-04-15 12:55:15'),
(6, 'n56saieowrh0i23nlkew9f0uo94a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum...', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52', '2023-05-20 13:14:54'),
(16, '4e3c7f6c-63b9-4e33-9535-90e1b0b55cae', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=34&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-18 09:25:49', '2023-05-20 12:47:22'),
(17, '65a4ff29-6dd6-4777-bb17-276379fc53f5', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=35&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-18 09:41:47', '2023-05-20 12:46:40'),
(18, 'e0ab7c71-9670-4e1e-a8a9-93e4773d6f20', 1, 'Course completed Alain!', 'Hoping you have learnt a lot from this course.', '[{\"Name\":\"More courses\",\"Description\":null,\"Command\":\"/courses\"}]', 'notify.png', 1, '2023-04-18 09:45:45', '2023-05-05 15:01:06'),
(26, '67798545-43be-4988-b55b-18c72ef267ad', 18, 'Actions required The!', 'Please visit your dashboard and complete your profile setup.', '[{\"Name\":\"Dashboard\",\"Description\":null,\"Command\":\"/user/dashboard\"}]', 'notify.png', 1, '2023-04-18 09:56:46', '2023-04-20 08:21:12'),
(27, 'ef64dc82-b04b-42de-b1e4-fc2e6551d2e2', 18, 'Welcome The to Skill-IT', 'Welcome and thank you for signing up on the Skill-IT website.', '[{\"Name\":\"Catalogs\",\"Description\":null,\"Command\":\"/catalogs\"}]', 'notify.png', 1, '2023-04-18 09:56:46', '2023-04-20 07:21:03'),
(28, 'a3697a66-aa68-462b-b346-c9a038656a33', 18, 'The verify email', 'Your account is not yet verified.', '[]', 'notify.png', 1, '2023-04-18 09:56:46', '2023-04-20 08:21:02'),
(29, 'd910179d-cf12-47e8-a680-398dd9e13ed0', 18, 'Course registered The!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=37&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-20 07:25:57', '2023-04-20 08:21:16'),
(30, '7b83fa57-de89-4d7d-bb99-b59231d22f0f', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=39&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-22 12:01:38', '2025-05-15 14:35:14');

-- =============================================
-- Re-enable foreign key checks
-- =============================================
SET FOREIGN_KEY_CHECKS = 1;

-- =============================================
-- VERIFICATION QUERIES
-- =============================================
SELECT 'Users seeded:' as Status, COUNT(*) as Count FROM user;
SELECT 'Accounts seeded:' as Status, COUNT(*) as Count FROM account;
SELECT 'Creators seeded:' as Status, COUNT(*) as Count FROM creator;
SELECT 'Courses seeded:' as Status, COUNT(*) as Count FROM course;
SELECT 'Chapters seeded:' as Status, COUNT(*) as Count FROM course_chapter;
SELECT 'Lessons seeded:' as Status, COUNT(*) as Count FROM course_lesson;
SELECT 'Content seeded:' as Status, COUNT(*) as Count FROM course_content;
SELECT 'Enrollments seeded:' as Status, COUNT(*) as Count FROM enrollment;
SELECT 'Engagements seeded:' as Status, COUNT(*) as Count FROM engagement;
SELECT 'User Skills seeded:' as Status, COUNT(*) as Count FROM user_skill;
SELECT 'User Socials seeded:' as Status, COUNT(*) as Count FROM user_social;
SELECT 'OTPs seeded:' as Status, COUNT(*) as Count FROM otp;
SELECT 'Notifications seeded:' as Status, COUNT(*) as Count FROM notification;

-- =============================================
-- END OF SEED SCRIPT
-- =============================================
