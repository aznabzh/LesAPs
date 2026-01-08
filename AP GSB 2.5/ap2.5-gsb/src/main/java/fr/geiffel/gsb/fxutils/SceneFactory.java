package fr.geiffel.gsb.fxutils;

import javafx.scene.Scene;

import java.io.IOException;

public interface SceneFactory {

    Scene getScene() throws IOException;

}
