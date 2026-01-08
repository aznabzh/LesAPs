package fr.geiffel.gsb.model.metier;

public enum Statut {

    VISITEUR("visiteur"),
    COMPTABLE("comptable"),
    GESTIONNAIRE("gestion");

    public final String label;

    Statut(String label) {
        this.label=label;
    }

    public static Statut valueFrom(String label) {
        for (Statut s : values()) {
            if (s.label.equals(label)) {
                return s;
            }
        }
        throw new IllegalStateException();
    }

}
