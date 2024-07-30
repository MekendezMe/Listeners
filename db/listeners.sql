-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: listeners
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `course` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course` VALUES (1,'Электрогазосварщик',480,18000,1,'2024-04-29 23:58:31'),(2,'Повар',480,16000,1,'2024-04-29 23:58:31'),(3,'Электрогазосварщик',680,18999.99,5,'2024-06-06 20:43:49'),(4,'Повар',360,13000,2,'2024-04-29 23:58:31'),(5,'Бухгалтерский учет',800,20000,2,'2024-06-06 20:44:21'),(6,'Повар',72,5000,3,'2024-04-29 23:58:31'),(7,'Электрогазосварщик',72,6000,3,'2024-04-29 23:58:31'),(8,'Математика и русский язык',172,9000,5,'2024-04-29 23:58:31'),(9,'1С:Бухгалтерия',40,3800,4,'2024-06-06 20:43:17'),(10,'1С:Предприятие',75,6500,4,'2024-04-29 23:58:31');
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `creditedstatus`
--

DROP TABLE IF EXISTS `creditedstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `creditedstatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `creditedstatus`
--

LOCK TABLES `creditedstatus` WRITE;
/*!40000 ALTER TABLE `creditedstatus` DISABLE KEYS */;
INSERT INTO `creditedstatus` VALUES (1,'зачислен'),(3,'учится'),(4,'закончил'),(5,'отчислен');
/*!40000 ALTER TABLE `creditedstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'сами'),(2,'предприятие');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document`
--

DROP TABLE IF EXISTS `document`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `document` (
  `id` int NOT NULL AUTO_INCREMENT,
  `insuranceNumber` varchar(15) DEFAULT NULL,
  `passport` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_passport_idx` (`passport`),
  CONSTRAINT `fk_passport` FOREIGN KEY (`passport`) REFERENCES `passport` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `document`
--

