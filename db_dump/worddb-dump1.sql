-- MySQL dump 10.13  Distrib 5.7.19, for Win32 (AMD64)
--
-- Host: localhost    Database: worddb
-- ------------------------------------------------------
-- Server version	5.7.19-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `img`
--

DROP TABLE IF EXISTS `img`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `img` (
  `imgId` int(5) NOT NULL,
  `imgPath` varchar(30) NOT NULL,
  PRIMARY KEY (`imgId`,`imgPath`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `img`
--

LOCK TABLES `img` WRITE;
/*!40000 ALTER TABLE `img` DISABLE KEYS */;
INSERT INTO `img` VALUES (2,'clues.jpg'),(3,'rescue.png'),(4,'enslave.jpg'),(5,'surrender.jpg'),(6,'requirement.png'),(7,'assume.jpg'),(8,'suffer.jpg'),(9,'exchange.png'),(10,'internal.png'),(11,'wage.jpg'),(12,'damnition.jpg'),(13,'gambling.jpg'),(14,'glance.png'),(15,'responsibility.jpg'),(16,'resemblance.png'),(17,'uncanny.jpg'),(18,'faith.jpg'),(19,'insular.gif'),(20,'reveal.jpg'),(21,'mediocre.jpg'),(22,'helmet.jpg'),(27,'honest.jpg'),(28,'foster.jpeg'),(29,'vehicle.jpeg');
/*!40000 ALTER TABLE `img` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `word`
--

DROP TABLE IF EXISTS `word`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `word` (
  `wordid` int(11) NOT NULL AUTO_INCREMENT,
  `wordName` varchar(30) NOT NULL,
  `TransName` varchar(30) DEFAULT NULL,
  `Status` int(1) DEFAULT NULL,
  PRIMARY KEY (`wordid`,`wordName`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `word`
--

LOCK TABLES `word` WRITE;
/*!40000 ALTER TABLE `word` DISABLE KEYS */;
INSERT INTO `word` VALUES (2,'clue','╨┐╨╛╨┤╤Б╨║╨░╨╖╨║╨░',2),(3,'rescue','╤Б╨┐╨░╤Б╨╡╨╜╨╕╨╡',1),(4,'enslave','╨┐╨╛╤А╨░╨▒╨╛╤Й╨░╤В╤М',1),(5,'surrender','╤Б╨┤╨░╨▓╨░╤В╤М╤Б╤П',2),(6,'requirement','╤В╤А╨╡╨▒╨╛╨▓╨░╨╜╨╕╨╡',0),(7,'assume','╨┐╤А╨╡╨┤╨┐╨╛╨╗╨░╨│╨░╤В╤М',2),(8,'suffer','╤Б╤В╤А╨░╨┤╨░╨╜╨╕╨╡',2),(9,'exchange','╨╛╨▒╨╝╨╡╨╜',1),(10,'internal','╨▓╨╜╤Г╤В╤А╨╡╨╜╨╜╨╕╨╣',0),(11,'wage','╨╖╨░╤А╨┐╨╗╨░╤В╨░',2),(12,'damnation','╨┐╤А╨╛╨║╨╗╤П╤В╨╕╨╡',1),(13,'gambling','╨░╨╖╨░╤А╤В╨╜╤Л╨╡ ╨╕╨│╤А╤Л',1),(14,'glance','╨▓╨╖╨│╨╗╤П╨┤',0),(15,'responsibility','╨╛╨▒╤П╨╖╨░╨╜╨╜╨╛╤Б╤В╤М',0),(16,'resemblance','╤Б╤Е╨╛╨┤╤Б╤В╨▓╨╛',0),(17,'uncanny','╨╢╤Г╤В╨║╨╕╨╣',0),(18,'faith','╨▓╨╡╤А╨░',2),(19,'insular','╤Б╨┤╨╡╤А╨╢╨░╨╜╨╜╨╛╤Б╤В╤М',0),(20,'reveal','╤Г╤В╨╡╤З╨║╨░',0),(21,'mediocre','╨┐╨╛╤Б╤А╨╡╨┤╤Б╤В╨▓╨╡╨╜╨╜╨╛╤Б╤В╤М',0),(22,'helmet','╤И╨╗╨╡╨╝',0),(27,'honest','╤З╨╡╤Б╤В╨╜╤Л╨╣',0),(28,'foster','╤Б╨┐╨╛╤Б╨╛╨▒╤Б╤В╨▓╨╛╨▓╨░╤В╤М',0),(29,'vehicle','╤В╤А╨░╨╜╤Б╨┐╨╛╤А╤В╨╜╨╛╨╡ ╤Б╤А╨╡╨┤╤Б╤В╨▓╨╛',0);
/*!40000 ALTER TABLE `word` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-13  9:41:33
