<?php

require_once __DIR__ . '/../modele/dao/utilisateur/UserDAO.php';
require_once __DIR__ . '/../modele/Token.php';

$secretKey = 'my_secret_key_1234';

//récupérer et verifier l existence du header authorization
$headers = getallheaders();
if (!isset($headers['Authorization'])) {
    http_response_code(401);
    echo json_encode(['error' => 'jeton manquant']);
    exit;
}

//verifier que le header commence bien par Bearer, puis le jeton
if (!preg_match('/Bearer\s(\S+)/', $headers['Authorization'], $matches)) {
    http_response_code(401);
    echo json_encode(['error' => 'format du jeton invalide']);
    exit;
}

$jwt = $matches[1];

//fonction dao
$response = UserDAO::GetCurrentAuthenticatedUser($jwt, $secretKey);

if (!$response) {
    http_response_code(401);
    echo json_encode(['error' => 'jeton invalide ou expiré']);
    exit;
}

echo json_encode(['data' => $response]);
