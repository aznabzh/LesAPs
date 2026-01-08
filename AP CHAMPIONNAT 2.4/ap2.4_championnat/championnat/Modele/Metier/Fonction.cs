using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace championnat.Modele.Metier
{
    public class Fonction
    {
        public string Code { get; set; }
        public string Libelle { get; set; }

        public Fonction()
        {
        }

        public Fonction(string code, string libelle)
        {
            Code = code;
            Libelle = libelle;
        }

        public override bool Equals(object obj)
        {
            return obj is Fonction fonction &&
                Code == fonction.Code &&
                Libelle == fonction.Libelle;
        }

        public override int GetHashCode()
        {
            int hashCode = 654775254;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Libelle);
            return hashCode;
        }
    }
}
