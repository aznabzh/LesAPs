package fr.geiffel.gsb.controllers.gestionnaire;

import fr.geiffel.gsb.Main;
import fr.geiffel.gsb.fxutils.SceneFactory;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;

import java.io.IOException;

public class GestionnaireListeFicheSceneFactory implements SceneFactory {

    public Scene getScene() throws IOException {
        FXMLLoader loader = new FXMLLoader(Main.class.getResource("viewGestionnaireListeFiches.fxml"));
        Parent root = loader.load();

        GestionnaireListeFichesController controller = loader.getController();
        controller.load();
        return new Scene(root);

    }

}
