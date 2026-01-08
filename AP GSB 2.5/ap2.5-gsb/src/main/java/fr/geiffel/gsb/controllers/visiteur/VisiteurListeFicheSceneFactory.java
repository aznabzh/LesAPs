package fr.geiffel.gsb.controllers.visiteur;

import fr.geiffel.gsb.Main;
import fr.geiffel.gsb.fxutils.SceneFactory;
import fr.geiffel.gsb.model.metier.Utilisateur;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;

import java.io.IOException;

public class VisiteurListeFicheSceneFactory implements SceneFactory {

    private Utilisateur utilisateur;

    public VisiteurListeFicheSceneFactory(Utilisateur utilisateur) {
        this.utilisateur = utilisateur;
    }

    public Scene getScene() throws IOException {
        FXMLLoader loader = new FXMLLoader(Main.class.getResource("viewVisiteurListeFiches.fxml"));
        Parent root = loader.load();

        VisiteurListeFichesController controller = loader.getController();
        controller.load(utilisateur);
        return new Scene(root);
    }

}
