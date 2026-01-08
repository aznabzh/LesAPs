using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace championnat.Modele.Metier
{
    public class Poste
    {
        public string Code { get; set; }
        public string Libelle { get; set; }

        public Poste()
        {
        }


        public Poste(string code, string libelle)
        {
            Code = code;
            Libelle = libelle;
        }

        public override bool Equals(object obj)
        {
            return obj is Poste poste &&
                   Code == poste.Code &&
                   Libelle == poste.Libelle;
        }

        public override int GetHashCode()
        {
            int hashCode = 673659966;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Libelle);
            return hashCode;
        }
    }
}
