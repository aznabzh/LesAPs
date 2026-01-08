package fr.geiffel.gsb.controllers.authentification;

import fr.geiffel.gsb.controllers.comptable.ComptableListeFicheSceneFactory;
import fr.geiffel.gsb.controllers.gestionnaire.GestionnaireListeFicheSceneFactory;
import fr.geiffel.gsb.controllers.visiteur.VisiteurListeFicheSceneFactory;
import fr.geiffel.gsb.fxutils.SceneFactory;
import fr.geiffel.gsb.fxutils.StageManager;
import fr.geiffel.gsb.model.DAO.AuthDAO;
import fr.geiffel.gsb.model.DBConnex;
import fr.geiffel.gsb.model.metier.Utilisateur;
import io.github.cdimascio.dotenv.Dotenv;
import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.input.KeyEvent;

import java.io.IOException;
import java.net.URL;
import java.util.Optional;
import java.util.ResourceBundle;


public class AuthentificationController {
	

	/**
	 * Les variables du fichier FXML associé
	 */
	@FXML
	private Label messageConnexionLabel;

	@FXML
	private TextField loginTextField;
	@FXML
	private PasswordField mdpPasswordField;
	
	
	/**
	 * Méthode associée à l'évènement click sur le bouton valider
	 * @param e
	 */
	@FXML
	protected void buttonValiderAuthentificationClick(ActionEvent e) {
			
		//On utilise AuthDAO pour essayer de connecter l'utilisateur
		//On récupère un Optional : si l'authentification a fonctionné, il contient un utilisateur
		//Si l'authentification n'a pas fonctionné, il est empty()
		Optional<Utilisateur> optionalUtilisateur = AuthDAO.authentification(loginTextField.getText() ,
																			mdpPasswordField.getText());

		//Fonctionnalité de Java 9 : si l'Optional contient un utilisateur (donc si l'authentification a
		//fonctionné, alors on appelle la fonction loadSceneAccordToStatut
		//Sinon, on modifie le label pour indiquer une erreur
		optionalUtilisateur.ifPresentOrElse((utilisateur)-> {
                    try {
                        loadSceneAccordingToStatut(utilisateur);
                    } catch (IOException ex) {
                        throw new RuntimeException(ex);
                    }
                },
				()->messageConnexionLabel.setText("Login ou mot de passe incorrect !"));
	}

	/**
	 * Méthode qui charge la Scene correcte en fonction du statut de l'utilisateur
	 * @param utilisateur -> l'utilisateur connecté
	 */
	protected void loadSceneAccordingToStatut(Utilisateur utilisateur) throws IOException {
		SceneFactory sceneFactory = switch (utilisateur.getStatut()) {
			case VISITEUR -> new VisiteurListeFicheSceneFactory(utilisateur);
			case COMPTABLE -> new ComptableListeFicheSceneFactory();
			case GESTIONNAIRE -> new GestionnaireListeFicheSceneFactory();
		};
		StageManager.changeScene(sceneFactory);
	}

	/**
	 * Fermeture de l'application associée au click sur le boton quitter
	 * @param e
	 */
	@FXML
	protected void quitterAuthentificationButton(ActionEvent e) {
		Platform.exit();
	}
}
