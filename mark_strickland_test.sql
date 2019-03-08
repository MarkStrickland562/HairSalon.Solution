-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 02, 2019 at 12:33 AM
-- Server version: 5.7.24
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mark_strickland`
--
DROP DATABASE IF EXISTS `mark_strickland_test`;

CREATE DATABASE IF NOT EXISTS `mark_strickland_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `mark_strickland_test`;

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `hire_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `gender` enum('Male','Female','Non-Binary') DEFAULT NULL,
  `stylists_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Table structure for table 'specialties'
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Table structure for table 'stylists_specialties'
--

CREATE TABLE `stylists_specialties` (
  `id` int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `stylists_id` int(11) NOT NULL,
  `specialities_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
