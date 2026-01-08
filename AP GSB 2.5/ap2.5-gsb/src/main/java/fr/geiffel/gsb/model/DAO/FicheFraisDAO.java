package fr.geiffel.gsb.model.DAO;


import fr.geiffel.gsb.model.DBConnex;
import fr.geiffel.gsb.model.metier.FicheFrais;
import fr.geiffel.gsb.model.metier.LigneFrais;
import fr.geiffel.gsb.model.metier.Utilisateur;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class FicheFraisDAO {
	
	/**
	 * M�thode permettant de r�cup�rer les fiches de frais
	 * @return ResultSet (la liste des fiches de frais
	 */
	 public static List<FicheFrais> allFichesFrais()
     {
		 List<FicheFrais> lesFiches = new ArrayList<>();
		 String requete = """
						SELECT idFiche, mois, annee, dateCreation,
							dateCloture, idEtat, montantDeclare, idUtilisateur
						FROM fichefrais 
						ORDER BY annee DESC , mois DESC """;
		 try(Connection conn = DBConnex.getConnection();
             PreparedStatement stmt = conn.prepareStatement(requete);
             ResultSet rs = stmt.executeQuery();){

			 Map<Integer, List<LigneFrais>> lesLignesFraisByIdFiche = LigneFraisDAO.allLignesFraisByIdFicheFrais();
			 var lesUtilisateur = UtilisateurDAO.allUtilisateursOwningFicheFrais();
			 while(rs.next()) {
				 Utilisateur utilisateur = lesUtilisateur.get(rs.getString("idUtilisateur"));
				 FicheFrais fiche = new FicheFrais(rs.getInt("idFiche"), rs.getInt("mois"),
						 rs.getInt("annee"), rs.getDate("dateCreation"),
						 rs.getDate("dateCloture"), rs.getString("idEtat"),
						 rs.getFloat("montantDeclare"), utilisateur);
				 fiche.setLesLignesFrais(lesLignesFraisByIdFiche.get(fiche.getId()));
				 utilisateur.addFicheFrais(fiche);
				 lesFiches.add(fiche);
			 }
		 } catch (SQLException e) {
			 System.out.println(e.getMessage());
		 }
		 return lesFiches;
     }

	public static List<FicheFrais> lesFichesFraisOfUtilisateur(Utilisateur utilisateur) {
		List<FicheFrais> lesFiches = new ArrayList<>();
		String requete = """
						SELECT idFiche, mois, annee, dateCreation,
							dateCloture, idEtat, montantDeclare
						FROM fichefrais
						WHERE idUtilisateur=?
						ORDER BY annee DESC , mois DESC """;
		try(Connection conn = DBConnex.getConnection();
			PreparedStatement stmt = conn.prepareStatement(requete)){
			stmt.setString(1, utilisateur.getId());
			ResultSet rs = stmt.executeQuery();

			Map<Integer, List<LigneFrais>> lesLignesFraisByIdFiche = LigneFraisDAO.allLignesFraisByIdFicheFrais();
			while(rs.next()) {
				FicheFrais fiche = new FicheFrais(rs.getInt("idFiche"), rs.getInt("mois"),
						rs.getInt("annee"), rs.getDate("dateCreation"),
						rs.getDate("dateCloture"), rs.getString("idEtat"),
						rs.getFloat("montantDeclare"), utilisateur);
				fiche.setLesLignesFrais(lesLignesFraisByIdFiche.get(fiche.getId()));
				lesFiches.add(fiche);
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		utilisateur.setFicheFrais(lesFiches);
		return lesFiches;
	}

	/**
	 * Méthode permettant de modifier l'état d'une fiche de frais
	 * @param unIdFiche id de la fiche à modifier
	 * @param nouvelEtat nouvel état à affecter
	 * @return true si l'opération a fonctionné, false sinon
	 */
	 public static boolean changerEtat(int unIdFiche , String nouvelEtat)
     {
		 boolean reussi = false;
	     String requete = """
					UPDATE fichefrais
					SET idEtat=?
					WHERE idFiche=?""";
		 try(Connection conn = DBConnex.getConnection();
		 	PreparedStatement stmt = conn.prepareStatement(requete);) {
			 stmt.setString(1, nouvelEtat);
			 stmt.setInt(2, unIdFiche);
			 reussi = stmt.execute();
		 } catch (SQLException e) {
			 System.out.println(e.getMessage());
		 }
         return reussi;
     }
	 
	 
	 public static boolean changerQuantiteValidee(int unIdFiche , int quantite , String typeFrais)
     {
		 boolean reussi = false;
		 String requete = """
				 UPDATE lignefrais
				 SET quantiteValidee=?
				 WHERE idFiche=?
				 AND idTypeFrais=?""";
		 try(Connection conn = DBConnex.getConnection();
			 PreparedStatement stmt = conn.prepareStatement(requete);) {
			 stmt.setInt(1, quantite);
			 stmt.setInt(2, unIdFiche);
			 stmt.setString(3, typeFrais);
			 reussi = stmt.execute();
		 } catch (SQLException e) {
			 System.out.println(e.getMessage());
		 }
		 return reussi;
     }



}
