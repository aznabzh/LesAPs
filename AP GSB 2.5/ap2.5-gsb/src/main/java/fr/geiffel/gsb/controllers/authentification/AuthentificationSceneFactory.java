package fr.geiffel.gsb.controllers.authentification;

import fr.geiffel.gsb.Main;
import fr.geiffel.gsb.fxutils.SceneFactory;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;

import java.io.IOException;

public class AuthentificationSceneFactory implements SceneFactory {

    public Scene getScene() throws IOException {
        FXMLLoader loader = new FXMLLoader(Main.class.getResource("viewConnexion.fxml"));
        Parent root = loader.load();

        AuthentificationController controller = loader.getController();
        return new Scene(root);
    }
}
