<?php


class Token {

    // encoder en base64Url
    public static function base64UrlEncode($data) {
        return rtrim(strtr(base64_encode($data), '+/', '-_'), '=');
    }

    // décoder en base64Url
    public static function base64UrlDecode($data) {
        $remainder = strlen($data) % 4;
        if ($remainder) {
            $padlen = 4 - $remainder;
            $data .= str_repeat('=', $padlen);
        }
        return base64_decode(strtr($data, '-_', '+/'));
    }

    //Header du JWT 
    public static function createJWTHeader() {
        $header = [
            'alg' => 'HS256',
            'typ' => 'JWT'
        ];
        return Token::base64UrlEncode(json_encode($header));
    }

    // créer le Payload
    public static function createJWTPayload($user) {
        $issuedAt = time();
        $expirationTime = $issuedAt + 3600;

        // LA PAYLOAD CONTIENT LES INFOS DE L'USISATEUR
        $payload = [
            'iat' => $issuedAt,
            'exp' => $expirationTime,
            'user_id' => $user['IDUSER'],
            'email' => $user['EMAIL']
        ];

        // Retourner le payload en base64Url
        return Token::base64UrlEncode(json_encode($payload));
    }

    // créer la signature du JWT
    public static function createJWTSignature($header, $payload, $secretKey) {
        $data = $header . '.' . $payload; // Combinaison de l'en-tête et de la charge utile
        return Token::base64UrlEncode(hash_hmac('sha256', $data, $secretKey, true)); // Signature avec la clé secrète
    }

    // créer le JWT complet
    public static function createJWT($user, $secretKey) {
        // Générer header, payload et signature
        $header = Token::createJWTHeader();
        $payload = Token::createJWTPayload($user);
        $signature = Token::createJWTSignature($header, $payload, $secretKey);

        // Retourner le JWT  header.payload.signature
        return $header . '.' . $payload . '.' . $signature;
    }

    public static function verifyJWT($jwt, $secretKey) {
        // on sépare le token entre le header, payload et signature
        $parts = explode('.', $jwt);
        if (count($parts) !== 3) {
            return false; // format invalide 
        }
    
        list($encodedHeader, $encodedPayload, $encodedSignature) = $parts;
    
        //on recalcule la sinature
        $expectedSignature = Token::createJWTSignature($encodedHeader, $encodedPayload, $secretKey);
    
        //comparaison des signatures
        if (!hash_equals($expectedSignature, $encodedSignature)) {
            return false; // la signature ne correspond pas
        }
    
        $header  = json_decode(Token::base64UrlDecode($encodedHeader), true);
        $payload = json_decode(Token::base64UrlDecode($encodedPayload), true);

        if (!isset($header['alg']) || $header['alg'] !== 'HS256') {
            return false;
        }
        if (!isset($payload['exp']) || $payload['exp'] < time()) {
            return false;
        }
    
        return $payload;
    }

    public static function getAuthorizationHeader() {
    if (isset($_SERVER['HTTP_AUTHORIZATION'])) {
        return $_SERVER['HTTP_AUTHORIZATION'];
    }
    if (isset($_SERVER['REDIRECT_HTTP_AUTHORIZATION'])) {
        return $_SERVER['REDIRECT_HTTP_AUTHORIZATION'];
    }
    return null;
}
}
?>
