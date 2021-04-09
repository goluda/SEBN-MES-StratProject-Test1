-- Adminer 4.8.0 MySQL 5.5.5-10.5.9-MariaDB-1:10.5.9+maria~focal dump


SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

SET NAMES utf8mb4;

create database materialy;
use materialy;

DROP TABLE IF EXISTS `bom`;
CREATE TABLE `bom` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MaterialNo` varchar(20) NOT NULL,
  `ComponentNo` varchar(20) NOT NULL,
  `Qty` decimal(18,2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


DROP TABLE IF EXISTS `material`;
CREATE TABLE `material` (
  `MaterialNo` varchar(20) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Price` decimal(18,2) NOT NULL,
  PRIMARY KEY (`MaterialNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


DROP TABLE IF EXISTS `Routing`;
CREATE TABLE `Routing` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MaterialNo` varchar(20) NOT NULL,
  `Description` varchar(50) NOT NULL,
  `Time` decimal(18,2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `Routing` (`Id`, `MaterialNo`, `Description`, `Time`) VALUES
(1,	'PRD1',	'Czynność 1',	20.00),
(2,	'PRD1',	'Czynność 2',	10.00),
(3,	'PRD2',	'Czynność 1',	5.00),
(4,	'PRD2',	'Czynność 2',	10.00),
(5,	'PRD2',	'Czynność 3',	7.00),
(6,	'PRD3',	'Czynność 1',	8.00),
(7,	'PRD3',	'Czynność 2',	5.00),
(8,	'PRD3',	'Czynność 3',	1.00),
(9,	'PRD4',	'Czynność 1',	8.00),
(10,	'PRD4',	'Czynność 2',	3.00),
(11,	'PRD5',	'Czynność 1',	10.00),
(12,	'PRD5',	'Czynność 2',	12.00),
(13,	'PRD5',	'Czynność 3',	3.00),
(14,	'PRD6',	'Czynność 1',	5.00),
(15,	'PRD7',	'Czynność 1',	10.00),
(16,	'PRD8',	'Czynność 1',	7.00),
(17,	'PRD9',	'Czynność 1',	5.00),
(18,	'PRD10',	'Czynność 1',	2.00),
(19,	'PRD11',	'Czynność 1',	7.00),
(20,	'PRD12',	'Czynność 1',	8.00),
(21,	'PRD12',	'Czynność 2',	4.00);


INSERT INTO `material` (`MaterialNo`, `Name`, `Price`) VALUES
('PRD1',	'Produkt 1',	0.00),
('PRD10',	'Komponent 6',	7.00),
('PRD11',	'Komponent 5',	6.00),
('PRD12',	'Komponent 7',	23.00),
('PRD13',	'Material 1',	2.00),
('PRD14',	'Material 2',	23.00),
('PRD15',	'Material 3',	16.00),
('PRD16',	'Material 4',	18.00),
('PRD17',	'Material 5',	21.00),
('PRD18',	'Material 6',	23.00),
('PRD19',	'Material 7',	7.00),
('PRD2',	'Produkt 2',	0.00),
('PRD20',	'Material 8',	2.00),
('PRD21',	'Material 10',	11.00),
('PRD22',	'Material 11',	9.00),
('PRD23',	'Material 12',	21.00),
('PRD3',	'Produkt 3',	0.00),
('PRD4',	'Produkt 4',	0.00),
('PRD5',	'Produkt 5',	0.00),
('PRD6',	'Komponent 1',	8.00),
('PRD7',	'Komponent 2',	2.00),
('PRD8',	'Komponent 3',	12.00),
('PRD9',	'Komponent 4',	34.00);




INSERT INTO `bom` (`Id`, `MaterialNo`, `ComponentNo`, `Qty`) VALUES
(1,	'PRD1',	'PRD6',	2.00),
(2,	'PRD1',	'PRD8',	1.00),
(3,	'PRD1',	'PRD13',	2.00),
(4,	'PRD1',	'PRD14',	3.00),
(5,	'PRD1',	'PRD15',	6.00),
(6,	'PRD2',	'PRD6',	2.00),
(7,	'PRD2',	'PRD7',	2.00),
(8,	'PRD2',	'PRD8',	1.00),
(9,	'PRD2',	'PRD9',	1.00),
(10,	'PRD2',	'PRD23',	7.00),
(11,	'PRD3',	'PRD7',	1.00),
(12,	'PRD3',	'PRD19',	10.00),
(13,	'PRD3',	'PRD10',	2.00),
(14,	'PRD4',	'PRD9',	1.00),
(15,	'PRD4',	'PRD10',	2.00),
(16,	'PRD5',	'PRD13',	10.00),
(17,	'PRD5',	'PRD22',	4.00),
(18,	'PRD5',	'P4D23',	8.00),
(19,	'PRD6',	'PRD7',	3.00),
(20,	'PRD6',	'PRD13',	1.00),
(21,	'PRD6',	'PRD14',	2.00),
(22,	'PRD7',	'PRD15',	23.00),
(23,	'PRD7',	'PRD16',	1.00),
(24,	'PRD7',	'PRD18',	4.00),
(25,	'PRD7',	'PRD20',	5.00),
(26,	'PRD7',	'PRD19',	4.00),
(27,	'PRD8',	'PRD7',	4.00),
(28,	'PRD8',	'PRD16',	3.00),
(29,	'PRD8',	'PRD17',	5.00),
(30,	'PRD8',	'PRD19',	4.00),
(31,	'PRD9',	'PRD8',	2.00),
(32,	'PRD9',	'PRD7',	2.00),
(33,	'PRD10',	'PRD14',	10.00),
(34,	'PRD10',	'PRD15',	20.00),
(35,	'PRD10',	'PRD16',	4.00),
(36,	'PRD10',	'PRD17',	2.00),
(37,	'PRD11',	'PRD15',	3.00),
(38,	'PRD11',	'PRD14',	2.00),
(39,	'PRD12',	'PRD22',	1.00),
(40,	'PRD12',	'PRD23',	1.00),
(41,	'PRD12',	'PRD16',	6.00);