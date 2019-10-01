-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 25, 2019 at 07:09 PM
-- Server version: 10.1.36-MariaDB
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
-- Database: `weatherdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `fivedaysinfo`
--

CREATE TABLE `fivedaysinfo` (
  `Temperature` double DEFAULT NULL,
  `Place` text,
  `Date` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fivedaysinfo`
--

INSERT INTO `fivedaysinfo` (`Temperature`, `Place`, `Date`) VALUES
(18, 'Longdon,GBR', '06.20.2019 10:00'),
(17, 'Longdon,GBR', '06.20.2019 13:00'),
(17, 'Longdon,GBR', '06.20.2019 16:00'),
(15, 'Longdon,GBR', '06.20.2019 19:00'),
(8, 'Longdon,GBR', '06.20.2019 22:00'),
(6, 'Longdon,GBR', '06.21.2019 01:00'),
(5, 'Longdon,GBR', '06.21.2019 04:00'),
(9, 'Longdon,GBR', '06.21.2019 07:00'),
(14, 'Longdon,GBR', '06.21.2019 10:00'),
(15, 'Longdon,GBR', '06.21.2019 13:00'),
(15, 'Longdon,GBR', '06.21.2019 16:00'),
(15, 'Longdon,GBR', '06.21.2019 19:00'),
(9, 'Longdon,GBR', '06.21.2019 22:00'),
(7, 'Longdon,GBR', '06.22.2019 01:00'),
(5, 'Longdon,GBR', '06.22.2019 04:00'),
(8, 'Longdon,GBR', '06.22.2019 07:00'),
(14, 'Longdon,GBR', '06.22.2019 10:00'),
(17, 'Longdon,GBR', '06.22.2019 13:00'),
(18, 'Longdon,GBR', '06.22.2019 16:00'),
(17, 'Longdon,GBR', '06.22.2019 19:00'),
(12, 'Longdon,GBR', '06.22.2019 22:00'),
(10, 'Longdon,GBR', '06.23.2019 01:00'),
(9, 'Longdon,GBR', '06.23.2019 04:00'),
(11, 'Longdon,GBR', '06.23.2019 07:00'),
(15, 'Longdon,GBR', '06.23.2019 10:00'),
(19, 'Longdon,GBR', '06.23.2019 13:00'),
(21, 'Longdon,GBR', '06.23.2019 16:00'),
(19, 'Longdon,GBR', '06.23.2019 19:00'),
(17, 'Longdon,GBR', '06.23.2019 22:00'),
(16, 'Longdon,GBR', '06.24.2019 01:00'),
(15, 'Longdon,GBR', '06.24.2019 04:00'),
(15, 'Longdon,GBR', '06.24.2019 07:00'),
(20, 'Longdon,GBR', '06.24.2019 10:00'),
(23, 'Longdon,GBR', '06.24.2019 13:00'),
(23, 'Longdon,GBR', '06.24.2019 16:00'),
(18, 'Longdon,GBR', '06.24.2019 19:00'),
(17, 'Longdon,GBR', '06.24.2019 22:00'),
(16, 'Longdon,GBR', '06.25.2019 01:00'),
(17, 'Longdon,GBR', '06.25.2019 04:00'),
(17, 'Longdon,GBR', '06.25.2019 07:00');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
