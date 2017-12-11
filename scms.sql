/*
Navicat MySQL Data Transfer

Source Server         : rollback
Source Server Version : 50714
Source Host           : localhost:3306
Source Database       : scms

Target Server Type    : MYSQL
Target Server Version : 50714
File Encoding         : 65001

Date: 2017-12-12 02:38:09
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
INSERT INTO `club` VALUES ('2', '测试', '1', '/Content/images/comment/2.jpg', '2017-12-07 22:50:39');
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
  `state` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clubactivity
-- ----------------------------
INSERT INTO `clubactivity` VALUES ('1', '2', 'a', 'a', '2017-11-30 23:02:38', null, '1');
INSERT INTO `clubactivity` VALUES ('2', '2', 'ab', 'a', '2017-11-30 23:03:02', null, '1');
INSERT INTO `clubactivity` VALUES ('3', '6', '测试活动', '测试场地', '2017-12-30 20:45:52', null, '1');

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clubmember
-- ----------------------------
INSERT INTO `clubmember` VALUES ('8', '1', '6', '2017-12-12 01:58:13');
INSERT INTO `clubmember` VALUES ('9', '1', '8', '2017-12-12 01:58:18');

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `actID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `text` varchar(255) CHARACTER SET utf8 NOT NULL,
  `time` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of comment
-- ----------------------------
INSERT INTO `comment` VALUES ('19', '2', '1', '测试', '2017-12-10 23:55:19');
INSERT INTO `comment` VALUES ('20', '2', '1', '??', '2017-12-11 00:07:52');
INSERT INTO `comment` VALUES ('21', '2', '1', '??', '2017-12-11 00:09:00');
INSERT INTO `comment` VALUES ('22', '1', '1', '??', '2017-12-11 00:19:40');
INSERT INTO `comment` VALUES ('23', '1', '1', '测试', '2017-12-11 00:21:30');
INSERT INTO `comment` VALUES ('24', '2', '1', '中文测试', '2017-12-11 00:21:46');
INSERT INTO `comment` VALUES ('25', '2', '1', '中文测试', '2017-12-11 00:23:24');
INSERT INTO `comment` VALUES ('26', '1', '1', '中文测试', '2017-12-11 00:25:28');
INSERT INTO `comment` VALUES ('27', '1', '1', '来来来', '2017-12-11 00:25:36');
INSERT INTO `comment` VALUES ('28', '1', '1', '1222', '2017-12-11 02:26:11');
INSERT INTO `comment` VALUES ('29', '1', '1', '66', '2017-12-11 15:43:01');
INSERT INTO `comment` VALUES ('30', '1', '1', '中文', '2017-12-11 15:43:10');

-- ----------------------------
-- Table structure for message
-- ----------------------------
DROP TABLE IF EXISTS `message`;
CREATE TABLE `message` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `from` int(11) NOT NULL,
  `to` int(11) NOT NULL,
  `subject` varchar(255) NOT NULL,
  `context` varchar(255) NOT NULL,
  `state` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of message
-- ----------------------------
INSERT INTO `message` VALUES ('1', '1', '1', 'asdf', '11', '1');
INSERT INTO `message` VALUES ('2', '1', '1', 'asdf', 'df', '1');
INSERT INTO `message` VALUES ('3', '1', '1', 'sadfffffff', 'gf', '0');
INSERT INTO `message` VALUES ('4', '1', '1', 'fffffffff', 'fffffffff', '0');

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of newmember
-- ----------------------------
INSERT INTO `newmember` VALUES ('8', '1', '3', '2017-12-11 16:32:40', null, null, '0');
INSERT INTO `newmember` VALUES ('9', '1', '2', '2017-12-12 00:55:46', null, null, '3');

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
