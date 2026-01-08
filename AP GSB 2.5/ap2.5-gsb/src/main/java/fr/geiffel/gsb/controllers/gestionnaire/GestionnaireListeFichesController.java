package fr.geiffel.gsb.controllers.gestionnaire;

import fr.geiffel.gsb.Main;
import fr.geiffel.gsb.fxutils.StageManager;
import fr.geiffel.gsb.model.DAO.FicheFraisDAO;
import fr.geiffel.gsb.model.metier.FicheFrais;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Alert;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;

import java.util.List;

public class GestionnaireListeFichesController {

	@FXML 	private TableView<FicheFrais> tableListeFiches;
	@FXML 	private TableColumn<FicheFrais , Integer > colIdFiche;
	@FXML 	private TableColumn<FicheFrais , String > colNomVisiteur;
	@FXML 	private TableColumn<FicheFrais , Integer > colMoisFiche;
	@FXML  private TableColumn<FicheFrais , String > colEtatFiche;

	//Déclaration de l'ObservableList nécessaire au remplissage de la tableView
	private ObservableList<FicheFrais> data = FXCollections.observableArrayList();

	/**
	 * Méthode qui charge toutes les données de la vue, appelée par la SceneFactory
	 */
	public void load() {
		remplissagetableViewListeFiches();
	}


	/**
	 * Ouverture de la fiche sélectionnée
	 * Click sur le bouton "Ouvrir fiche sélectionnée"
	 * @param e
	 */
	@FXML
	private void buttonOuvrirFicheClick(ActionEvent e) {
		int index = tableListeFiches.getSelectionModel().getSelectedIndex();
		if(index >= 0) {
			FicheFrais uneFiche = tableListeFiches.getSelectionModel().getSelectedItem();
		}else {
			Alert alert = new Alert(Alert.AlertType.ERROR);
			alert.setHeaderText("Sélectionnez une fiche de frais");
			alert.getDialogPane().setContentText("Vous devez sélectionner une fiche de frais afin de la visualiser");
			alert.showAndWait();
		}
	}

	/**
	 * Remplissage le la tableView "liste des fiches de frais"
	 */
	private void remplissagetableViewListeFiches() {
		List<FicheFrais> lesFichesFrais = FicheFraisDAO.allFichesFrais();
		data.addAll(lesFichesFrais);

		colIdFiche.setCellValueFactory(new PropertyValueFactory<FicheFrais,Integer>("id"));
		colMoisFiche.setCellValueFactory(new PropertyValueFactory<FicheFrais,Integer>("moisAnnee"));
		colNomVisiteur.setCellValueFactory(new PropertyValueFactory<FicheFrais,String>("nomPrenomUtilisateur"));
		colEtatFiche.setCellValueFactory(new PropertyValueFactory<FicheFrais,String>("etatLong"));

		tableListeFiches.setItems(data);
	}

	public void previousScene(ActionEvent actionEvent) {
		StageManager.previousScene();
	}
}
