/*
Navicat MySQL Data Transfer

Source Server         : rollback
Source Server Version : 50714
Source Host           : localhost:3306
Source Database       : scms

Target Server Type    : MYSQL
Target Server Version : 50714
File Encoding         : 65001

Date: 2017-12-10 16:16:03
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for club
-- ----------------------------
DROP TABLE IF EXISTS `club`;
CREATE TABLE `club` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) CHARACTER SET utf8 NOT NULL,
  `state` int(11) NOT NULL,
  `logo` varchar(255) NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of club
-- ----------------------------
INSERT INTO `club` VALUES ('2', '测试', '1', '/Content/images/comment/1.jpg', '2017-12-07 22:50:39');
INSERT INTO `club` VALUES ('3', '测试', '1', '/Content/images/comment/2.jpg', '2017-12-07 22:51:11');
INSERT INTO `club` VALUES ('4', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('5', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('6', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('7', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('8', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('9', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('10', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('11', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('12', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('13', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('14', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('15', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('16', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('17', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('18', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('19', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('20', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');
INSERT INTO `club` VALUES ('21', '测试', '1', '/Content/images/comment/3.jpg', '2017-12-08 11:53:00');

-- ----------------------------
-- Table structure for clubactivity
-- ----------------------------
DROP TABLE IF EXISTS `clubactivity`;
CREATE TABLE `clubactivity` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `clubID` int(11) NOT NULL,
  `name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `place` varchar(255) CHARACTER SET utf8 NOT NULL,
  `time` datetime NOT NULL,
  `other` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clubactivity
-- ----------------------------
INSERT INTO `clubactivity` VALUES ('1', '1', 'a', 'a', '2017-11-30 23:02:38', null);
INSERT INTO `clubactivity` VALUES ('2', '1', 'a', 'a', '2017-11-30 23:03:02', null);

-- ----------------------------
-- Table structure for clubmanager
-- ----------------------------
DROP TABLE IF EXISTS `clubmanager`;
CREATE TABLE `clubmanager` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cludID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clubmanager
-- ----------------------------

-- ----------------------------
-- Table structure for clubmember
-- ----------------------------
DROP TABLE IF EXISTS `clubmember`;
CREATE TABLE `clubmember` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL,
  `clubid` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clubmember
-- ----------------------------

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `actID` int(11) NOT NULL,
  `text` varchar(255) CHARACTER SET utf8 NOT NULL,
  `time` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of comment
-- ----------------------------

-- ----------------------------
-- Table structure for message
-- ----------------------------
DROP TABLE IF EXISTS `message`;
CREATE TABLE `message` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `from` int(11) NOT NULL,
  `context` varchar(255) NOT NULL,
  `state` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of message
-- ----------------------------

-- ----------------------------
-- Table structure for newclub
-- ----------------------------
DROP TABLE IF EXISTS `newclub`;
CREATE TABLE `newclub` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 NOT NULL,
  `userID` int(11) NOT NULL,
  `logo` varchar(255) CHARACTER SET utf8 NOT NULL,
  `describe` varchar(255) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of newclub
-- ----------------------------

-- ----------------------------
-- Table structure for newmember
-- ----------------------------
DROP TABLE IF EXISTS `newmember`;
CREATE TABLE `newmember` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userID` int(11) NOT NULL,
  `clubID` int(11) NOT NULL,
  `time` datetime NOT NULL,
  `checkTime` datetime DEFAULT NULL,
  `checkUser` int(11) DEFAULT NULL,
  `state` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of newmember
-- ----------------------------

-- ----------------------------
-- Table structure for teacher
-- ----------------------------
DROP TABLE IF EXISTS `teacher`;
CREATE TABLE `teacher` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of teacher
-- ----------------------------

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `name` varchar(20) CHARACTER SET utf8 NOT NULL,
  `id` int(11) NOT NULL,
  `pwd` varchar(32) CHARACTER SET utf8 NOT NULL,
  `sex` int(1) NOT NULL,
  `age` int(3) NOT NULL,
  `class` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `department` int(1) DEFAULT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('a', '1', 'e10adc3949ba59abbe56e057f20f883e', '1', '12', null, null);
