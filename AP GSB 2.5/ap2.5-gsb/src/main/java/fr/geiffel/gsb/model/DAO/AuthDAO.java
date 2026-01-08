package fr.geiffel.gsb.model.DAO;

import fr.geiffel.gsb.model.DBConnex;
import fr.geiffel.gsb.model.metier.Utilisateur;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Optional;

/**
 * Classe DAO contenant des méthodes pour faciliter l'authentification
 * des utilisateurs
 */
public class AuthDAO {

    /**
     * Méthode d'authentification d'un utilisateur
     * @param login
     * @param mdp
     * @return Optionnal
     */
    public static Optional<Utilisateur> authentification(String login , String mdp) {
        Utilisateur utilisateur = null;
        String query = """
                SELECT id , nom , prenom, login,
                    statut, adresse, cp, ville,
                    dateEmbauche
                FROM utilisateur
                WHERE login = ? and mdp = ?""";
        try (Connection conn = DBConnex.getConnection();
             PreparedStatement stmt = conn.prepareStatement(query)) {
            stmt.setString(1, login);
            stmt.setString(2, mdp);
            ResultSet rs = stmt.executeQuery();

            while(rs.next()) {
                utilisateur = new Utilisateur(rs.getString("id"), rs.getString("nom"),
                        rs.getString("prenom"), rs.getString("login"),
                        rs.getString("statut"), rs.getString("adresse"),
                        rs.getString("cp"), rs.getString("ville"),
                        rs.getDate("dateEmbauche"));
            }
        } catch (SQLException e) {
            e.printStackTrace();
            System.out.println(e.getMessage());
        }
        return Optional.ofNullable(utilisateur);
    }
}
