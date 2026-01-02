-- =============================================
-- Seed Final Remaining Data
-- Content, Enrollments, Engagements, User Skills/Socials, OTPs, Notifications
-- =============================================

USE skillit;

SET FOREIGN_KEY_CHECKS = 0;

-- =============================================
-- 1. SEED COURSE CONTENT (17 records)
-- =============================================
INSERT INTO `course_content` (`contentID`, `lessonID`, `guid`, `authorID`, `content_number`, `title`, `video_link`, `content`, `date_created`, `last_modified`, `note`)
VALUES
(1, 1, '69e32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'History', '', 'HISTORY OF XAMARIN - Xamarin is an open-source development platform that extends .NET capability to build Android, iOS, tvOS, watchOS, macOS and Windows apps using C#. Xamarin is based on .NET with the libraries and runtime used to simplify the development of cross platform mobile native apps. It was founded in 2011, initially named as Mono which was later changed to Xamarin in May 2011 as a result of forking Mono to support Android and iOS platforms. Xamarin was acquired by Microsoft in February 2016 and released for free as open source mobile application.', '2023-02-09 11:49:26', '2023-02-13 12:55:21', ''),
(2, 1, '69a32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'The Evolution', '', '.NET MAUI is more or less a rewrite of Xamarin.Forms. Microsoft built .NET MAUI on top of Xamarin Forms but made numerous improvements that allow you to create cross-platform UI much more efficiently and consistently than ever before.', '2023-02-09 11:49:26', '2023-02-13 12:55:21', ''),
(3, 2, '69c32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'Your first MAUI App', '', 'Choose an ASP.NET Core web UI - ASP.NET Core is a complete UI framework. Razor Pages is a page-focused framework for building server-rendered HTML. Blazor is a component-based framework for building interactive client-side and server-side web UI with .NET.', '2023-02-12 07:42:27', '2023-02-13 12:55:21', ''),
(4, 2, '69b32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Debug on an Android emulator', 'https://www.youtube.com/watch?v=hVrwuMnCtok', 'The Android Emulator can be run in various configurations to simulate different Android devices. Each configuration is created as a virtual device. When you deploy and test your app, you select a preconfigured or custom virtual device that simulates a physical Android device such as a Pixel phone.', '2023-04-05 10:04:38', '2023-04-05 10:04:38', ''),
(5, 2, '69e32b1mn-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 3, 'Launching the Emulator', '', 'Near the top of Visual Studio, there is the Solution Configurations drop-down menu that can be used to select Debug or Release. Choosing Debug causes the debugger to attach to the application process running inside the emulator after the app starts, while choosing Release disables the debugger. For more information about release builds, see Understanding Xamarin.Android build types.', '2023-04-05 10:04:38', '2023-04-05 10:04:38', ''),
(6, 3, '69e32b1b-5105-45e7-a1x4-858927b2ea1e', 1661689919349, 1, 'How to enable hardware acceleration with Android emulators', '', 'This article explains how to use your computers hardware acceleration features to maximize Android Emulator performance. Virtual machine acceleration greatly improves the performance of the Android Emulator and is recommended. See how you can use VM acceleration, which hardware acceleration technologies are available, and how to enable them.', '2023-04-05 10:23:38', '2023-04-05 10:23:38', ''),
(7, 3, '69e32b1b-5105-45e7-a1a4-858927b2oi1e', 1661689919349, 2, 'Accelerating Android emulators on Windows', '', 'The following virtualization technologies are available for accelerating the Android emulator: 1) Microsofts Hyper-V and the Windows Hypervisor Platform (WHPX). Hyper-V is a virtualization feature of Windows that makes it possible to run virtualized computer systems on a physical host computer. 2) Intels Hardware Accelerated Execution Manager (HAXM). HAXM is a virtualization engine for computers running Intel CPUs.', '2023-04-05 10:23:38', '2023-04-05 10:23:38', ''),
(8, 4, '69e32b1b-5105-45e7-r1a4-858927b2ea1e', 1661689919349, 1, 'Build an iOS app with .NET CLI', '', 'In this tutorial, you will learn how to create and run a .NET MAUI app on iOS in a Mac Catalyst app using a Mac thats paired to Visual Studio 2022 on a Windows PC over a network or USB connection. All .NET MAUI apps for iOS must be built and deployed on a Mac, even if youre doing development on a PC. If you dont have a Mac, you can run your .NET MAUI iOS app on the iOS simulator.', '2023-04-05 10:28:26', '2023-04-05 10:28:26', ''),
(9, 4, '69z32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Launch the app on a specific simulator', '', 'A .NET MAUI iOS app can be launched on a specific iOS simulator with the dotnet build command, by specifying the target identifier and device identifier. To retrieve the list of installed simulators, open the Terminal and enter the following command: xcrun simctl list. The output from this command includes the unique device identifier (UDID) of each iOS simulator on your Mac.', '2023-04-05 10:28:27', '2023-04-05 10:28:27', ''),
(10, 5, '69e32b1b-5105-45w7-a1a4-858927b2ea1e', 1661689919349, 1, 'Deploy and debug your .NET MAUI app on Windows', '', 'You can use your local Windows development computer to deploy and debug a .NET MAUI app to a Windows desktop computer. The Windows app is deployed to the local desktop computer from Visual Studio by default. In Visual Studio, choose the Framework drop down and select net8.0-windows. Visual Studio may prompt you to turn on Developer Mode for Windows. Developer Mode for Windows enables you to sideload and test apps without deploying them through the Microsoft Store.', '2023-04-05 10:32:19', '2023-04-05 10:32:19', ''),
(11, 6, '69e78b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Build a Mac Catalyst app with .NET CLI', '', 'In this tutorial, you will learn how to create and run a .NET MAUI app on Mac Catalyst on a Mac using Visual Studio Code. To run and debug a .NET MAUI Mac Catalyst app in Visual Studio Code on a Mac, the C# Dev Kit is required. For more information, see Install C# Dev Kit for VS Code.', '2023-04-05 10:32:19', '2023-04-05 10:32:19', ''),
(12, 10, '69e32q1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'Create a custom control using handlers', '', 'A standard requirement for apps is the ability to play videos from web-based sources. However, .NET MAUI doesnt include a cross-platform control for playing videos. In this article, you will learn how to create a .NET MAUI cross-platform VideoPlayer control, by using the handler architecture, that can be used to play a video from a web source.', '2023-04-05 10:35:41', '2023-04-05 10:35:41', ''),
(13, 9, '69e32b1b-5105-45e7-a1a4-858427b2ea1v', 1661689919349, 1, 'ListView', '', 'The .NET MAUI ListView displays a scrollable vertical list of selectable data items. ListView is useful for displaying lists of data that require scrolling, particularly when the lists are long. Each item in a ListView is defined by a DataTemplate, which uses cells to display its data. .NET MAUI includes a number of cell types that represent different scenarios.', '2023-04-05 10:35:41', '2023-04-05 10:35:41', ''),
(14, 7, '69b32b1b-5105-45e7-a1a4-258927b2ea1e', 1661689919349, 1, 'Building app', 'https://www.youtube.com/watch?v=66tfvFeALBQ', '', '2023-04-05 10:41:52', '2023-04-05 10:41:52', ''),
(15, 8, '69e32b1b-5105-45e7-a1a4-858927b2rt1e', 1661689919349, 1, 'Creating App', 'https://www.youtube.com/playlist?list=PLPLcAzuCoR98L2Md7PiFtLhiz9PSURTPo', '', '2023-04-05 10:41:52', '2023-04-05 10:41:52', ''),
(16, 2, '69e92b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 4, 'Resources for learning .NET MAUI', '', 'There are many different resources available for you to use to learn .NET MAUI. This article provides a quick tour to the materials that can help you master .NET MAUI. Microsoft Learn provides free interactive training modules and guided projects to help you get started learning .NET MAUI.', '2023-04-05 12:15:16', '2023-04-05 12:15:16', ''),
(17, 9, '69e32b1b-5105-45e7-a1a4-858927b2tx1e', 1661689919349, 2, 'ContentView', '', 'The .NET MAUI ContentView is a control that enables the creation of custom, reusable controls. The ContentView class inherits from TemplatedView. The ContentView class defines a Content property, of type View, which represents the content of the ContentView. This property is backed by a BindableProperty object, which means that it can be the target of data bindings, and styled.', '2023-04-05 12:15:16', '2023-04-05 12:15:16', ''),
(19, 12, 'a98slkdgitkdsa-234pewjgpjdkww234as', 1661689919349, 1, 'Taking first steps', 'https://www.youtube.com/watch?v=s1bk-68aB1U', '', '2023-04-05 17:12:13', '2023-04-05 17:12:13', '');

-- =============================================
-- 2. SEED ENROLLMENTS (4 records)
-- =============================================
INSERT INTO `enrollment` (`enrollmentID`, `userID`, `courseID`, `date_enrolled`, `is_completed`, `date_completed`)
VALUES
(37, 1681811805905, 1, '2023-04-20 08:25:57', 0, '2023-04-20 08:25:57'),
(38, 1661689094366, 3, '2023-04-22 07:56:08', 0, '2023-04-22 07:56:08'),
(39, 1661689094366, 1, '2023-04-22 13:01:38', 0, '2023-04-22 13:01:38'),
(40, 1661689094366, 2, '2023-04-24 06:29:56', 0, '2023-04-24 06:29:56');

-- =============================================
-- 3. SEED ENGAGEMENTS (3 records)
-- =============================================
INSERT INTO `engagement` (`engagementID`, `userID`, `catalogID`, `engagedDate`, `completed`)
VALUES
(24, 1661689094366, 2, '2023-03-30', 0),
(25, 1661689094366, 6, '2023-04-04', 0),
(26, 1661689094366, 3, '2025-05-15', 0);

-- =============================================
-- 4. SEED USER SKILLS (15 records)
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
-- 5. SEED USER SOCIALS (12 records)
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
-- 6. SEED OTPs (9 records)
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
-- 7. SEED NOTIFICATIONS (12 records)
-- =============================================
INSERT INTO `notification` (`notificationId`, `notification_guid`, `accountId`, `caption`, `details`, `actions`, `icon`, `marked_as_read`, `date_created`, `date_read`)
VALUES
(1, 'ndsaieowrh0ionlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis in. Etiam Erat sed fringilla Ultricies. Ullamcorper Pellentesque placerat egestas in fermentum parturient Quisque senectus nullam, fringilla dis sapien. Mauris, rutrum amet viverra turpis dignissim, nostra.', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52', '2025-05-15 14:35:02'),
(4, 'ndsaieowrh0i23nlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis in. Etiam Erat sed fringilla Ultricies. Ullamcorper Pellentesque placerat egestas in fermentum parturient Quisque senectus nullam, fringilla dis sapien. Mauris, rutrum amet viverra turpis dignissim, nostra.', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52', '2023-04-15 22:51:46'),
(5, 'n56saieowrh0i23nlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis in. Etiam Erat sed fringilla Ultricies. Ullamcorper Pellentesque placerat egestas in fermentum parturient Quisque senectus nullam, fringilla dis sapien. Mauris, rutrum amet viverra turpis dignissim, nostra.', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2021-12-15 00:00:00', '2023-04-15 12:55:15'),
(6, 'n56saieowrh0i23nlkew9f0uo94a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis in. Etiam Erat sed fringilla Ultricies. Ullamcorper Pellentesque placerat egestas in fermentum parturient Quisque senectus nullam, fringilla dis sapien. Mauris, rutrum amet viverra turpis dignissim, nostra.', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52', '2023-05-20 13:14:54'),
(16, '4e3c7f6c-63b9-4e33-9535-90e1b0b55cae', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=34&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-18 09:25:49', '2023-05-20 12:47:22'),
(17, '65a4ff29-6dd6-4777-bb17-276379fc53f5', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=35&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-18 09:41:47', '2023-05-20 12:46:40'),
(18, 'e0ab7c71-9670-4e1e-a8a9-93e4773d6f20', 1, 'Course completed Alain!', 'Hoping you have learnt a lot from this course.', '[{\"Name\":\"More courses\",\"Description\":null,\"Command\":\"/courses\"}]', 'notify.png', 1, '2023-04-18 09:45:45', '2023-05-05 15:01:06'),
(26, '67798545-43be-4988-b55b-18c72ef267ad', 18, 'Actions required The!', 'Please visit your dashboard and complete your profile setup.', '[{\"Name\":\"Dashboard\",\"Description\":null,\"Command\":\"/user/dashboard\"}]', 'notify.png', 1, '2023-04-18 09:56:46', '2023-04-20 08:21:12'),
(27, 'ef64dc82-b04b-42de-b1e4-fc2e6551d2e2', 18, 'Welcome The to Skill-IT', 'Welcome and thank you for signing up on the Skill-IT website.', '[{\"Name\":\"Catalogs\",\"Description\":null,\"Command\":\"/catalogs\"}]', 'notify.png', 1, '2023-04-18 09:56:46', '2023-04-20 07:21:03'),
(28, 'a3697a66-aa68-462b-b346-c9a038656a33', 18, 'The verify email', 'Your account is not yet verified.', '[]', 'notify.png', 1, '2023-04-18 09:56:46', '2023-04-20 08:21:02'),
(29, 'd910179d-cf12-47e8-a680-398dd9e13ed0', 18, 'Course registered The!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=37&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-20 07:25:57', '2023-04-20 08:21:16'),
(30, '7b83fa57-de89-4d7d-bb99-b59231d22f0f', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=39&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-22 12:01:38', '2025-05-15 14:35:14');

SET FOREIGN_KEY_CHECKS = 1;

-- =============================================
-- VERIFICATION
-- =============================================
SELECT 'Content seeded:' as Status, COUNT(*) as Count FROM course_content;
SELECT 'Enrollments seeded:' as Status, COUNT(*) as Count FROM enrollment;
SELECT 'Engagements seeded:' as Status, COUNT(*) as Count FROM engagement;
SELECT 'User Skills seeded:' as Status, COUNT(*) as Count FROM user_skill;
SELECT 'User Socials seeded:' as Status, COUNT(*) as Count FROM user_social;
SELECT 'OTPs seeded:' as Status, COUNT(*) as Count FROM otp;
SELECT 'Notifications seeded:' as Status, COUNT(*) as Count FROM notification;
