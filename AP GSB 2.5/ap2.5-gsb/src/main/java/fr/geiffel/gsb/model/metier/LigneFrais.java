package fr.geiffel.gsb.model.metier;

import fr.geiffel.gsb.model.DAO.TypeFraisDAO;

public class LigneFrais {

	private FicheFrais ficheFrais;
    private TypeFrais typeFrais;
    private int quantiteDeclaree;
    private int quantiteValidee;

	public LigneFrais(TypeFrais typeFrais, int quantiteDeclaree, int quantiteValidee) {
		this.typeFrais = typeFrais;
		this.quantiteDeclaree = quantiteDeclaree;
		this.quantiteValidee = quantiteValidee;
	}

	public LigneFrais(FicheFrais ficheFrais, TypeFrais typeFrais, int quantiteDeclaree, int quantiteValidee) {
		this.ficheFrais = ficheFrais;
		this.typeFrais = typeFrais;
		this.quantiteDeclaree = quantiteDeclaree;
		this.quantiteValidee = quantiteValidee;
	}

	public FicheFrais getFicheFrais() {
		return ficheFrais;
	}

	public void setFicheFrais(FicheFrais ficheFrais) {
		this.ficheFrais = ficheFrais;
	}

	public TypeFrais getTypeFrais() {
		return typeFrais;
	}

	public void setTypeFrais(TypeFrais typeFrais) {
		this.typeFrais = typeFrais;
	}

	public int getQuantiteDeclaree() {
		return quantiteDeclaree;
	}

	public void setQuantiteDeclaree(int quantiteDeclaree) {
		this.quantiteDeclaree = quantiteDeclaree;
	}

	public int getQuantiteValidee() {
		return quantiteValidee;
	}

	public void setQuantiteValidee(int quantiteValidee) {
		this.quantiteValidee = quantiteValidee;
	}
}