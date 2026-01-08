package fr.geiffel.gsb.controllers.comptable;

import fr.geiffel.gsb.Main;
import fr.geiffel.gsb.fxutils.SceneFactory;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;

import java.io.IOException;

public class ComptableListeFicheSceneFactory implements SceneFactory {

    public Scene getScene() throws IOException {
        FXMLLoader loader = new FXMLLoader(Main.class.getResource("viewComptableListeFiches.fxml"));
        Parent root = loader.load();

        ComptableListeFichesController controller = loader.getController();
        controller.load();
        return new Scene(root);
    }

}