LOCK TABLES `document` WRITE;
/*!40000 ALTER TABLE `document` DISABLE KEYS */;
INSERT INTO `document` VALUES (1,'287-951-825 80',1),(5,'123-213-124 12',6);
/*!40000 ALTER TABLE `document` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `education`
--

DROP TABLE IF EXISTS `education`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `education` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `education`
--

LOCK TABLES `education` WRITE;
/*!40000 ALTER TABLE `education` DISABLE KEYS */;
INSERT INTO `education` VALUES (1,'основное общее','2024-05-09 21:26:02'),(2,'среднее общее','2024-05-08 22:47:35'),(3,'ППКЗ','2024-05-08 22:47:35'),(4,'ППССЗ','2024-05-08 22:47:35'),(5,'высшее профессиональное (магистр)','2024-05-08 22:47:35'),(6,'высшее профессиональное (бакалавр)','2024-05-08 22:47:35');
/*!40000 ALTER TABLE `education` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'123','Егоров','Даниил','Дмитриевич','Разработчик','ronaldo.png','2024-06-14 22:57:29'),(3,'130','Давыдова','Кристина','Денисовна','Кассир','plug.jpg','2024-06-14 22:24:27'),(4,'125','Антонов','Николай','Сергеевич','Мастер','kroos.jpg','2024-06-14 22:42:10'),(5,'145','Давыдов','Денис','Николаевич','Заведующий','alisson.jpg','2024-06-10 17:58:41');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employment`
--

DROP TABLE IF EXISTS `employment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employment`
--

LOCK TABLES `employment` WRITE;
/*!40000 ALTER TABLE `employment` DISABLE KEYS */;
INSERT INTO `employment` VALUES (1,'учащийся','2024-05-09 21:26:02'),(2,'безработный','2024-05-09 21:59:10'),(5,'студент ВО','2024-05-09 21:26:02'),(6,'занятый','2024-05-09 22:01:39');
/*!40000 ALTER TABLE `employment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `endstatus`
--

DROP TABLE IF EXISTS `endstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `endstatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `endstatus`
--

LOCK TABLES `endstatus` WRITE;
/*!40000 ALTER TABLE `endstatus` DISABLE KEYS */;
INSERT INTO `endstatus` VALUES (1,'освоен'),(2,'не освоен');
/*!40000 ALTER TABLE `endstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gender`
--

DROP TABLE IF EXISTS `gender`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gender` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gender`
--

LOCK TABLES `gender` WRITE;
/*!40000 ALTER TABLE `gender` DISABLE KEYS */;
INSERT INTO `gender` VALUES (1,'Мужской'),(2,'Женский');
/*!40000 ALTER TABLE `gender` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group`
--

DROP TABLE IF EXISTS `group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `countPeople` int NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group`
--

LOCK TABLES `group` WRITE;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
INSERT INTO `group` VALUES (1,'БД-23',10,'2024-04-28 21:41:42'),(2,'ИС-21А',2,'2024-04-28 21:41:42'),(3,'ИС-21Б',3,'2024-04-28 21:41:42'),(4,'ИС-22А',17,'2024-04-28 21:41:42'),(6,'БУ-24А',2,'2024-04-28 22:38:32');
/*!40000 ALTER TABLE `group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `listener`
--

DROP TABLE IF EXISTS `listener`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listener` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listener`
--

LOCK TABLES `listener` WRITE;
/*!40000 ALTER TABLE `listener` DISABLE KEYS */;
INSERT INTO `listener` VALUES (44,'Иванов','Иван','Иванович','ул. Пушкина, д.10','2008-04-20','+7 (321) 412-4214',1,1,1,1,'2024-06-13 20:18:58'),(45,'Петров','Петр','Петрович','пр. Ленина, д.25','2007-04-25','987-65-43',1,1,1,1,'2024-04-21 23:59:17'),(46,'Сидорова','Мария','','ул. Гагарина, д.7','1990-11-20','111-22-33',1,1,1,1,'2024-04-21 23:59:17'),(47,'Смирнов','Александр','Сергеевич','пр. Мира, д.15','2009-10-10','+7 (555) 667-7312',1,5,1,1,'2024-04-25 22:23:47'),(49,'Иванова','Татьяна','Сергеевна','пр. Победы, д.8','1979-09-03','+7 (777) 889-9223',1,4,1,1,'2024-06-13 14:30:29'),(50,'Смирнов','Сергей','Петрович','ул. Ленина, д.30','1985-04-17','333-44-55',1,1,1,1,'2024-04-21 23:59:17'),(51,'Попов','Дмитрий','Алексеевич','пр. Строителей, д.22','2007-04-29','+7 (777) 889-9492',1,1,1,1,'2024-04-21 23:59:17'),(52,'Михайлова','Елена','Андреевна','ул. Кирова, д.6','2010-04-29','+7 (527) 889-9492',1,1,1,1,'2024-04-21 23:59:17'),(53,'Кузнецов','Анатолий','Анатольевич','пр. Мира, д.18','2007-03-20','999-00-11',1,1,1,1,'2024-04-21 23:59:17'),(54,'Иванова','Анна','Александровна','ул. Лермонтова, д.3','1993-08-25','111-22-33',1,1,1,1,'2024-04-21 23:59:17'),(55,'Смирнов','Николай','Павлович','пр. Мира, д.7','1989-04-30','+7 (444) 556-6312',1,1,1,1,'2024-04-25 00:59:46'),(56,'Петрова','Наталья','Сергеевна','ул. Горького, д.12','1987-11-15','777-88-99',1,1,1,1,'2024-04-21 23:59:17'),(57,'Кузнецов','Владимир','Иванович','пр. Стачек, д.21','1990-02-10','999-00-11',1,1,1,1,'2024-04-21 23:59:17'),(58,'Сидоров','Тимофей','Федорович','ул. Пушкина, д.5','2007-04-15','222-33-44',1,1,1,1,'2024-04-21 23:59:17'),(59,'Павлова','Екатерина','Петровна','пр. Ленина, д.9','1984-03-22','888-99-44',1,1,1,1,'2024-04-21 23:59:17'),(60,'Михайлов','Дмитрий','Владимирович','ул. Кирова, д.17','1992-09-07','555-66-77',1,1,1,1,'2024-04-21 23:59:17'),(61,'Новикова','Ольга','Михайловна','пр. Победы, д.11','1983-12-03','333-44-55',1,1,1,1,'2024-04-21 23:59:17'),(62,'Федоров','Станислав','Егорович','ул. Гагарина, д.2','1980-07-28','666-77-88',1,1,1,1,'2024-04-21 23:59:17'),(63,'Белов','Александр','Семенович','пр. Московский, д.4','1981-05-19','123-45-67',1,1,1,1,'2024-04-21 23:59:17'),(65,'Сергеев','Николай','Александрович','Заволжье','2002-12-12','+7 (321) 321-3213',1,1,5,1,'2024-04-21 23:59:17');
/*!40000 ALTER TABLE `listener` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `openstatus`
--

DROP TABLE IF EXISTS `openstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `openstatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `openstatus`
--

LOCK TABLES `openstatus` WRITE;
/*!40000 ALTER TABLE `openstatus` DISABLE KEYS */;
INSERT INTO `openstatus` VALUES (1,'открыт'),(2,'закрыт');
/*!40000 ALTER TABLE `openstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organization`
--

DROP TABLE IF EXISTS `organization`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organization` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organization`
--

LOCK TABLES `organization` WRITE;
/*!40000 ALTER TABLE `organization` DISABLE KEYS */;
INSERT INTO `organization` VALUES (1,'ООО \"Пицца\"','ООО \"Пицца\"','г. Заволжье, ул. Пушкина, д. 56','123456789123','123456789','123456789','Министерство финансов Нижегородской обл. (ГБПОУ ЗАМТ)','40601810422023000001 ВОЛГО-ВЯТСКОЕ ГУ БАНКА РОССИИ Г. НИЖНИЙ НОВГОРОД','40102810745370000024','03224643220000003206','Кузбыев И.А.','серия 52Л01 № 002002, выданной 07 апреля 2015 г. Министерством образования Нижегородской области','СБЕРБАНК','2024-05-08 22:47:35'),(2,'ООО \"Кукояки\"','ООО \"Кукояки\"','г. Заволжье, ул. Пушкина, д. 57','312421414142','412441242','144214124','Есть','Есть','40102810745370000025','03224643220000003201','Игорин К. В.','Интересная','СБЕРБАНК','2024-05-01 20:49:08'),(3,'Государственное бюджетное профессиональное учреждение \"Заволжский автоматорный техникум\"','ГБПОУ \"ЗАМТ\"','606520 Нижегородская область, Городецкий район, г. Заволжье, пр. Мира 18','5248007963','524801001','042202001','Министерство финансов Нижегородской обл. (ГБПОУ \"ЗАМТ\")','40601810422023000001 ВОЛГО-ВЯТСКОЕ ГУ БАНКА РОССИИ Г. НИЖНИЙ НОВГОРОД','40102810745370000024','03224643220000003200','Осянин Андрей Николаевич','серия 52Л01 № 002002, выданной 07 апреля 2015 г. Министерством образования Нижегородской области',NULL,'2024-05-11 01:57:43');
/*!40000 ALTER TABLE `organization` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passport`
--

DROP TABLE IF EXISTS `passport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `passport` (
  `id` int NOT NULL AUTO_INCREMENT,
  `series` varchar(4) NOT NULL,
  `number` varchar(6) NOT NULL,
  `issueDate` date NOT NULL,
  `issuedBy` varchar(80) NOT NULL,
  `departmentCode` varchar(8) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passport`
--

LOCK TABLES `passport` WRITE;
/*!40000 ALTER TABLE `passport` DISABLE KEYS */;
INSERT INTO `passport` VALUES (1,'2250','456231','2018-03-27','ГУ МВД России по Нижегородской области','321-412'),(6,'1232','521321','2018-02-15','ГУ МВД России по Нижегородской области','123-213');
/*!40000 ALTER TABLE `passport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `record` int NOT NULL,
  `date` date NOT NULL,
  `paid` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_record_code_idx` (`record`),
  CONSTRAINT `fk_record_payment` FOREIGN KEY (`record`) REFERENCES `record` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (22,7,'2024-06-13',1500);
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paymentstatus`
--

DROP TABLE IF EXISTS `paymentstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paymentstatus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paymentstatus`
--

LOCK TABLES `paymentstatus` WRITE;
/*!40000 ALTER TABLE `paymentstatus` DISABLE KEYS */;
INSERT INTO `paymentstatus` VALUES (2,'не оплачен'),(3,'оплачен');
/*!40000 ALTER TABLE `paymentstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qualification`
--

DROP TABLE IF EXISTS `qualification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `qualification` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `modifiedBy` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qualification`
--

LOCK TABLES `qualification` WRITE;
/*!40000 ALTER TABLE `qualification` DISABLE KEYS */;
INSERT INTO `qualification` VALUES (1,'подготовка','2024-05-09 21:26:02'),(2,'переподготовка','2024-05-11 00:15:59'),(3,'повышение квалификации','2024-05-09 21:26:02'),(4,'курсы дополнительного образования','2024-05-09 21:26:02'),(5,'подготовительные курсы','2024-05-09 21:26:02'),(6,'курсы по профессиям','2024-05-21 20:35:30');
/*!40000 ALTER TABLE `qualification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `record`
--

DROP TABLE IF EXISTS `record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `record` (
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
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `record`
--

LOCK TABLES `record` WRITE;
/*!40000 ALTER TABLE `record` DISABLE KEYS */;
INSERT INTO `record` VALUES (2,46,'КУ-24-15',1,2,9,'2024-04-30',0,'2024-05-05','2024-05-30',NULL,2,1,5,1,0,'КП-2022.10','2024-06-23','КП-2022.15','2024-07-23','2024-06-23 17:18:34'),(5,44,'БУ-23.14',NULL,2,2,'2024-05-01',1,'2024-05-02','2024-10-04',4,3,2,1,1,0,NULL,NULL,NULL,NULL,'2024-05-06 21:15:37'),(7,44,'БУ-23.10',NULL,3,9,'2024-05-02',0,'2024-02-06','2024-05-04',NULL,2,2,3,1,1500,'РП-23212','2024-06-14','РП-4444','2024-08-13','2024-06-13 14:45:35'),(9,44,'КУ-23.10',NULL,6,9,'2024-05-02',0,'2024-07-05','2024-09-05',NULL,2,2,4,2,0,NULL,NULL,NULL,NULL,'2024-06-23 19:31:10'),(10,50,'БУ-23.20',NULL,6,9,'2024-05-06',0,'2024-04-02','2024-04-07',NULL,2,2,3,1,0,NULL,NULL,NULL,NULL,'2024-05-14 23:54:51'),(11,52,'БУ-23.76',NULL,6,9,'2024-05-06',0,'2024-04-02','2024-07-05',NULL,2,2,5,1,0,NULL,NULL,NULL,NULL,'2024-05-06 21:15:37'),(12,54,'БУ.23-15',NULL,4,2,'2024-05-06',0,'2024-05-07','2024-05-26',NULL,3,1,1,1,0,'КП-2022','2024-05-25','КП-2022','2024-05-25','2024-05-25 04:58:29'),(13,59,'БУ-23.17',NULL,NULL,5,'2024-05-06',0,'2024-04-03','2024-04-06',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-05-06 21:15:37'),(14,63,'БУ-23.60',NULL,NULL,3,'2024-05-06',0,'2024-04-02','2024-07-07',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-05-06 21:15:37'),(16,58,'УЦ-22.10',2,3,8,'2024-06-07',0,'2024-06-08','2024-06-10',12,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:44:22'),(17,53,'УА-22.10',NULL,4,8,'2024-06-07',0,'2024-06-10','2024-10-11',11,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:48:31'),(18,44,'АВ-2022.10',NULL,4,6,'2024-06-07',0,'2024-06-15','2024-06-19',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:51:33'),(19,47,'КК-2022-10',NULL,4,5,'2024-06-07',0,'2024-06-20','2024-09-20',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:53:10'),(20,44,'БУ-24.15',NULL,4,5,'2024-06-07',0,'2024-06-20','2024-10-20',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-07 00:54:08'),(21,46,'БУ-пп.2020',NULL,2,10,'2024-06-13',0,'2024-06-13','2024-09-13',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-13 20:31:36'),(22,49,'СП-2022.10',NULL,4,10,'2024-06-13',0,'2024-06-13','2024-06-19',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-13 20:31:58'),(23,47,'БУ-23.10.15',2,4,5,'2024-06-23',0,'2024-05-23','2024-09-23',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 16:35:03'),(24,47,'БК-12.222',2,4,10,'2024-06-23',0,'2024-05-23','2024-05-29',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 16:36:44'),(25,50,'КК-2022.15',2,4,4,'2024-06-23',0,'2024-06-20','2024-06-29',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 19:35:18'),(26,51,'БУ-2022.15',NULL,4,8,'2024-06-23',0,'2024-02-09','2024-09-09',4,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 19:36:14'),(27,51,'2024.КК/15',2,4,2,'2024-06-23',1,'2024-02-09','2024-04-09',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 19:45:27'),(28,51,'КК-2022/155',2,4,2,'2024-06-23',1,'2024-03-09','2024-06-09',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 19:48:30'),(29,51,'КУ-2022/165',2,4,4,'2024-06-23',1,'2024-07-09','2024-08-09',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 19:52:11'),(30,51,'КУ-2022/1111',2,4,8,'2024-06-23',1,'2024-09-09','2024-10-09',4,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 19:57:19'),(31,51,'ПП.2022/12',2,4,8,'2024-06-23',1,'2024-09-09','2024-10-09',4,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 20:06:12'),(32,51,'2022-КУ/15',1,4,8,'2024-06-23',1,'2024-05-23','2024-06-23',NULL,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 20:07:34'),(33,51,'2022/15-КУ',NULL,4,8,'2024-06-23',0,'2024-04-23','2024-05-23',4,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 20:08:23'),(34,51,'2022-КУ/153',NULL,3,8,'2024-06-23',1,'2024-06-24','2024-06-25',4,2,2,1,1,0,NULL,NULL,NULL,NULL,'2024-06-23 20:10:41');
/*!40000 ALTER TABLE `record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `representative`
--

DROP TABLE IF EXISTS `representative`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `representative` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `representative`
--

LOCK TABLES `representative` WRITE;
/*!40000 ALTER TABLE `representative` DISABLE KEYS */;
INSERT INTO `representative` VALUES (4,'Сергеев','Иван','Игоревич','Нижегородская область, Городецкий район, г. Заволжье, ул. Рылеева, д. 55','+7 (904) 950-6242',51,'2024-05-05 00:15:12'),(5,'Иванов','Петр','Алексеевич','Московская область, г. Москва, ул. Ленина, д. 10','+7 (904) 950-6243',45,'2024-04-30 01:22:58'),(6,'Георгиев','Олег','Иванович','Нижегородская область, Балахнинский район, д. Гумнищи, д. 105','+7 (904) 952-4123',47,'2024-05-05 00:13:39'),(11,'Иванов','Сергей','Исламович','Нижегородская область, Нижегородская область, Балахнинский район, д. Гумнищи, д. 107','+7 (904) 954-2312',53,'2024-05-05 01:17:49'),(12,'Антонов','Иван','Анатольевич','Нижегородская область, Балахнинский район, д. Гумнищи, д. 120','+7 (940) 421-0412',58,'2024-05-05 01:21:50'),(13,'Игнатьев','Николай','Игнатьевич','Нижегородская область, Балахнинский район, д. Гумнищи, д. 150','+7 (431) 241-2412',52,'2024-06-06 21:37:42'),(14,'Петросян','Иван','Петрович','Нижегородская область, Балахнинский район, д. Гумнищи, д. 105','+7 (904) 925-1251',44,'2024-05-06 21:07:56'),(15,'Иванов','Антон','Георгиевич','Нижегородская область, Балахнинский район, д. Гумнищи, д. 115','+7 (332) 131-3213',54,'2024-06-06 21:38:20');
/*!40000 ALTER TABLE `representative` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Системный администратор'),(2,'Секретарь'),(3,'Заведующий');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'admin','998ed4d621742d0c2d85ed84173db569afa194d4597686cae947324aa58ab4bb',1,'Егоров','Даниил','Дмитриевич','2024-05-17 00:37:33'),(4,'manager','c3303edd9cd9054461f0931ddadbcb954d4fcb4e136b4db8985b730fd67f7add',3,'Хмелева','Елена','Олеговна','2024-05-17 00:38:14'),(5,'secretary','2a1572d6d657277c599e8db3d421d1d3e77cd416f0959862d5f2752422dcd90c',2,'Полянина','Инна','Евгеньевна','2024-05-17 00:38:41');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-23 20:15:39
