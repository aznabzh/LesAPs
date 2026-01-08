package fr.geiffel.gsb.fxutils;

import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;

import java.net.URL;
import java.util.ResourceBundle;

public class PreviousButtonController implements Initializable {

    @FXML
    Button btn;


    @Override
    public void initialize(URL location, ResourceBundle resources) {
        btn.setOnAction(e-> StageManager.previousScene());
    }
}
