package fr.geiffel.gsb.fxutils;

import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class StageManager {
    private final static Stage stage = new Stage();
    private final static List<SceneFactory> sceneFactories = new ArrayList<>();

    public static void changeScene(SceneFactory sceneFactory) throws IOException {
        stage.setScene(sceneFactory.getScene());
        stage.sizeToScene();
        sceneFactories.add(sceneFactory);
    }

    public static void previousScene() {
        try {
            Scene scene = sceneFactories.get(sceneFactories.size() - 2).getScene();
            stage.setScene(scene);
            sceneFactories.remove(sceneFactories.size() - 1);
        } catch (IOException e) {
            ErrorManager.manageError("Erreur lors du retour", e);
        }
    }

    public static Stage getStage() {
        return stage;
    }
}
