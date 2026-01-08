package fr.geiffel.gsb.model.DAO;

import fr.geiffel.gsb.model.DBConnex;
import fr.geiffel.gsb.model.metier.Utilisateur;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.*;

public class UtilisateurDAO {

	public static List<Utilisateur> allUtilisateurs() {
		List<Utilisateur> lesUtilisateurs = new ArrayList<>();
		String query = """
                SELECT id , nom , prenom, login,
                    statut, adresse, cp, ville,
                    dateEmbauche
                FROM utilisateur""";
		try (Connection conn = DBConnex.getConnection();
             PreparedStatement stmt = conn.prepareStatement(query);
             ResultSet rs = stmt.executeQuery()) {
			while(rs.next()) {
				Utilisateur utilisateur = new Utilisateur(rs.getString("id"), rs.getString("nom"),
						rs.getString("prenom"), rs.getString("login"),
						rs.getString("statut"), rs.getString("adresse"),
						rs.getString("cp"), rs.getString("ville"),
						rs.getDate("dateEmbauche"));
				lesUtilisateurs.add(utilisateur);
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		return lesUtilisateurs;
	}

	public static Map<String, Utilisateur> allUtilisateursOwningFicheFrais() {
		Map<String, Utilisateur> lesUtilisateurs = new HashMap<>();
		String query = """
                SELECT id , nom , prenom, login,
                    statut, adresse, cp, ville,
                    dateEmbauche
                FROM utilisateur, fichefrais
                WHERE fichefrais.idUtilisateur = utilisateur.id""";

		try (Connection conn = DBConnex.getConnection();
			 PreparedStatement stmt = conn.prepareStatement(query);
			 ResultSet rs = stmt.executeQuery()) {
			while(rs.next()) {
				Utilisateur utilisateur = new Utilisateur(rs.getString("id"), rs.getString("nom"),
						rs.getString("prenom"), rs.getString("login"),
						rs.getString("statut"), rs.getString("adresse"),
						rs.getString("cp"), rs.getString("ville"),
						rs.getDate("dateEmbauche"));
				lesUtilisateurs.put(utilisateur.getId(), utilisateur);
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		return lesUtilisateurs;
	}
	
	/**
	 * Métode permettant de récupérer les informations relatives à un utilisateur
	 * @param id (id utilidsateur)
	 * @return Un optional qui contient l'utilisateur s'il existe, ou empty() sinon
	 */
	public static Optional<Utilisateur> getUtilisateurById(String id)
     {
		 Utilisateur utilisateur = null;
		 String query = """
					SELECT id , nom , prenom, login, 
						statut, adresse, cp, ville,
						dateEmbauche 
					FROM utilisateur
					WHERE id = ?""";
		 try (Connection conn = DBConnex.getConnection();
			  PreparedStatement stmt = conn.prepareStatement(query)) {
			 stmt.setString(1, id);
			 ResultSet rs = stmt.executeQuery();

			 while(rs.next()) {
				 utilisateur = new Utilisateur(rs.getString("id"), rs.getString("nom"),
						 rs.getString("prenom"), rs.getString("login"),
						 rs.getString("statut"), rs.getString("adresse"),
						 rs.getString("cp"), rs.getString("ville"),
						 rs.getDate("dateEmbauche"));
			 }
		 } catch (SQLException e) {
			 System.out.println(e.getMessage());
		 }
		 return Optional.ofNullable(utilisateur);
     }
}
