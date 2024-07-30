-- MySqlBackup.NET 2.3.6
-- Dump Time: 2024-06-23 16:51:09
-- --------------------------------------
-- Server version 8.0.31 MySQL Community Server - GPL


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of creditedstatus
-- 

DROP TABLE IF EXISTS `creditedstatus`;
CREATE TABLE IF NOT EXISTS `creditedstatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table creditedstatus
-- 

/*!40000 ALTER TABLE `creditedstatus` DISABLE KEYS */;
INSERT INTO `creditedstatus`(`id`,`name`) VALUES(1,'зачислен'),(3,'учится'),(4,'закончил'),(5,'отчислен');
/*!40000 ALTER TABLE `creditedstatus` ENABLE KEYS */;

-- 
-- Definition of customer
-- 

DROP TABLE IF EXISTS `customer`;
CREATE TABLE IF NOT EXISTS `customer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table customer
-- 

/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer`(`id`,`name`) VALUES(1,'сами'),(2,'предприятие');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;

-- 
-- Definition of education
-- 

DROP TABLE IF EXISTS `education`;
CREATE TABLE IF NOT EXISTS `education` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table education
-- 

/*!40000 ALTER TABLE `education` DISABLE KEYS */;
INSERT INTO `education`(`id`,`title`,`modifiedBy`) VALUES(1,'основное общее','2024-05-09 21:26:02'),(2,'среднее общее','2024-05-08 22:47:35'),(3,'ППКЗ','2024-05-08 22:47:35'),(4,'ППССЗ','2024-05-08 22:47:35'),(5,'высшее профессиональное (магистр)','2024-05-08 22:47:35'),(6,'высшее профессиональное (бакалавр)','2024-05-08 22:47:35');
/*!40000 ALTER TABLE `education` ENABLE KEYS */;

-- 
-- Definition of employee
-- 

DROP TABLE IF EXISTS `employee`;
CREATE TABLE IF NOT EXISTS `employee` (
  `id` int NOT NULL AUTO_INCREMENT,
  `code` varchar(3) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `job` varchar(80) NOT NULL,
  `image` varchar(100) NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table employee
-- 

/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee`(`id`,`code`,`surname`,`name`,`patronymic`,`job`,`image`,`modifiedBy`) VALUES(1,'123','Егоров','Даниил','Дмитриевич','Разработчик','ronaldo.png','2024-06-14 22:57:29'),(3,'130','Давыдова','Кристина','Денисовна','Кассир','plug.jpg','2024-06-14 22:24:27'),(4,'125','Антонов','Николай','Сергеевич','Мастер','kroos.jpg','2024-06-14 22:42:10'),(5,'145','Давыдов','Денис','Николаевич','Заведующий','alisson.jpg','2024-06-10 17:58:41');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;

-- 
-- Definition of employment
-- 

DROP TABLE IF EXISTS `employment`;
CREATE TABLE IF NOT EXISTS `employment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table employment
-- 

/*!40000 ALTER TABLE `employment` DISABLE KEYS */;
INSERT INTO `employment`(`id`,`title`,`modifiedBy`) VALUES(1,'учащийся','2024-05-09 21:26:02'),(2,'безработный','2024-05-09 21:59:10'),(5,'студент ВО','2024-05-09 21:26:02'),(6,'занятый','2024-05-09 22:01:39');
/*!40000 ALTER TABLE `employment` ENABLE KEYS */;

-- 
-- Definition of endstatus
-- 

DROP TABLE IF EXISTS `endstatus`;
CREATE TABLE IF NOT EXISTS `endstatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table endstatus
-- 

/*!40000 ALTER TABLE `endstatus` DISABLE KEYS */;
INSERT INTO `endstatus`(`id`,`name`) VALUES(1,'освоен'),(2,'не освоен');
/*!40000 ALTER TABLE `endstatus` ENABLE KEYS */;

-- 
-- Definition of gender
-- 

DROP TABLE IF EXISTS `gender`;
CREATE TABLE IF NOT EXISTS `gender` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table gender
-- 

/*!40000 ALTER TABLE `gender` DISABLE KEYS */;
INSERT INTO `gender`(`id`,`name`) VALUES(1,'Мужской'),(2,'Женский');
/*!40000 ALTER TABLE `gender` ENABLE KEYS */;

