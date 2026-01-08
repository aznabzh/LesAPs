package fr.geiffel.gsb.model.metier;

public class TypeFrais {
	private String id;
	private String libelle;
	private float montant;

	public TypeFrais(String id, String libelle, float montant) {
		this.id = id;
		this.libelle = libelle;
		this.montant = montant;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getLibelle() {
		return libelle;
	}

	public void setLibelle(String libelle) {
		this.libelle = libelle;
	}

	public float getMontant() {
		return montant;
	}

	public void setMontant(float montant) {
		this.montant = montant;
	}
}