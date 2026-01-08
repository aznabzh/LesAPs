<?php


require_once __DIR__ . '/../modele/dao/utilisateur/UserDAO.php';


function login($input, $secretKey){

    if (!isset($input['email'], $input['password'])) {
        http_response_code(400);
        echo json_encode(["error" => "Email and password required"]);
        exit;
    }

    $email = $input['email'];
    $password = $input['password'];

    $response = UserDAO::authentication($email, $password, $secretKey);

    if ($response) {
        echo json_encode($response);
    } else {
        http_response_code(401);
        echo json_encode(["message" => "Invalid credentials"]);
    }
}

function passwordToken($secretKey) {

    $email = $_POST['username'] ?? null;
    $password = $_POST['password'] ?? null;

    if (!$email || !$password) {
        http_response_code(400);
        echo json_encode(["error" => "username and password required"]);
        exit;
    }
    $tokenData = UserDAO::authentication($email, $password, $secretKey);

    if ($tokenData) {
        echo json_encode([
            "access_token" => $tokenData["access_token"],
            "token_type"   => $tokenData["token_type"] ?? "Bearer",
            "expires_in"   => $tokenData["expires_in"] ?? 3600
        ]);
    } else {
        http_response_code(400);
        echo json_encode(["error" => "Invalid credentials"]);
    }
}

