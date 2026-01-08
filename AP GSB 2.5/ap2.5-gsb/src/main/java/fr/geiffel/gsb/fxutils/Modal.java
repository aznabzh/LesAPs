package fr.geiffel.gsb.fxutils;


import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.layout.VBox;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class Modal {

    public static Stage getModal(String textToDisplay) {
        Stage modal = new Stage();
        modal.initModality(Modality.APPLICATION_MODAL);
        Button closeButton = new Button("Ok");
        closeButton.setOnAction(e -> modal.close());

        VBox dialogLayout = new VBox();
        TextArea text = new TextArea(textToDisplay);
        text.setEditable(false);
        text.setWrapText(true);
        dialogLayout.getChildren().addAll(text);
        dialogLayout.getChildren().addAll(closeButton);
        dialogLayout.setAlignment(Pos.CENTER);
        dialogLayout.setSpacing(10);

        modal.initOwner(StageManager.getStage());
        modal.setScene(new Scene(dialogLayout,  200,  100));
        modal.sizeToScene();
        return modal;
    }

}
