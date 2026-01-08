package fr.geiffel.gsb.model.DAO;

import fr.geiffel.gsb.model.DBConnex;
import fr.geiffel.gsb.model.metier.TypeFrais;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class TypeFraisDAO {

	/**
	 * Méthode permettant de récupérer les informations de tous les TypeFrais
	 * @return la liste de tous les TypeFrais
	 */
	public static List<TypeFrais> allTypesFrais() {
		List<TypeFrais> lesTypesFrais = new ArrayList<>();
		String query = """
				SELECT id, libelle, montant
				FROM typefrais""";
		try(Connection conn = DBConnex.getConnection();
            PreparedStatement stmt = conn.prepareStatement(query);
            ResultSet rs = stmt.executeQuery()) {

			while (rs.next()) {
				TypeFrais typeFrais = new TypeFrais(rs.getString("id"),
						rs.getString("libelle"), rs.getInt("montant"));
				lesTypesFrais.add(typeFrais);
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		return lesTypesFrais;
	}

	public static Map<String, TypeFrais> allTypeFrais() {
		Map<String, TypeFrais> lesTypesFrais = new HashMap<>();
		String query = """
				SELECT id, libelle, montant
				FROM typefrais""";
		try(Connection conn = DBConnex.getConnection();
			PreparedStatement stmt = conn.prepareStatement(query);
			ResultSet rs = stmt.executeQuery()) {

			while (rs.next()) {
				TypeFrais typeFrais = new TypeFrais(rs.getString("id"),
						rs.getString("libelle"), rs.getInt("montant"));
				lesTypesFrais.put(typeFrais.getId(), typeFrais);
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		return lesTypesFrais;
	}
}
