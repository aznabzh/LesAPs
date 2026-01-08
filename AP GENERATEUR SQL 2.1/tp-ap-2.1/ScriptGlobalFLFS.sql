-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 28 jan. 2025 à 13:59
-- Version du serveur : 5.7.40
-- Version de PHP : 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `scriptglobalflfs`
--

-- --------------------------------------------------------

--
-- Structure de la table `arbitre`
--

DROP TABLE IF EXISTS `arbitre`;
CREATE TABLE IF NOT EXISTS `arbitre` (
  `CodeA` varchar(4) NOT NULL,
  `NomA` varchar(30) DEFAULT NULL,
  `PrenomA` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`CodeA`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `arbitre`
--

INSERT INTO `arbitre` (`CodeA`, `NomA`, `PrenomA`) VALUES
('A1', 'Lefort', 'Philippe'),
('A2', 'Trébeau', 'Sébastien'),
('A3', 'Ritterlan', 'Hervé'),
('A4', 'Rubens', 'Stéphane'),
('A5', 'Leoperon', 'Philippe'),
('A6', 'Durand', 'Jean Charles'),
('A7', 'Stéfanin', 'Loïc'),
('A8', 'Renom', 'Pierre'),
('A9', 'Fieffe', 'Eric'),
('A10', 'Lepont', 'Jacques'),
('A11', 'Pierrin', 'Marcel'),
('A12', 'Monin', 'Jean');

-- --------------------------------------------------------

--
-- Structure de la table `arbitrer`
--

DROP TABLE IF EXISTS `arbitrer`;
CREATE TABLE IF NOT EXISTS `arbitrer` (
  `CodeMatch` varchar(4) NOT NULL,
  `CodeArbitre` varchar(4) NOT NULL,
  `RoleArbitre` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`CodeArbitre`,`CodeMatch`),
  KEY `CodeMatch` (`CodeMatch`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `arbitrer`
--

INSERT INTO `arbitrer` (`CodeMatch`, `CodeArbitre`, `RoleArbitre`) VALUES
('M1', 'A1', 'terrain'),
('M1', 'A12', 'table'),
('M10', 'A10', 'terrain'),
('M10', 'A4', 'table'),
('M11', 'A11', 'terrain'),
('M11', 'A5', 'table'),
('M12', 'A12', 'terrain'),
('M12', 'A6', 'table'),
('M13', 'A1', 'terrain'),
('M13', 'A5', 'table'),
('M14', 'A3', 'terrain'),
('M14', 'A7', 'table'),
('M15', 'A6', 'terrain'),
('M15', 'A8', 'table'),
('M16', 'A9', 'terrain'),
('M16', 'A11', 'table'),
('M17', 'A10', 'terrain'),
('M17', 'A12', 'table'),
('M18', 'A2', 'terrain'),
('M18', 'A4', 'table'),
('M19', 'A1', 'terrain'),
('M19', 'A10', 'table'),
('M2', 'A11', 'terrain'),
('M2', 'A4', 'table'),
('M20', 'A2', 'terrain'),
('M20', 'A12', 'table'),
('M21', 'A3', 'terrain'),
('M21', 'A11', 'table'),
('M22', 'A4', 'terrain'),
('M22', 'A9', 'table'),
('M23', 'A5', 'terrain'),
('M23', 'A8', 'table'),
('M24', 'A6', 'terrain'),
('M24', 'A7', 'table'),
('M3', 'A10', 'terrain'),
('M3', 'A2', 'table'),
('M4', 'A5', 'terrain'),
('M4', 'A9', 'table'),
('M5', 'A3', 'terrain'),
('M5', 'A8', 'table'),
('M6', 'A6', 'terrain'),
('M6', 'A7', 'table'),
('M7', 'A2', 'terrain'),
('M7', 'A7', 'table'),
('M8', 'A2', 'terrain'),
('M8', 'A8', 'table'),
('M9', 'A3', 'terrain'),
('M9', 'A9', 'table');

-- --------------------------------------------------------

--
-- Structure de la table `categorie`
--

DROP TABLE IF EXISTS `categorie`;
CREATE TABLE IF NOT EXISTS `categorie` (
  `CodeCat` varchar(4) NOT NULL,
  `LibelleC` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`CodeCat`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `categorie`
--

INSERT INTO `categorie` (`CodeCat`, `LibelleC`) VALUES
('S1', 'Junior'),
('S2', 'Senior');

-- --------------------------------------------------------

--
-- Structure de la table `club`
--

DROP TABLE IF EXISTS `club`;
CREATE TABLE IF NOT EXISTS `club` (
  `CodeC` varchar(4) NOT NULL,
  `NomC` varchar(30) DEFAULT NULL,
  `AdresseC` varchar(40) DEFAULT NULL,
  `VilleC` varchar(20) DEFAULT NULL,
  `CPC` varchar(5) DEFAULT NULL,
  `TelC` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`CodeC`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `club`
--

INSERT INTO `club` (`CodeC`, `NomC`, `AdresseC`, `VilleC`, `CPC`, `TelC`) VALUES
('C1', 'SF Belleville', '', 'Verdun', '55100', ''),
('C2', 'SCA Epinal', '', 'Epinal', '88000', ''),
('C3', 'USL Mineenne', '', 'St Mihiel', '55300', ''),
('C4', 'FC Toul', '', 'Toul', '54200', ''),
('C5', 'US Etain', '', 'Etain', '55400', ''),
('C6', 'ESP Lunéville', '', 'Lunéville', '54300', ''),
('C7', 'FC Velaines', '', 'Velaines', '55500', ''),
('C8', 'FCSTD', '', 'Saint Dié', '88100', ''),
('C9', 'District Vosges', '', 'Epinal', '88000', ''),
('C10', 'FC Val Dunois', '', 'Behonne', '55000', ''),
('C11', 'FC Bruch Forbach', '', 'Forbach', '76000', ''),
('C12', 'FC Commercy', '', 'Velaines', '55500', '');

-- --------------------------------------------------------

--
-- Structure de la table `equipe`
--

DROP TABLE IF EXISTS `equipe`;
CREATE TABLE IF NOT EXISTS `equipe` (
  `CodeE` varchar(4) NOT NULL,
  `CodeClub` varchar(4) NOT NULL,
  `CodeCateg` varchar(4) NOT NULL,
  PRIMARY KEY (`CodeE`),
  KEY `CodeClub` (`CodeClub`),
  KEY `CodeCateg` (`CodeCateg`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `equipe`
--

INSERT INTO `equipe` (`CodeE`, `CodeClub`, `CodeCateg`) VALUES
('E1', 'C1', 'S1'),
('E2', 'C1', 'S1'),
('E3', 'C2', 'S1'),
('E4', 'C3', 'S1'),
('E5', 'C4', 'S1'),
('E6', 'C3', 'S1'),
('E7', 'C2', 'S1'),
('E8', 'C5', 'S1'),
('E9', 'C6', 'S1'),
('E10', 'C4', 'S1'),
('E11', 'C6', 'S1'),
('E12', 'C5', 'S1'),
('E13', 'C5', 'S2'),
('E14', 'C6', 'S2'),
('E15', 'C5', 'S2'),
('E16', 'C4', 'S2'),
('E17', 'C2', 'S2'),
('E18', 'C1', 'S2'),
('E19', 'C6', 'S2'),
('E20', 'C2', 'S2'),
('E21', 'C1', 'S2'),
('E22', 'C4', 'S2'),
('E23', 'C3', 'S2'),
('E24', 'C3', 'S2');

-- --------------------------------------------------------

--
-- Structure de la table `joueur`
--

DROP TABLE IF EXISTS `joueur`;
CREATE TABLE IF NOT EXISTS `joueur` (
  `NumJ` varchar(4) NOT NULL,
  `NomJ` varchar(30) DEFAULT NULL,
  `PrenomJ` varchar(30) DEFAULT NULL,
  `DateNaissJ` varchar(10) DEFAULT NULL,
  `NumLicJ` varchar(4) DEFAULT NULL,
  `CodeEquipe` varchar(4) NOT NULL,
  PRIMARY KEY (`NumJ`),
  KEY `CodeEquipe` (`CodeEquipe`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `joueur`
--

INSERT INTO `joueur` (`NumJ`, `NomJ`, `PrenomJ`, `DateNaissJ`, `NumLicJ`, `CodeEquipe`) VALUES
('1', 'ACHARD', 'Patrick', '09/09/1978', '8752', 'E11'),
('2', 'ANDRE', 'Pascal', '01/07/1970', '5008', 'E11'),
('3', 'ANDRI', 'Henri', '08/02/1977', '7629', 'E16'),
('4', 'ARNAUD', 'Philippe', '09/03/1978', '2439', 'E5'),
('5', 'AUDOUARD', 'Jean-Claude', '02/08/1971', '6281', 'E4'),
('6', 'AUGAGNEUR', 'Jean-Paul', '16/04/1970', '1599', 'E21'),
('7', 'AUROI', 'Lucien', '15/09/1984', '1717', 'E23'),
('8', 'BALEYDIER', 'Henri', '26/08/1980', '2380', 'E9'),
('9', 'BALLIGAND', 'Serge', '15/03/1984', '1612', 'E8'),
('10', 'BAVUSO', 'François', '17/05/1971', '5000', 'E5'),
('11', 'BAYET', 'Benoit', '01/07/1970', '4589', 'E24'),
('12', 'BAYET', 'Bruno', '07/07/1976', '6740', 'E14'),
('13', 'BAYLE', 'Alexis', '24/06/1978', '4351', 'E7'),
('14', 'BENOIT', 'Lucien', '14/02/1983', '4632', 'E4'),
('15', 'BERGER', 'Christian', '27/03/1981', '9296', 'E11'),
('16', 'BERNARD', 'Alain', '01/01/1970', '8414', 'E11'),
('17', 'BERTHELIER', 'Patrick', '21/09/1975', '1479', 'E16'),
('18', 'BERTHOLON', 'Gérard', '26/02/1980', '3485', 'E16'),
('19', 'BLANCHIN', 'Gérard', '18/06/1972', '8969', 'E6'),
('20', 'BONNAMOUR', 'Etienne', '28/10/1982', '2438', 'E13'),
('21', 'BORY', 'Philippe', '09/09/1978', '9203', 'E8'),
('22', 'BOS', 'Stanley', '14/02/1983', '4751', 'E1'),
('23', 'BOUCHET', 'Philippe', '12/06/1981', '5530', 'E11'),
('24', 'BOUCHET', 'Matéo', '06/06/1975', '2639', 'E7'),
('25', 'BOURDON', 'Alain', '09/03/1978', '9193', 'E22'),
('26', 'BOURDON', 'Denis', '27/09/1981', '1089', 'E4'),
('27', 'BOYER', 'Christian', '07/07/1976', '7012', 'E1'),
('28', 'BRISSE', 'Thierry', '09/09/1978', '5619', 'E3'),
('29', 'BROCHIER', 'Alain', '09/09/1978', '5210', 'E9'),
('30', 'BROERS', 'Detlef', '18/06/1972', '1263', 'E3'),
('31', 'CARNAT', 'Robert', '14/02/1983', '5605', 'E24'),
('32', 'CHAMBON', 'Pierre', '30/06/1984', '2726', 'E11'),
('33', 'CHAPON', 'André', '25/01/1979', '1823', 'E6'),
('34', 'CHAUSSAT', 'Jean-Marc', '06/12/1975', '7277', 'E8'),
('35', 'CHERPIN', 'Guy', '21/03/1975', '5062', 'E16'),
('36', 'CHIL', 'Gérard', '10/10/1979', '5398', 'E18'),
('37', 'CIVRAIS', 'Christian', '04/04/1973', '9512', 'E11'),
('38', 'CLAVELLOUX', 'Julien', '27/03/1981', '1416', 'E22'),
('39', 'CLUZEL', 'Sylvain', '06/12/1975', '9660', 'E6'),
('40', 'COMBETTE', 'Yves', '26/02/1980', '6254', 'E23'),
('41', 'COQUARD', 'Alexandre', '18/12/1972', '8503', 'E3'),
('42', 'CORNET', 'Antoine', '29/11/1983', '9648', 'E24'),
('43', 'COTTE', 'Jean-René', '23/11/1977', '5110', 'E8'),
('44', 'COUCHAUD', 'Gérard', '25/01/1979', '5112', 'E11'),
('45', 'CROS', 'Aurélien', '23/05/1977', '6869', 'E4'),
('46', 'DEBOVE', 'Christian', '01/01/1970', '2145', 'E9'),
('47', 'DECLINE', 'Robert', '08/08/1977', '7551', 'E24'),
('48', 'DEFOSSE', 'Michel', '04/10/1973', '2352', 'E3'),
('49', 'DELORME', 'Joseph', '15/09/1984', '9662', 'E22'),
('50', 'DELORME', 'André', '19/01/1973', '5295', 'E12'),
('51', 'DENIS', 'Clément', '01/01/1970', '9329', 'E18'),
('52', 'DESLANDES', 'Pascal', '29/05/1983', '6866', 'E15'),
('53', 'DESSERLE', 'Guy', '07/01/1976', '3067', 'E2'),
('54', 'DESSERT', 'Stéphane', '21/03/1975', '7174', 'E3'),
('55', 'DIXNEUF', 'Patrick', '23/11/1977', '5774', 'E16'),
('56', 'DUBUS', 'Yvon', '15/09/1984', '9941', 'E11'),
('57', 'DUPIN', 'Roger', '07/07/1976', '9167', 'E1'),
('58', 'EMONET', 'Henri', '03/09/1972', '7662', 'E8'),
('59', 'EPINAT', 'Olivier', '03/03/1972', '9317', 'E17'),
('60', 'ESCOFFIER', 'Christian', '05/05/1974', '8424', 'E18'),
('61', 'FAIDIT', 'Serge', '29/11/1983', '7440', 'E18'),
('62', 'FAYOLLE', 'Pierre', '09/09/1978', '2538', 'E1'),
('63', 'FEOLA', 'Jean-Michel', '28/10/1982', '9979', 'E4'),
('64', 'FERRATON', 'Michel', '12/12/1981', '9569', 'E9'),
('65', 'FERRE', 'Jean-Paul', '10/10/1979', '6313', 'E11'),
('66', 'FERREOL', 'Emile', '04/10/1973', '6013', 'E3'),
('67', 'FEUILLASTRE', 'Alain', '27/03/1981', '4268', 'E19'),
('68', 'FORISSIER', 'Louis', '18/06/1972', '2516', 'E2'),
('69', 'FORISSIER', 'Pierrick', '08/08/1977', '7665', 'E16'),
('70', 'FRAGNE', 'Marcel', '01/01/1970', '6695', 'E2'),
('71', 'FRANCE', 'Fernand', '26/08/1980', '3360', 'E13'),
('72', 'GENEBRIER', 'Gaspard', '12/12/1981', '7032', 'E7'),
('73', 'GENEVRIER', 'Gérard', '03/03/1972', '4265', 'E3'),
('74', 'GIROMINI', 'Guy', '19/07/1973', '5813', 'E13'),
('75', 'GRENETIER', 'Etienne', '11/05/1980', '1566', 'E19'),
('76', 'GRIOT', 'Gilbert', '04/10/1973', '9279', 'E10'),
('77', 'GUILLAUMONT', 'Alain', '01/01/1970', '6390', 'E21'),
('78', 'GUILLOT', 'Claude', '25/07/1979', '7374', 'E14'),
('79', 'GUILLOT', 'André', '22/10/1976', '3699', 'E4'),
('80', 'GUILLOT', 'Pierre', '13/07/1982', '3201', 'E12'),
('81', 'GUILLOT', 'Jean', '16/10/1970', '1380', 'E7'),
('82', 'HOGG', 'Jean-Claude', '10/10/1979', '2498', 'E23'),
('83', 'HUBERT', 'André', '27/03/1981', '2667', 'E12'),
('84', 'JACQUEMOND', 'Olivier', '13/01/1982', '8343', 'E5'),
('85', 'JAUMOTTE', 'Jacques', '20/02/1974', '2190', 'E3'),
('86', 'KLEIN', 'Jean-Luc', '05/11/1974', '6959', 'E15'),
('87', 'KURADJIAN', 'Alain', '15/09/1984', '8202', 'E16'),
('88', 'LACAZE', 'Roger', '04/10/1973', '7751', 'E9'),
('89', 'LARDEREAU', 'Robert', '25/07/1979', '6150', 'E16'),
('90', 'LAUROT', 'Pascale', '25/01/1979', '5896', 'E4'),
('91', 'LAVAUD', 'Jacques', '29/05/1983', '9113', 'E11'),
('92', 'LECONNETABLE', 'Claude', '01/07/1970', '7501', 'E7'),
('93', 'LELOUP', 'Alain', '03/09/1972', '6666', 'E20'),
('94', 'LEPETIT', 'François', '15/03/1984', '7744', 'E15'),
('95', 'LEROUX', 'Philippe', '27/09/1981', '8945', 'E4'),
('96', 'LORON', 'André', '08/02/1977', '1487', 'E8'),
('97', 'LORON', 'Louis', '29/11/1983', '2594', 'E10'),
('98', 'MANCINI', 'Olivier', '04/10/1973', '1528', 'E2'),
('99', 'MARECHAL', 'Morgan', '08/02/1977', '7177', 'E21'),
('100', 'MARECHAL', 'Jacques', '28/10/1982', '9267', 'E10'),
('101', 'MASSELIN', 'André', '06/06/1975', '5390', 'E6'),
('102', 'MASSON', 'Joël', '22/04/1976', '8899', 'E17'),
('103', 'MEJEAN', 'Jacques', '02/02/1971', '1208', 'E8'),
('104', 'MIGRAINE', 'Jacques', '20/02/1974', '3124', 'E20'),
('105', 'MOLLON', 'Jean', '22/04/1976', '4405', 'E22'),
('106', 'MONIER', 'Bernard', '23/11/1977', '8012', 'E3'),
('107', 'MORLIN', 'Guy', '14/02/1983', '9122', 'E7'),
('108', 'MOUCHARAT', 'Jean-Claude', '27/09/1981', '6059', 'E3'),
('109', 'MOULARD', 'André', '10/04/1979', '9953', 'E3'),
('110', 'MYARD', 'André', '08/02/1977', '4636', 'E12'),
('111', 'NAACKE', 'Philippe', '12/06/1981', '9832', 'E3'),
('112', 'NOURRISSON', 'Brigitte', '07/01/1976', '1930', 'E4'),
('113', 'OLLIVIER', 'Franck', '27/09/1981', '7107', 'E5'),
('114', 'PAGNAN', 'Albert', '16/04/1970', '2706', 'E6'),
('115', 'PARANT', 'Daniel', '06/12/1975', '7904', 'E19'),
('116', 'PARRA', 'Michel', '05/11/1974', '3145', 'E20'),
('117', 'PASCA', 'Jean', '19/07/1973', '5247', 'E20'),
('118', 'PAULIGNAN', 'Martine', '11/05/1980', '5240', 'E22'),
('119', 'PEDARRE', 'Michel', '19/07/1973', '8412', 'E12'),
('120', 'PEREZ', 'Martin', '25/07/1979', '5441', 'E15'),
('121', 'PERRET', 'Olivier', '01/01/1970', '5549', 'E7'),
('122', 'PERRET', 'Richard', '03/03/1972', '9160', 'E22'),
('123', 'PETIT', 'Nicolas', '02/02/1971', '4427', 'E17'),
('124', 'PEYRARD', 'Yves', '30/12/1984', '5334', 'E17'),
('125', 'PHILIBERT', 'Georges', '21/03/1975', '6624', 'E10'),
('126', 'PIALLAT', 'René', '06/06/1975', '7035', 'E24'),
('127', 'PLANCHET', 'Marcel', '06/06/1975', '8901', 'E15'),
('128', 'POIROT', 'Georges', '01/07/1970', '5320', 'E19'),
('129', 'POULALIER', 'Paul', '03/03/1972', '1477', 'E19'),
('130', 'POYET', 'Noel', '09/03/1978', '6480', 'E23'),
('131', 'PREBET', 'Danielle', '09/09/1978', '6283', 'E5'),
('132', 'PREBET', 'Gérard', '20/08/1974', '4753', 'E6'),
('133', 'PREYNAT', 'Jean louis', '13/07/1982', '9115', 'E24'),
('134', 'PREYNAT', 'Maurice', '15/03/1984', '3785', 'E10'),
('135', 'RABEYRIN', 'Richard', '16/10/1970', '8301', 'E1'),
('136', 'RANCHON', 'Bernard', '11/11/1980', '6287', 'E23'),
('137', 'RANCHON', 'Jean-François', '10/10/1979', '4837', 'E2'),
('138', 'RASCLE', 'Pierre', '24/12/1978', '6487', 'E6'),
('139', 'RAYMOND', 'Serge', '23/05/1977', '6056', 'E6'),
('140', 'REMILLIEUX', 'Jacques', '27/03/1981', '3676', 'E11'),
('141', 'RENAUD', 'Jacques', '08/08/1977', '2058', 'E3'),
('142', 'RICCOBENE', 'Maxime', '27/03/1981', '8038', 'E2'),
('143', 'RIFELDE', 'Robert', '15/09/1984', '4578', 'E11'),
('144', 'ROBERT', 'Denis', '11/05/1980', '4602', 'E5'),
('145', 'ROLHION', 'Daniel', '12/12/1981', '4816', 'E7'),
('146', 'SAVOLDELLI', 'René', '03/09/1972', '5471', 'E4'),
('147', 'SCHREIBER', 'Robert', '17/11/1971', '8567', 'E19'),
('148', 'SCILY', 'Gérard', '16/04/1970', '5897', 'E17'),
('149', 'SELLIER', 'Laurent', '09/09/1978', '3696', 'E23'),
('150', 'SOLA', 'Albert', '07/07/1976', '4584', 'E10'),
('151', 'SOULAS', 'Gérard', '16/10/1970', '5621', 'E12'),
('152', 'SOULIER', 'Daniel', '23/11/1977', '9988', 'E15'),
('153', 'SUCHAUT', 'Antoine', '11/05/1980', '5516', 'E9'),
('154', 'SUCHAUT', 'Thierry', '11/05/1980', '4916', 'E4'),
('155', 'TABART', 'Gabriel', '29/11/1983', '4089', 'E1'),
('156', 'TEYSSIER', 'Serge', '05/05/1974', '6406', 'E3'),
('157', 'TISSOT', 'Roger', '19/07/1973', '5757', 'E14'),
('158', 'TIXIER', 'Georges', '10/04/1979', '7143', 'E18'),
('159', 'TRAN', 'Charly', '11/05/1980', '8753', 'E2'),
('160', 'TRAN', 'Auguste', '16/10/1970', '6392', 'E7'),
('161', 'TRIOMPHE', 'Jérémy', '09/03/1978', '9472', 'E17'),
('162', 'VALLAT', 'Daniel', '18/12/1972', '7085', 'E5'),
('163', 'VAUX', 'Roland', '29/05/1983', '9788', 'E20'),
('164', 'VILLARD', 'Marc', '10/10/1979', '2707', 'E6'),
('165', 'VIVIAND', 'Louis', '27/03/1981', '1131', 'E4'),
('166', 'WISNIEWSKI', 'Romain', '23/11/1977', '9185', 'E8'),
('167', 'ZAPOTOCKY', 'Jean', '15/09/1984', '5333', 'E2'),
('168', 'ZUDDAS', 'Pierre', '18/04/1980', '3931', 'E4');

-- --------------------------------------------------------

--
-- Structure de la table `match`
--

DROP TABLE IF EXISTS `match`;
CREATE TABLE IF NOT EXISTS `match` (
  `CodeM` varchar(4) NOT NULL,
  `DateM` varchar(10) DEFAULT NULL,
  `LieuM` varchar(40) DEFAULT NULL,
  `ScoreEquipe1` int(11) DEFAULT NULL,
  `ScoreEquipe2` int(11) DEFAULT NULL,
  `CodeEquipe1` varchar(4) NOT NULL,
  `CodeEquipe2` varchar(4) NOT NULL,
  PRIMARY KEY (`CodeM`),
  KEY `CodeEquipe1` (`CodeEquipe1`),
  KEY `CodeEquipe2` (`CodeEquipe2`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `match`
--

INSERT INTO `match` (`CodeM`, `DateM`, `LieuM`, `ScoreEquipe1`, `ScoreEquipe2`, `CodeEquipe1`, `CodeEquipe2`) VALUES
('M1', '10/10/2015', 'Verdun', 1, 3, 'E1', 'E2'),
('M2', '10/10/2015', 'Toul', 2, 2, 'E5', 'E4'),
('M3', '10/10/2015', 'Epinal', 1, 4, 'E3', 'E12'),
('M4', '10/10/2015', 'Etain', 2, 2, 'E8', 'E7'),
('M5', '10/10/2015', 'St Mihiel', 3, 3, 'E6', 'E10'),
('M6', '10/10/2015', 'Lunéville', 2, 4, 'E9', 'E11'),
('M7', '17/10/2015', 'St Mihiel', 1, 3, 'E4', 'E1'),
('M8', '17/10/2015', 'Etain', 0, 2, 'E12', 'E3'),
('M9', '17/10/2015', 'Epinal', 1, 0, 'E7', 'E6'),
('M10', '17/10/2015', 'Verdun', 3, 1, 'E2', 'E8'),
('M11', '17/10/2015', 'Toul', 2, 0, 'E5', 'E9'),
('M12', '17/10/2015', 'Lunéville', 2, 2, 'E11', 'E10'),
('M13', '17/10/2015', 'St Mihiel', 0, 0, 'E23', 'E12'),
('M14', '17/10/2015', 'Epinal', 1, 3, 'E20', 'E13'),
('M15', '17/10/2015', 'Toul', 3, 4, 'E22', 'E14'),
('M16', '17/10/2015', 'Lunéville', 2, 3, 'E19', 'E16'),
('M17', '17/10/2015', 'Verdun', 3, 1, 'E21', 'E17'),
('M18', '17/10/2015', 'Etain', 0, 1, 'E15', 'E18'),
('M19', '24/10/2015', 'Etain', 1, 2, 'E15', 'E19'),
('M20', '24/10/2015', 'Lunéville', 2, 1, 'E14', 'E20'),
('M21', '24/10/2015', 'Toul', 4, 3, 'E16', 'E21'),
('M22', '24/10/2015', 'Verdun', 2, 2, 'E18', 'E22'),
('M23', '24/10/2015', 'Epinal', 3, 1, 'E17', 'E23'),
('M24', '24/10/2015', 'St Mihiel', 0, 0, 'E24', 'E13');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
