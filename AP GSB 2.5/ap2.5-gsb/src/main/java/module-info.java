module fr.geiffel.gsb {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.sql;
    requires io.github.cdimascio.dotenv.java;


    exports fr.geiffel.gsb;
    exports fr.geiffel.gsb.model.metier;
    exports fr.geiffel.gsb.model.DAO;
    exports fr.geiffel.gsb.fxutils;

    opens fr.geiffel.gsb to javafx.fxml;
    opens fr.geiffel.gsb.controllers.authentification;
    opens fr.geiffel.gsb.controllers.comptable;
    opens fr.geiffel.gsb.controllers.gestionnaire;
    opens fr.geiffel.gsb.controllers.visiteur;
    opens fr.geiffel.gsb.fxutils;

    exports fr.geiffel.gsb.controllers.authentification to javafx.fxml;
    exports fr.geiffel.gsb.controllers.comptable to javafx.fxml;
    exports fr.geiffel.gsb.controllers.gestionnaire to javafx.fxml;
    exports fr.geiffel.gsb.controllers.visiteur to javafx.fxml;
    exports fr.geiffel.gsb.model;
}