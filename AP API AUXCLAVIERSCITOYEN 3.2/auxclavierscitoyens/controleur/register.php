<?php


$secretKey = 'my_secret_key_1234';

$inputJSON = file_get_contents('php://input');
$input = json_decode($inputJSON, TRUE);

if (!isset($input['email'], $input['password'])) {
    http_response_code(400);
    header('Content-Type: application/json');
    echo json_encode(['message' => 'Données incomplètes']);
    exit;
}

$email = $input['email'];
$password = $input['password'];

if (!UserDAO::register($email, $password)) {
    http_response_code(409);
    header('Content-Type: application/json');
    echo json_encode(['message' => 'Email déjà utilisé']);
    exit;
}

$response = UserDAO::authentication($email, $password, $secretKey);

if ($response) {
    http_response_code(201);
    header('Content-Type: application/json');
    echo json_encode($response);
    exit;
}

http_response_code(500);
header('Content-Type: application/json');
echo json_encode(['message' => 'Utilisateur créé mais authentification impossible']);
exit;
?>