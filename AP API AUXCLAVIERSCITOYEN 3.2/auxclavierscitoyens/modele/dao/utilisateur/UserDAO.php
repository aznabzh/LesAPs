<?php

require_once 'modele/dao/DBConnex.php';
require_once 'modele/Token.php';


class UserDAO {

    public static function authentication(string $email, string $password, $secretKey) {

        $preparedQuery = DBConnex::getInstance()->prepare("
            SELECT IDUSER, PASSWORD, EMAIL, NAME
            FROM USER
            WHERE EMAIL = :EMAIL
        ");

        $preparedQuery->bindParam(":EMAIL", $email);
        $preparedQuery->execute();

        $user = $preparedQuery->fetch(PDO::FETCH_ASSOC);

        
        if (!$user || !password_verify($password, $user['PASSWORD'])) {
           return false;
        }

        $jwt = Token::createJWT($user, $secretKey);
            // Retourner les informations du jeton d'accès
            return [
                'access_token' => $jwt,
                'token_type' => 'Bearer',
                'expires_in' => 3600,
                'accessToken' => 'string',
                'expiresIn' => 0
                 
            ];
    }

    /**
     * @param string $email
     * @param string $password
     * @return false|void
     */
    public static function register(string $email, string $password): bool
    {
        // hash du mot de passe
        $password = password_hash($password, PASSWORD_ARGON2ID);

        // verifie si l adresse email existe
        $preparedQuery = DBConnex::getInstance()->prepare("SELECT count(*) FROM user WHERE EMAIL = :email");
        $preparedQuery->bindParam(":email", $email);
        $preparedQuery->execute();

        if ($preparedQuery->fetchColumn() > 0) {
            return false;
        }

        // si l email n existe pas, on crée l utilisateur
        $preparedQuery = DBConnex::getInstance()->prepare("INSERT INTO user (EMAIL, PASSWORD) VALUES (:email, :password)");
        $preparedQuery->bindParam(":email", $email);
        $preparedQuery->bindParam(":password", $password);

        $req = $preparedQuery->execute();
        return $req;
    }

    /**
     * recupere l'utilisateur (token et infos) actuellement authentifié a l aide du token
     *
     * @param string $jwt       jeton de l utilisateur
     * @param string $secretKey clé secrète pour vérifier le JWT
     * @return array|null       Retourne les infos de l utilisateur
     */

    public static function GetCurrentAuthenticatedUser($jwt, $secretKey)
    {
        //découper le jwt en 3 parties : header, payload, signature
        $parts = explode('.', $jwt);
        if (count($parts) !== 3) {
            return null;
        }
        [$headerEncoded, $payloadEncoded, $signature] = $parts;

        //Verif de la signature
        $expectedSignature = Token::base64UrlEncode(
            hash_hmac('sha256', "$headerEncoded.$payloadEncoded", $secretKey, true)
        );

        if (!hash_equals($expectedSignature, $signature)) {
            return null;
        }

        //décoder le payload
        $payload = json_decode(Token::base64UrlDecode($payloadEncoded), true);
        if (!$payload || !isset($payload['user_id'])) {
            return null;
        }

        //verif l expiration du token
        if (isset($payload['exp']) && time() > $payload['exp']) {
            return null;
        }

        //retourner les infos de l utilisateur
        return [
            'id' => $payload['user_id'],
            'email' => $payload['email'],
            'name' => $payload['name'] ?? null,
        ];
    }
    public static function updateUserDetails($id, $email, $name){

        $preparedQuery = DBConnex::getInstance()->prepare("UPDATE user SET EMAIL = :email, NAME = :name WHERE IDUSER = :id");
        $preparedQuery->bindParam(":id", $id);
        $preparedQuery->bindParam(":email", $email);
        $preparedQuery->bindParam(":name", $name);

        $preparedQuery->execute();

        if ($preparedQuery->rowCount() === 0) {

            $checkQuery = DBConnex::getInstance()->prepare("SELECT IDUSER, EMAIL, NAME FROM user WHERE IDUSER = :id");
            $checkQuery->bindParam(":id", $id);
            $checkQuery->execute();
            $user = $checkQuery->fetch(PDO::FETCH_ASSOC);

            if (!$user) {
                http_response_code(404);
                return json_encode(["message" => "User not found"]);
            }
            return json_encode($user);
        }

        $preparedQuery = DBConnex::getInstance()->prepare("SELECT IDUSER, EMAIL, NAME FROM user WHERE IDUSER = :id");
        $preparedQuery->bindParam(":id", $id);
        $preparedQuery->execute();
        $user = $preparedQuery->fetch(PDO::FETCH_ASSOC);

        http_response_code(200);
        return json_encode($user);
    }

    public static function updatePassword($id, $password){

        $preparedQuery = DBConnex::getInstance()->prepare("UPDATE user SET PASSWORD = :password WHERE IDUSER = :id");
        $preparedQuery->bindParam(":id", $id);
        $password = password_hash($password, PASSWORD_ARGON2ID);
        $preparedQuery->bindParam(":password", $password);
        $preparedQuery->execute();
        if ($preparedQuery->rowCount() === 0) {
            http_response_code(404);
            return json_encode(["message" => "User not found"]);
        }

        //Verif de la signature
        $expectedSignature = Token::base64UrlEncode(
            hash_hmac('sha256', "$headerEncoded.$payloadEncoded", $secretKey, true)
        );

        if (!hash_equals($expectedSignature, $signature)) {
            return null;
        }

        //décoder le payload
        $payload = json_decode(Token::base64UrlDecode($payloadEncoded), true);
        if (!$payload || !isset($payload['user_id'])) {
            return null;
        }

        //verif l expiration du token
        if (isset($payload['exp']) && time() > $payload['exp']) {
            return null;
        }

        //retourner les infos de l utilisateur
        return [
            'id' => $payload['user_id'],
            'email' => $payload['email'],
            'name' => $payload['name'] ?? null,
        ];
        http_response_code(200);
        return json_encode(["success" => true]);
    }

    public static function getUserByID($id) {
    $requete = "SELECT IDUSER, EMAIL, NAME
                FROM USER
                WHERE IDUSER = :IDUSER;";
    $res = DBConnex::getInstance()->prepare($requete);
    $res->execute([":IDUSER" => $id]);
    $reponse =  $res->fetchAll(PDO::FETCH_ASSOC);

    return json_encode($reponse);
}
}
?>
