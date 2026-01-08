package fr.geiffel.gsb.model;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import io.github.cdimascio.dotenv.*;

public class DBConnex {

    private static Dotenv dotenv = Dotenv.load();
    private static final String DB_HOST = dotenv.get("DB_HOST") != null ? dotenv.get("DB_HOST") : "127.0.01";
    private static final String DB_PORT = dotenv.get("DB_PORT") != null ? dotenv.get("DB_PORT") : "3306";
    private static final String DB_NAME = dotenv.get("DB_NAME") != null ? dotenv.get("DB_NAME") : "gsb";
    private static final String DB_USER = dotenv.get("DB_USER") != null ? dotenv.get("DB_USER") : "root";
    private static final String DB_PASSWORD = dotenv.get("DB_PASSWORD") != null ? dotenv.get("DB_PASSWORD") : "";
    private static String URL = "jdbc:mysql://%s:%s/%s".formatted(DB_HOST,
                                                                DB_PORT,
                                                                DB_NAME);
    public static Connection getConnection() throws SQLException {
        return DriverManager.getConnection(URL, DB_USER, DB_PASSWORD);
    }
}

/* MISSION 2
if (fiche.getEtat() == Etat.cloturee){
    fiche.valider() ;
} else {
desactiver le btn valider de l'interface
}
+ message box









*/