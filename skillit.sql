-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 12, 2026 at 06:01 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `skillit`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `accountID` bigint(20) NOT NULL,
  `userID` bigint(20) NOT NULL,
  `roleID` bigint(20) NOT NULL,
  `accountType` int(11) NOT NULL,
  `status` int(11) NOT NULL,
  `last_login` datetime(6) DEFAULT NULL,
  `last_logout` datetime(6) DEFAULT NULL,
  `login_info` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`login_info`)),
  `login_attemp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`login_attemp`)),
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`accountID`, `userID`, `roleID`, `accountType`, `status`, `last_login`, `last_logout`, `login_info`, `login_attemp`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1, 1661689094366, 2, 0, 3, '2022-08-28 13:18:14.000000', NULL, '[{\"Longitude\":\"1661689094366\",\"Latitude\":\"1661689094366\",\"DateTime\":\"2022-08-28T12:18:14.366Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"154.72.169.139\"}]', '[{\"DateTime\":\"2022-08-28T12:18:14.366Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(3, 1661689919349, 1, 1, 3, '2022-08-28 13:31:59.000000', NULL, '[{\"Longitude\":\"1661689919349\",\"Latitude\":\"1661689919349\",\"DateTime\":\"2022-08-28T12:31:59.349Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"154.72.169.139\"}]', '[{\"DateTime\":\"2022-08-28T12:31:59.349Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(4, 1663957971467, 3, 1, 3, '2022-09-23 18:32:53.000000', NULL, '[{\"Longitude\":\"10.1667\",\"Latitude\":\"5.9333\",\"DateTime\":\"2022-09-23T18:32:51.467Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.253\"}]', '[{\"DateTime\":\"2022-09-23T18:32:51.467Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(6, 1668679350122, 1, 1, 3, '2022-11-17 11:02:30.000000', NULL, '[{\"Longitude\":\"1668679350122\",\"Latitude\":\"1668679350122\",\"DateTime\":\"2022-11-17T10:02:30.122Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.184\"}]', '[{\"DateTime\":\"2022-11-17T10:02:30.122Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(7, 1671885852119, 2, 1, 3, '2022-12-24 13:44:24.000000', NULL, '[{\"Longitude\":\"1671885852119\",\"Latitude\":\"1671885852119\",\"DateTime\":\"2022-12-24T12:44:12.119Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.245\"}]', '[{\"DateTime\":\"2022-12-24T12:44:12.119Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(9, 1677925925595, 1, 1, 3, '2023-03-04 11:32:06.000000', NULL, '[{\"Longitude\":\"1677925925595\",\"Latitude\":\"1677925925595\",\"DateTime\":\"2023-03-04T10:32:05.595Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.157\"}]', '[{\"DateTime\":\"2023-03-04T10:32:05.595Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(15, 1678544061950, 1, 1, 3, '2023-03-11 14:14:22.000000', NULL, '[{\"Longitude\":\"4.6628\",\"Latitude\":\"52.3952\",\"DateTime\":\"2023-03-11T14:14:21.95Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"51.15.5.5\"}]', '[{\"DateTime\":\"2023-03-11T14:14:21.95Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(18, 1681811805905, 1, 1, 3, '2023-04-18 09:56:46.000000', NULL, '[{\"Longitude\":\"10.146\",\"Latitude\":\"5.9597\",\"DateTime\":\"2023-04-18T09:56:45.906Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.239\"}]', '[{\"DateTime\":\"2023-04-18T09:56:45.906Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `achievement`
--

CREATE TABLE `achievement` (
  `achievementID` bigint(20) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` varchar(500) NOT NULL,
  `type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `catalog`
--

CREATE TABLE `catalog` (
  `catalogID` bigint(20) NOT NULL,
  `title` varchar(250) NOT NULL,
  `image_url` varchar(500) NOT NULL,
  `image_thumbnail_url` varchar(500) DEFAULT NULL,
  `data` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`data`)),
  `descriptions` text NOT NULL,
  `link` text NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `catalog`
--

INSERT INTO `catalog` (`catalogID`, `title`, `image_url`, `image_thumbnail_url`, `data`, `descriptions`, `link`, `date_created`, `last_modified`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1, '.Net MAUI For Beginners', 'https://i.ytimg.com/vi/Hh279ES_FNQ/maxresdefault.jpg', 'https://i.ytimg.com/vi/Hh279ES_FNQ/hqdefault.jpg', '{\"title\":\"What is .NET MAUI? [1 of 8] | .NET MAUI for Beginners\",\"author_name\":\"dotnet\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/Hh279ES_FNQ/hqdefault.jpg\"}', 'Welcome to the .NET MAUI for Beginners series where you will learn the basics of building multi-platform apps with .NET MAUI for iOS, Android, macOS, and Windows from a shared C# codebase.', 'https://youtu.be/Hh279ES_FNQ?list=PLdo4fOcmZ0oUBAdL2NwBpDs32zwGqb9DY', '2026-01-02 17:05:31.000000', '2026-01-02 17:05:31.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(2, 'Suggestion Site App', 'https://i.ytimg.com/vi/eEyAKk4NeSg/maxresdefault.jpg', 'https://i.ytimg.com/vi/eEyAKk4NeSg/hqdefault.jpg', '{\"title\":\"Suggestion Site App\",\"author_name\":\"IAmTimCorey\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/eEyAKk4NeSg/hqdefault.jpg\"}', 'Welcome to the course on building a Suggestion Site App. In this course, we are going to design, build, and test a production-ready application using C#. This course is sponsored by MongoDB.', 'https://www.youtube.com/playlist?list=PLLWMQd6PeGY0cZFMqx5ijmdaD87sJKCsU', '2026-01-02 17:05:31.000000', '2026-01-02 17:05:31.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(3, 'Blazor on Desktop: PWA, Electron or .NET MAUI', 'https://i.ytimg.com/vi/2MxfNrtx2l8/maxresdefault.jpg', 'https://i.ytimg.com/vi/2MxfNrtx2l8/hqdefault.jpg', '{\"title\":\"Blazor on Desktop: PWA, Electron or .NET MAUI - Sam Basu\",\"author_name\":\"Dotnet Frontend Day\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/2MxfNrtx2l8/hqdefault.jpg\"}', 'The desire to see web technologies power experiences on mobile/desktop is nothing new. With Blazor, developers get to build modern web apps with C#/.NET, running on the server or fully client-side through WebAssembly.', 'https://www.youtube.com/watch?v=2MxfNrtx2l8', '2026-01-02 17:05:31.000000', '2026-01-02 17:05:31.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(4, 'How to ACTUALLY learn to code... 7 Roadmaps for 2023', 'https://i.ytimg.com/vi/66tfvFeALBQ/maxresdefault.jpg', 'https://i.ytimg.com/vi/66tfvFeALBQ/hqdefault.jpg', '{\"title\":\"How to ACTUALLY learn to code... 7 Roadmaps for 2023\",\"author_name\":\"Fireship\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/66tfvFeALBQ/hqdefault.jpg\"}', 'Explore 7 roadmaps or learning paths for beginner developers. The goal of this video is to provide a starting point for aspiring software engineers looking to learn web development, mobile, desktop, IoT, data science, game dev, and low-level systems.', 'https://www.youtube.com/watch?v=66tfvFeALBQ', '2026-01-02 17:05:31.000000', '2026-01-02 17:05:31.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(5, 'Entity Framework Core - Join Related Tables with LINQ', 'https://i.ytimg.com/vi/KgmMFFojhiA/maxresdefault.jpg', 'https://i.ytimg.com/vi/KgmMFFojhiA/hqdefault.jpg', '{\"title\":\"One Way to Join Related Tables with LINQ and Entity Framework Core\",\"author_name\":\"Coding Under Pressure\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/KgmMFFojhiA/hqdefault.jpg\"}', 'Today we are going to take a look at one way to join tables and their data with Entity Framework using LINQ.', 'https://www.youtube.com/watch?v=KgmMFFojhiA', '2026-01-02 17:05:31.000000', '2026-01-02 17:05:31.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(6, 'What is gRPC - Remote Procedure Calls', 'https://i.ytimg.com/vi/hVrwuMnCtok/maxresdefault.jpg', 'https://i.ytimg.com/vi/hVrwuMnCtok/hqdefault.jpg', '{\"title\":\"What is gRPC? (Remote Procedure Calls)\",\"author_name\":\"IBM Technology\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/hVrwuMnCtok/hqdefault.jpg\"}', 'Are you using REST APIs for your microservice-to-microservice communication? There\'s a faster, more scalable solution: gRPC. It is a modern communication framework from the Cloud Native Computing Foundation.', 'https://www.youtube.com/watch?v=hVrwuMnCtok', '2026-01-02 17:05:31.000000', '2026-01-02 17:05:31.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `certificate`
--

CREATE TABLE `certificate` (
  `certificateID` bigint(20) NOT NULL,
  `name` varchar(250) NOT NULL,
  `description` varchar(500) NOT NULL,
  `type` int(11) NOT NULL,
  `date_issued` datetime(6) DEFAULT NULL,
  `date_expired` datetime(6) DEFAULT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `chapter_quiz`
--

CREATE TABLE `chapter_quiz` (
  `chapter_quizID` bigint(20) NOT NULL,
  `quizID` bigint(20) NOT NULL,
  `chapterID` bigint(20) NOT NULL,
  `authorID` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `city`
--

CREATE TABLE `city` (
  `cityId` bigint(20) NOT NULL,
  `countryId` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL,
  `name` varchar(250) NOT NULL,
  `latitude` double NOT NULL,
  `longitude` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `country`
--

CREATE TABLE `country` (
  `countryId` bigint(20) NOT NULL,
  `name` varchar(100) NOT NULL,
  `iso2` varchar(2) NOT NULL,
  `phoneCode` int(11) NOT NULL,
  `currency_symbol` varchar(5) NOT NULL,
  `capital` varchar(100) NOT NULL,
  `currency` varchar(3) NOT NULL,
  `region` varchar(50) NOT NULL,
  `subregion` varchar(2) NOT NULL,
  `iso3` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `country`
--

INSERT INTO `country` (`countryId`, `name`, `iso2`, `phoneCode`, `currency_symbol`, `capital`, `currency`, `region`, `subregion`, `iso3`) VALUES
(1, 'Afghanistan', 'AF', 93, '؋', 'Kabul', 'AFN', 'Asia', 'AS', 'AFG'),
(14, 'Australia', 'AU', 61, '$', 'Canberra', 'AUD', 'Oceania', 'OC', 'AUS'),
(19, 'Bangladesh', 'BD', 880, '৳', 'Dhaka', 'BDT', 'Asia', 'AS', 'BGD'),
(22, 'Belgium', 'BE', 32, '€', 'Brussels', 'EUR', 'Europe', 'EU', 'BEL'),
(32, 'Brazil', 'BR', 55, 'R$', 'Brasilia', 'BRL', 'South America', 'SA', 'BRA'),
(39, 'Cameroon', 'CM', 237, 'FCFA', 'Yaounde', 'XAF', 'Africa', 'AF', 'CMR'),
(40, 'Canada', 'CA', 1, '$', 'Ottawa', 'CAD', 'North America', 'NA', 'CAN'),
(46, 'China', 'CN', 86, '¥', 'Beijing', 'CNY', 'Asia', 'AS', 'CHN'),
(49, 'Colombia', 'CO', 57, '$', 'Bogota', 'COP', 'South America', 'SA', 'COL'),
(61, 'Denmark', 'DK', 45, 'Kr.', 'Copenhagen', 'DKK', 'Europe', 'EU', 'DNK'),
(66, 'Egypt', 'EG', 20, 'ج.م', 'Cairo', 'EGP', 'Africa', 'AF', 'EGY'),
(75, 'Finland', 'FI', 358, '€', 'Helsinki', 'EUR', 'Europe', 'EU', 'FIN'),
(76, 'France', 'FR', 33, '€', 'Paris', 'EUR', 'Europe', 'EU', 'FRA'),
(83, 'Germany', 'DE', 49, '€', 'Berlin', 'EUR', 'Europe', 'EU', 'DEU'),
(84, 'Ghana', 'GH', 233, 'GH₵', 'Accra', 'GHS', 'Africa', 'AF', 'GHA'),
(86, 'Greece', 'GR', 30, '€', 'Athens', 'EUR', 'Europe', 'EU', 'GRC'),
(100, 'Hong Kong', 'HK', 852, '$', 'Hong Kong', 'HKD', 'Asia', 'AS', 'HKG'),
(103, 'India', 'IN', 91, '₹', 'New Delhi', 'INR', 'Asia', 'AS', 'IND'),
(104, 'Indonesia', 'ID', 62, 'Rp', 'Jakarta', 'IDR', 'Asia', 'AS', 'IDN'),
(107, 'Ireland', 'IE', 353, '€', 'Dublin', 'EUR', 'Europe', 'EU', 'IRL'),
(109, 'Israel', 'IL', 972, '₪', 'Jerusalem', 'ILS', 'Asia', 'AS', 'ISR'),
(110, 'Italy', 'IT', 39, '€', 'Rome', 'EUR', 'Europe', 'EU', 'ITA'),
(112, 'Japan', 'JP', 81, '¥', 'Tokyo', 'JPY', 'Asia', 'AS', 'JPN'),
(116, 'Kenya', 'KE', 254, 'KSh', 'Nairobi', 'KES', 'Africa', 'AF', 'KEN'),
(119, 'South Korea', 'KR', 82, '₩', 'Seoul', 'KRW', 'Asia', 'AS', 'KOR'),
(145, 'Mexico', 'MX', 52, '$', 'Mexico City', 'MXN', 'North America', 'NA', 'MEX'),
(158, 'Netherlands', 'NL', 31, '€', 'Amsterdam', 'EUR', 'Europe', 'EU', 'NLD'),
(161, 'New Zealand', 'NZ', 64, '$', 'Wellington', 'NZD', 'Oceania', 'OC', 'NZL'),
(164, 'Nigeria', 'NG', 234, '₦', 'Abuja', 'NGN', 'Africa', 'AF', 'NGA'),
(168, 'Norway', 'NO', 47, 'kr', 'Oslo', 'NOK', 'Europe', 'EU', 'NOR'),
(170, 'Pakistan', 'PK', 92, '₨', 'Islamabad', 'PKR', 'Asia', 'AS', 'PAK'),
(177, 'Philippines', 'PH', 63, '₱', 'Manila', 'PHP', 'Asia', 'AS', 'PHL'),
(179, 'Poland', 'PL', 48, 'zł', 'Warsaw', 'PLN', 'Europe', 'EU', 'POL'),
(180, 'Portugal', 'PT', 351, '€', 'Lisbon', 'EUR', 'Europe', 'EU', 'PRT'),
(185, 'Russia', 'RU', 70, '₽', 'Moscow', 'RUB', 'Asia', 'AS', 'RUS'),
(197, 'Saudi Arabia', 'SA', 966, '﷼', 'Riyadh', 'SAR', 'Asia', 'AS', 'SAU'),
(203, 'Singapore', 'SG', 65, '$', 'Singapur', 'SGD', 'Asia', 'AS', 'SGP'),
(209, 'South Africa', 'ZA', 27, 'R', 'Pretoria', 'ZAR', 'Africa', 'AF', 'ZAF'),
(212, 'Spain', 'ES', 34, '€', 'Madrid', 'EUR', 'Europe', 'EU', 'ESP'),
(213, 'Sri Lanka', 'LK', 94, 'Rs', 'Colombo', 'LKR', 'Asia', 'AS', 'LKA'),
(218, 'Sweden', 'SE', 46, 'kr', 'Stockholm', 'SEK', 'Europe', 'EU', 'SWE'),
(219, 'Switzerland', 'CH', 41, 'CHf', 'Berne', 'CHF', 'Europe', 'EU', 'CHE'),
(221, 'Taiwan', 'TW', 886, '$', 'Taipei', 'TWD', 'Asia', 'AS', 'TWN'),
(224, 'Thailand', 'TH', 66, '฿', 'Bangkok', 'THB', 'Asia', 'AS', 'THA'),
(231, 'Turkey', 'TR', 90, '₺', 'Ankara', 'TRY', 'Asia', 'AS', 'TUR'),
(237, 'United Arab Emirates', 'AE', 971, 'إ.د', 'Abu Dhabi', 'AED', 'Asia', 'AS', 'ARE'),
(238, 'United Kingdom', 'GB', 44, '£', 'London', 'GBP', 'Europe', 'EU', 'GBR'),
(239, 'United States', 'US', 1, '$', 'Washington', 'USD', 'North America', 'NA', 'USA'),
(245, 'Vietnam', 'VN', 84, '₫', 'Hanoi', 'VND', 'Asia', 'AS', 'VNM');

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `courseID` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL,
  `name` varchar(250) NOT NULL,
  `description` text NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) NOT NULL,
  `date_publish` datetime(6) NOT NULL,
  `is_published` tinyint(1) NOT NULL,
  `is_open` tinyint(1) NOT NULL,
  `authorID` bigint(20) DEFAULT NULL,
  `level` int(11) NOT NULL,
  `cover_image` varchar(250) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`courseID`, `guid`, `name`, `description`, `date_created`, `last_modified`, `date_publish`, `is_published`, `is_open`, `authorID`, `level`, `cover_image`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1, '3024u5nirjt04io5w0etiokqt03o', '.NET MAUI for beginners', 'Overview of ASP.NET Core - ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps.', '2023-01-13 15:20:10.000000', '2023-02-13 12:55:21.000000', '2023-01-13 15:20:10.000000', 0, 1, 1661689919349, 0, 'default.png', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(2, 'lk8403riojd90ol0sd9goiwtlsd80to', 'Java SE - Springboot Advanced', 'Spring Boot is one of the Java-based application development platforms, particularly known for creating microservices and online programs.', '2023-02-23 19:32:53.000000', '2023-02-23 19:32:53.000000', '2023-02-23 19:32:53.000000', 0, 1, 1661689919349, 1, 'default.png', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(3, 'eowirio0i23orj90sj23or0aow3r3', 'E-Commerce with NodeJs and MongoDB', 'MongoDB and Node.js work seamlessly together in modern tech stacks. Learn how to set up Node.js and MongoDB.', '2023-02-23 19:32:53.000000', '2023-02-23 19:32:53.000000', '2023-02-23 19:32:53.000000', 0, 1, 1661689919349, 0, 'default.png', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `course_chapter`
--

CREATE TABLE `course_chapter` (
  `chapterID` bigint(20) NOT NULL,
  `courseID` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL,
  `title` varchar(250) NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) NOT NULL,
  `authorID` bigint(20) DEFAULT NULL,
  `chapter_number` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `course_chapter`
--

INSERT INTO `course_chapter` (`chapterID`, `courseID`, `guid`, `title`, `date_created`, `last_modified`, `authorID`, `chapter_number`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1, 1, '69e32b1b-5105-45e7-a1a4-858927b2ierw', 'Introduction', '2023-01-13 15:22:05.000000', '2023-02-13 12:55:21.000000', 1661689919349, 1, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(2, 1, '69e32b1ri-5105-45e7-a1a4-858927b2ea1', 'Building Apps', '2023-01-13 15:22:05.000000', '2023-02-13 12:55:21.000000', 1661689919349, 2, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(3, 1, '69e32b1b-5105-45e7-a1a4-858927b2ea1e', 'Platform Configurations', '2023-04-05 09:50:50.000000', '2023-04-05 09:50:50.000000', 1661689919349, 3, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(4, 1, '64e32b1b-5105-45e7-a1a4-858927b2ea1e', 'MAUI Widgets', '2023-04-05 09:50:50.000000', '2023-04-05 09:50:50.000000', 1661689919349, 4, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(6, 1, 'lkjdhafs;klniniaonrgkh043', 'Testing Your MAUI App', '2023-04-05 17:10:03.000000', '2023-04-05 17:10:03.000000', 1661689919349, 5, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `course_content`
--

CREATE TABLE `course_content` (
  `contentID` bigint(20) NOT NULL,
  `lessonID` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL,
  `authorID` bigint(20) DEFAULT NULL,
  `content_number` int(11) NOT NULL,
  `title` varchar(250) NOT NULL,
  `video_link` varchar(2083) NOT NULL,
  `content` text NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) NOT NULL,
  `note` varchar(250) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `course_content`
--

INSERT INTO `course_content` (`contentID`, `lessonID`, `guid`, `authorID`, `content_number`, `title`, `video_link`, `content`, `date_created`, `last_modified`, `note`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1, 1, '69e32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'History', '', 'HISTORY OF XAMARIN - Xamarin is an open-source development platform that extends .NET capability to build Android, iOS, tvOS, watchOS, macOS and Windows apps using C#. Xamarin is based on .NET with the libraries and runtime used to simplify the development of cross platform mobile native apps. It was founded in 2011, initially named as Mono which was later changed to Xamarin in May 2011 as a result of forking Mono to support Android and iOS platforms. Xamarin was acquired by Microsoft in February 2016 and released for free as open source mobile application.', '2023-02-09 11:49:26.000000', '2023-02-13 12:55:21.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(2, 1, '69a32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'The Evolution', '', '.NET MAUI is more or less a rewrite of Xamarin.Forms. Microsoft built .NET MAUI on top of Xamarin Forms but made numerous improvements that allow you to create cross-platform UI much more efficiently and consistently than ever before.', '2023-02-09 11:49:26.000000', '2023-02-13 12:55:21.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(3, 2, '69c32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'Your first MAUI App', '', 'Choose an ASP.NET Core web UI - ASP.NET Core is a complete UI framework. Razor Pages is a page-focused framework for building server-rendered HTML. Blazor is a component-based framework for building interactive client-side and server-side web UI with .NET.', '2023-02-12 07:42:27.000000', '2023-02-13 12:55:21.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(4, 2, '69b32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Debug on an Android emulator', 'https://www.youtube.com/watch?v=hVrwuMnCtok', 'The Android Emulator can be run in various configurations to simulate different Android devices. Each configuration is created as a virtual device. When you deploy and test your app, you select a preconfigured or custom virtual device that simulates a physical Android device such as a Pixel phone.', '2023-04-05 10:04:38.000000', '2023-04-05 10:04:38.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(5, 2, '69e32b1mn-5105-45e7-a1a4-858927b2ea1', 1661689919349, 3, 'Launching the Emulator', '', 'Near the top of Visual Studio, there is the Solution Configurations drop-down menu that can be used to select Debug or Release. Choosing Debug causes the debugger to attach to the application process running inside the emulator after the app starts, while choosing Release disables the debugger. For more information about release builds, see Understanding Xamarin.Android build types.', '2023-04-05 10:04:38.000000', '2023-04-05 10:04:38.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(6, 3, '69e32b1b-5105-45e7-a1x4-858927b2ea1e', 1661689919349, 1, 'How to enable hardware acceleration with Android emulators', '', 'This article explains how to use your computers hardware acceleration features to maximize Android Emulator performance. Virtual machine acceleration greatly improves the performance of the Android Emulator and is recommended. See how you can use VM acceleration, which hardware acceleration technologies are available, and how to enable them.', '2023-04-05 10:23:38.000000', '2023-04-05 10:23:38.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(7, 3, '69e32b1b-5105-45e7-a1a4-858927b2oi1e', 1661689919349, 2, 'Accelerating Android emulators on Windows', '', 'The following virtualization technologies are available for accelerating the Android emulator: 1) Microsofts Hyper-V and the Windows Hypervisor Platform (WHPX). Hyper-V is a virtualization feature of Windows that makes it possible to run virtualized computer systems on a physical host computer. 2) Intels Hardware Accelerated Execution Manager (HAXM). HAXM is a virtualization engine for computers running Intel CPUs.', '2023-04-05 10:23:38.000000', '2023-04-05 10:23:38.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(8, 4, '69e32b1b-5105-45e7-r1a4-858927b2ea1e', 1661689919349, 1, 'Build an iOS app with .NET CLI', '', 'In this tutorial, you will learn how to create and run a .NET MAUI app on iOS in a Mac Catalyst app using a Mac thats paired to Visual Studio 2022 on a Windows PC over a network or USB connection. All .NET MAUI apps for iOS must be built and deployed on a Mac, even if youre doing development on a PC. If you dont have a Mac, you can run your .NET MAUI iOS app on the iOS simulator.', '2023-04-05 10:28:26.000000', '2023-04-05 10:28:26.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(9, 4, '69z32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Launch the app on a specific simulator', '', 'A .NET MAUI iOS app can be launched on a specific iOS simulator with the dotnet build command, by specifying the target identifier and device identifier. To retrieve the list of installed simulators, open the Terminal and enter the following command: xcrun simctl list. The output from this command includes the unique device identifier (UDID) of each iOS simulator on your Mac.', '2023-04-05 10:28:27.000000', '2023-04-05 10:28:27.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(10, 5, '69e32b1b-5105-45w7-a1a4-858927b2ea1e', 1661689919349, 1, 'Deploy and debug your .NET MAUI app on Windows', '', 'You can use your local Windows development computer to deploy and debug a .NET MAUI app to a Windows desktop computer. The Windows app is deployed to the local desktop computer from Visual Studio by default. In Visual Studio, choose the Framework drop down and select net8.0-windows. Visual Studio may prompt you to turn on Developer Mode for Windows. Developer Mode for Windows enables you to sideload and test apps without deploying them through the Microsoft Store.', '2023-04-05 10:32:19.000000', '2023-04-05 10:32:19.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(11, 6, '69e78b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 2, 'Build a Mac Catalyst app with .NET CLI', '', 'In this tutorial, you will learn how to create and run a .NET MAUI app on Mac Catalyst on a Mac using Visual Studio Code. To run and debug a .NET MAUI Mac Catalyst app in Visual Studio Code on a Mac, the C# Dev Kit is required. For more information, see Install C# Dev Kit for VS Code.', '2023-04-05 10:32:19.000000', '2023-04-05 10:32:19.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(12, 10, '69e32q1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 1, 'Create a custom control using handlers', '', 'A standard requirement for apps is the ability to play videos from web-based sources. However, .NET MAUI doesnt include a cross-platform control for playing videos. In this article, you will learn how to create a .NET MAUI cross-platform VideoPlayer control, by using the handler architecture, that can be used to play a video from a web source.', '2023-04-05 10:35:41.000000', '2023-04-05 10:35:41.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(13, 9, '69e32b1b-5105-45e7-a1a4-858427b2ea1v', 1661689919349, 1, 'ListView', '', 'The .NET MAUI ListView displays a scrollable vertical list of selectable data items. ListView is useful for displaying lists of data that require scrolling, particularly when the lists are long. Each item in a ListView is defined by a DataTemplate, which uses cells to display its data. .NET MAUI includes a number of cell types that represent different scenarios.', '2023-04-05 10:35:41.000000', '2023-04-05 10:35:41.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(14, 7, '69b32b1b-5105-45e7-a1a4-258927b2ea1e', 1661689919349, 1, 'Building app', 'https://www.youtube.com/watch?v=66tfvFeALBQ', '', '2023-04-05 10:41:52.000000', '2023-04-05 10:41:52.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(15, 8, '69e32b1b-5105-45e7-a1a4-858927b2rt1e', 1661689919349, 1, 'Creating App', 'https://www.youtube.com/playlist?list=PLPLcAzuCoR98L2Md7PiFtLhiz9PSURTPo', '', '2023-04-05 10:41:52.000000', '2023-04-05 10:41:52.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(16, 2, '69e92b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, 4, 'Resources for learning .NET MAUI', '', 'There are many different resources available for you to use to learn .NET MAUI. This article provides a quick tour to the materials that can help you master .NET MAUI. Microsoft Learn provides free interactive training modules and guided projects to help you get started learning .NET MAUI.', '2023-04-05 12:15:16.000000', '2023-04-05 12:15:16.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(17, 9, '69e32b1b-5105-45e7-a1a4-858927b2tx1e', 1661689919349, 2, 'ContentView', '', 'The .NET MAUI ContentView is a control that enables the creation of custom, reusable controls. The ContentView class inherits from TemplatedView. The ContentView class defines a Content property, of type View, which represents the content of the ContentView. This property is backed by a BindableProperty object, which means that it can be the target of data bindings, and styled.', '2023-04-05 12:15:16.000000', '2023-04-05 12:15:16.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(19, 12, 'a98slkdgitkdsa-234pewjgpjdkww234as', 1661689919349, 1, 'Taking first steps', 'https://www.youtube.com/watch?v=s1bk-68aB1U', '', '2023-04-05 17:12:13.000000', '2023-04-05 17:12:13.000000', '', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `course_data`
--

CREATE TABLE `course_data` (
  `dataID` bigint(20) NOT NULL,
  `enrollmentID` bigint(20) NOT NULL,
  `start_date` datetime(6) NOT NULL,
  `last_modified` datetime(6) NOT NULL,
  `study_record` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`study_record`)),
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `course_data`
--

INSERT INTO `course_data` (`dataID`, `enrollmentID`, `start_date`, `last_modified`, `study_record`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1, 43, '2026-01-03 00:25:31.506864', '2026-01-03 00:25:31.506935', '[{\"CourseIndexId\":1,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":1,\"ContentId\":1,\"ChapterNumber\":1,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1p\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":true,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T00:14:55.3482667Z\",\"DateDone\":\"2026-01-03T01:14:55.3471392+01:00\"},{\"CourseIndexId\":2,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":1,\"ContentId\":2,\"ChapterNumber\":1,\"LessonNumber\":1,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1p\",\"ContentGuid\":\"69a32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.3723041+01:00\",\"DateDone\":\"2026-01-03T01:14:55.3723062+01:00\"},{\"CourseIndexId\":3,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":2,\"ContentId\":3,\"ChapterNumber\":1,\"LessonNumber\":2,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-g1a4-858927b2ea1e\",\"ContentGuid\":\"69c32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.3947377+01:00\",\"DateDone\":\"2026-01-03T01:14:55.3947396+01:00\"},{\"CourseIndexId\":4,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":2,\"ContentId\":4,\"ChapterNumber\":1,\"LessonNumber\":2,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-g1a4-858927b2ea1e\",\"ContentGuid\":\"69b32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.415718+01:00\",\"DateDone\":\"2026-01-03T01:14:55.4157206+01:00\"},{\"CourseIndexId\":5,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":2,\"ContentId\":5,\"ChapterNumber\":1,\"LessonNumber\":2,\"ContentNumber\":3,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-g1a4-858927b2ea1e\",\"ContentGuid\":\"69e32b1mn-5105-45e7-a1a4-858927b2ea1\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.4274276+01:00\",\"DateDone\":\"2026-01-03T01:14:55.4274293+01:00\"},{\"CourseIndexId\":6,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":2,\"ContentId\":16,\"ChapterNumber\":1,\"LessonNumber\":2,\"ContentNumber\":4,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-g1a4-858927b2ea1e\",\"ContentGuid\":\"69e92b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.439768+01:00\",\"DateDone\":\"2026-01-03T01:14:55.4397697+01:00\"},{\"CourseIndexId\":7,\"CourseId\":1,\"ChapterId\":2,\"LessonId\":7,\"ContentId\":14,\"ChapterNumber\":2,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1ri-5105-45e7-a1a4-858927b2ea1\",\"LessonGuid\":\"69e32b1b-9805-45e7-a1a4-858927b2ea1e\",\"ContentGuid\":\"69b32b1b-5105-45e7-a1a4-258927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.4695323+01:00\",\"DateDone\":\"2026-01-03T01:14:55.4695345+01:00\"},{\"CourseIndexId\":8,\"CourseId\":1,\"ChapterId\":2,\"LessonId\":8,\"ContentId\":15,\"ChapterNumber\":2,\"LessonNumber\":2,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1ri-5105-45e7-a1a4-858927b2ea1\",\"LessonGuid\":\"63e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2rt1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.5037987+01:00\",\"DateDone\":\"2026-01-03T01:14:55.5038032+01:00\"},{\"CourseIndexId\":9,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":3,\"ContentId\":6,\"ChapterNumber\":3,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45er7-a1a4-858927b2ea1\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1x4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.5670261+01:00\",\"DateDone\":\"2026-01-03T01:14:55.5670277+01:00\"},{\"CourseIndexId\":10,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":3,\"ContentId\":7,\"ChapterNumber\":3,\"LessonNumber\":1,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45er7-a1a4-858927b2ea1\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2oi1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.5778243+01:00\",\"DateDone\":\"2026-01-03T01:14:55.5778261+01:00\"},{\"CourseIndexId\":11,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":4,\"ContentId\":8,\"ChapterNumber\":3,\"LessonNumber\":2,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5195-45e7-a1a4-858927b2ea1e\",\"ContentGuid\":\"69e32b1b-5105-45e7-r1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.6082642+01:00\",\"DateDone\":\"2026-01-03T01:14:55.608266+01:00\"},{\"CourseIndexId\":12,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":4,\"ContentId\":9,\"ChapterNumber\":3,\"LessonNumber\":2,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5195-45e7-a1a4-858927b2ea1e\",\"ContentGuid\":\"69z32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.6357571+01:00\",\"DateDone\":\"2026-01-03T01:14:55.6357589+01:00\"},{\"CourseIndexId\":13,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":5,\"ContentId\":10,\"ChapterNumber\":3,\"LessonNumber\":3,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1u-5105-45e7-a1a4-856927b2ea1e\",\"ContentGuid\":\"69e32b1b-5105-45w7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.6635135+01:00\",\"DateDone\":\"2026-01-03T01:14:55.6635154+01:00\"},{\"CourseIndexId\":14,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":6,\"ContentId\":11,\"ChapterNumber\":3,\"LessonNumber\":4,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45uo7-a1a4-858927b2ea1\",\"ContentGuid\":\"69e78b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.725615+01:00\",\"DateDone\":\"2026-01-03T01:14:55.7256201+01:00\"},{\"CourseIndexId\":15,\"CourseId\":1,\"ChapterId\":4,\"LessonId\":9,\"ContentId\":13,\"ChapterNumber\":4,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"64e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1k\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858427b2ea1v\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.8083677+01:00\",\"DateDone\":\"2026-01-03T01:14:55.8083694+01:00\"},{\"CourseIndexId\":16,\"CourseId\":1,\"ChapterId\":4,\"LessonId\":9,\"ContentId\":17,\"ChapterNumber\":4,\"LessonNumber\":1,\"ContentNumber\":2,\"ChapterGuid\":\"64e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1k\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2tx1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.82418+01:00\",\"DateDone\":\"2026-01-03T01:14:55.8241817+01:00\"},{\"CourseIndexId\":17,\"CourseId\":1,\"ChapterId\":4,\"LessonId\":10,\"ContentId\":12,\"ChapterNumber\":4,\"LessonNumber\":2,\"ContentNumber\":1,\"ChapterGuid\":\"64e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1j\",\"ContentGuid\":\"69e32q1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.8492686+01:00\",\"DateDone\":\"2026-01-03T01:14:55.8492702+01:00\"},{\"CourseIndexId\":18,\"CourseId\":1,\"ChapterId\":6,\"LessonId\":12,\"ContentId\":19,\"ChapterNumber\":5,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"lkjdhafs;klniniaonrgkh043\",\"LessonGuid\":\"afod9orhk0sdtiowejf90aetkweiu0\",\"ContentGuid\":\"a98slkdgitkdsa-234pewjgpjdkww234as\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":true,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.9074324+01:00\",\"DateDone\":\"2026-01-03T01:14:55.9074369+01:00\"}]', '2026-01-03 00:25:31.674201', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `course_enrollments_analytics`
--

CREATE TABLE `course_enrollments_analytics` (
  `id` bigint(20) NOT NULL,
  `enrollment_id` bigint(20) NOT NULL,
  `course_id` bigint(20) NOT NULL,
  `user_id` bigint(20) NOT NULL,
  `enrolled_at` datetime(6) NOT NULL,
  `completed_at` datetime(6) DEFAULT NULL,
  `is_completed` tinyint(1) NOT NULL,
  `completion_percentage` decimal(65,30) NOT NULL,
  `total_time_spent_minutes` int(11) NOT NULL,
  `last_accessed_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `course_lesson`
