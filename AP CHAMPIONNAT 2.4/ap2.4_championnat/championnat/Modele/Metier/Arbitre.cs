using championnat.Formulaires.fonction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace championnat.Modele.Metier
{
    public class Arbitre
    {
        public String Code { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        public Arbitre()
        {
        }

        public Arbitre(String code, String nom, String prenom) {
            Code = code;
            Nom = nom;
            Prenom = prenom;
        }

        public override bool Equals(object obj)
        {
            return obj is Arbitre arbitre &&
                Code == arbitre.Code &&
                Nom == arbitre.Nom &&
                Prenom == arbitre.Prenom;

        }

        public override int GetHashCode()
        {
            int hashCode = 785354917;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prenom);
            return hashCode;
        }
    }
}
