CREATE DATABASE Championnat;
USE Championnat;


--
-- table arbitre
--
CREATE TABLE IF NOT EXISTS arbitre (
  CodeA varchar(4) NOT NULL,
  NomA varchar(20) NOT NULL,
  PrenomA varchar(20) NOT NULL,
  PRIMARY KEY (CodeA)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO arbitre (CodeA, NomA, PrenomA) VALUES
('A1', 'Lefort', 'Philippe'),
('A10', 'Lepont', 'Jacques'),
('A11', 'Pierrin', 'Marcel'),
('A12', 'Monin', 'Jean'),
('A2', 'Trebeau', 'Sébastien'),
('A3', 'Ritterlan', 'Hervé'),
('A4', 'Rubens', 'Stéphane'),
('A5', 'Leoperon', 'Philippe'),
('A6', 'Durand', 'Jean Charles'),
('A7', 'Stéfanin', 'Loïc'),
('A8', 'Renom', 'Pierre'),
('A9', 'Fieffe', 'Eric');

-- --------------------------------------------------------
--
-- table Fonction
--

DROP TABLE IF EXISTS fonction ;
CREATE TABLE IF NOT EXISTS fonction (
  CodeFct varchar(4) NOT NULL,
  LibelleFct varchar(20) NOT NULL,
  PRIMARY KEY (CodeFct) 
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO fonction (CodeFct, LibelleFct) VALUES
('TA', 'Table'),
('TE', 'Terrain');

--
-- table arbitrer
--

DROP TABLE IF EXISTS arbitrer;
CREATE TABLE IF NOT EXISTS arbitrer (
  CodeArbitre varchar(4) NOT NULL,
  CodeMatch varchar(4) NOT NULL,
  FonctionArbitre varchar(4) NOT NULL,
  PRIMARY KEY (CodeArbitre,CodeMatch)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table arbitrer
--

INSERT INTO arbitrer (CodeArbitre, CodeMatch, FonctionArbitre) VALUES
('A1', 'M1', 'TE'),
('A1', 'M13', 'TE'),
('A1', 'M19', 'TE'),
('A10', 'M10', 'TE'),
('A10', 'M17', 'TE'),
('A10', 'M19', 'TA'),
('A10', 'M3', 'TE'),
('A11', 'M11', 'TE'),
('A11', 'M16', 'TA'),
('A11', 'M2', 'TE'),
('A11', 'M21', 'TA'),
('A12', 'M1', 'TA'),
('A12', 'M12', 'TE'),
('A12', 'M17', 'TA'),
('A12', 'M20', 'TA'),
('A2', 'M18', 'TE'),
('A2', 'M20', 'TE'),
('A2', 'M3', 'TA'),
('A2', 'M7', 'TE'),
('A2', 'M8', 'TE'),
('A3', 'M14', 'TE'),
('A3', 'M21', 'TE'),
('A3', 'M5', 'TE'),
('A3', 'M9', 'TE'),
('A4', 'M10', 'TA'),
('A4', 'M18', 'TA'),
('A4', 'M2', 'TA'),
('A4', 'M22', 'TE'),
('A5', 'M11', 'TA'),
('A5', 'M13', 'TA'),
('A5', 'M23', 'TE'),
('A5', 'M4', 'TE'),
('A6', 'M12', 'TA'),
('A6', 'M15', 'TE'),
('A6', 'M24', 'TE'),
('A6', 'M6', 'TE'),
('A7', 'M14', 'TA'),
('A7', 'M24', 'TA'),
('A7', 'M6', 'TA'),
('A7', 'M7', 'TA'),
('A8', 'M15', 'TA'),
('A8', 'M23', 'TA'),
('A8', 'M5', 'TA'),
('A8', 'M8', 'TA'),
('A9', 'M16', 'TE'),
('A9', 'M22', 'TA'),
('A9', 'M4', 'TA'),
('A9', 'M9', 'TA');

--
-- table categorie
--

DROP TABLE IF EXISTS categorie;
CREATE TABLE IF NOT EXISTS categorie (
  CodeCat varchar(4) NOT NULL,
  LibelleCat varchar(20) NOT NULL,
  PRIMARY KEY (CodeCat)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO categorie (CodeCat, LibelleCat) VALUES
('S1', 'Junior'),
('S2', 'Senior');

--
-- table club
--

CREATE TABLE IF NOT EXISTS club (
  CodeC varchar(4) NOT NULL,
  NomC varchar(20) NOT NULL,
  VilleC varchar(30) DEFAULT NULL,
  CPC varchar(5) DEFAULT NULL,
  TelC varchar(14) DEFAULT NULL,
  PRIMARY KEY (CodeC)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO club (CodeC, NomC, VilleC, CPC, TelC) VALUES
('C1', 'SF Belleville',  'Verdun', '55100', ''),
('C10', 'FC Val Dunois',  'Behonne', '55000', ''),
('C11', 'FC Bruch Forbach', 'Forbach', '76000', ''),
('C12', 'FC Commercy',  'Velaines', '55500', ''),
('C2', 'SCA Epinal',  'Epinal', '88000', ''),
('C3', 'USL Mineenne',  'St Mihiel', '55300', ''),
('C4', 'FC Toul', 'Toul', '54200', ''),
('C5', 'US Etain', 'Etain', '55400', ''),
('C6', 'ESP Lunéville', 'Lunéville', '54300', ''),
('C7', 'FC Velaines', 'Velaines', '55500', ''),
('C8', 'FCSTD', 'Saint Dié', '88100', ''),
('C9', 'District Vosges', 'Epinal', '88000', '');


--
-- table equipe
--

DROP TABLE IF EXISTS equipe;
CREATE TABLE IF NOT EXISTS equipe (
  CodeE varchar(4) NOT NULL,
  CodeClub varchar(4) NOT NULL,
  CodeCateg varchar(4) NOT NULL,
  PRIMARY KEY (CodeE)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO equipe (CodeE, CodeClub, CodeCateg) VALUES
('E1', 'C1', 'S1'),
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
('E2', 'C1', 'S1'),
('E20', 'C2', 'S2'),
('E21', 'C1', 'S2'),
('E22', 'C4', 'S2'),
('E23', 'C3', 'S2'),
('E24', 'C3', 'S2'),
('E3', 'C2', 'S1'),
('E4', 'C3', 'S1'),
('E5', 'C4', 'S1'),
('E6', 'C3', 'S1'),
('E7', 'C2', 'S1'),
('E8', 'C5', 'S1'),
('E9', 'C6', 'S1');

--
-- table poste
--

DROP TABLE IF EXISTS poste;
CREATE TABLE IF NOT EXISTS poste (
  CodeP varchar(4) NOT NULL,
  LibelleP varchar(20) NOT NULL,
  PRIMARY KEY (CodeP)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO poste (CodeP, LibelleP) VALUES
('GRD', 'Gardien'),
('DEF', 'Défenseur'),
('ALR', 'Ailier'),
('PVT', 'Pivot'),
('UNV', 'Universel');

-- --------------------------------------------------------

--
-- table joueur
--

DROP TABLE IF EXISTS joueur;
CREATE TABLE IF NOT EXISTS joueur (
  NumJ int(11) NOT NULL,
  NomJ varchar(20) DEFAULT NULL,
  PrenomJ varchar(20) DEFAULT NULL,
  DateNaissJ DATE DEFAULT NULL, 
  NumLicenceJ varchar(10) DEFAULT NULL,
  CodeEquipe varchar(4) NOT NULL,
  CodePoste varchar(4) ,
  PRIMARY KEY (NumJ)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table joueur
--

INSERT INTO joueur (NumJ, NomJ, PrenomJ, DateNaissJ, NumLicenceJ, CodeEquipe, CodePoste) VALUES
(1, 'ACHARD', 'Patrick','1978-09-9', '8752504422', 'E11' ,'UNV'),
(2, 'ANDRE', 'Pascal','1970-07-1', '5008121528', 'E11' ,'DEF'),
(3, 'ANDRI', 'Henri','1977-02-8', '7629104910', 'E16' ,'GRD'),
(4, 'ARNAUD', 'Philippe','1978-03-9', '2439258097', 'E5' ,'ALR'),
(5, 'AUDOUARD', 'Jean-Claude','1971-08-2', '6281306978', 'E4' ,'GRD'),
(6, 'AUGAGNEUR', 'Jean-Paul','1970-04-16', '1599486091', 'E21' ,'GRD'),
(7, 'AUROI', 'Lucien','1984-09-15', '1717995615', 'E23' ,'UNV'),
(8, 'BALEYDIER', 'Henri','1980-08-26', '2380284764', 'E9' ,'ALR'),
(9, 'BALLIGAND', 'Serge','1984-03-15', '1612514095', 'E8' ,'PVT'),
(10, 'BAVUSO', 'François','1971-05-17', '5000559614', 'E5' ,'DEF'),
(11, 'BAYET', 'Benoit','1970-07-1', '4589534716', 'E24' ,'DEF'),
(12, 'BAYET', 'Bruno','1976-07-7', '6740352810', 'E14' ,'DEF'),
(13, 'BAYLE', 'Alexis','1978-06-24', '4351189386', 'E7' ,'ALR'),
(14, 'BENOIT', 'Lucien','1983-02-14', '4632074453', 'E4' ,'GRD'),
(15, 'BERGER', 'Christian','1981-03-27', '9296088373', 'E11' ,'DEF'),
(16, 'BERNARD', 'Alain','1970-01-1', '8414640626', 'E11' ,'PVT'),
(17, 'BERTHELIER', 'Patrick','1975-09-21', '1479145860', 'E16' ,'UNV'),
(18, 'BERTHOLON', 'Gérard','1980-02-26', '3485242400', 'E16' ,'DEF'),
(19, 'BLANCHIN', 'Gérard','1972-06-18', '8969623885', 'E6' ,'GRD'),
(20, 'BONNAMOUR', 'Etienne','1982-10-28', '2438961857', 'E13' ,'GRD'),
(21, 'BORY', 'Philippe','1978-09-9', '9203553597', 'E8' ,'GRD'),
(22, 'BOS', 'Stanley','1983-02-14', '4751805248', 'E1' ,'ALR'),
(23, 'BOUCHET', 'Philippe','1981-06-12', '5530430833', 'E11' ,'ALR'),
(24, 'BOUCHET', 'Matéo','1975-06-6', '2639252741', 'E7' ,'PVT'),
(25, 'BOURDON', 'Alain','1978-03-9', '9193417985', 'E22' ,'GRD'),
(26, 'BOURDON', 'Denis','1981-09-27', '1089306218', 'E4' ,'ALR'),
(27, 'BOYER', 'Christian','1976-07-7', '7012541756', 'E1' ,'DEF'),
(28, 'BRISSE', 'Thierry','1978-09-9', '5619171786', 'E3' ,'DEF'),
(29, 'BROCHIER', 'Alain','1978-09-9', '5210040608', 'E9' ,'PVT'),
(30, 'BROERS', 'Detlef','1972-06-18', '1263801968', 'E3' ,'GRD'),
(31, 'CARNAT', 'Robert','1983-02-14', '5605470797', 'E24' ,'ALR'),
(32, 'CHAMBON', 'Pierre','1984-06-30', '2726698993', 'E11' ,'DEF'),
(33, 'CHAPON', 'André','1979-01-25', '1823471429', 'E6' ,'PVT'),
(34, 'CHAUSSAT', 'Jean-Marc','1975-12-6', '7277253144', 'E8' ,'DEF'),
(35, 'CHERPIN', 'Guy','1975-03-21', '5062487255', 'E16' ,'DEF'),
(36, 'CHIL', 'Gérard','1979-10-10', '5398813190', 'E18' ,'PVT'),
(37, 'CIVRAIS', 'Christian','1973-04-4', '9512374929', 'E11' ,'DEF'),
(38, 'CLAVELLOUX', 'Julien','1981-03-27', '1416905043', 'E22' ,'DEF'),
(39, 'CLUZEL', 'Sylvain','1975-12-6', '9660304226', 'E6' ,'PVT'),
(40, 'COMBETTE', 'Yves','1980-02-26', '6254055335', 'E23' ,'ALR'),
(41, 'COQUARD', 'Alexandre','1972-12-18', '8503836205', 'E3' ,'ALR'),
(42, 'CORNET', 'Antoine','1983-11-29', '9648829727', 'E24' ,'UNV'),
(43, 'COTTE', 'Jean-René','1977-11-23', '5110136938', 'E8' ,'DEF'),
(44, 'COUCHAUD', 'Gérard','1979-01-25', '5112015742', 'E11' ,'PVT'),
(45, 'CROS', 'Aurélien','1977-05-23', '6869070924', 'E4' ,'UNV'),
(46, 'DEBOVE', 'Christian','1970-01-1', '2145441712', 'E9' ,'PVT'),
(47, 'DECLINE', 'Robert','1977-08-8', '7551189660', 'E24' ,'PVT'),
(48, 'DEFOSSE', 'Michel','1973-10-4', '2352941467', 'E3' ,'DEF'),
(49, 'DELORME', 'Joseph','1984-09-15', '9662425113', 'E22' ,'GRD'),
(50, 'DELORME', 'André','1973-01-19', '5295089264', 'E12' ,'PVT'),
(51, 'DENIS', 'Clément','1970-01-1', '9329920308', 'E18' ,'GRD'),
(52, 'DESLANDES', 'Pascal','1983-05-29', '6866170500', 'E15' ,'UNV'),
(53, 'DESSERLE', 'Guy','1976-01-7', '3067332808', 'E2' ,'GRD'),
(54, 'DESSERT', 'Stéphane','1975-03-21', '7174232436', 'E3' ,'PVT'),
(55, 'DIXNEUF', 'Patrick','1977-11-23', '577468970', 'E16' ,'DEF'),
(56, 'DUBUS', 'Yvon','1984-09-15', '9941118082', 'E11' ,'PVT'),
(57, 'DUPIN', 'Roger','1976-07-7', '9167728364', 'E1' ,'UNV'),
(58, 'EMONET', 'Henri','1972-09-3', '7662022926', 'E8' ,'GRD'),
(59, 'EPINAT', 'Olivier','1972-03-3', '9317710292', 'E17' ,'PVT'),
(60, 'ESCOFFIER', 'Christian','1974-05-5', '8424670982', 'E18' ,'GRD'),
(61, 'FAIDIT', 'Serge','1983-11-29', '7440152704', 'E18' ,'GRD'),
(62, 'FAYOLLE', 'Pierre','1978-09-9', '2538945178', 'E1' ,'DEF'),
(63, 'FEOLA', 'Jean-Michel','1982-10-28', '9979318508', 'E4' ,'PVT'),
(64, 'FERRATON', 'Michel','1981-12-12', '9569690997', 'E9' ,'UNV'),
(65, 'FERRE', 'Jean-Paul','1979-10-10', '6313720571', 'E11' ,'PVT'),
(66, 'FERREOL', 'Emile','1973-10-4', '6013397169', 'E3' ,'PVT'),
(67, 'FEUILLASTRE', 'Alain','1981-03-27', '4268372373', 'E19' ,'DEF'),
(68, 'FORISSIER', 'Louis','1972-06-18', '2516505686', 'E2' ,'UNV'),
(69, 'FORISSIER', 'Pierrick','1977-08-8', '7665828677', 'E16' ,'GRD'),
(70, 'FRAGNE', 'Marcel','1970-01-1', '6695628907', 'E2' ,'UNV'),
(71, 'FRANCE', 'Fernand','1980-08-26', '3360603300', 'E13' ,'GRD'),
(72, 'GENEBRIER', 'Gaspard','1981-12-12', '7032149395', 'E7' ,'ALR'),
(73, 'GENEVRIER', 'Gérard','1972-03-3', '4265739911', 'E3' ,'PVT'),
(74, 'GIROMINI', 'Guy','1973-07-19', '5813407382', 'E13' ,'GRD'),
(75, 'GRENETIER', 'Etienne','1980-05-11', '1566199758', 'E19' ,'DEF'),
(76, 'GRIOT', 'Gilbert','1973-10-4', '9279939640', 'E10' ,'ALR'),
(77, 'GUILLAUMONT', 'Alain','1970-01-1', '6390936333', 'E21' ,'ALR'),
(78, 'GUILLOT', 'Claude','1979-07-25', '7374530580', 'E14' ,'PVT'),
(79, 'GUILLOT', 'André','1976-10-22', '369977694', 'E4' ,'UNV'),
(80, 'GUILLOT', 'Pierre','1982-07-13', '3201489381', 'E12' ,'GRD'),
(81, 'GUILLOT', 'Jean','1970-10-16', '1380121602', 'E7' ,'ALR'),
(82, 'HOGG', 'Jean-Claude','1979-10-10', '2498442285', 'E23' ,'ALR'),
(83, 'HUBERT', 'André','1981-03-27', '2667700509', 'E12' ,'DEF'),
(84, 'JACQUEMOND', 'Olivier','1982-01-13', '8343781406', 'E5' ,'ALR'),
(85, 'JAUMOTTE', 'Jacques','1974-02-20', '2190873432', 'E3' ,'PVT'),
(86, 'KLEIN', 'Jean-Luc','1974-11-5', '6959171809', 'E15' ,'GRD'),
(87, 'KURADJIAN', 'Alain','1984-09-15', '8202240814', 'E16' ,'DEF'),
(88, 'LACAZE', 'Roger','1973-10-4', '7751213624', 'E9' ,'UNV'),
(89, 'LARDEREAU', 'Robert','1979-07-25', '6150051573', 'E16' ,'ALR'),
(90, 'LAUROT', 'Pascale','1979-01-25', '5896614054', 'E4' ,'ALR'),
(91, 'LAVAUD', 'Jacques','1983-05-29', '9113309124', 'E11' ,'UNV'),
(92, 'LECONNETABLE', 'Claude','1970-07-1', '7501456408', 'E7' ,'GRD'),
(93, 'LELOUP', 'Alain','1972-09-3', '6666653550', 'E20' ,'ALR'),
(94, 'LEPETIT', 'François','1984-03-15', '7744550552', 'E15' ,'UNV'),
(95, 'LEROUX', 'Philippe','1981-09-27', '8945439794', 'E4' ,'ALR'),
(96, 'LORON', 'André','1977-02-8', '1487102996', 'E8' ,'PVT'),
(97, 'LORON', 'Louis','1983-11-29', '2594917897', 'E10' ,'ALR'),
(98, 'MANCINI', 'Olivier','1973-10-4', '1528959838', 'E2' ,'GRD'),
(99, 'MARECHAL', 'Morgan','1977-02-8', '7177573713', 'E21' ,'ALR'),
(100, 'MARECHAL', 'Jacques','1982-10-28', '9267034117', 'E10' ,'DEF'),
(101, 'MASSELIN', 'André','1975-06-6', '5390504457', 'E6' ,'ALR'),
(102, 'MASSON', 'Joël','1976-04-22', '8899736825', 'E17' ,'DEF'),
(103, 'MEJEAN', 'Jacques','1971-02-2', '1208063991', 'E8' ,'UNV'),
(104, 'MIGRAINE', 'Jacques','1974-02-20', '3124650721', 'E20' ,'UNV'),
(105, 'MOLLON', 'Jean','1976-04-22', '4405443049', 'E22' ,'UNV'),
(106, 'MONIER', 'Bernard','1977-11-23', '8012523891', 'E3' ,'UNV'),
(107, 'MORLIN', 'Guy','1983-02-14', '9122811682', 'E7' ,'UNV'),
(108, 'MOUCHARAT', 'Jean-Claude','1981-09-27', '6059965993', 'E3' ,'UNV'),
(109, 'MOULARD', 'André','1979-04-10', '9953077256', 'E3' ,'GRD'),
(110, 'MYARD', 'André','1977-02-8', '4636027059', 'E12' ,'ALR'),
(111, 'NAACKE', 'Philippe','1981-06-12', '9832311817', 'E3' ,'DEF'),
(112, 'NOURRISSON', 'Brigitte','1976-01-7', '1930194461', 'E4' ,'DEF'),
(113, 'OLLIVIER', 'Franck','1981-09-27', '7107684996', 'E5' ,'GRD'),
(114, 'PAGNAN', 'Albert','1970-04-16', '2706294236', 'E6' ,'ALR'),
(115, 'PARANT', 'Daniel','1975-12-6', '7904418855', 'E19' ,'DEF'),
(116, 'PARRA', 'Michel','1974-11-5', '3145994735', 'E20' ,'GRD'),
(117, 'PASCA', 'Jean','1973-07-19', '5247926734', 'E20' ,'ALR'),
(118, 'PAULIGNAN', 'Martine','1980-05-11', '5240138538', 'E22' ,'GRD'),
(119, 'PEDARRE', 'Michel','1973-07-19', '8412537400', 'E12' ,'GRD'),
(120, 'PEREZ', 'Martin','1979-07-25', '5441630538', 'E15' ,'GRD'),
(121, 'PERRET', 'Olivier','1970-01-1', '5549494314', 'E7' ,'GRD'),
(122, 'PERRET', 'Richard','1972-03-3', '9160541820', 'E22' ,'GRD'),
(123, 'PETIT', 'Nicolas','1971-02-2', '4427313422', 'E17' ,'PVT'),
(124, 'PEYRARD', 'Yves','1984-12-30', '5334170881', 'E17' ,'GRD'),
(125, 'PHILIBERT', 'Georges','1975-03-21', '6624998759', 'E10' ,'GRD'),
(126, 'PIALLAT', 'René','1975-06-6', '7035004250', 'E24' ,'DEF'),
(127, 'PLANCHET', 'Marcel','1975-06-6', '8901300065', 'E15' ,'GRD'),
(128, 'POIROT', 'Georges','1970-07-1', '5320861385', 'E19' ,'DEF'),
(129, 'POULALIER', 'Paul','1972-03-3', '1477564890', 'E19' ,'UNV'),
(130, 'POYET', 'Noel','1978-03-9', '6480900902', 'E23' ,'GRD'),
(131, 'PREBET', 'Danielle','1978-09-9', '6283891598', 'E5' ,'GRD'),
(132, 'PREBET', 'Gérard','1974-08-20', '4753918268', 'E6' ,'UNV'),
(133, 'PREYNAT', 'Jean louis','1982-07-13', '9115687879', 'E24' ,'ALR'),
(134, 'PREYNAT', 'Maurice','1984-03-15', '3785832762', 'E10' ,'PVT'),
(135, 'RABEYRIN', 'Richard','1970-10-16', '8301013634', 'E1' ,'DEF'),
(136, 'RANCHON', 'Bernard','1980-11-11', '6287320605', 'E23' ,'PVT'),
(137, 'RANCHON', 'Jean-François','1979-10-10', '4837398970', 'E2' ,'UNV'),
(138, 'RASCLE', 'Pierre','1978-12-24', '6487555509', 'E6' ,'DEF'),
(139, 'RAYMOND', 'Serge','1977-05-23', '6056133143', 'E6' ,'UNV'),
(140, 'REMILLIEUX', 'Jacques','1981-03-27', '3676388692', 'E11' ,'DEF'),
(141, 'RENAUD', 'Jacques','1977-08-8', '2058192146', 'E3' ,'PVT'),
(142, 'RICCOBENE', 'Maxime','1981-03-27', '8038967047', 'E2' ,'DEF'),
(143, 'RIFELDE', 'Robert','1984-09-15', '4578612266', 'E11' ,'GRD'),
(144, 'ROBERT', 'Denis','1980-05-11', '4602963164', 'E5' ,'ALR'),
(145, 'ROLHION', 'Daniel','1981-12-12', '4816300240', 'E7' ,'UNV'),
(146, 'SAVOLDELLI', 'René','1972-09-3', '5471537711', 'E4' ,'DEF'),
(147, 'SCHREIBER', 'Robert','1971-11-17', '8567175752', 'E19' ,'DEF'),
(148, 'SCILY', 'Gérard','1970-04-16', '5897253946', 'E17' ,'ALR'),
(149, 'SELLIER', 'Laurent','1978-09-9', '3696525495', 'E23' ,'ALR'),
(150, 'SOLA', 'Albert','1976-07-7', '4584663668', 'E10' ,'GRD'),
(151, 'SOULAS', 'Gérard','1970-10-16', '5621270166', 'E12' ,'PVT'),
(152, 'SOULIER', 'Daniel','1977-11-23', '9988395165', 'E15' ,'GRD'),
(153, 'SUCHAUT', 'Antoine','1980-05-11', '5516956642', 'E9' ,'ALR'),
(154, 'SUCHAUT', 'Thierry','1980-05-11', '4916004100', 'E4' ,'GRD'),
(155, 'TABART', 'Gabriel','1983-11-29', '4089496660', 'E1' ,'ALR'),
(156, 'TEYSSIER', 'Serge','1974-05-5', '6406878418', 'E3' ,'ALR'),
(157, 'TISSOT', 'Roger','1973-07-19', '5757981544', 'E14' ,'DEF'),
(158, 'TIXIER', 'Georges','1979-04-10', '7143492558', 'E18' ,'UNV'),
(159, 'TRAN', 'Charly','1980-05-11', '8753149059', 'E2' ,'PVT'),
(160, 'TRAN', 'Auguste','1970-10-16', '6392991940', 'E7' ,'DEF'),
(161, 'TRIOMPHE', 'Jérémy','1978-03-9', '9472042185', 'E17' ,'ALR'),
(162, 'VALLAT', 'Daniel','1972-12-18', '7085153078', 'E5' ,'GRD'),
(163, 'VAUX', 'Roland','1983-05-29', '9788953727', 'E20' ,'GRD'),
(164, 'VILLARD', 'Marc','1979-10-10', '2707953508', 'E6' ,'ALR'),
(165, 'VIVIAND', 'Louis','1981-03-27', '1131332589', 'E4' ,'GRD'),
(166, 'WISNIEWSKI', 'Romain','1977-11-23', '9185944706', 'E8' ,'DEF'),
(167, 'ZAPOTOCKY', 'Jean','1984-09-15', '5333775982', 'E2' ,'DEF'),
(168, 'ZUDDAS', 'Pierre','1980-04-18', '3931918364', 'E4' ,'UNV');




-- --------------------------------------------------------

--
-- table matches
--

CREATE TABLE IF NOT EXISTS matches (
  CodeM varchar(4) NOT NULL, 
  DateM DATE DEFAULT NULL,  
  LieuM varchar(30) DEFAULT NULL,
  ScoreEquipe1 int(11) DEFAULT NULL,
  ScoreEquipe2 int(11) DEFAULT NULL,
  CodeEquipe1 varchar(4) DEFAULT NULL,
  CodeEquipe2 varchar(4) DEFAULT NULL,
  PRIMARY KEY (CodeM)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO matches (CodeM, DateM, LieuM, ScoreEquipe1, ScoreEquipe2, CodeEquipe1, CodeEquipe2) VALUES
('M1', '2024-10-17', 0, 1, 3, 'E1', 'E2'),
('M10', '2024-10-17', 0, 3, 1, 'E2', 'E8'),
('M11', '2024-10-17', 0, 2, 0, 'E5', 'E9'),
('M12', '2024-10-17', 0, 2, 2, 'E11', 'E10'),
('M13', '2024-10-17', 0, 0, 0, 'E23', 'E12'),
('M14', '2024-10-17', 0, 1, 3, 'E20', 'E13'),
('M15', '2024-10-17', 0, 3, 4, 'E22', 'E14'),
('M16', '2024-10-17', 0, 2, 3, 'E19', 'E16'),
('M17', '2024-10-17', 0, 3, 1, 'E21', 'E17'),
('M18', '2024-10-17', 0, 0, 1, 'E15', 'E18'),
('M19', '2024-10-24', 0, 1, 2, 'E15', 'E19'),
('M2', '2024-10-10', 0, 2, 2, 'E5', 'E4'),
('M20', '2024-10-24', 0, 2, 1, 'E14', 'E20'),
('M21', '2024-10-24', 0, 4, 3, 'E16', 'E21'),
('M22', '2024-10-24', 0, 2, 2, 'E18', 'E22'),
('M23', '2024-10-24', 0, 3, 1, 'E17', 'E23'),
('M24', '2024-10-24', 0, 0, 0, 'E24', 'E13'),
('M3', '2024-10-10', 0, 1, 4, 'E3', 'E12'),
('M4', '2024-10-10', 0, 2, 2, 'E8', 'E7'),
('M5', '2024-10-10', 0, 3, 3, 'E6', 'E10'),
('M6', '2024-10-10', 0, 2, 4, 'E9', 'E11'),
('M7', '2024-10-17', 0, 1, 3, 'E4', 'E1'),
('M8', '2024-10-17', 0, 0, 2, 'E12', 'E3'),
('M9', '2024-10-17', 0, 1, 0, 'E7', 'E6');

ALTER TABLE arbitrer
  ADD CONSTRAINT arbitrer_ibfk_1 FOREIGN KEY (CodeArbitre) REFERENCES arbitre (CodeA) ON DELETE CASCADE,
  ADD CONSTRAINT arbitrer_ibfk_2 FOREIGN KEY (CodeMatch) REFERENCES matches (CodeM) ON DELETE CASCADE,
  ADD CONSTRAINT arbitrer_ibfk_3 FOREIGN KEY (FonctionArbitre) REFERENCES fonction(CodeFct) ON DELETE CASCADE;

ALTER TABLE equipe
  ADD CONSTRAINT equipe_ibfk_1 FOREIGN KEY (CodeClub) REFERENCES club (CodeC) ON DELETE CASCADE,
  ADD CONSTRAINT equipe_ibfk_2 FOREIGN KEY (CodeCateg) REFERENCES categorie (CodeCat) ON DELETE CASCADE;

ALTER TABLE joueur
  ADD CONSTRAINT joueur_ibfk_1 FOREIGN KEY (CodeEquipe) REFERENCES equipe (CodeE) ON DELETE CASCADE,
  ADD CONSTRAINT joueur_ibfk_2 FOREIGN KEY (CodePoste) REFERENCES poste(CodeP) ON DELETE CASCADE;

ALTER TABLE matches
  ADD CONSTRAINT matches_ibfk_1 FOREIGN KEY (CodeEquipe1) REFERENCES equipe (CodeE) ON DELETE CASCADE,
  ADD CONSTRAINT matches_ibfk_2 FOREIGN KEY (CodeEquipe2) REFERENCES equipe (CodeE) ON DELETE CASCADE;
COMMIT;

