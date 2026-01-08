<?php
require_once 'modele/dao/DBConnex.php';
header('Content-Type: application/json');


/**
 * Affiche tous les tournois.
 *
 * Cette fonction récupère tous les tournois présents dans la base de données.
 *
 * @return  json des informations des tournois
 */
function getTournois()
{
    $requetePrepa = DBConnex::getInstance()->prepare("SELECT * FROM tournament");
    $requetePrepa->execute();
    $infoTournois = $requetePrepa->fetchAll(PDO::FETCH_ASSOC);

    if ($infoTournois) {
        http_response_code(200);
        return json_encode(["data", $infoTournois]);
    } else {
        http_response_code(404);
    }
}

/**
 * Affiche un tournoi précis.
 *
 * Cette fonction récupère le tournoi pour l'id donné.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 *
 * @return  json des informations de ce tournoi
 */
function getTournoiById($tournamentId)
{
    $requetePrepa = DBConnex::getInstance()->prepare("SELECT * FROM tournament WHERE IDTOURNAMENT = :idtournament");
    $requetePrepa->execute([":idtournament" => $tournamentId]);
    $infoTournoi = $requetePrepa->fetchAll(PDO::FETCH_ASSOC);
    if ($infoTournoi) {
        http_response_code(200);
        return json_encode($infoTournoi);
    } else {
        http_response_code(404);
        echo json_encode(['error' => 'Tournament not found']);
    }

}

/**
 * Ajoute un tournoi.
 *
 * Cette fonction ajoute un tournoi dans la base de données,
 * vérifie s'il y a assez d'équipes à participer,
 * et ajoute le jeux s'il n'existe pas déjà.
 *
 * @param   $userId         Identifiant de l'utilisateur qui fait l'ajout.
 * @param   $body           Données envoyées par le client :
 *                              - 'name' (varchar) : nom du tournoi à ajouter
 *                              - 'game' (varchar) : nom du jeux à ajouter
 *                              - 'teamCount' (varchar) : nombre d'équipes à participer
 *
 * @return  json des informations du tournoi
 */
function createTournament($body, $userId){
    if ($body["teamCount"] < 2) {
        http_response_code(400);
        return json_encode(["message" => "teamCount must be >= 2"]);
    }

    $db = DBConnex::getInstance();
    $gameName = trim($body["game"]);

    $checkGame = $db->prepare("
        SELECT idGame 
        FROM game 
        WHERE name = :game
    ");
    $checkGame->execute([":game" => $gameName]);
    $game = $checkGame->fetch(PDO::FETCH_ASSOC);
    if ($game) {
        $gameId = $game["idGame"];
    } else {
        $insertGame = $db->prepare("
            INSERT INTO game (NAME)
            VALUES (:game)
        ");
        $insertGame->execute([":game" => $gameName]);

        $gameId = $db->lastInsertId();
    }

    $insertTournament = $db->prepare("
        INSERT INTO tournament (name, idGame, idUser, status)
        VALUES (:name, :idGame, $userId ,'pending')
    ");
    $insertTournament->execute([
        ":name" => $body["name"],
        ":idGame" => $gameId,
    ]);
    $tournamentId = $db->lastInsertId();

    http_response_code(201);
    return json_encode([
        "data" => [
            "id" => $tournamentId,
            "name" => $body["name"],
            "game" => $gameName,
            "status" => "pending"
        ]
    ]);
}

/**
 * Met à jour un tournoi.
 *
 * Cette fonction met à jour un tournoi dans la base de données,
 * vérifie s'il jeux existe déjà autrement il est créé s'il est modifié,
 * puis vérifie le statut s'il y a un changement pour mettre à jour les dates en conséquence.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 * @param   $body           Données envoyées par le client :
 *                              - 'name' (varchar) : nom du tournoi à modifier
 *                              - 'game' (varchar) : nom du jeux à modifier
 *                              - 'winner' (varchar) : nom l'équipes gagnante à modifier
 *                              - 'status' (varchar) : status du tournoi à modifier
 *
 * @return  json des nouvelles informations du tournoi
 */
function updateTournoi($tournamentId, $body){
    $fields = [];
    $params = [":id" => $tournamentId];

    if (isset($body["name"])) {
        $fields[] = "NAME = :name";
        $params[":name"] = $body["name"];
    }
    if (isset($body["game"])) {
        $fields[] = "IDGAME = :game";
        $params[":game"] = $body["game"];
    }
    if (isset($body["winner"])) {
        $fields[] = "WINNER = :winner";
        $params[":winner"] = $body["winner"];
    }
    if (isset($body["status"])) {
        $fields[] = "STATUS = :status";
        $params[":status"] = $body["status"];
        $status = strtolower($body["status"]);

        if ($status === "en cours" || $status === "in progress") {
            $fields[] = "dateStart = NOW()";
        }
        if ($status === "finish" || $status === "terminé") {
            $fields[] = "dateEnd = NOW()";
        }
    }
    if (empty($fields)) {
        http_response_code(400);
        return json_encode(["error" => "No fields to update"]);
    }

    $updateTournament = "
        UPDATE tournament
        SET " . implode(", ", $fields) . "
        WHERE IDTOURNAMENT = :id
    ";
    $requetePrepa = DBConnex::getInstance()->prepare($updateTournament);
    $requetePrepa->execute($params);

    if ($requetePrepa->rowCount() === 0) {
        http_response_code(404);
        return json_encode(["error" => "Tournament not found"]);
    }
    return getTournoiById($tournamentId);
}

/**
 * Supprime un tournoi précis.
 *
 * Cette fonction supprime un tournoi dans la base de donnée.
 *
 * @param   $tournamentId   Identifiant du tournoi.
 *
 * @return  true si la suppression à bien fonctionnée
 */
function deleteTournament($tournamentId)
{
    $delete = DBConnex::getInstance()->prepare("
    DELETE FROM tournament
    WHERE IDTOURNAMENT = :tournamentId
");
    $delete->execute([":tournamentId" => $tournamentId]);

    if ($delete->rowCount() === 0) {
        http_response_code(404);
        return json_encode(["error" => "Tournament not found"]);
    }

    http_response_code(200);
    return json_encode(["success" => true]);
}




    
