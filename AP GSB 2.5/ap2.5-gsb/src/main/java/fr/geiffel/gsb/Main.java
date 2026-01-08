package fr.geiffel.gsb;


import fr.geiffel.gsb.controllers.authentification.AuthentificationSceneFactory;
import fr.geiffel.gsb.fxutils.SceneFactory;
import fr.geiffel.gsb.fxutils.StageManager;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.util.ArrayList;
import java.util.List;

public class Main extends Application {

	/**
	 * Chargement au lancement de l'application de le vue "viewConnexion.fxml"
	 */
	@Override
	public void start(Stage stage) {
		try {
			SceneFactory factory = new AuthentificationSceneFactory();
			stage = StageManager.getStage();
			stage.setTitle("GSB Gestion des frais - Compta Fiche de frais");
			StageManager.changeScene(factory);
			stage.show();

		} catch(Exception e) {
			System.out.println(e.getMessage());
		}
	}


	public static void main(String[] args) {
		launch(args);
	}
}
