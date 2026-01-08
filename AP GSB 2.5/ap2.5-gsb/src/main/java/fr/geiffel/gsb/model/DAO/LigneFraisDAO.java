package fr.geiffel.gsb.model.DAO;

import fr.geiffel.gsb.model.DBConnex;
import fr.geiffel.gsb.model.metier.FicheFrais;
import fr.geiffel.gsb.model.metier.LigneFrais;
import fr.geiffel.gsb.model.metier.TypeFrais;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class LigneFraisDAO {
    public static Map<Integer, List<LigneFrais>> allLignesFraisByIdFicheFrais() {
        Map<Integer, List<LigneFrais>> lesLignesFraisByIdFiche = new HashMap<>();
        Map<String, TypeFrais> lesTypesFrais = TypeFraisDAO.allTypeFrais();
        String query = """
                SELECT idFiche, idTypeFrais, quantiteDeclaree, quantiteValidee
                FROM lignefrais""";
        try(Connection conn = DBConnex.getConnection();
            PreparedStatement stmt = conn.prepareStatement(query)) {
            ResultSet rs = stmt.executeQuery();

            while (rs.next()) {
                Integer idFicheFrais = rs.getInt("idFiche");
                LigneFrais ligneFrais = new LigneFrais(lesTypesFrais.get(rs.getString("idTypeFrais")),
                                                        rs.getInt("quantiteDeclaree"),
                                                        rs.getInt("quantiteValidee"));
                if (lesLignesFraisByIdFiche.containsKey(idFicheFrais)) {
                    var listLignes = lesLignesFraisByIdFiche.get(idFicheFrais);
                    listLignes.add(ligneFrais);
                    lesLignesFraisByIdFiche.replace(idFicheFrais, listLignes);
                } else {
                    List<LigneFrais> lesLignes = new ArrayList<>();
                    lesLignes.add(ligneFrais);
                    lesLignesFraisByIdFiche.put(idFicheFrais, lesLignes);
                }
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return lesLignesFraisByIdFiche;
    }
}