-- 
-- Definition of group
-- 

DROP TABLE IF EXISTS `group`;
CREATE TABLE IF NOT EXISTS `group` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `countPeople` int NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table group
-- 

/*!40000 ALTER TABLE `group` DISABLE KEYS */;
INSERT INTO `group`(`id`,`name`,`countPeople`,`modifiedBy`) VALUES(1,'БД-23',10,'2024-04-28 21:41:42'),(2,'ИС-21А',2,'2024-04-28 21:41:42'),(3,'ИС-21Б',2,'2024-04-28 21:41:42'),(4,'ИС-22А',8,'2024-04-28 21:41:42'),(6,'БУ-24А',3,'2024-04-28 22:38:32');
/*!40000 ALTER TABLE `group` ENABLE KEYS */;

-- 
-- Definition of listener
-- 

DROP TABLE IF EXISTS `listener`;
CREATE TABLE IF NOT EXISTS `listener` (
  `id` int NOT NULL AUTO_INCREMENT,
  `surname` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `address` varchar(80) DEFAULT NULL,
  `birthday` date NOT NULL,
  `phone` varchar(18) NOT NULL,
  `employment` int NOT NULL,
  `education` int NOT NULL,
  `document` int NOT NULL,
  `gender` int NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_employment_idx` (`employment`),
  KEY `fk_education_idx` (`education`),
  KEY `fk_gender_idx` (`gender`),
  KEY `fk_document_idx` (`document`),
  CONSTRAINT `fk_document` FOREIGN KEY (`document`) REFERENCES `document` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_education` FOREIGN KEY (`education`) REFERENCES `education` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_employment` FOREIGN KEY (`employment`) REFERENCES `employment` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_gender` FOREIGN KEY (`gender`) REFERENCES `gender` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table listener
-- 

/*!40000 ALTER TABLE `listener` DISABLE KEYS */;
INSERT INTO `listener`(`id`,`surname`,`name`,`patronymic`,`address`,`birthday`,`phone`,`employment`,`education`,`document`,`gender`,`modifiedBy`) VALUES(44,'Иванов','Иван','Иванович','ул. Пушкина, д.10','2008-04-20 00:00:00','+7 (321) 412-4214',1,1,1,1,'2024-06-13 20:18:58'),(45,'Петров','Петр','Петрович','пр. Ленина, д.25','2007-04-25 00:00:00','987-65-43',1,1,1,1,'2024-04-21 23:59:17'),(46,'Сидорова','Мария','','ул. Гагарина, д.7','1990-11-20 00:00:00','111-22-33',1,1,1,1,'2024-04-21 23:59:17'),(47,'Смирнов','Александр','Сергеевич','пр. Мира, д.15','2009-10-10 00:00:00','+7 (555) 667-7312',1,5,1,1,'2024-04-25 22:23:47'),(49,'Иванова','Татьяна','Сергеевна','пр. Победы, д.8','1979-09-03 00:00:00','+7 (777) 889-9223',1,4,1,1,'2024-06-13 14:30:29'),(50,'Смирнов','Сергей','Петрович','ул. Ленина, д.30','1985-04-17 00:00:00','333-44-55',1,1,1,1,'2024-04-21 23:59:17'),(51,'Попов','Дмитрий','Алексеевич','пр. Строителей, д.22','2007-04-29 00:00:00','+7 (777) 889-9492',1,1,1,1,'2024-04-21 23:59:17'),(52,'Михайлова','Елена','Андреевна','ул. Кирова, д.6','2010-04-29 00:00:00','+7 (527) 889-9492',1,1,1,1,'2024-04-21 23:59:17'),(53,'Кузнецов','Анатолий','Анатольевич','пр. Мира, д.18','2007-03-20 00:00:00','999-00-11',1,1,1,1,'2024-04-21 23:59:17'),(54,'Иванова','Анна','Александровна','ул. Лермонтова, д.3','1993-08-25 00:00:00','111-22-33',1,1,1,1,'2024-04-21 23:59:17'),(55,'Смирнов','Николай','Павлович','пр. Мира, д.7','1989-04-30 00:00:00','+7 (444) 556-6312',1,1,1,1,'2024-04-25 00:59:46'),(56,'Петрова','Наталья','Сергеевна','ул. Горького, д.12','1987-11-15 00:00:00','777-88-99',1,1,1,1,'2024-04-21 23:59:17'),(57,'Кузнецов','Владимир','Иванович','пр. Стачек, д.21','1990-02-10 00:00:00','999-00-11',1,1,1,1,'2024-04-21 23:59:17'),(58,'Сидоров','Тимофей','Федорович','ул. Пушкина, д.5','2007-04-15 00:00:00','222-33-44',1,1,1,1,'2024-04-21 23:59:17'),(59,'Павлова','Екатерина','Петровна','пр. Ленина, д.9','1984-03-22 00:00:00','888-99-44',1,1,1,1,'2024-04-21 23:59:17'),(60,'Михайлов','Дмитрий','Владимирович','ул. Кирова, д.17','1992-09-07 00:00:00','555-66-77',1,1,1,1,'2024-04-21 23:59:17'),(61,'Новикова','Ольга','Михайловна','пр. Победы, д.11','1983-12-03 00:00:00','333-44-55',1,1,1,1,'2024-04-21 23:59:17'),(62,'Федоров','Станислав','Егорович','ул. Гагарина, д.2','1980-07-28 00:00:00','666-77-88',1,1,1,1,'2024-04-21 23:59:17'),(63,'Белов','Александр','Семенович','пр. Московский, д.4','1981-05-19 00:00:00','123-45-67',1,1,1,1,'2024-04-21 23:59:17'),(65,'Сергеев','Николай','Александрович','Заволжье','2002-12-12 00:00:00','+7 (321) 321-3213',1,1,5,1,'2024-04-21 23:59:17');
/*!40000 ALTER TABLE `listener` ENABLE KEYS */;

-- 
-- Definition of openstatus
-- 

DROP TABLE IF EXISTS `openstatus`;
CREATE TABLE IF NOT EXISTS `openstatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table openstatus
-- 

/*!40000 ALTER TABLE `openstatus` DISABLE KEYS */;
INSERT INTO `openstatus`(`id`,`name`) VALUES(1,'открыт'),(2,'закрыт');
/*!40000 ALTER TABLE `openstatus` ENABLE KEYS */;

-- 
-- Definition of organization
-- 

DROP TABLE IF EXISTS `organization`;
CREATE TABLE IF NOT EXISTS `organization` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `littleName` varchar(100) DEFAULT NULL,
  `requisites` varchar(150) NOT NULL,
  `inn` varchar(12) NOT NULL,
  `kpp` varchar(9) NOT NULL,
  `bik` varchar(9) NOT NULL,
  `personalAccount` varchar(100) DEFAULT NULL,
  `paymentAccount` varchar(100) NOT NULL,
  `onlyTreasureAccount` varchar(20) NOT NULL,
  `treasureAccount` varchar(20) NOT NULL,
  `director` varchar(80) DEFAULT NULL,
  `license` varchar(100) DEFAULT NULL,
  `bank` varchar(70) DEFAULT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table organization
-- 

/*!40000 ALTER TABLE `organization` DISABLE KEYS */;
INSERT INTO `organization`(`id`,`name`,`littleName`,`requisites`,`inn`,`kpp`,`bik`,`personalAccount`,`paymentAccount`,`onlyTreasureAccount`,`treasureAccount`,`director`,`license`,`bank`,`modifiedBy`) VALUES(1,'ООО \"Пицца\"','ООО \"Пицца\"','г. Заволжье, ул. Пушкина, д. 56','123456789123','123456789','123456789','Министерство финансов Нижегородской обл. (ГБПОУ ЗАМТ)','40601810422023000001 ВОЛГО-ВЯТСКОЕ ГУ БАНКА РОССИИ Г. НИЖНИЙ НОВГОРОД','40102810745370000024','03224643220000003206','Кузбыев И.А.','серия 52Л01 № 002002, выданной 07 апреля 2015 г. Министерством образования Нижегородской области','СБЕРБАНК','2024-05-08 22:47:35'),(2,'ООО \"Кукояки\"','ООО \"Кукояки\"','г. Заволжье, ул. Пушкина, д. 57','312421414142','412441242','144214124','Есть','Есть','40102810745370000025','03224643220000003201','Игорин К. В.','Интересная','СБЕРБАНК','2024-05-01 20:49:08'),(3,'Государственное бюджетное профессиональное учреждение \"Заволжский автоматорный техникум\"','ГБПОУ \"ЗАМТ\"','606520 Нижегородская область, Городецкий район, г. Заволжье, пр. Мира 18','5248007963','524801001','042202001','Министерство финансов Нижегородской обл. (ГБПОУ \"ЗАМТ\")','40601810422023000001 ВОЛГО-ВЯТСКОЕ ГУ БАНКА РОССИИ Г. НИЖНИЙ НОВГОРОД','40102810745370000024','03224643220000003200','Осянин Андрей Николаевич','серия 52Л01 № 002002, выданной 07 апреля 2015 г. Министерством образования Нижегородской области',NULL,'2024-05-11 01:57:43');
/*!40000 ALTER TABLE `organization` ENABLE KEYS */;

-- 
-- Definition of passport
-- 

DROP TABLE IF EXISTS `passport`;
CREATE TABLE IF NOT EXISTS `passport` (
  `id` int NOT NULL AUTO_INCREMENT,
  `series` varchar(4) NOT NULL,
  `number` varchar(6) NOT NULL,
  `issueDate` date NOT NULL,
  `issuedBy` varchar(80) NOT NULL,
  `departmentCode` varchar(8) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table passport
-- 

/*!40000 ALTER TABLE `passport` DISABLE KEYS */;
INSERT INTO `passport`(`id`,`series`,`number`,`issueDate`,`issuedBy`,`departmentCode`) VALUES(1,'2250','456231','2018-03-27 00:00:00','ГУ МВД России по Нижегородской области','321-412'),(6,'1232','521321','2018-02-15 00:00:00','ГУ МВД России по Нижегородской области','123-213');
/*!40000 ALTER TABLE `passport` ENABLE KEYS */;

-- 
-- Definition of document
-- 

DROP TABLE IF EXISTS `document`;
CREATE TABLE IF NOT EXISTS `document` (
  `id` int NOT NULL AUTO_INCREMENT,
  `insuranceNumber` varchar(15) DEFAULT NULL,
  `passport` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_passport_idx` (`passport`),
  CONSTRAINT `fk_passport` FOREIGN KEY (`passport`) REFERENCES `passport` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table document
-- 

/*!40000 ALTER TABLE `document` DISABLE KEYS */;
INSERT INTO `document`(`id`,`insuranceNumber`,`passport`) VALUES(1,'287-951-825 80',1),(5,'123-213-124 12',6);
/*!40000 ALTER TABLE `document` ENABLE KEYS */;

-- 
-- Definition of paymentstatus
-- 

DROP TABLE IF EXISTS `paymentstatus`;
CREATE TABLE IF NOT EXISTS `paymentstatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table paymentstatus
-- 

/*!40000 ALTER TABLE `paymentstatus` DISABLE KEYS */;
INSERT INTO `paymentstatus`(`id`,`name`) VALUES(2,'не оплачен'),(3,'оплачен');
/*!40000 ALTER TABLE `paymentstatus` ENABLE KEYS */;

-- 
-- Definition of qualification
-- 

DROP TABLE IF EXISTS `qualification`;
CREATE TABLE IF NOT EXISTS `qualification` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table qualification
-- 

/*!40000 ALTER TABLE `qualification` DISABLE KEYS */;
INSERT INTO `qualification`(`id`,`name`,`modifiedBy`) VALUES(1,'подготовка','2024-05-09 21:26:02'),(2,'переподготовка','2024-05-11 00:15:59'),(3,'повышение квалификации','2024-05-09 21:26:02'),(4,'курсы дополнительного образования','2024-05-09 21:26:02'),(5,'подготовительные курсы','2024-05-09 21:26:02'),(6,'курсы по профессиям','2024-05-21 20:35:30');
/*!40000 ALTER TABLE `qualification` ENABLE KEYS */;

-- 
-- Definition of course
-- 

DROP TABLE IF EXISTS `course`;
CREATE TABLE IF NOT EXISTS `course` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `duration` int NOT NULL,
  `price` double NOT NULL,
  `qualification` int NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_qualification_idx` (`qualification`),
  CONSTRAINT `fk_qualification` FOREIGN KEY (`qualification`) REFERENCES `qualification` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table course
-- 

/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course`(`id`,`name`,`duration`,`price`,`qualification`,`modifiedBy`) VALUES(1,'Электрогазосварщик',480,18000,1,'2024-04-29 23:58:31'),(2,'Повар',480,16000,1,'2024-04-29 23:58:31'),(3,'Электрогазосварщик',680,18999.99,5,'2024-06-06 20:43:49'),(4,'Повар',360,13000,2,'2024-04-29 23:58:31'),(5,'Бухгалтерский учет',800,20000,2,'2024-06-06 20:44:21'),(6,'Повар',72,5000,3,'2024-04-29 23:58:31'),(7,'Электрогазосварщик',72,6000,3,'2024-04-29 23:58:31'),(8,'Математика и русский язык',172,9000,5,'2024-04-29 23:58:31'),(9,'1С:Бухгалтерия',40,3800,4,'2024-06-06 20:43:17'),(10,'1С:Предприятие',75,6500,4,'2024-04-29 23:58:31');
/*!40000 ALTER TABLE `course` ENABLE KEYS */;

-- 
-- Definition of representative
-- 

DROP TABLE IF EXISTS `representative`;
CREATE TABLE IF NOT EXISTS `representative` (
  `id` int NOT NULL AUTO_INCREMENT,
  `surname` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `address` varchar(150) NOT NULL,
  `phone` varchar(18) NOT NULL,
  `idListener` int NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_lis_rep_idx` (`idListener`),
  CONSTRAINT `fk_lis_rep` FOREIGN KEY (`idListener`) REFERENCES `listener` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table representative
-- 

/*!40000 ALTER TABLE `representative` DISABLE KEYS */;
INSERT INTO `representative`(`id`,`surname`,`name`,`patronymic`,`address`,`phone`,`idListener`,`modifiedBy`) VALUES(4,'Сергеев','Иван','Игоревич','Нижегородская область, Городецкий район, г. Заволжье, ул. Рылеева, д. 55','+7 (904) 950-6242',51,'2024-05-05 00:15:12'),(5,'Иванов','Петр','Алексеевич','Московская область, г. Москва, ул. Ленина, д. 10','+7 (904) 950-6243',45,'2024-04-30 01:22:58'),(6,'Георгиев','Олег','Иванович','Нижегородская область, Балахнинский район, д. Гумнищи, д. 105','+7 (904) 952-4123',47,'2024-05-05 00:13:39'),(11,'Иванов','Сергей','Исламович','Нижегородская область, Нижегородская область, Балахнинский район, д. Гумнищи, д. 107','+7 (904) 954-2312',53,'2024-05-05 01:17:49'),(12,'Антонов','Иван','Анатольевич','Нижегородская область, Балахнинский район, д. Гумнищи, д. 120','+7 (940) 421-0412',58,'2024-05-05 01:21:50'),(13,'Игнатьев','Николай','Игнатьевич','Нижегородская область, Балахнинский район, д. Гумнищи, д. 150','+7 (431) 241-2412',52,'2024-06-06 21:37:42'),(14,'Петросян','Иван','Петрович','Нижегородская область, Балахнинский район, д. Гумнищи, д. 105','+7 (904) 925-1251',44,'2024-05-06 21:07:56'),(15,'Иванов','Антон','Георгиевич','Нижегородская область, Балахнинский район, д. Гумнищи, д. 115','+7 (332) 131-3213',54,'2024-06-06 21:38:20');
/*!40000 ALTER TABLE `representative` ENABLE KEYS */;

-- 
-- Definition of record
-- 

DROP TABLE IF EXISTS `record`;
CREATE TABLE IF NOT EXISTS `record` (
  `id` int NOT NULL AUTO_INCREMENT,
  `listener` int NOT NULL,
  `code` varchar(45) NOT NULL,
  `organization` int DEFAULT NULL,
  `group` int DEFAULT NULL,
  `course` int NOT NULL,
  `decorationDate` date NOT NULL,
  `maternityCapital` int NOT NULL,
  `startCourse` date NOT NULL,
  `endCourse` date NOT NULL,
  `representative` int DEFAULT NULL,
  `paymentStatus` int NOT NULL,
  `endStatus` int NOT NULL,
  `creditedStatus` int NOT NULL,
  `openStatus` int NOT NULL,
  `actualPayment` double NOT NULL,
  `transferOrder` varchar(45) DEFAULT NULL,
  `dateTransferOrder` date DEFAULT NULL,
  `expulsionOrder` varchar(45) DEFAULT NULL,
  `dateExpulsionOrder` date DEFAULT NULL,
  `modifiedBy` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_listener_idx` (`listener`),
  KEY `fk_organization_record_idx` (`organization`),
  KEY `fk_group_idx` (`group`),
  KEY `fk_representative_idx` (`representative`),
  KEY `fk_course_record_idx` (`course`),
  KEY `fk_paymentStatus_idx` (`paymentStatus`),
  KEY `fk_openStatus_idx` (`openStatus`),
  KEY `fk_creditedStatus_idx` (`creditedStatus`),
  KEY `fk_endStatus_idx` (`endStatus`),
  CONSTRAINT `fk_course_record` FOREIGN KEY (`course`) REFERENCES `course` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_creditedStatus` FOREIGN KEY (`creditedStatus`) REFERENCES `creditedstatus` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_endStatus` FOREIGN KEY (`endStatus`) REFERENCES `endstatus` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_group_record` FOREIGN KEY (`group`) REFERENCES `group` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_listener` FOREIGN KEY (`listener`) REFERENCES `listener` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_openStatus` FOREIGN KEY (`openStatus`) REFERENCES `openstatus` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_organization_record` FOREIGN KEY (`organization`) REFERENCES `organization` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_paymentStatus` FOREIGN KEY (`paymentStatus`) REFERENCES `paymentstatus` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_representative` FOREIGN KEY (`representative`) REFERENCES `representative` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table record
-- 

/*!40000 ALTER TABLE `record` DISABLE KEYS */;
INSERT INTO `record`(`id`,`listener`,`code`,`organization`,`group`,`course`,`decorationDate`,`maternityCapital`,`startCourse`,`endCourse`,`representative`,`paymentStatus`,`endStatus`,`creditedStatus`,`openStatus`,`actualPayment`,`transferOrder`,`dateTransferOrder`,`expulsionOrder`,`dateExpulsionOrder`,`modifiedBy`) VALUES(2,46,'КУ-24-15',1,2,9,'2024-04-30 00:00:00',0,'2024-05-05 00:00:00','2024-05-30 00:00:00',NULL,2,1,5,1,0,'КП-2022.10',NULL,'КП-2022.15',NULL,'2024-06-23 16:42:12'),(5,44,'БУ-23.14',NULL,2,2,'2024-05-01 00:00:00',1,'2024-05-02 00:00:00','2024-10-04 00:00:00',4,3,2,1,1,0,NULL,NULL,NULL,NULL,'2024-05-06 21:15:37'),(7,44,'БУ-23.10',NULL,3,9,'2024-05-02 00:00:00',0,'2024-02-06 00:00:00','2024-05-04 00:00:00',NULL,2,2,3,1,1500,'РП-23212','2024-06-14 00:00:00','РП-4444','2024-08-13 00:00:00','2024-06-13 14:45:35'),(9,44,'КУ-23.10',NULL,6,9,'2024-05-02 00:00:00',0,'2024-07-05 00:00:00','2024-09-05 00:00:00',NULL,2,2,4,2,0,NULL,NULL,NULL,NULL,'2024-05-14 23:53:45'),(10,50,'БУ-23.20',NULL,6,9,'2024-05-06 00:00:00',0,'2024-04-02 00:00:00','2024-04-07 00:00:00',NULL,2,2,3,1,0,NULL,NULL,NULL,NULL,'2024-05-14 23:54:51'),(11,52,'БУ-23.76',NULL,6,9,'2024-05-06 00:00:00',0,'2024-04-02 00:00:00','2024-07-05 00:00:00',NULL,2,2,5,1,0,NULL,NULL,NULL,NULL,'2024-05-06 21:15:37'),(12,54,'БУ.23-15',NULL,4,2,'2024-05-06 00:00:00',0,'2024-05-07 00:00:00','2024-05-26 00:00:00',NULL,3,1,1,1,0,'КП-2022','2024-05-25 00:00:00','КП-2022','2024-05-25 00:00:00','2024-05-25 04:58:29'),(13,59,'БУ-23.17',NULL,NULL,5,'2024-05-06 00:00:00',0,'2024-04-03 00:00:00','2024-04-06 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-05-06 21:15:37'),(14,63,'БУ-23.60',NULL,NULL,3,'2024-05-06 00:00:00',0,'2024-04-02 00:00:00','2024-07-07 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-05-06 21:15:37'),(16,58,'УЦ-22.10',2,3,8,'2024-06-07 00:00:00',0,'2024-06-08 00:00:00','2024-06-10 00:00:00',12,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:44:22'),(17,53,'УА-22.10',NULL,4,8,'2024-06-07 00:00:00',0,'2024-06-10 00:00:00','2024-10-11 00:00:00',11,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:48:31'),(18,44,'АВ-2022.10',NULL,4,6,'2024-06-07 00:00:00',0,'2024-06-15 00:00:00','2024-06-19 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:51:33'),(19,47,'КК-2022-10',NULL,4,5,'2024-06-07 00:00:00',0,'2024-06-20 00:00:00','2024-09-20 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:53:10'),(20,44,'БУ-24.15',NULL,4,5,'2024-06-07 00:00:00',0,'2024-06-20 00:00:00','2024-10-20 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:54:08'),(21,46,'БУ-пп.2020',NULL,2,10,'2024-06-13 00:00:00',0,'2024-06-13 00:00:00','2024-09-13 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-13 20:31:36'),(22,49,'СП-2022.10',NULL,4,10,'2024-06-13 00:00:00',0,'2024-06-13 00:00:00','2024-06-19 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-13 20:31:58'),(23,47,'БУ-23.10.15',2,4,5,'2024-06-23 00:00:00',0,'2024-05-23 00:00:00','2024-09-23 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 16:35:03'),(24,47,'БК-12.222',2,4,10,'2024-06-23 00:00:00',0,'2024-05-23 00:00:00','2024-05-29 00:00:00',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 16:36:44');
/*!40000 ALTER TABLE `record` ENABLE KEYS */;

-- 
-- Definition of payment
-- 

DROP TABLE IF EXISTS `payment`;
CREATE TABLE IF NOT EXISTS `payment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `record` int NOT NULL,
  `date` date NOT NULL,
  `paid` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_record_code_idx` (`record`),
  CONSTRAINT `fk_record_payment` FOREIGN KEY (`record`) REFERENCES `record` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table payment
-- 

/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment`(`id`,`record`,`date`,`paid`) VALUES(22,7,'2024-06-13 00:00:00',1500);
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;

-- 
-- Definition of role
-- 

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table role
-- 

/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role`(`id`,`title`) VALUES(1,'Системный администратор'),(2,'Секретарь'),(3,'Заведующий');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;

-- 
-- Definition of user
-- 

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(50) NOT NULL,
  `password` varchar(150) NOT NULL,
  `role` int NOT NULL,
  `surname` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_role_idx` (`role`),
  CONSTRAINT `fk_role` FOREIGN KEY (`role`) REFERENCES `role` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table user
-- 

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user`(`id`,`login`,`password`,`role`,`surname`,`name`,`patronymic`,`modifiedBy`) VALUES(1,'admin','998ed4d621742d0c2d85ed84173db569afa194d4597686cae947324aa58ab4bb',1,'Егоров','Даниил','Дмитриевич','2024-05-17 00:37:33'),(4,'manager','c3303edd9cd9054461f0931ddadbcb954d4fcb4e136b4db8985b730fd67f7add',3,'Хмелева','Елена','Олеговна','2024-05-17 00:38:14'),(5,'secretary','2a1572d6d657277c599e8db3d421d1d3e77cd416f0959862d5f2752422dcd90c',2,'Полянина','Инна','Евгеньевна','2024-05-17 00:38:41');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2024-06-23 16:51:09
-- Total time: 0:0:0:0:147 (d:h:m:s:ms)
