package fr.geiffel.gsb.model.metier;


import java.util.Date;
import java.util.ArrayList;
import java.util.List;


public class Utilisateur {

	private String id;
    private String nom ;
    private String prenom;
    private String login;
    private Statut statut;
    private String adresse;
    private String codePostal;
    private String ville;
    private Date dateEmbauche;
    private List<FicheFrais> ficheFrais;
    

    public Utilisateur(String unId, String unNom,
                       String unPrenom, String unLogin,
                       String unStatut,  String uneAdresse,
                       String unCp , String uneVille,
                       Date uneDateEmb)
    {
        id = unId;
        nom = unNom;
        prenom = unPrenom;
        login = unLogin;
        statut = Statut.valueFrom(unStatut);
        adresse = uneAdresse;
        codePostal = unCp;
        ville = uneVille;
        dateEmbauche = uneDateEmb;
        ficheFrais = new ArrayList<>();
    }

    public String getId()
    {
        return id;
    }
    public String getNom()
    {
        return nom;
    }
    public String getLogin() {
        return login;
    }
    public String getPrenom()
    {
        return prenom;
    }
    public String getAdresse()
    {
        return adresse;
    }
    public String getCodePostal()
    {
        return codePostal;
    }
    public String getVille()
    {
        return ville;
    }
    public Date getDateEmbauche()
    {
        return dateEmbauche;
    }
    public String getStatutAsString() {
        return statut.label;
    }
    public Statut getStatut() {
        return statut;
    }
    public List<FicheFrais> getFicheFrais() {return ficheFrais;}

    public String getNomComplet()
    {
        return  nom + " " + prenom;
    }
    public String getCPVille()
    {
        return codePostal + " " +  ville;
    }

    public void setId(String id) {
        this.id = id;
    }
    public void setNom(String nom) {
        this.nom = nom;
    }
    public void setLogin(String login) {
        this.login = login;
    }
    public void setPrenom(String prenom) {
        this.prenom = prenom;
    }
    public void setAdresse(String adresse) {
        this.adresse = adresse;
    }
    public void setCodePostal(String codePostal) {
        this.codePostal = codePostal;
    }
    public void setVille(String ville) {
        this.ville = ville;
    }
    public void setDateEmbauche(Date dateEmbauche) {
        this.dateEmbauche = dateEmbauche;
    }
	public void setStatut(String statut) {
		this.statut = Statut.valueOf(statut);
	}
    public void setStatut(Statut statut) {
        this.statut = statut;
    }

    /**
     * Setter du paramètre FicheFrais
     * @param ficheFrais la liste de FicheFrais à affecter à l'Utilisateur
     */
    public void setFicheFrais(List<FicheFrais> ficheFrais) {
        this.ficheFrais = ficheFrais;
    }

    /**
     * Ajoute une FicheFrais à la liste des FicheFrais de l'utilisateur
     * @param fiche la FicheFrais à ajouter
     */
    public void addFicheFrais(FicheFrais fiche) {
        this.ficheFrais.add(fiche);
    }
}
	

