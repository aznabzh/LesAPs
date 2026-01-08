package fr.geiffel.gsb.model.metier;



import java.text.DateFormatSymbols;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class FicheFrais {

	private int id;
	private int mois;
	private int annee;
	private Date dateCreation;
	private Date dateCloture;
	private String etat;
	private float montantDeclare;
	private Utilisateur utilisateur;
	private List<LigneFrais> lesLignes;

	        
	public FicheFrais(int unId , int unMois, int uneAnnee,
					  Date uneDateCreation, Date uneDateCloture,
					  String unEtat, float unMontantDeclare,
					  Utilisateur unUtilisateur) {
		id = unId;
		mois = unMois;
		annee = uneAnnee;
		dateCreation = uneDateCreation;
		dateCloture = uneDateCloture;
		etat = unEtat;
		montantDeclare = unMontantDeclare;
		utilisateur = unUtilisateur;
		lesLignes = new ArrayList<>();
	}

	public int getId() {
		return id;
	}
	public int getMois() {
		return mois;
	}
	public int getAnnee() {
		return annee;
	}
	public Date getDateCreation() {
		return dateCreation;
	}
	public Date getDateCloture() {
		return dateCloture;
	}
	public String getEtat() {
		return etat;
	}
	public float getMontantDeclare() {
		return montantDeclare;
	}

	public Utilisateur getUtilisateur() {
		return utilisateur;
	}
	public String getEtatLong() {
		switch (etat){
			case "EC":
				return "EC-En cours de saisie";
				case "CL":
					return "CL-Cl�tur�e"; case "VA": return "VA-Valid�e"; default: return "MP-Mise en paiement";
		}

	}
	public String getMoisAnnee() {

		String s_mois = new DateFormatSymbols().getMonths()[mois - 1];
		return String.valueOf(annee) + '-'+ String.format("%02d",mois) + '[' +s_mois +']';

	}

	public String getMoisLettre() {

		return new DateFormatSymbols().getMonths()[mois - 1];

	}

	public List<LigneFrais> getLesLignes(){
		return lesLignes ;
	}


	public Integer nbLignes(){
		return lesLignes.size() ;
	}



	public String getNomPrenomUtilisateur() {
		return utilisateur.getNomComplet();
	}

	public float getTotalDeclare() {

		float total = 0;
		for (LigneFrais uneLigneFrais: lesLignes)
		{
			total += uneLigneFrais.getQuantiteDeclaree(); //* uneLigneFrais.getTarif();
		}
		return total;
	}


	public void setLesLignesFrais(List<LigneFrais> uneListeLignesFrais) {
		lesLignes = uneListeLignesFrais;
	}
	public void changerEtatFiche(String nouvelEtat)
	{
		etat = nouvelEtat;
	}


	public LigneFrais chercherLigneFrais(String idTypeFrais) {
		for (LigneFrais uneLigneFrais : lesLignes)
		{
			if (uneLigneFrais.getTypeFrais().getId() == idTypeFrais)
			{
				return uneLigneFrais;
			}
		}
		return null;
	}
}


