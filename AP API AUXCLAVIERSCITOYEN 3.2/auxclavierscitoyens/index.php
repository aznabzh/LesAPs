<?php
header('Content-Type: application/json');

include_once 'modele/Token.php';
require 'modele/dao/tournoi/tournoi.php';
require 'modele/dao/round/round.php';
require 'modele/dao/team/team.php';
require 'modele/dao/match/match.php';
require 'modele/dao/utilisateur/UserDAO.php';
require 'controleur/login.php';


$secretKey = 'my_secret_key_1234';

// Détection automatique du chemin de base du projet
$scriptName = dirname($_SERVER['SCRIPT_NAME']);
$requestUri = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);

$basePath = $scriptName . '/api/v1';
$request = str_replace($basePath, '', $requestUri);

$uri = explode('/', trim($request, '/'));
$method = $_SERVER['REQUEST_METHOD'];

$inputJSON = file_get_contents('php://input');
$input = json_decode($inputJSON, TRUE);

//Si la requete demande un token pour y acceder...
if($request !== '/auth/login' && $request !== '/auth/register'){

    $authHeader = Token::getAuthorizationHeader();
    if (!$authHeader) {
        http_response_code(401);
        echo json_encode(['error' => 'Missing Authorization header']);
        exit;
    }

    $token = preg_replace('/^Bearer\s+/i', '', $authHeader);

    $payload = Token::verifyJWT($token, $secretKey);

    if($payload === false){
        http_response_code(401);
        echo "Invalid or expired token";
        exit;
    }
}

// Endpoints with parameters
if ($method == 'DELETE'){
    if($uri[0] == 'tournaments' && isset($uri[1]) && !isset($uri[2])){
        echo deleteTournament($uri[1]);
    }
    elseif($uri[0]=='tournaments' && $uri[2]=='teams' && !isset($uri[4])){
        echo deleteTeamInTournament($uri[1],$uri[3]);
    }
    
}
// Endpoints with parameters
elseif($method == 'PUT'){
    if($uri[0] == 'users' && $uri[2]=='password' && !isset($uri[3])){
        echo updatePassword($uri[1], $input['password']);
    }
    elseif($uri[0] == 'users' && isset($uri[1]) && !isset($uri[2])){
            echo UserDAO::updateUserDetails($uri[1], $input['email'], $input['name']);
        }
    elseif($uri[0] == 'tournaments' && isset($uri[1]) && !isset($uri[2])){
        echo updateTournoi($uri[1], $input);
    }
    elseif($uri[0]=='tournaments' && $uri[2]=='teams' && !isset($uri[4])){
        echo updateTeamInTournament($uri[1], $uri[3], $input);
    }
    elseif($uri[0]=='tournaments' && $uri[2]=='matches' && $uri[4]=='point' && !isset($uri[5])){
        echo updateMatchPointsInTournament($uri[1], $uri[3], $input);
    }
}
elseif($method == 'POST'){
    // Endpoints without parameters
    switch ($request){
        case '/auth/login':
            echo login($input, $secretKey);;
            break;
        case '/auth/register':
            require __DIR__ . '/controleur/register.php';
            break;
        case '/tournaments':
            $userId = $payload['user_id'];
            echo createTournament($input, $userId);
            break;
        case '/auth/token':
            echo passwordToken($secretKey);
            break;
    }
    // Endpoints with parameters
    if($uri[0]=='tournaments' && $uri[2]=='teams' && !isset($uri[3])){
        echo createTeamInTournament($uri[1], $input);
    }

}
elseif($method == 'GET'){
    // Endpoints without parameters
    switch ($request){
        case '/tournaments':
            echo getTournois();
            break;

        //endpoint pour le get current user
        case '/auth/me';
            require __DIR__ . '/controleur/me.php';
            break;

    }

    // Endpoints with parameters
    if($uri[0] == 'users' && isset($uri[1]) && !isset($uri[2])){
        echo UserDAO::getUserByID($uri[1]);
    }
    elseif($uri[0] == 'tournaments' && isset($uri[1]) && !isset($uri[2])){
        echo getTournoiById($uri[1]);

    }
    elseif($uri[0]=='tournaments' && $uri[2]=='teams' && !isset($uri[3])){
        echo getTeamsInTournament($uri[1]);
    }
    elseif($uri[0]=='tournaments' && $uri[2]=='teams' && !isset($uri[4])){
        echo getTeamByIdInTournament($uri[1], $uri[3]);
    }
    elseif($uri[0]=='tournaments' && $uri[2]=='rounds' && !isset($uri[3])){
        echo getAllRoundsInTournament($uri[1]);
    }
    elseif($uri[0]=='tournaments' && $uri[2]=='rounds' && !isset($uri[4])){
        echo getRoundByIdInTournament($uri[1], $uri[3]);
    }
    elseif($uri[0]=='tournaments' && $uri[2]=='matches' && !isset($uri[3])){
        echo getMatchesInTournament($uri[1]);
    }
    elseif($uri[0]=='tournaments' && $uri[2]=='matches' && !isset($uri[4])){
        echo getMatchByIdInTournament($uri[1], $uri[3]);
    }
}
