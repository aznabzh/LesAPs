CREATE DATABASE `gsb`;

USE `gsb`;

CREATE TABLE IF NOT EXISTS `fichefrais` (
  `idFiche` int(11) NOT NULL,
  `idUtilisateur` char(4) NOT NULL,
  `mois` int(2) NOT NULL,
  `annee` int(4) NOT NULL,
  `dateCreation` date NOT NULL,
  `dateCloture` date DEFAULT NULL,
  `idEtat` varchar(2) NOT NULL DEFAULT 'EC',
  `montantDeclare` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `lignefrais` (
  `idFiche` int(11) NOT NULL,
  `idTypeFrais` char(3) NOT NULL,
  `quantiteDeclaree` int(11) DEFAULT NULL,
  `quantiteValidee` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `typefrais` (
  `id` char(3) NOT NULL,
  `libelle` char(20) NOT NULL,
  `montant` decimal(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `typefrais` (`id`, `libelle`, `montant`) VALUES
('ETP', 'Forfait Etape', '110.00'),
('KM', 'Frais Km', '0.70'),
('NUI', 'Nuitée Hôtel', '80.00'),
('REP', 'Repas Restaurant', '25.00');

CREATE TABLE IF NOT EXISTS `utilisateur` (
  `id` char(4) NOT NULL,
  `nom` char(30) DEFAULT NULL,
  `prenom` char(30) DEFAULT NULL,
  `login` char(20) DEFAULT NULL,
  `mdp` char(20) DEFAULT NULL,
  `statut` varchar(10) NOT NULL,
  `adresse` char(30) DEFAULT NULL,
  `cp` char(5) DEFAULT NULL,
  `ville` char(30) DEFAULT NULL,
  `dateEmbauche` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `utilisateur` (`id`, `nom`, `prenom`, `login`, `mdp`, `statut`, `adresse`, `cp`, `ville`, `dateEmbauche`) VALUES
('a1', 'Grossous', 'Monique', 'compta', '12345', 'comptable', '35 avenue de la monnaie', '33000', 'Bordeaux', '2014-06-11'),
('a131', 'Treize', 'Louis', 'ltreize', '54321', 'gestion', '8 rue des Charmes', '46000', 'Cahors', '2005-12-21'),
('a17', 'Andre', 'David', 'dandre', 'azerty', 'visiteur', '1 rue Petit', '46200', 'Lalbenque', '1998-11-23'),
('f21', 'Finck', 'Jacques', 'jfinck', 'mpb3t', 'visiteur', '10 avenue du Prado', '13002', 'Marseille', '2001-11-10'),
('f39', 'Frémont', 'Fernande', 'ffremont', 'xs5tq', 'visiteur', '4 route de la mer', '13012', 'Allauh', '1998-10-01'),
('f4', 'Gest', 'Alain', 'agest', 'dywvt', 'visiteur', '30 avenue de la mer', '13025', 'Berre', '1995-11-01');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `fichefrais`
--
ALTER TABLE `fichefrais`
  ADD PRIMARY KEY (`idFiche`),
  ADD KEY `idUtilisateur` (`idUtilisateur`);

--
-- Index pour la table `lignefrais`
--
ALTER TABLE `lignefrais`
  ADD PRIMARY KEY (`idFiche`,`idTypeFrais`),
  ADD KEY `idTypeFrais` (`idTypeFrais`);

--
-- Index pour la table `typefrais`
--
ALTER TABLE `typefrais`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `fichefrais`
--
ALTER TABLE `fichefrais`
  MODIFY `idFiche` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;
