using System;
using System.Collections.Generic;

namespace championnat.Modele.Metier
{
    public class Joueur
    {
        /*
         * En C#, les getters/setters ne s'appellent pas getAttribut/setAttribut
         * A la place, on crée des "propriétés", qui portent le nom de l'attribut commençant par une majuscule
         * On rajoute ensuite un getter avec le mot-clé get et/ou un setter avec set
         */
        private int numero;
        public int Numero { get => numero; set => numero = value; }

        /*
         * Mais on peut aussi faire le choix de déclarer directement des propriétés
         * Les attributs associés seront générés automatiquement (en private) par C#
         */
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string NumeroLicence { get; set; }
        public Poste Poste { get; set; }

        public Joueur()
        {
        }

        //Au lieu d'utiliser this.attribut = paramètre, notre constructeur utilise les propriétés créées
        public Joueur(int numero, string nom, string prenom, 
            DateTime dateDeNaissance, string numeroLicence, Poste poste)
        {
            Numero = numero;
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            NumeroLicence = numeroLicence;
            Poste = poste;
        }

        /*
         * Manipulation des propriétés : 
         * 
         *   Joueur j = new Joueur();
         *   j.Nom; -> appelle le getter
         *   
         *   j.Nom = "Machin"; -> appelle le setter
         * 
         */


        public override bool Equals(object obj)
        {
            return obj is Joueur joueur &&
                   Numero == joueur.Numero &&
                   Nom == joueur.Nom &&
                   Prenom == joueur.Prenom &&
                   DateDeNaissance == joueur.DateDeNaissance &&
                   NumeroLicence == joueur.NumeroLicence &&
                   EqualityComparer<Poste>.Default.Equals(Poste, joueur.Poste);
        }

        public override int GetHashCode()
        {
            int hashCode = -1756506589;
            hashCode = hashCode * -1521134295 + Numero.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prenom);
            hashCode = hashCode * -1521134295 + DateDeNaissance.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumeroLicence);
            hashCode = hashCode * -1521134295 + EqualityComparer<Poste>.Default.GetHashCode(Poste);
            return hashCode;
        }
    }
}
