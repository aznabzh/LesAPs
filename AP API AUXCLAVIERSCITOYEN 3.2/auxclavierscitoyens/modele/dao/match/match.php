<?php
header('Content-Type: application/json');
require_once 'modele/dao/DBConnex.php';

/**
 * Récupère le numéro d'équipe des teams d'un match.
 *
 * Cette fonction récupère id et le numéro des équipes pour leurs participations au match du tournoi,
 * vérifie les numéros qui correspond à l'id de la team1 et de la team2,
 * puis ajoute les id des teams à leurs numéros de teams pour le match.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $matchId        Identifiant du match.
 *
 * @return  tableau des id pour le numéro de team
 */
function getNumTeamsForMatch($tournamentId, $matchId){
    $requetePrepaTeams = DBConnex::getInstance()->prepare(
        "SELECT IDTEAM, NUMTEAM
         FROM participate
         WHERE IDTOURNAMENT = :tournamentId
         AND IDMATCHS = :matchId"
    );
    $requetePrepaTeams->execute([
        ":tournamentId" => $tournamentId,
        ":matchId"      => $matchId
    ]);
    $teamsInfo = $requetePrepaTeams->fetchAll(PDO::FETCH_ASSOC);

    $team1Id = $team2Id = null;
    foreach ($teamsInfo as $team) {
        if ($team["NUMTEAM"] == 1) {
            $team1Id = $team["IDTEAM"];
        }
        if ($team["NUMTEAM"] == 2) {
            $team2Id = $team["IDTEAM"];
        }
    }
    return [ 
        "team1Id" =>  $team1Id,
        "team2Id" => $team2Id
    ];
}

/**
 * Affiche tous les matchs d'un tournoi.
 *
 * Cette fonction récupère les matchs pour le tournoi donné,
 * vérifie les équipes qui correspond à team1 ou team2 pour chaque match,
 * puis ajoute les équipes concernées aux informations de chaque match.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 *
 * @return  json des informations de ce match
 */
function getMatchesInTournament($tournamentId) {

    $requetePrepa = DBConnex::getInstance()->prepare(
        "SELECT * FROM matchs WHERE idtournament = :tournamentId"
    );
    $requetePrepa->execute([":tournamentId" => $tournamentId]);

    $matchesInfo = $requetePrepa->fetchAll(PDO::FETCH_ASSOC);

    foreach ($matchesInfo as &$match){
        $matchId = $match["IDMATCHS"];
        $teams = getNumTeamsForMatch($tournamentId, $matchId);
        $match = array_merge($match, $teams);
    }

    return json_encode(["data" => $matchesInfo]);
}

/**
 * Affiche le match précis d'un tournoi.
 *
 * Cette fonction récupère le match pour le tournoi donné,
 * vérifie les équipes qui correspond à team1 ou team2,
 * puis ajoute les équipes aux informations du match.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $matchId        Identifiant du match.
 *
 * @return  json des informations de ce match
 */
function getMatchByIdInTournament($tournamentId, $matchId) {
    $requetePrepaMatch = DBConnex::getInstance()->prepare(
        "SELECT *
         FROM matchs
         WHERE IDTOURNAMENT = :tournamentId
         AND IDMATCHS = :matchId"
    );
    $requetePrepaMatch->execute([
        ":tournamentId" => $tournamentId,
        ":matchId"      => $matchId
    ]);
    $matchInfo = $requetePrepaMatch->fetch(PDO::FETCH_ASSOC);

    $teams = getNumTeamsForMatch($tournamentId, $matchId);
    $matchInfo = array_merge($matchInfo, $teams);
    if (!$matchInfo) {
        http_response_code(404);
        return json_encode(["error" => "Match not found"]);
    }else{
        http_response_code(200);
        return json_encode(["data" => [$matchInfo]]);
    }
}

/**
 * Met à jour le score d'une équipe dans un match d'un tournoi.
 *
 * Cette fonction récupère les deux équipes associées au match,
 * vérifie si l'équipe envoyée dans la requête correspond à team1 ou team2,
 * puis met à jour le score approprié dans la table `matchs`.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $matchId        Identifiant du match.
 * @param   $body           Données envoyées par le client :
 *                              - 'teamId' (int) : ID de l'équipe à mettre à jour
 *                              - 'teamPoint' (int) : Nouveau score de l'équipe
 *
 * @return  true si la mise à jour à bien fonctionnée
 */
function updateMatchPointsInTournament($tournamentId, $matchId, $body) {
    $teams = getNumTeamsForMatch($tournamentId, $matchId);
    if($body["teamId"] == $teams["team1Id"]){
        $update = DBConnex::getInstance()->prepare("
            UPDATE matchs
            SET SCORETEAM1 = :teamPoint 
            WHERE IDMATCHS = :matchId
            AND idtournament = :tournamentId
         ");
        $update->execute([
        ":teamPoint"    => $body["teamPoint"],
        ":matchId"      => $matchId,
        ":tournamentId" => $tournamentId
        ]);
    }
    if($body["teamId"] == $teams["team2Id"]){
        $update = DBConnex::getInstance()->prepare("
            UPDATE matchs
            SET SCORETEAM2 = :teamPoint 
            WHERE IDMATCHS = :matchId
            AND idtournament = :tournamentId
        ");
        $update->execute([
        ":teamPoint"    => $body["teamPoint"],
        ":matchId"      => $matchId,
        ":tournamentId" => $tournamentId
        ]);
    }
    
    if ($update->rowCount() === 0) {
        http_response_code(404);
        return json_encode(["message" => "Match not found"]);
    }

    http_response_code(200);
    return json_encode(["success" => true]);
}