<?php
header('Content-Type: application/json');
require_once 'modele/dao/DBConnex.php';

/**
 * Récupère les id des matchs d'un round.
 *
 * Cette fonction récupère id des matchs pour leurs participations au match du tournoi.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $roundId        Identifiant du round.
 *
 * @return  tableau des id de match
 */
function getIdMatchsForRound($tournamentId, $roundId){
    $requetePrepaMatchsForRound = DBConnex::getInstance()->prepare("SELECT IDMATCHS FROM matchs WHERE IDtournament = :tournamentId AND IDROUND = :roundId" );
    $requetePrepaMatchsForRound->execute([
        ":tournamentId" => $tournamentId,
        ":roundId"    => $roundId
    ]);
    $matchsForRoundInfo = $requetePrepaMatchsForRound->fetchAll(PDO::FETCH_ASSOC);
    return $matchsForRoundInfo;
}

/**
 * Affiche tous les rounds d'un tournoi.
 *
 * Cette fonction récupère les rounds pour le tournoi donné,
 * vérifie les ids de matchs qui correspondent à chaque round,
 * puis ajoute les id des matchs concernés par chaque round.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 *
 * @return  json des informations de ce match
 */
function getAllRoundsInTournament($tournamentId) {
    $requetePrepa = DBConnex::getInstance()->prepare("SELECT * FROM round WHERE IDtournament = :tournamentId" );
    $requetePrepa->execute([":tournamentId" => $tournamentId]);

    $roundsInfo = $requetePrepa->fetchAll(PDO::FETCH_ASSOC);

    foreach ($roundsInfo as &$round){
        $roundId = $round["IDROUND"];
        $match = getIdMatchsForRound($tournamentId, $roundId);
        $round['matchIds'] = $match;
    }

    return json_encode([ "data" => $roundsInfo]);
}

/**
 * Affiche le round précis d'un tournoi.
 *
 * Cette fonction récupère le round pour le tournoi donné,
 * puis récupère les informations des matchs correspondants au round,
 * et ajoute les id des matchs concernés par ce round.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $roundId        Identifiant du round.
 *
 * @return  json des informations de ce match
 */
function getRoundByIdInTournament($tournamentId, $roundId) {
    $requetePrepaRound = DBConnex::getInstance()->prepare("SELECT * FROM round WHERE IDtournament = :tournamentId AND IDROUND = :roundId" );
    $requetePrepaRound->execute([
        ":tournamentId" => $tournamentId,
        ":roundId"    => $roundId
    ]);
    $roundInfo = $requetePrepaRound->fetch(PDO::FETCH_ASSOC);

    $matchsForRoundInfo = getIdMatchsForRound($tournamentId, $roundId);
    
    $roundInfo["matchIds"] = $matchsForRoundInfo;

    if ($roundInfo) {
        http_response_code(200);
        return json_encode([ "data" => $roundInfo]);
    } else {
        http_response_code(404);
        echo json_encode(['error' => 'Round not found']);
    }
}

