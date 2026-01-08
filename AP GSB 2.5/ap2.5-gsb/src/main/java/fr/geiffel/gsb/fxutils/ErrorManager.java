package fr.geiffel.gsb.fxutils;

import javafx.stage.Stage;

import java.util.Arrays;

public class ErrorManager {

    public static void manageError(String text, Exception e) {
        Stage modal = Modal.getModal(text);
        modal.showAndWait();
        e.printStackTrace();
    }

}
