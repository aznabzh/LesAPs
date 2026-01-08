<?php
header('Content-Type: application/json');
require_once 'modele/dao/DBConnex.php';

/**
 * Affiche toutes les équipes d'un tournoi.
 *
 * Cette fonction récupère les équipes pour le tournoi donné.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 *
 * @return  json des informations des équipes
 */
function getTeamsInTournament($tournamentId) {
    $requetePrepa = DBConnex::getInstance()->prepare("SELECT * FROM team WHERE IDTOURNAMENT = :IDtournament" );
    $requetePrepa->execute([":IDtournament" => $tournamentId]);
    $teamsInfo = $requetePrepa->fetchAll(PDO::FETCH_ASSOC);

    return json_encode([ "data" => $teamsInfo]);
}

/**
 * Affiche une équipe précise d'un tournoi.
 *
 * Cette fonction récupère l'équipe pour le tournoi donné.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $teamId         Identifiant de l'équipe.
 *
 * @return  json des informations de cette équipe
 */
function getTeamByIdInTournament($tournamentId, $teamId) {
    $requetePrepa = DBConnex::getInstance()->prepare("SELECT * FROM team WHERE IDTOURNAMENT = :tournamentId AND IDTEAM = :teamId" );
    $requetePrepa->execute([
        ":tournamentId" => $tournamentId,
        ":teamId"    => $teamId
    ]);
    $teamInfo = $requetePrepa->fetchAll(PDO::FETCH_ASSOC);

    if ($teamInfo) {
        http_response_code(200);
        return json_encode([ "data" => $teamInfo]);
    } else {
        http_response_code(404);
        echo json_encode(['error' => 'Team not found']);
    }
}

/**
 * Ajoute une équipe à un tournoi.
 *
 * Cette fonction ajoute une équipe dans la base de données.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $body           Données envoyées par le client :
 *                              - 'name' (varchar) : nom l'équipe à ajouter
 *
 * @return  json des informations de cette équipe
 */
function createTeamInTournament($tournamentId, $body) {
    $insert = DBConnex::getInstance()->prepare("
        INSERT INTO team (NAME, IDTOURNAMENT, POINTS)
        VALUES (:name, :tournamentId, 0)
    ");

    $insert->execute([
        ":name" => $body["name"],
        ":tournamentId" => $tournamentId
    ]);

    $teamId = DBConnex::getInstance()->lastInsertId();
    return getTeamByIdInTournament($tournamentId, $teamId);
}

/**
 * Met à jour l'équipe d'un tournoi.
 *
 * Cette fonction met à jour l'équipe associée au tournoi.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $teamId         Identifiant de l'équipe.
 * @param   $body           Données envoyées par le client :
 *                              - 'name' (varchar) : nom l'équipe à modifier
 *                              - 'point' (int) : point de l'équipe à modifier
 *                              - 'image' (longblob) : image de l'équipe à modifier
 *
 * @return  json des nouvelles informations de cette équipe
 */
function updateTeamInTournament($tournamentId, $teamId, $body) {
    $fields = [];
    $params = [":id" => $tournamentId, ":teamId" => $teamId];

    if (isset($body["name"])) {
        $fields[] = "NAME = :name";
        $params[":name"] = $body["name"];
    }

    if (isset($body["points"])) {
        $fields[] = "POINTS = :points";
        $params[":points"] = $body["points"];
    }

    if (isset($body["image"])) {
        $fields[] = "IMAGE = :image";
        $params[":image"] = $body["image"];
    }

    if (empty($fields)) {
        http_response_code(400);
        return json_encode(["error" => "No fields to update"]);
    }

    $updateTeam = "
        UPDATE TEAM
        SET " . implode(", ", $fields) . "
        WHERE IDTOURNAMENT = :id
        AND IDTEAM = :teamId
    ";

    $requetePrepa = DBConnex::getInstance()->prepare($updateTeam);
    $requetePrepa->execute($params);

    if ($requetePrepa->rowCount() === 0) {
        http_response_code(404);
        return json_encode(["error" => "Team not found"]);
    }

    return getTeamByIdInTournament($tournamentId, $teamId);
}

/**
 * Supprime l'équipe précis d'un tournoi.
 *
 * Cette fonction supprime une équipe dans la base de donnée associée au tournoi.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $teamId         Identifiant de l'équipe.
 *
 * @return  true si la suppression à bien fonctionnée
 */
function deleteTeamInTournament($tournamentId, $teamId) {
    $delete = DBConnex::getInstance()->prepare("
        DELETE FROM team
        WHERE idteam = :teamId
        AND idTournament = :tournamentId
    ");

    $delete->execute([
        ":teamId" => $teamId,
        ":tournamentId" => $tournamentId
    ]);

    if ($delete->rowCount() === 0) {
        http_response_code(404);
        return json_encode(["message" => "Team not found"]);
    }

    http_response_code(200);
    return json_encode(["success" => true]);
}