--

CREATE TABLE `course_lesson` (
  `lessonID` bigint(20) NOT NULL,
  `topic` varchar(250) NOT NULL,
  `chapterID` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL,
  `authorID` bigint(20) DEFAULT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) NOT NULL,
  `lesson_number` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `course_lesson`
--

INSERT INTO `course_lesson` (`lessonID`, `topic`, `chapterID`, `guid`, `authorID`, `date_created`, `last_modified`, `lesson_number`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1, '.NET MAUI and History', 1, '69e32b1b-5105-45e7-a1a4-858927b2ea1p', 1661689919349, '2023-01-13 15:24:30.000000', '2023-02-13 12:55:21.000000', 1, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(2, 'Getting started with .NET MAUI', 1, '69e32b1b-5105-45e7-g1a4-858927b2ea1e', 1661689919349, '2023-02-03 22:04:48.000000', '2023-02-13 12:55:21.000000', 2, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(3, 'Configuring .NET MAUI for Android', 3, '69e32b1b-5105-45er7-a1a4-858927b2ea1', 1661689919349, '2023-04-05 09:53:43.000000', '2023-04-05 09:53:43.000000', 1, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(4, 'Configuring .NET MAUI for IOS', 3, '69e32b1b-5195-45e7-a1a4-858927b2ea1e', 1661689919349, '2023-04-05 09:53:43.000000', '2023-04-05 09:53:43.000000', 2, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(5, 'Configuring .NET MAUI for Windows', 3, '69e32b1u-5105-45e7-a1a4-856927b2ea1e', 1661689919349, '2023-04-05 09:53:43.000000', '2023-04-05 09:53:43.000000', 3, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(6, 'Configuring .NET MAUI for Mac', 3, '69e32b1b-5105-45uo7-a1a4-858927b2ea1', 1661689919349, '2023-04-05 09:53:43.000000', '2023-04-05 09:53:43.000000', 4, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(7, 'Build A Todo App', 2, '69e32b1b-9805-45e7-a1a4-858927b2ea1e', 1661689919349, '2023-04-05 09:56:43.000000', '2023-04-05 09:56:43.000000', 1, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(8, 'Build A Phone Book App', 2, '63e32b1b-5105-45e7-a1a4-858927b2ea1e', 1661689919349, '2023-04-05 09:56:43.000000', '2023-04-05 09:56:43.000000', 2, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(9, 'ListView and CollectionView', 4, '69e32b1b-5105-45e7-a1a4-858927b2ea1k', 1661689919349, '2023-04-05 09:58:18.000000', '2023-04-05 09:58:18.000000', 1, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(10, 'Buttons and Click controls', 4, '69e32b1b-5105-45e7-a1a4-858927b2ea1j', 1661689919349, '2023-04-05 09:58:18.000000', '2023-04-05 09:58:18.000000', 2, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(12, 'Unit Test a .NET MAUI App', 6, 'afod9orhk0sdtiowejf90aetkweiu0', 1661689919349, '2023-04-05 17:11:16.000000', '2023-04-05 17:11:16.000000', 1, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `course_views`
--

CREATE TABLE `course_views` (
  `id` bigint(20) NOT NULL,
  `course_id` bigint(20) NOT NULL,
  `user_id` bigint(20) NOT NULL,
  `viewed_at` datetime(6) NOT NULL,
  `ip_address` varchar(45) DEFAULT NULL,
  `user_agent` varchar(500) DEFAULT NULL,
  `referrer_url` varchar(2083) DEFAULT NULL,
  `session_duration_seconds` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `creator`
--

CREATE TABLE `creator` (
  `authorID` bigint(20) NOT NULL,
  `accountID` bigint(20) NOT NULL,
  `roleID` bigint(20) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `creator`
--

INSERT INTO `creator` (`authorID`, `accountID`, `roleID`, `status`) VALUES
(1661689919349, 1, 2, 0);

-- --------------------------------------------------------

--
-- Table structure for table `data_index`
--

CREATE TABLE `data_index` (
  `indexId` bigint(20) NOT NULL,
  `courseId` bigint(20) NOT NULL,
  `index_data` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`index_data`)),
  `last_modified` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `data_index`
--

INSERT INTO `data_index` (`indexId`, `courseId`, `index_data`, `last_modified`) VALUES
(1, 1, '[{\"CourseIndexId\":1,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":1,\"ContentId\":1,\"ChapterNumber\":1,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1p\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":true,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T00:14:55.3482667Z\",\"DateDone\":\"2026-01-03T01:14:55.3471392+01:00\"},{\"CourseIndexId\":2,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":1,\"ContentId\":2,\"ChapterNumber\":1,\"LessonNumber\":1,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1p\",\"ContentGuid\":\"69a32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.3723041+01:00\",\"DateDone\":\"2026-01-03T01:14:55.3723062+01:00\"},{\"CourseIndexId\":3,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":2,\"ContentId\":3,\"ChapterNumber\":1,\"LessonNumber\":2,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-g1a4-858927b2ea1e\",\"ContentGuid\":\"69c32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.3947377+01:00\",\"DateDone\":\"2026-01-03T01:14:55.3947396+01:00\"},{\"CourseIndexId\":4,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":2,\"ContentId\":4,\"ChapterNumber\":1,\"LessonNumber\":2,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-g1a4-858927b2ea1e\",\"ContentGuid\":\"69b32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.415718+01:00\",\"DateDone\":\"2026-01-03T01:14:55.4157206+01:00\"},{\"CourseIndexId\":5,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":2,\"ContentId\":5,\"ChapterNumber\":1,\"LessonNumber\":2,\"ContentNumber\":3,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-g1a4-858927b2ea1e\",\"ContentGuid\":\"69e32b1mn-5105-45e7-a1a4-858927b2ea1\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.4274276+01:00\",\"DateDone\":\"2026-01-03T01:14:55.4274293+01:00\"},{\"CourseIndexId\":6,\"CourseId\":1,\"ChapterId\":1,\"LessonId\":2,\"ContentId\":16,\"ChapterNumber\":1,\"LessonNumber\":2,\"ContentNumber\":4,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ierw\",\"LessonGuid\":\"69e32b1b-5105-45e7-g1a4-858927b2ea1e\",\"ContentGuid\":\"69e92b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.439768+01:00\",\"DateDone\":\"2026-01-03T01:14:55.4397697+01:00\"},{\"CourseIndexId\":7,\"CourseId\":1,\"ChapterId\":2,\"LessonId\":7,\"ContentId\":14,\"ChapterNumber\":2,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1ri-5105-45e7-a1a4-858927b2ea1\",\"LessonGuid\":\"69e32b1b-9805-45e7-a1a4-858927b2ea1e\",\"ContentGuid\":\"69b32b1b-5105-45e7-a1a4-258927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.4695323+01:00\",\"DateDone\":\"2026-01-03T01:14:55.4695345+01:00\"},{\"CourseIndexId\":8,\"CourseId\":1,\"ChapterId\":2,\"LessonId\":8,\"ContentId\":15,\"ChapterNumber\":2,\"LessonNumber\":2,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1ri-5105-45e7-a1a4-858927b2ea1\",\"LessonGuid\":\"63e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2rt1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.5037987+01:00\",\"DateDone\":\"2026-01-03T01:14:55.5038032+01:00\"},{\"CourseIndexId\":9,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":3,\"ContentId\":6,\"ChapterNumber\":3,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45er7-a1a4-858927b2ea1\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1x4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.5670261+01:00\",\"DateDone\":\"2026-01-03T01:14:55.5670277+01:00\"},{\"CourseIndexId\":10,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":3,\"ContentId\":7,\"ChapterNumber\":3,\"LessonNumber\":1,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45er7-a1a4-858927b2ea1\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2oi1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.5778243+01:00\",\"DateDone\":\"2026-01-03T01:14:55.5778261+01:00\"},{\"CourseIndexId\":11,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":4,\"ContentId\":8,\"ChapterNumber\":3,\"LessonNumber\":2,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5195-45e7-a1a4-858927b2ea1e\",\"ContentGuid\":\"69e32b1b-5105-45e7-r1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.6082642+01:00\",\"DateDone\":\"2026-01-03T01:14:55.608266+01:00\"},{\"CourseIndexId\":12,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":4,\"ContentId\":9,\"ChapterNumber\":3,\"LessonNumber\":2,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5195-45e7-a1a4-858927b2ea1e\",\"ContentGuid\":\"69z32b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.6357571+01:00\",\"DateDone\":\"2026-01-03T01:14:55.6357589+01:00\"},{\"CourseIndexId\":13,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":5,\"ContentId\":10,\"ChapterNumber\":3,\"LessonNumber\":3,\"ContentNumber\":1,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1u-5105-45e7-a1a4-856927b2ea1e\",\"ContentGuid\":\"69e32b1b-5105-45w7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.6635135+01:00\",\"DateDone\":\"2026-01-03T01:14:55.6635154+01:00\"},{\"CourseIndexId\":14,\"CourseId\":1,\"ChapterId\":3,\"LessonId\":6,\"ContentId\":11,\"ChapterNumber\":3,\"LessonNumber\":4,\"ContentNumber\":2,\"ChapterGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45uo7-a1a4-858927b2ea1\",\"ContentGuid\":\"69e78b1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.725615+01:00\",\"DateDone\":\"2026-01-03T01:14:55.7256201+01:00\"},{\"CourseIndexId\":15,\"CourseId\":1,\"ChapterId\":4,\"LessonId\":9,\"ContentId\":13,\"ChapterNumber\":4,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"64e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1k\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858427b2ea1v\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":false,\"DateUnlocked\":\"2026-01-03T01:14:55.8083677+01:00\",\"DateDone\":\"2026-01-03T01:14:55.8083694+01:00\"},{\"CourseIndexId\":16,\"CourseId\":1,\"ChapterId\":4,\"LessonId\":9,\"ContentId\":17,\"ChapterNumber\":4,\"LessonNumber\":1,\"ContentNumber\":2,\"ChapterGuid\":\"64e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1k\",\"ContentGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2tx1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":false,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.82418+01:00\",\"DateDone\":\"2026-01-03T01:14:55.8241817+01:00\"},{\"CourseIndexId\":17,\"CourseId\":1,\"ChapterId\":4,\"LessonId\":10,\"ContentId\":12,\"ChapterNumber\":4,\"LessonNumber\":2,\"ContentNumber\":1,\"ChapterGuid\":\"64e32b1b-5105-45e7-a1a4-858927b2ea1e\",\"LessonGuid\":\"69e32b1b-5105-45e7-a1a4-858927b2ea1j\",\"ContentGuid\":\"69e32q1b-5105-45e7-a1a4-858927b2ea1e\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":false,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.8492686+01:00\",\"DateDone\":\"2026-01-03T01:14:55.8492702+01:00\"},{\"CourseIndexId\":18,\"CourseId\":1,\"ChapterId\":6,\"LessonId\":12,\"ContentId\":19,\"ChapterNumber\":5,\"LessonNumber\":1,\"ContentNumber\":1,\"ChapterGuid\":\"lkjdhafs;klniniaonrgkh043\",\"LessonGuid\":\"afod9orhk0sdtiowejf90aetkweiu0\",\"ContentGuid\":\"a98slkdgitkdsa-234pewjgpjdkww234as\",\"IsDone\":false,\"IsUnlocked\":false,\"IsDeleted\":false,\"HasQuiz\":false,\"IsLastChapter\":true,\"IsLastLesson\":true,\"IsLastContent\":true,\"DateUnlocked\":\"2026-01-03T01:14:55.9074324+01:00\",\"DateDone\":\"2026-01-03T01:14:55.9074369+01:00\"}]', '2026-01-03 00:14:56.330656');

-- --------------------------------------------------------

--
-- Table structure for table `email`
--

CREATE TABLE `email` (
  `emailId` bigint(20) NOT NULL,
  `address` varchar(100) NOT NULL,
  `is_primary` tinyint(1) NOT NULL,
  `can_mail_to` tinyint(1) NOT NULL,
  `type` int(11) NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) DEFAULT NULL,
  `is_verified` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `engagement`
--

CREATE TABLE `engagement` (
  `engagementID` bigint(20) NOT NULL,
  `userID` bigint(20) NOT NULL,
  `catalogID` bigint(20) NOT NULL,
  `engagedDate` datetime(6) NOT NULL,
  `completed` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `engagement`
--

INSERT INTO `engagement` (`engagementID`, `userID`, `catalogID`, `engagedDate`, `completed`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(24, 1661689094366, 2, '2023-03-30 00:00:00.000000', 0, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(25, 1661689094366, 6, '2023-04-04 00:00:00.000000', 0, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(26, 1661689094366, 3, '2025-05-15 00:00:00.000000', 0, '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `enrollment`
--

CREATE TABLE `enrollment` (
  `enrollmentID` bigint(20) NOT NULL,
  `userID` bigint(20) NOT NULL,
  `courseID` bigint(20) NOT NULL,
  `date_enrolled` datetime(6) NOT NULL,
  `is_completed` tinyint(1) NOT NULL,
  `date_completed` datetime(6) NOT NULL,
  `completion_percentage` decimal(65,30) NOT NULL,
  `last_accessed` datetime(6) DEFAULT NULL,
  `enrolled_at` datetime(6) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `enrollment`
--

INSERT INTO `enrollment` (`enrollmentID`, `userID`, `courseID`, `date_enrolled`, `is_completed`, `date_completed`, `completion_percentage`, `last_accessed`, `enrolled_at`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(43, 1671885852119, 1, '2026-01-03 01:25:30.520445', 0, '2026-01-03 01:25:30.520659', 0.000000000000000000000000000000, NULL, '2026-01-03 00:25:30.517550', '2026-01-03 00:25:31.102995', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `enrollment_quiz`
--

CREATE TABLE `enrollment_quiz` (
  `enrollment_quizID` bigint(20) NOT NULL,
  `enrollmentID` bigint(20) NOT NULL,
  `quizID` bigint(20) NOT NULL,
  `date_taken` datetime(6) NOT NULL,
  `passed` tinyint(1) NOT NULL,
  `points` int(11) NOT NULL,
  `time_taken` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `feedback`
--

CREATE TABLE `feedback` (
  `feedbackId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `subject` varchar(100) NOT NULL,
  `content` text NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `date_modified` datetime(6) NOT NULL,
  `included_images` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`included_images`)),
  `read_by` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`read_by`)),
  `is_read` tinyint(1) NOT NULL,
  `tag_ids` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`tag_ids`)),
  `topic_ids` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`topic_ids`)),
  `subject_ids` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`subject_ids`)),
  `category_ids` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`category_ids`)),
  `response` text NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `language`
--

CREATE TABLE `language` (
  `languageId` bigint(20) NOT NULL,
  `countryId` bigint(20) DEFAULT NULL,
  `name` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `language`
--

INSERT INTO `language` (`languageId`, `countryId`, `name`) VALUES
(1, 238, 'English'),
(2, 76, 'French'),
(3, 212, 'Spanish'),
(4, 46, 'Chinese'),
(5, 112, 'Japanese'),
(6, 83, 'German'),
(7, 180, 'Portuguese'),
(8, 185, 'Russian'),
(9, 103, 'Hindi'),
(10, 119, 'Korean');

-- --------------------------------------------------------

--
-- Table structure for table `news_letter`
--

CREATE TABLE `news_letter` (
  `news_letterId` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL,
  `letter_body` longtext NOT NULL,
  `letter_type` int(11) NOT NULL,
  `schedule_date` datetime(6) NOT NULL,
  `status` int(11) NOT NULL,
  `date_created` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `news_letter_subscriber`
--

CREATE TABLE `news_letter_subscriber` (
  `news_letter_subscriberId` int(11) NOT NULL,
  `emailId` bigint(20) NOT NULL,
  `subscriber_code` varchar(8) NOT NULL,
  `date_subscribed` datetime(6) NOT NULL,
  `NewsLetterId` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `notification`
--

CREATE TABLE `notification` (
  `notificationId` bigint(20) NOT NULL,
  `notification_guid` varchar(36) NOT NULL,
  `accountId` bigint(20) NOT NULL,
  `caption` varchar(100) NOT NULL,
  `details` varchar(250) NOT NULL,
  `actions` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`actions`)),
  `icon` varchar(250) NOT NULL,
  `marked_as_read` tinyint(1) NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `date_read` datetime(6) DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `notification`
--

INSERT INTO `notification` (`notificationId`, `notification_guid`, `accountId`, `caption`, `details`, `actions`, `icon`, `marked_as_read`, `date_created`, `date_read`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1, 'ndsaieowrh0ionlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis in. Etiam Erat sed fringilla Ultricies. Ullamcorper Pellentesque placerat egestas in fermentum parturient Quisque senectus nullam, fringilla dis sapien. Mauris, rutrum amet viverra turp', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52.000000', '2025-05-15 14:35:02.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(4, 'ndsaieowrh0i23nlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis in. Etiam Erat sed fringilla Ultricies. Ullamcorper Pellentesque placerat egestas in fermentum parturient Quisque senectus nullam, fringilla dis sapien. Mauris, rutrum amet viverra turp', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52.000000', '2023-04-15 22:51:46.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(5, 'n56saieowrh0i23nlkew9f0ui4a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis in. Etiam Erat sed fringilla Ultricies. Ullamcorper Pellentesque placerat egestas in fermentum parturient Quisque senectus nullam, fringilla dis sapien. Mauris, rutrum amet viverra turp', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2021-12-15 00:00:00.000000', '2023-04-15 12:55:15.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(6, 'n56saieowrh0i23nlkew9f0uo94a9s0dl3', 1, 'New Dummy Notification', 'Dis Sagittis cum at mattis At. Aliquet fermentum pharetra mollis in. Etiam Erat sed fringilla Ultricies. Ullamcorper Pellentesque placerat egestas in fermentum parturient Quisque senectus nullam, fringilla dis sapien. Mauris, rutrum amet viverra turp', '[{\"name\":\"Visit\",\"command\":\"/dashboard\",\"description\":\"Go to user dashboard\"}]', 'notify.png', 1, '2023-04-15 11:11:52.000000', '2023-05-20 13:14:54.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(16, '4e3c7f6c-63b9-4e33-9535-90e1b0b55cae', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=34&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-18 09:25:49.000000', '2023-05-20 12:47:22.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(17, '65a4ff29-6dd6-4777-bb17-276379fc53f5', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=35&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-18 09:41:47.000000', '2023-05-20 12:46:40.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(18, 'e0ab7c71-9670-4e1e-a8a9-93e4773d6f20', 1, 'Course completed Alain!', 'Hoping you have learnt a lot from this course.', '[{\"Name\":\"More courses\",\"Description\":null,\"Command\":\"/courses\"}]', 'notify.png', 1, '2023-04-18 09:45:45.000000', '2023-05-05 15:01:06.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(26, '67798545-43be-4988-b55b-18c72ef267ad', 18, 'Actions required The!', 'Please visit your dashboard and complete your profile setup.', '[{\"Name\":\"Dashboard\",\"Description\":null,\"Command\":\"/user/dashboard\"}]', 'notify.png', 1, '2023-04-18 09:56:46.000000', '2023-04-20 08:21:12.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(27, 'ef64dc82-b04b-42de-b1e4-fc2e6551d2e2', 18, 'Welcome The to Skill-IT', 'Welcome and thank you for signing up on the Skill-IT website.', '[{\"Name\":\"Catalogs\",\"Description\":null,\"Command\":\"/catalogs\"}]', 'notify.png', 1, '2023-04-18 09:56:46.000000', '2023-04-20 07:21:03.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(28, 'a3697a66-aa68-462b-b346-c9a038656a33', 18, 'The verify email', 'Your account is not yet verified.', '[]', 'notify.png', 1, '2023-04-18 09:56:46.000000', '2023-04-20 08:21:02.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(29, 'd910179d-cf12-47e8-a680-398dd9e13ed0', 18, 'Course registered The!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=37&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-20 07:25:57.000000', '2023-04-20 08:21:16.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(30, '7b83fa57-de89-4d7d-bb99-b59231d22f0f', 1, 'Course registered Alain!', 'You successfully enrolled to our .NET MAUI for beginners course.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=39&courseIndexId=1\"}]', 'notify.png', 1, '2023-04-22 12:01:38.000000', '2025-05-15 14:35:14.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(31, 'af8291da-f070-447f-8952-d25aa472c462', 7, 'Course registered Rousanne!', 'You successfully enrolled to our .NET MAUI for beginners. Hoping you will learn a lot from this course, for we are so glad you are taking the course with us.', '[{\"Name\":\"Visit\",\"Description\":null,\"Command\":\"/course/3024u5nirjt04io5w0etiokqt03o?cryptId=43&courseIndexId=1\"}]', 'notify.png', 1, '2026-01-03 00:25:32.041904', '2026-07-12 13:00:46.668064', '2026-01-03 00:25:32.239359', '2026-07-12 13:00:50.422159', NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `otp`
--

CREATE TABLE `otp` (
  `otpID` bigint(20) NOT NULL,
  `code` int(11) NOT NULL,
  `expiryDate` datetime(6) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `otp`
--

INSERT INTO `otp` (`otpID`, `code`, `expiryDate`, `userId`, `guid`) VALUES
(17, 122886, '2023-03-07 00:00:00.000000', 1671885852119, '6d1e0444-7bd5-4494-8245-2093bb56633f'),
(18, 265709, '2023-03-07 00:00:00.000000', 1671885852119, '51fb9e86-ee5b-475d-a28c-d33dac5cff1a'),
(19, 444858, '2023-03-07 00:00:00.000000', 1671885852119, 'c4ccd274-d78f-4eb2-851c-a92181c201cc'),
(20, 687774, '2023-03-07 00:00:00.000000', 1671885852119, '9ad93627-6078-4bf7-9a78-fb24d50e695a'),
(22, 75251, '2023-05-11 00:00:00.000000', 1661689094366, '3c29411d-3bc9-4845-9771-96df4e3fdf06'),
(23, 366145, '2023-05-11 00:00:00.000000', 1678544061950, '2ea966eb-548f-48b7-81d3-e43dec75fb49'),
(24, 523017, '2023-03-12 00:00:00.000000', 1678544061950, 'd50b2ee1-f281-45a7-9bb9-08604ceafdfd'),
(27, 904757, '2023-06-18 00:00:00.000000', 1681811805905, 'd0d37f06-8785-43ff-a173-40e049a2f0fe'),
(28, 915756, '2026-02-28 00:00:00.000000', 1677925925595, '4ab5b9c3-7ae0-4e92-a3d0-33f3254c2ae8');

-- --------------------------------------------------------

--
-- Table structure for table `password`
--

CREATE TABLE `password` (
  `passwordId` int(11) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `hashed` varchar(1000) NOT NULL,
  `salt` varbinary(128) NOT NULL,
  `last_changed` datetime(6) NOT NULL,
  `past_passwords` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`past_passwords`))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phone`
--

CREATE TABLE `phone` (
  `phoneId` bigint(20) NOT NULL,
  `countryId` bigint(20) NOT NULL,
  `number` int(11) NOT NULL,
  `is_primary` tinyint(1) NOT NULL,
  `can_notify` tinyint(1) NOT NULL,
  `is_verified` tinyint(1) NOT NULL,
  `type` int(11) NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `project`
--

CREATE TABLE `project` (
  `projectID` bigint(20) NOT NULL,
  `name` varchar(500) NOT NULL,
  `owner` varchar(100) NOT NULL,
  `description` varchar(2000) NOT NULL,
  `soureLink` varchar(500) NOT NULL,
  `link` varchar(500) NOT NULL,
  `skillSet` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`skillSet`)),
  `userID` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `question`
--

CREATE TABLE `question` (
  `questionID` bigint(20) NOT NULL,
  `authorID` bigint(20) DEFAULT NULL,
  `text` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `question_answer`
--

CREATE TABLE `question_answer` (
  `question_answerID` bigint(20) NOT NULL,
  `questionID` bigint(20) NOT NULL,
  `answer` text NOT NULL,
  `is_correct` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `question_answer_response`
--

CREATE TABLE `question_answer_response` (
  `question_answer_responseID` bigint(20) NOT NULL,
  `questionID` bigint(20) NOT NULL,
  `enrollmentID` bigint(20) NOT NULL,
  `question_answerID` bigint(20) NOT NULL,
  `time_answered` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `quiz`
--

CREATE TABLE `quiz` (
  `quizID` bigint(20) NOT NULL,
  `authorID` bigint(20) DEFAULT NULL,
  `date_created` datetime(6) NOT NULL,
  `quiz_code` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `quiz_question`
--

CREATE TABLE `quiz_question` (
  `quiz_questionID` bigint(20) NOT NULL,
  `quizID` bigint(20) NOT NULL,
  `questionID` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `region`
--

CREATE TABLE `region` (
  `regionId` bigint(20) NOT NULL,
  `countryId` bigint(20) NOT NULL,
  `guid` varchar(36) NOT NULL,
  `name` varchar(100) NOT NULL,
  `short_code` varchar(5) NOT NULL,
  `capital_city` bigint(20) NOT NULL,
  `latitude` varchar(11) NOT NULL,
  `longitude` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

CREATE TABLE `role` (
  `roleID` bigint(20) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `role`
--

INSERT INTO `role` (`roleID`, `name`, `description`) VALUES
(1, 'User', ''),
(2, 'Admin', ''),
(3, 'Creator', '');

-- --------------------------------------------------------

--
-- Table structure for table `sentmails`
--

CREATE TABLE `sentmails` (
  `mailId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `email_body` text NOT NULL,
  `date_sent` datetime(6) NOT NULL,
  `email_type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sentmails`
--

INSERT INTO `sentmails` (`mailId`, `userId`, `email_body`, `date_sent`, `email_type`) VALUES
(1, 1671885852119, '<!doctype html>\r\n            <html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n\r\n            <head>\r\n                <title>\r\n\r\n                </title>\r\n                <!--[if !mso]><!-- -->\r\n                <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n                <!--<![endif]-->\r\n                <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\r\n                <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n                <style type=\"text/css\">\r\n                    #outlook a {\r\n                        padding: 0;\r\n                    }\r\n\r\n                    .ReadMsgBody {\r\n                        width: 100%;\r\n                    }\r\n\r\n                    .ExternalClass {\r\n                        width: 100%;\r\n                    }\r\n\r\n                    .ExternalClass * {\r\n                        line-height: 100%;\r\n                    }\r\n\r\n                    body {\r\n                        margin: 0;\r\n                        padding: 0;\r\n                        -webkit-text-size-adjust: 100%;\r\n                        -ms-text-size-adjust: 100%;\r\n                    }\r\n\r\n                    table,\r\n                    td {\r\n                        border-collapse: collapse;\r\n                        mso-table-lspace: 0pt;\r\n                        mso-table-rspace: 0pt;\r\n                    }\r\n\r\n                    img {\r\n                        border: 0;\r\n                        height: auto;\r\n                        line-height: 100%;\r\n                        outline: none;\r\n                        text-decoration: none;\r\n                        -ms-interpolation-mode: bicubic;\r\n                    }\r\n\r\n                    p {\r\n                        display: block;\r\n                        margin: 13px 0;\r\n                    }\r\n                </style>\r\n                <!--[if !mso]><!-->\r\n                <style type=\"text/css\">\r\n                    @media only screen and (max-width:480px) {\r\n                        @-ms-viewport {\r\n                            width: 320px;\r\n                        }\r\n                        @viewport {\r\n                            width: 320px;\r\n                        }\r\n                    }\r\n                </style>\r\n                <!--<![endif]-->\r\n                <!--[if mso]>\r\n                    <xml>\r\n                    <o:OfficeDocumentSettings>\r\n                      <o:AllowPNG/>\r\n                      <o:PixelsPerInch>96</o:PixelsPerInch>\r\n                    </o:OfficeDocumentSettings>\r\n                    </xml>\r\n                    <![endif]-->\r\n                <!--[if lte mso 11]>\r\n                    <style type=\"text/css\">\r\n                      .outlook-group-fix { width:100% !important; }\r\n                    </style>\r\n                    <![endif]-->\r\n\r\n\r\n                <style type=\"text/css\">\r\n                    @media only screen and (min-width:480px) {\r\n                        .mj-column-per-100 {\r\n                            width: 100% !important;\r\n                        }\r\n                    }\r\n                </style>\r\n\r\n\r\n                <style type=\"text/css\">\r\n                </style>\r\n\r\n            </head>\r\n\r\n            <body style=\"background-color:#f9f9f9;\">\r\n\r\n\r\n                <div style=\"background-color:#f9f9f9;\">\r\n\r\n\r\n                    <!--[if mso | IE]>\r\n                  <table\r\n                     align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:600px;\" width=\"600\"\r\n                  >\r\n                    <tr>\r\n                      <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n                  <![endif]-->\r\n\r\n\r\n                    <div style=\"background:#f9f9f9;background-color:#f9f9f9;Margin:0px auto;max-width:600px;\">\r\n\r\n                        <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"background:#f9f9f9;background-color:#f9f9f9;width:100%;\">\r\n                            <tbody>\r\n                                <tr>\r\n                                    <td style=\"border-bottom:#333957 solid 5px;direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;\">\r\n                                        <!--[if mso | IE]>\r\n                              <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n\r\n                    <tr>\r\n\r\n                    </tr>\r\n\r\n                              </table>\r\n                            <![endif]-->\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody>\r\n                        </table>\r\n\r\n                    </div>\r\n\r\n\r\n                    <!--[if mso | IE]>\r\n                      </td>\r\n                    </tr>\r\n                  </table>\r\n\r\n                  <table\r\n                     align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:600px;\" width=\"600\"\r\n                  >\r\n                    <tr>\r\n                      <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n                  <![endif]-->\r\n\r\n\r\n                    <div style=\"background:#fff;background-color:#fff;Margin:0px auto;max-width:600px;\">\r\n\r\n                        <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"background:#fff;background-color:#fff;width:100%;\">\r\n                            <tbody>\r\n                                <tr>\r\n                                    <td style=\"border:#dddddd solid 1px;border-top:0px;direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;\">\r\n                                        <!--[if mso | IE]>\r\n                              <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n\r\n                    <tr>\r\n\r\n                        <td\r\n                           style=\"vertical-align:bottom;width:600px;\"\r\n                        >\r\n                      <![endif]-->\r\n\r\n                                        <div class=\"mj-column-per-100 outlook-group-fix\" style=\"font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:bottom;width:100%;\">\r\n\r\n                                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"vertical-align:bottom;\" width=\"100%\">\r\n\r\n                                                <tr>\r\n                                                    <td align=\"center\" style=\"font-size:0px;padding:10px 25px;word-break:break-word;\">\r\n\r\n                                                        <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"border-collapse:collapse;border-spacing:0px;\">\r\n                                                            <tbody>\r\n                                                                <tr>\r\n                                                                    <td style=\"width:200px;\">\r\n\r\n                                                                        <img height=\"auto\" src=\"http://skillit-001-site1.btempurl.com/assets/icons/logo.png\"\r\n                                                                            style=\"border:0;display:block;outline:none;text-decoration:none;width:100%;\" width=\"64\" />\r\n\r\n                                                                    </td>\r\n                                                                </tr>\r\n                                                            </tbody>\r\n                                                        </table>\r\n\r\n                                                    </td>\r\n                                                </tr>\r\n\r\n\r\n                                                <tr>\r\n                                                    <td align=\"center\" style=\"font-size:0px;padding:10px 25px;word-break:break-word;\">\r\n\r\n                                                        <div style=\"font-family:\'Helvetica Neue\',Arial,sans-serif;font-size:24px;font-weight:bold;line-height:22px;text-align:center;color:#525252;\">\r\n                                                            Thank you for enrolling\r\n                                                        </div>\r\n\r\n                                                    </td>\r\n                                                </tr>\r\n\r\n                                                <tr>\r\n                                                    <td align=\"left\" style=\"font-size:0px;padding:10px 25px;word-break:break-word;\">\r\n\r\n                                                        <div style=\"font-family:\'Helvetica Neue\',Arial,sans-serif;font-size:14px;line-height:22px;text-align:left;color:#525252;\">\r\n                                                            <p>You successfully enrolled to our <b>.NET MAUI for beginners</b> course this day <b>Saturday, 3 January 2026</b>. \r\n                                                                Hoping you will learn a lot from this course, for we are so glad you are taking the course with us. </p>\r\n                                                        </div>\r\n\r\n                                                    </td>\r\n                                                </tr>\r\n\r\n                                                <tr>\r\n                                                    <td align=\"center\" style=\"font-size:0px;padding:10px 25px;padding-top:30px;padding-bottom:50px;word-break:break-word;\">\r\n\r\n                                                        <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"border-collapse:separate;line-height:100%;\">\r\n                                                            <tr>\r\n                                                                <td align=\"center\" bgcolor=\"#2F67F6\" role=\"presentation\" style=\"border:none;border-radius:3px;color:#ffffff;cursor:auto;padding:15px 25px;\" valign=\"middle\">\r\n                                                                    <p style=\"background:#2F67F6;color:#ffffff;font-family:\'Helvetica Neue\',Arial,sans-serif;font-size:15px;font-weight:normal;line-height:120%;Margin:0;text-decoration:none;text-transform:none;\">\r\n                                                                        <a href=\"http://skillit-001-site1.btempurl.com/course_detail/3024u5nirjt04io5w0etiokqt03o\" style=\"color:#fff; text-decoration:none\">\r\n                      Continue learning</a>\r\n                                                                    </p>\r\n                                                                </td>\r\n                                                            </tr>\r\n                                                        </table>\r\n\r\n                                                    </td>\r\n                                                </tr>\r\n\r\n                                                <tr>\r\n                                                    <td align=\"center\" style=\"font-size:0px;padding:10px 25px;word-break:break-word;\">\r\n                                    \r\n                                                        <div\r\n                                                            style=\"font-family:\'Helvetica Neue\',Arial,sans-serif;font-size:24px;font-weight:bold;line-height:22px;text-align:center;color:#525252;\">\r\n                                                            Let us know your experience\r\n                                                        </div>\r\n                                    \r\n                                                    </td>\r\n                                                </tr>\r\n                                    \r\n                                                <tr>\r\n                                                    <td align=\"left\" style=\"font-size:0px;padding:10px 25px;word-break:break-word;\">\r\n                                    \r\n                                                        <div\r\n                                                            style=\"font-family:\'Helvetica Neue\',Arial,sans-serif;font-size:14px;line-height:22px;text-align:left;color:#525252;\">\r\n                                                            <p>\r\n                                                                Please leave us a feedback to tell us more about your experiences because we would love to here from our users.\r\n                                                                <br/>\r\n                                                                <center>You can leave us an email <br/> <a href=\"mailto:support@itskills.ovh\" style=\"color:#2F67F6\">support@itskills.ovh</a>\r\n                                                                <br/> or via our website\r\n                                                                <br> <a href=\"http://skillit-001-site1.btempurl.com/feedback\" style=\"color:#2F67F6\">http://skillit-001-site1.btempurl.com/feedback</a></center>\r\n                                                            </p>\r\n                                                        </div>\r\n\r\n                                                    </td>\r\n                                                </tr>\r\n\r\n                                                <tr>\r\n                                                    <td align=\"left\" style=\"font-size:0px;padding:10px 25px;word-break:break-word;\">\r\n\r\n                                                        <div\r\n                                                            style=\"font-family:\'Helvetica Neue\',Arial,sans-serif;font-size:14px;line-height:20px;text-align:left;color:#525252;\">\r\n                                                            Happy learning,<br><br>Skill-IT Educate, Educate Team<br>\r\n                                                            <a href=\"http://skillit-001-site1.btempurl.com\" style=\"color:#2F67F6\">http://skillit-001-site1.btempurl.com</a>\r\n                                                        </div>\r\n\r\n                                                    </td>\r\n                                                </tr>\r\n\r\n                                            </table>\r\n\r\n                                        </div>\r\n\r\n                                        <!--[if mso | IE]>\r\n                        </td>\r\n\r\n                    </tr>\r\n\r\n                              </table>\r\n                            <![endif]-->\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody>\r\n                        </table>\r\n\r\n                    </div>\r\n\r\n\r\n                    <!--[if mso | IE]>\r\n                      </td>\r\n                    </tr>\r\n                  </table>\r\n\r\n                  <table\r\n                     align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:600px;\" width=\"600\"\r\n                  >\r\n                    <tr>\r\n                      <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n                  <![endif]-->\r\n\r\n\r\n            <div style=\"Margin:0px auto;max-width:600px;\">\r\n\r\n                <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"width:100%;\">\r\n                    <tbody>\r\n                        <tr>\r\n                            <td style=\"direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;\">\r\n                                <!--[if mso | IE]>\r\n                              <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n\r\n                    <tr>\r\n\r\n                        <td\r\n                           style=\"vertical-align:bottom;width:600px;\"\r\n                        >\r\n                      <![endif]-->\r\n\r\n                                <div class=\"mj-column-per-100 outlook-group-fix\"\r\n                                    style=\"font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:bottom;width:100%;\">\r\n\r\n                                    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" width=\"100%\">\r\n                                        <tbody>\r\n                                            <tr>\r\n                                                <td style=\"vertical-align:bottom;padding:0;\">\r\n\r\n                                                    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\"\r\n                                                        width=\"100%\">\r\n\r\n                                                        <tr>\r\n                                                            <td align=\"center\"\r\n                                                                style=\"font-size:0px;padding:0;word-break:break-word;\">\r\n\r\n                                                                <div\r\n                                                                    style=\"font-family:\'Helvetica Neue\',Arial,sans-serif;font-size:12px;font-weight:300;line-height:1;text-align:center;color:#575757;\">\r\n                                                                    Cameroon (CM), Africa\r\n                                                                </div>\r\n\r\n                                                            </td>\r\n                                                        </tr>\r\n\r\n                                                    </table>\r\n\r\n                                                </td>\r\n                                            </tr>\r\n                                        </tbody>\r\n                                    </table>\r\n\r\n                                </div>\r\n\r\n                                <!--[if mso | IE]>\r\n                        </td>\r\n\r\n                    </tr>\r\n\r\n                              </table>\r\n                            <![endif]-->\r\n                            </td>\r\n                        </tr>\r\n                    </tbody>\r\n                </table>\r\n\r\n            </div>\r\n\r\n                    <!--[if mso | IE]>\r\n                      </td>\r\n                    </tr>\r\n                  </table>\r\n                  <![endif]-->\r\n\r\n\r\n                </div>\r\n\r\n            </body>\r\n\r\n            </html>', '2026-01-03 00:25:32.259581', 2);

-- --------------------------------------------------------

--
-- Table structure for table `simple_location`
--

CREATE TABLE `simple_location` (
  `locationId` int(11) NOT NULL,
  `longitude` varchar(15) NOT NULL,
  `latitude` varchar(15) NOT NULL,
  `description` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `skill`
--

CREATE TABLE `skill` (
  `skillID` bigint(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `level` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `skill`
--

INSERT INTO `skill` (`skillID`, `name`, `level`) VALUES
(1, 'Web Development', 3),
(2, 'Mobile Development', 2),
(3, 'C# Programming', 2),
(4, 'JavaScript', 3),
(5, 'Python', 2),
(6, 'Java', 2),
(7, 'SQL', 3),
(8, 'Graphics Design', 2),
(9, 'UI/UX Design', 3),
(10, 'DevOps', 2),
(11, 'Cloud Computing', 2),
(12, 'Machine Learning', 0),
(13, 'Baking', 0);

-- --------------------------------------------------------

--
-- Table structure for table `social`
--

CREATE TABLE `social` (
  `socialID` bigint(20) NOT NULL,
  `name` varchar(20) NOT NULL,
  `link` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `social`
--

INSERT INTO `social` (`socialID`, `name`, `link`) VALUES
(1, 'Twitter', 'twitter.com'),
(2, 'Facebook', 'facebook.com'),
(3, 'LinkedIn', 'linkedin.com'),
(4, 'GitHub', 'github.com'),
(5, 'Instagram', 'instagram.com'),
(6, 'YouTube', 'youtube.com');

-- --------------------------------------------------------

--
-- Table structure for table `testimonial`
--

CREATE TABLE `testimonial` (
  `testimonialId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `content` text NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) NOT NULL,
  `is_approved` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userID` bigint(20) NOT NULL,
  `first_name` varchar(15) NOT NULL,
  `last_name` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(500) NOT NULL,
  `dob` datetime(6) NOT NULL,
  `address` varchar(100) NOT NULL,
  `gender` int(11) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `profile_image` varchar(250) NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `CreatedBy` bigint(20) DEFAULT NULL,
  `UpdatedBy` bigint(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userID`, `first_name`, `last_name`, `email`, `username`, `password`, `dob`, `address`, `gender`, `phone`, `profile_image`, `date_created`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `IsDeleted`, `DeletedAt`, `DeletedBy`) VALUES
(1661689094366, 'Alain', 'Kimbu', 'k.n.alain@gmail.com', 'Aprilman', 'AE1t3CWEYAqaIE0ISiCol6N8m+YsEvPO1Dq3WRn+G7pkYvMEjp3vOe/dOutAcQr84g==', '2022-08-28 00:00:00.000000', 'Bambui, NorthWest Cameroon', 0, '651008132', '1661689094366_k.n.alain@gmail.com_profileImage.png', '2022-08-28 12:18:14.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(1661689919349, 'Alain', 'Kimbu', 'i.am@mail.com', 'ak2000', 'AOEEDhsuyl6lTjWbPvo5VhArqeGuOrrv8CQdgBQNlHkzQTjeJMAow1xCBE+kwSwUqg==', '2022-08-28 00:00:00.000000', 'Address', 0, '623012523', '', '2022-08-28 12:31:59.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(1663957971467, 'Bradon', 'Ted', 'ted.bradon@mail.com', 'bradon', 'AAbhkMr741DvERk3DOG5S31cOQN/DUdbp5WJ4OQIQG42z0+FoNhyFqRBK6XG41Yq9w==', '0001-01-01 00:00:00.000000', 'Bambui, NorthWest Cameroon', 0, '623948023', '', '2022-09-23 18:32:51.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(1668679350122, 'Alain', 'Kimbu', 'nik.alain@gmail.com', 'kan23', 'AP/aIdz5B3LmJ3WhsLsGIlTI0cnYr28/X3mZ43Q8NUm4oNB0Qmgigqy6P008JYlEjw==', '2000-04-29 00:00:00.000000', 'Bambui, Mile 10 mattam quarter', 0, '651008132', '', '2022-11-17 10:02:30.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(1671885852119, 'Rousanne', 'Ngam', 'rousy@gmail.com', 'Rousy', 'AH1GgIzuUu/a/t7sUzVuHLOF0aq9e8Gpj72r9bhlaG/vTOOKEippxN61TwldtuGXwQ==', '2026-01-17 00:00:00.000000', 'Bambui, Mile 10 mattam quarter', 1, '670312417', '1671885852119_rousy@gmail.com_profileImage.png', '2022-12-24 12:44:12.000000', '0001-01-01 00:00:00.000000', '2026-01-02 20:34:11.077435', NULL, NULL, 0, NULL, NULL),
(1677925925595, 'Randy', 'King', 'randy.king@email.com', 'King_R', 'AFveUqywGJGRUy6qINcpdHlZ4kolQxsYubNOQX8jhQHq5Ehjk8QsZK928aqJOhqcSQ==', '1993-04-14 00:00:00.000000', 'Bamenda Cameroon', 0, '651008132', '1677925925595_randy.king@email.com_profileImage.png', '2023-03-04 10:32:05.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(1678544061950, 'Lord', 'Kimbu', 'lordkimbu@gmail.com', 'Lord_K', 'AI5F6F59KvyQUnGmKUA/OverOK465h/P8jiFFRpAC5EtXvIHd7Yt/A487/QfejqulA==', '2000-02-16 00:00:00.000000', 'Bambui, NorthWest Cameroon', 0, '651008132', '1678544061950_lordkimbu@gmail.com_profileImage.png', '2023-03-11 14:14:22.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(1681811805905, 'The', 'Name', 'test@gmail.com', 'test_guy', 'AEGdiiEK0i1hb1h18J9rLIfabiZLdRbDjF4ooiFHtQjSN4r3ox3gx9nLVXpFVq8Ujg==', '2023-04-18 00:00:00.000000', 'Address', 0, '673801740', '', '2023-04-18 09:56:46.000000', '0000-00-00 00:00:00.000000', NULL, NULL, NULL, 0, NULL, NULL),
(1681811805906, '', '', '', '', '', '0001-01-01 00:00:00.000000', '', 0, '', '', '2026-01-02 20:59:53.651722', '2026-01-02 20:59:53.742036', NULL, NULL, NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `user_achievement`
--

CREATE TABLE `user_achievement` (
  `user_achievementID` bigint(20) NOT NULL,
  `achievementID` bigint(20) NOT NULL,
  `userID` bigint(20) NOT NULL,
  `enrollmentID` bigint(20) DEFAULT NULL,
  `catalogID` bigint(20) DEFAULT NULL,
  `user_skillID` bigint(20) DEFAULT NULL,
  `languageID` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_certificate`
--

CREATE TABLE `user_certificate` (
  `user_certificateID` bigint(20) NOT NULL,
  `certificateID` bigint(20) NOT NULL,
  `userID` bigint(20) NOT NULL,
  `courseID` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_city`
--

CREATE TABLE `user_city` (
  `user_cityId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `cityId` bigint(20) NOT NULL,
  `date_set` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_country`
--

CREATE TABLE `user_country` (
  `user_countryId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `countryId` bigint(20) NOT NULL,
  `date_set` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_email`
--

CREATE TABLE `user_email` (
  `user_emailId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `emailId` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_phone`
--

CREATE TABLE `user_phone` (
  `user_phoneId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `phoneId` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_region`
--

CREATE TABLE `user_region` (
  `user_regionId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `regionId` bigint(20) NOT NULL,
  `date_set` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_skill`
--

CREATE TABLE `user_skill` (
  `user_skillID` bigint(20) NOT NULL,
  `skillID` bigint(20) NOT NULL,
  `userID` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user_skill`
--

INSERT INTO `user_skill` (`user_skillID`, `skillID`, `userID`) VALUES
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
(18, 6, 1661689094366),
(19, 13, 1681811805906);

-- --------------------------------------------------------

--
-- Table structure for table `user_social`
--

CREATE TABLE `user_social` (
  `user_socialID` bigint(20) NOT NULL,
  `socialID` bigint(20) NOT NULL,
  `userID` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user_social`
--

INSERT INTO `user_social` (`user_socialID`, `socialID`, `userID`) VALUES
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

-- --------------------------------------------------------

--
-- Table structure for table `user_token`
--

CREATE TABLE `user_token` (
  `user_tokenId` bigint(20) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `token` varchar(500) NOT NULL,
  `expiry_date` datetime(6) NOT NULL,
  `date_created` datetime(6) NOT NULL,
  `last_modified` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20260102160149_InitialCreate', '8.0.0'),
('20260102164713_SeedRoles', '8.0.0'),
('20260102165337_SeedCountriesAndLanguages', '8.0.0'),
('20260102165643_SeedSkillsSocialsAndCatalogs', '8.0.0'),
('20260102172027_SeedUsers', '8.0.0'),
('20260102172214_SeedAccounts', '8.0.0'),
('20260102172330_SeedAllRemainingData', '8.0.0'),
('20260102181221_AddLocationAndTokenEntities', '8.0.0'),
('20260102183354_AddNewsletterPasswordLocation', '8.0.0');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`accountID`),
  ADD UNIQUE KEY `IX_account_userID` (`userID`),
  ADD KEY `IX_account_roleID` (`roleID`);

--
-- Indexes for table `achievement`
--
ALTER TABLE `achievement`
  ADD PRIMARY KEY (`achievementID`);

--
-- Indexes for table `catalog`
--
ALTER TABLE `catalog`
  ADD PRIMARY KEY (`catalogID`);

--
-- Indexes for table `certificate`
--
ALTER TABLE `certificate`
  ADD PRIMARY KEY (`certificateID`);

--
-- Indexes for table `chapter_quiz`
--
ALTER TABLE `chapter_quiz`
  ADD PRIMARY KEY (`chapter_quizID`),
  ADD KEY `IX_chapter_quiz_authorID` (`authorID`),
  ADD KEY `IX_chapter_quiz_chapterID` (`chapterID`),
  ADD KEY `IX_chapter_quiz_quizID` (`quizID`);

--
-- Indexes for table `city`
--
ALTER TABLE `city`
  ADD PRIMARY KEY (`cityId`),
  ADD UNIQUE KEY `idx_city_guid_unique` (`guid`),
  ADD KEY `idx_city_country` (`countryId`);

--
-- Indexes for table `country`
--
ALTER TABLE `country`
  ADD PRIMARY KEY (`countryId`);

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`courseID`),
  ADD UNIQUE KEY `idx_course_guid_unique` (`guid`),
  ADD KEY `idx_course_author` (`authorID`),
  ADD KEY `idx_course_deleted` (`IsDeleted`),
  ADD KEY `idx_course_published_level` (`is_published`,`level`,`date_publish`);

--
-- Indexes for table `course_chapter`
--
ALTER TABLE `course_chapter`
  ADD PRIMARY KEY (`chapterID`),
  ADD KEY `idx_chapter_course_number` (`courseID`,`chapter_number`),
  ADD KEY `IX_course_chapter_authorID` (`authorID`);

--
-- Indexes for table `course_content`
--
ALTER TABLE `course_content`
  ADD PRIMARY KEY (`contentID`),
  ADD KEY `idx_content_lesson_number` (`lessonID`,`content_number`),
  ADD KEY `IX_course_content_authorID` (`authorID`);

--
-- Indexes for table `course_data`
--
ALTER TABLE `course_data`
  ADD PRIMARY KEY (`dataID`),
  ADD KEY `IX_course_data_enrollmentID` (`enrollmentID`);

--
-- Indexes for table `course_enrollments_analytics`
--
ALTER TABLE `course_enrollments_analytics`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_courseenrollment_course_date` (`course_id`,`enrolled_at`),
  ADD KEY `idx_courseenrollment_user_completed` (`user_id`,`is_completed`);

--
-- Indexes for table `course_lesson`
--
ALTER TABLE `course_lesson`
  ADD PRIMARY KEY (`lessonID`),
  ADD KEY `idx_lesson_chapter_number` (`chapterID`,`lesson_number`),
  ADD KEY `IX_course_lesson_authorID` (`authorID`);

--
-- Indexes for table `course_views`
--
ALTER TABLE `course_views`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_courseview_course_date` (`course_id`,`viewed_at`),
  ADD KEY `idx_courseview_user_date` (`user_id`,`viewed_at`);

--
-- Indexes for table `creator`
--
ALTER TABLE `creator`
  ADD PRIMARY KEY (`authorID`),
  ADD UNIQUE KEY `IX_creator_accountID` (`accountID`),
  ADD KEY `IX_creator_roleID` (`roleID`);

--
-- Indexes for table `data_index`
--
ALTER TABLE `data_index`
  ADD PRIMARY KEY (`indexId`),
  ADD KEY `IX_data_index_courseId` (`courseId`);

--
-- Indexes for table `email`
--
ALTER TABLE `email`
  ADD PRIMARY KEY (`emailId`),
  ADD UNIQUE KEY `idx_email_address_unique` (`address`);

--
-- Indexes for table `engagement`
--
ALTER TABLE `engagement`
  ADD PRIMARY KEY (`engagementID`),
  ADD UNIQUE KEY `idx_engagement_user_catalog` (`userID`,`catalogID`),
  ADD KEY `idx_engagement_user_completed` (`userID`,`completed`,`engagedDate`),
  ADD KEY `IX_engagement_catalogID` (`catalogID`);

--
-- Indexes for table `enrollment`
--
ALTER TABLE `enrollment`
  ADD PRIMARY KEY (`enrollmentID`),
  ADD UNIQUE KEY `idx_enrollment_user_course` (`userID`,`courseID`),
  ADD KEY `idx_enrollment_deleted` (`IsDeleted`),
  ADD KEY `idx_enrollment_user_completed` (`userID`,`is_completed`,`date_enrolled`),
  ADD KEY `IX_enrollment_courseID` (`courseID`);

--
-- Indexes for table `enrollment_quiz`
--
ALTER TABLE `enrollment_quiz`
  ADD PRIMARY KEY (`enrollment_quizID`),
  ADD KEY `IX_enrollment_quiz_enrollmentID` (`enrollmentID`),
  ADD KEY `IX_enrollment_quiz_quizID` (`quizID`);

--
-- Indexes for table `feedback`
--
ALTER TABLE `feedback`
  ADD PRIMARY KEY (`feedbackId`),
  ADD KEY `IX_feedback_userId` (`userId`);

--
-- Indexes for table `language`
--
ALTER TABLE `language`
  ADD PRIMARY KEY (`languageId`),
  ADD KEY `IX_language_countryId` (`countryId`);

--
-- Indexes for table `news_letter`
--
ALTER TABLE `news_letter`
  ADD PRIMARY KEY (`news_letterId`),
  ADD UNIQUE KEY `idx_newsletter_guid_unique` (`guid`),
  ADD KEY `idx_newsletter_status_schedule` (`status`,`schedule_date`);

--
-- Indexes for table `news_letter_subscriber`
--
ALTER TABLE `news_letter_subscriber`
  ADD PRIMARY KEY (`news_letter_subscriberId`),
  ADD UNIQUE KEY `idx_newslettersubscriber_code_unique` (`subscriber_code`),
  ADD KEY `idx_newslettersubscriber_email` (`emailId`),
  ADD KEY `IX_news_letter_subscriber_NewsLetterId` (`NewsLetterId`);

--
-- Indexes for table `notification`
--
ALTER TABLE `notification`
  ADD PRIMARY KEY (`notificationId`),
  ADD KEY `idx_notification_account_read_date` (`accountId`,`marked_as_read`,`date_created`);

--
-- Indexes for table `otp`
--
ALTER TABLE `otp`
  ADD PRIMARY KEY (`otpID`),
  ADD UNIQUE KEY `idx_otp_code_user` (`code`,`userId`),
  ADD UNIQUE KEY `idx_otp_guid` (`guid`),
  ADD KEY `idx_otp_user_code_expiry` (`userId`,`code`,`expiryDate`);

--
-- Indexes for table `password`
--
ALTER TABLE `password`
  ADD PRIMARY KEY (`passwordId`),
  ADD KEY `idx_password_lastchanged` (`last_changed`),
  ADD KEY `idx_password_user` (`userId`);

--
-- Indexes for table `phone`
--
ALTER TABLE `phone`
  ADD PRIMARY KEY (`phoneId`),
  ADD KEY `IX_phone_countryId` (`countryId`);

--
-- Indexes for table `project`
--
ALTER TABLE `project`
  ADD PRIMARY KEY (`projectID`),
  ADD KEY `IX_project_userID` (`userID`);

--
-- Indexes for table `question`
--
ALTER TABLE `question`
  ADD PRIMARY KEY (`questionID`),
  ADD KEY `IX_question_authorID` (`authorID`);

--
-- Indexes for table `question_answer`
--
ALTER TABLE `question_answer`
  ADD PRIMARY KEY (`question_answerID`),
  ADD KEY `IX_question_answer_questionID` (`questionID`);

--
-- Indexes for table `question_answer_response`
--
ALTER TABLE `question_answer_response`
  ADD PRIMARY KEY (`question_answer_responseID`),
  ADD KEY `IX_question_answer_response_enrollmentID` (`enrollmentID`),
  ADD KEY `IX_question_answer_response_question_answerID` (`question_answerID`),
  ADD KEY `IX_question_answer_response_questionID` (`questionID`);

--
-- Indexes for table `quiz`
--
ALTER TABLE `quiz`
  ADD PRIMARY KEY (`quizID`),
  ADD KEY `IX_quiz_authorID` (`authorID`);

--
-- Indexes for table `quiz_question`
--
ALTER TABLE `quiz_question`
  ADD PRIMARY KEY (`quiz_questionID`),
  ADD KEY `IX_quiz_question_questionID` (`questionID`),
  ADD KEY `IX_quiz_question_quizID` (`quizID`);

--
-- Indexes for table `region`
--
ALTER TABLE `region`
  ADD PRIMARY KEY (`regionId`),
  ADD UNIQUE KEY `idx_region_guid_unique` (`guid`),
  ADD KEY `idx_region_country` (`countryId`);

--
-- Indexes for table `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`roleID`);

--
-- Indexes for table `sentmails`
--
ALTER TABLE `sentmails`
  ADD PRIMARY KEY (`mailId`);

--
-- Indexes for table `simple_location`
--
ALTER TABLE `simple_location`
  ADD PRIMARY KEY (`locationId`);

--
-- Indexes for table `skill`
--
ALTER TABLE `skill`
  ADD PRIMARY KEY (`skillID`);

--
-- Indexes for table `social`
--
ALTER TABLE `social`
  ADD PRIMARY KEY (`socialID`);

--
-- Indexes for table `testimonial`
--
ALTER TABLE `testimonial`
  ADD PRIMARY KEY (`testimonialId`),
  ADD UNIQUE KEY `idx_testimonial_user_unique` (`userId`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userID`),
  ADD UNIQUE KEY `idx_user_email_unique` (`email`),
  ADD UNIQUE KEY `idx_user_username_unique` (`username`),
  ADD KEY `idx_user_deleted` (`IsDeleted`);

--
-- Indexes for table `user_achievement`
--
ALTER TABLE `user_achievement`
  ADD PRIMARY KEY (`user_achievementID`),
  ADD KEY `IX_user_achievement_achievementID` (`achievementID`),
  ADD KEY `IX_user_achievement_catalogID` (`catalogID`),
  ADD KEY `IX_user_achievement_enrollmentID` (`enrollmentID`),
  ADD KEY `IX_user_achievement_user_skillID` (`user_skillID`),
  ADD KEY `IX_user_achievement_userID` (`userID`);

--
-- Indexes for table `user_certificate`
--
ALTER TABLE `user_certificate`
  ADD PRIMARY KEY (`user_certificateID`),
  ADD KEY `IX_user_certificate_certificateID` (`certificateID`),
  ADD KEY `IX_user_certificate_courseID` (`courseID`),
  ADD KEY `IX_user_certificate_userID` (`userID`);

--
-- Indexes for table `user_city`
--
ALTER TABLE `user_city`
  ADD PRIMARY KEY (`user_cityId`),
  ADD UNIQUE KEY `idx_usercity_user_city_unique` (`userId`,`cityId`),
  ADD KEY `IX_user_city_cityId` (`cityId`);

--
-- Indexes for table `user_country`
--
ALTER TABLE `user_country`
  ADD PRIMARY KEY (`user_countryId`),
  ADD UNIQUE KEY `idx_usercountry_user_country_unique` (`userId`,`countryId`),
  ADD KEY `IX_user_country_countryId` (`countryId`);

--
-- Indexes for table `user_email`
--
ALTER TABLE `user_email`
  ADD PRIMARY KEY (`user_emailId`),
  ADD KEY `IX_user_email_emailId` (`emailId`),
  ADD KEY `IX_user_email_userId` (`userId`);

--
-- Indexes for table `user_phone`
--
ALTER TABLE `user_phone`
  ADD PRIMARY KEY (`user_phoneId`),
  ADD KEY `IX_user_phone_phoneId` (`phoneId`),
  ADD KEY `IX_user_phone_userId` (`userId`);

--
-- Indexes for table `user_region`
--
ALTER TABLE `user_region`
  ADD PRIMARY KEY (`user_regionId`),
  ADD UNIQUE KEY `idx_userregion_user_region_unique` (`userId`,`regionId`),
  ADD KEY `IX_user_region_regionId` (`regionId`);

--
-- Indexes for table `user_skill`
--
ALTER TABLE `user_skill`
  ADD PRIMARY KEY (`user_skillID`),
  ADD KEY `IX_user_skill_skillID` (`skillID`),
  ADD KEY `IX_user_skill_userID` (`userID`);

--
-- Indexes for table `user_social`
--
ALTER TABLE `user_social`
  ADD PRIMARY KEY (`user_socialID`),
  ADD KEY `IX_user_social_socialID` (`socialID`),
  ADD KEY `IX_user_social_userID` (`userID`);

--
-- Indexes for table `user_token`
--
ALTER TABLE `user_token`
  ADD PRIMARY KEY (`user_tokenId`),
  ADD UNIQUE KEY `idx_usertoken_user_unique` (`userId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account`
--
ALTER TABLE `account`
  MODIFY `accountID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `achievement`
--
ALTER TABLE `achievement`
  MODIFY `achievementID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `catalog`
--
ALTER TABLE `catalog`
  MODIFY `catalogID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `certificate`
--
ALTER TABLE `certificate`
  MODIFY `certificateID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `chapter_quiz`
--
ALTER TABLE `chapter_quiz`
  MODIFY `chapter_quizID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `city`
--
ALTER TABLE `city`
  MODIFY `cityId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `country`
--
ALTER TABLE `country`
  MODIFY `countryId` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=246;

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `courseID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `course_chapter`
--
ALTER TABLE `course_chapter`
  MODIFY `chapterID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `course_content`
--
ALTER TABLE `course_content`
  MODIFY `contentID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `course_data`
--
ALTER TABLE `course_data`
  MODIFY `dataID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `course_enrollments_analytics`
--
ALTER TABLE `course_enrollments_analytics`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `course_lesson`
--
ALTER TABLE `course_lesson`
  MODIFY `lessonID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `course_views`
--
ALTER TABLE `course_views`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `creator`
--
ALTER TABLE `creator`
  MODIFY `authorID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1661689919350;

--
-- AUTO_INCREMENT for table `data_index`
--
ALTER TABLE `data_index`
  MODIFY `indexId` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `email`
--
ALTER TABLE `email`
  MODIFY `emailId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `engagement`
--
ALTER TABLE `engagement`
  MODIFY `engagementID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `enrollment`
--
ALTER TABLE `enrollment`
  MODIFY `enrollmentID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT for table `enrollment_quiz`
--
ALTER TABLE `enrollment_quiz`
  MODIFY `enrollment_quizID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `feedback`
--
ALTER TABLE `feedback`
  MODIFY `feedbackId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `language`
--
ALTER TABLE `language`
  MODIFY `languageId` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `news_letter`
--
ALTER TABLE `news_letter`
  MODIFY `news_letterId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `news_letter_subscriber`
--
ALTER TABLE `news_letter_subscriber`
  MODIFY `news_letter_subscriberId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification`
--
ALTER TABLE `notification`
  MODIFY `notificationId` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `otp`
--
ALTER TABLE `otp`
  MODIFY `otpID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `password`
--
ALTER TABLE `password`
  MODIFY `passwordId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `phone`
--
ALTER TABLE `phone`
  MODIFY `phoneId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `project`
--
ALTER TABLE `project`
  MODIFY `projectID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `question`
--
ALTER TABLE `question`
  MODIFY `questionID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `question_answer`
--
ALTER TABLE `question_answer`
  MODIFY `question_answerID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `question_answer_response`
--
ALTER TABLE `question_answer_response`
  MODIFY `question_answer_responseID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `quiz`
--
ALTER TABLE `quiz`
  MODIFY `quizID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `quiz_question`
--
ALTER TABLE `quiz_question`
  MODIFY `quiz_questionID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `region`
--
ALTER TABLE `region`
  MODIFY `regionId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `role`
--
ALTER TABLE `role`
  MODIFY `roleID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `sentmails`
--
ALTER TABLE `sentmails`
  MODIFY `mailId` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `simple_location`
--
ALTER TABLE `simple_location`
  MODIFY `locationId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `skill`
--
ALTER TABLE `skill`
  MODIFY `skillID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `social`
--
ALTER TABLE `social`
  MODIFY `socialID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `testimonial`
--
ALTER TABLE `testimonial`
  MODIFY `testimonialId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `userID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1681811805907;

--
-- AUTO_INCREMENT for table `user_achievement`
--
ALTER TABLE `user_achievement`
  MODIFY `user_achievementID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_certificate`
--
ALTER TABLE `user_certificate`
  MODIFY `user_certificateID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_city`
--
ALTER TABLE `user_city`
  MODIFY `user_cityId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_country`
--
ALTER TABLE `user_country`
  MODIFY `user_countryId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_email`
--
ALTER TABLE `user_email`
  MODIFY `user_emailId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_phone`
--
ALTER TABLE `user_phone`
  MODIFY `user_phoneId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_region`
--
ALTER TABLE `user_region`
  MODIFY `user_regionId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_skill`
--
ALTER TABLE `user_skill`
  MODIFY `user_skillID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `user_social`
--
ALTER TABLE `user_social`
  MODIFY `user_socialID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `user_token`
--
ALTER TABLE `user_token`
  MODIFY `user_tokenId` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `FK_account_role_roleID` FOREIGN KEY (`roleID`) REFERENCES `role` (`roleID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_account_user_userID` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `chapter_quiz`
--
ALTER TABLE `chapter_quiz`
  ADD CONSTRAINT `FK_chapter_quiz_course_chapter_chapterID` FOREIGN KEY (`chapterID`) REFERENCES `course_chapter` (`chapterID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_chapter_quiz_creator_authorID` FOREIGN KEY (`authorID`) REFERENCES `creator` (`authorID`),
  ADD CONSTRAINT `FK_chapter_quiz_quiz_quizID` FOREIGN KEY (`quizID`) REFERENCES `quiz` (`quizID`) ON DELETE CASCADE;

--
-- Constraints for table `city`
--
ALTER TABLE `city`
  ADD CONSTRAINT `FK_city_country_countryId` FOREIGN KEY (`countryId`) REFERENCES `country` (`countryId`) ON DELETE CASCADE;

--
-- Constraints for table `course`
--
ALTER TABLE `course`
  ADD CONSTRAINT `FK_course_creator_authorID` FOREIGN KEY (`authorID`) REFERENCES `creator` (`authorID`);

--
-- Constraints for table `course_chapter`
--
ALTER TABLE `course_chapter`
  ADD CONSTRAINT `FK_course_chapter_course_courseID` FOREIGN KEY (`courseID`) REFERENCES `course` (`courseID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_course_chapter_creator_authorID` FOREIGN KEY (`authorID`) REFERENCES `creator` (`authorID`);

--
-- Constraints for table `course_content`
--
ALTER TABLE `course_content`
  ADD CONSTRAINT `FK_course_content_course_lesson_lessonID` FOREIGN KEY (`lessonID`) REFERENCES `course_lesson` (`lessonID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_course_content_creator_authorID` FOREIGN KEY (`authorID`) REFERENCES `creator` (`authorID`);

--
-- Constraints for table `course_data`
--
ALTER TABLE `course_data`
  ADD CONSTRAINT `FK_course_data_enrollment_enrollmentID` FOREIGN KEY (`enrollmentID`) REFERENCES `enrollment` (`enrollmentID`) ON DELETE CASCADE;

--
-- Constraints for table `course_enrollments_analytics`
--
ALTER TABLE `course_enrollments_analytics`
  ADD CONSTRAINT `FK_course_enrollments_analytics_course_course_id` FOREIGN KEY (`course_id`) REFERENCES `course` (`courseID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_course_enrollments_analytics_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `course_lesson`
--
ALTER TABLE `course_lesson`
  ADD CONSTRAINT `FK_course_lesson_course_chapter_chapterID` FOREIGN KEY (`chapterID`) REFERENCES `course_chapter` (`chapterID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_course_lesson_creator_authorID` FOREIGN KEY (`authorID`) REFERENCES `creator` (`authorID`);

--
-- Constraints for table `course_views`
--
ALTER TABLE `course_views`
  ADD CONSTRAINT `FK_course_views_course_course_id` FOREIGN KEY (`course_id`) REFERENCES `course` (`courseID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_course_views_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `creator`
--
ALTER TABLE `creator`
  ADD CONSTRAINT `FK_creator_account_accountID` FOREIGN KEY (`accountID`) REFERENCES `account` (`accountID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_creator_role_roleID` FOREIGN KEY (`roleID`) REFERENCES `role` (`roleID`) ON DELETE CASCADE;

--
-- Constraints for table `data_index`
--
ALTER TABLE `data_index`
  ADD CONSTRAINT `FK_data_index_course_courseId` FOREIGN KEY (`courseId`) REFERENCES `course` (`courseID`) ON DELETE CASCADE;

--
-- Constraints for table `engagement`
--
ALTER TABLE `engagement`
  ADD CONSTRAINT `FK_engagement_catalog_catalogID` FOREIGN KEY (`catalogID`) REFERENCES `catalog` (`catalogID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_engagement_user_userID` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `enrollment`
--
ALTER TABLE `enrollment`
  ADD CONSTRAINT `FK_enrollment_course_courseID` FOREIGN KEY (`courseID`) REFERENCES `course` (`courseID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_enrollment_user_userID` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `enrollment_quiz`
--
ALTER TABLE `enrollment_quiz`
  ADD CONSTRAINT `FK_enrollment_quiz_enrollment_enrollmentID` FOREIGN KEY (`enrollmentID`) REFERENCES `enrollment` (`enrollmentID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_enrollment_quiz_quiz_quizID` FOREIGN KEY (`quizID`) REFERENCES `quiz` (`quizID`) ON DELETE CASCADE;

--
-- Constraints for table `feedback`
--
ALTER TABLE `feedback`
  ADD CONSTRAINT `FK_feedback_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `language`
--
ALTER TABLE `language`
  ADD CONSTRAINT `FK_language_country_countryId` FOREIGN KEY (`countryId`) REFERENCES `country` (`countryId`);

--
-- Constraints for table `news_letter_subscriber`
--
ALTER TABLE `news_letter_subscriber`
  ADD CONSTRAINT `FK_news_letter_subscriber_email_emailId` FOREIGN KEY (`emailId`) REFERENCES `email` (`emailId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_news_letter_subscriber_news_letter_NewsLetterId` FOREIGN KEY (`NewsLetterId`) REFERENCES `news_letter` (`news_letterId`);

--
-- Constraints for table `notification`
--
ALTER TABLE `notification`
  ADD CONSTRAINT `FK_notification_account_accountId` FOREIGN KEY (`accountId`) REFERENCES `account` (`accountID`) ON DELETE CASCADE;

--
-- Constraints for table `otp`
--
ALTER TABLE `otp`
  ADD CONSTRAINT `FK_otp_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `password`
--
ALTER TABLE `password`
  ADD CONSTRAINT `FK_password_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `phone`
--
ALTER TABLE `phone`
  ADD CONSTRAINT `FK_phone_country_countryId` FOREIGN KEY (`countryId`) REFERENCES `country` (`countryId`) ON DELETE CASCADE;

--
-- Constraints for table `project`
--
ALTER TABLE `project`
  ADD CONSTRAINT `FK_project_user_userID` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `question`
--
ALTER TABLE `question`
  ADD CONSTRAINT `FK_question_creator_authorID` FOREIGN KEY (`authorID`) REFERENCES `creator` (`authorID`);

--
-- Constraints for table `question_answer`
--
ALTER TABLE `question_answer`
  ADD CONSTRAINT `FK_question_answer_question_questionID` FOREIGN KEY (`questionID`) REFERENCES `question` (`questionID`) ON DELETE CASCADE;

--
-- Constraints for table `question_answer_response`
--
ALTER TABLE `question_answer_response`
  ADD CONSTRAINT `FK_question_answer_response_enrollment_enrollmentID` FOREIGN KEY (`enrollmentID`) REFERENCES `enrollment` (`enrollmentID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_question_answer_response_question_answer_question_answerID` FOREIGN KEY (`question_answerID`) REFERENCES `question_answer` (`question_answerID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_question_answer_response_question_questionID` FOREIGN KEY (`questionID`) REFERENCES `question` (`questionID`) ON DELETE CASCADE;

--
-- Constraints for table `quiz`
--
ALTER TABLE `quiz`
  ADD CONSTRAINT `FK_quiz_creator_authorID` FOREIGN KEY (`authorID`) REFERENCES `creator` (`authorID`);

--
-- Constraints for table `quiz_question`
--
ALTER TABLE `quiz_question`
  ADD CONSTRAINT `FK_quiz_question_question_questionID` FOREIGN KEY (`questionID`) REFERENCES `question` (`questionID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_quiz_question_quiz_quizID` FOREIGN KEY (`quizID`) REFERENCES `quiz` (`quizID`) ON DELETE CASCADE;

--
-- Constraints for table `region`
--
ALTER TABLE `region`
  ADD CONSTRAINT `FK_region_country_countryId` FOREIGN KEY (`countryId`) REFERENCES `country` (`countryId`) ON DELETE CASCADE;

--
-- Constraints for table `testimonial`
--
ALTER TABLE `testimonial`
  ADD CONSTRAINT `FK_testimonial_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_achievement`
--
ALTER TABLE `user_achievement`
  ADD CONSTRAINT `FK_user_achievement_achievement_achievementID` FOREIGN KEY (`achievementID`) REFERENCES `achievement` (`achievementID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_achievement_catalog_catalogID` FOREIGN KEY (`catalogID`) REFERENCES `catalog` (`catalogID`),
  ADD CONSTRAINT `FK_user_achievement_enrollment_enrollmentID` FOREIGN KEY (`enrollmentID`) REFERENCES `enrollment` (`enrollmentID`),
  ADD CONSTRAINT `FK_user_achievement_user_skill_user_skillID` FOREIGN KEY (`user_skillID`) REFERENCES `user_skill` (`user_skillID`),
  ADD CONSTRAINT `FK_user_achievement_user_userID` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_certificate`
--
ALTER TABLE `user_certificate`
  ADD CONSTRAINT `FK_user_certificate_certificate_certificateID` FOREIGN KEY (`certificateID`) REFERENCES `certificate` (`certificateID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_certificate_course_courseID` FOREIGN KEY (`courseID`) REFERENCES `course` (`courseID`),
  ADD CONSTRAINT `FK_user_certificate_user_userID` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_city`
--
ALTER TABLE `user_city`
  ADD CONSTRAINT `FK_user_city_city_cityId` FOREIGN KEY (`cityId`) REFERENCES `city` (`cityId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_city_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_country`
--
ALTER TABLE `user_country`
  ADD CONSTRAINT `FK_user_country_country_countryId` FOREIGN KEY (`countryId`) REFERENCES `country` (`countryId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_country_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_email`
--
ALTER TABLE `user_email`
  ADD CONSTRAINT `FK_user_email_email_emailId` FOREIGN KEY (`emailId`) REFERENCES `email` (`emailId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_email_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_phone`
--
ALTER TABLE `user_phone`
  ADD CONSTRAINT `FK_user_phone_phone_phoneId` FOREIGN KEY (`phoneId`) REFERENCES `phone` (`phoneId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_phone_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_region`
--
ALTER TABLE `user_region`
  ADD CONSTRAINT `FK_user_region_region_regionId` FOREIGN KEY (`regionId`) REFERENCES `region` (`regionId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_region_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_skill`
--
ALTER TABLE `user_skill`
  ADD CONSTRAINT `FK_user_skill_skill_skillID` FOREIGN KEY (`skillID`) REFERENCES `skill` (`skillID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_skill_user_userID` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_social`
--
ALTER TABLE `user_social`
  ADD CONSTRAINT `FK_user_social_social_socialID` FOREIGN KEY (`socialID`) REFERENCES `social` (`socialID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_user_social_user_userID` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_token`
--
ALTER TABLE `user_token`
  ADD CONSTRAINT `FK_user_token_user_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
