using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace championnat.Modele.Metier
{
    public class Match
    {
        public String CodeM { get; set; }
        public DateTime Date { get; set; }
        public String Lieu { get; set; }
        public int ScoreE1 { get; set; }
        public int ScoreE2 { get; set; }
        public String CodeE1 { get; set; }
        public String CodeE2 { get; set; }

        public Match()
        {
        }

        public Match(string codeM, DateTime date, string lieu, int scoreE1, int scoreE2, string codeE1, string codeE2)
        {
            CodeM = codeM;
            Date = date;
            Lieu = lieu;
            ScoreE1 = scoreE1;
            ScoreE2 = scoreE2;
            CodeE1 = codeE1;
            CodeE2 = codeE2;
        }

        public override bool Equals(object obj)
        {
            return obj is Match match &&
                   CodeM == match.CodeM &&
                   Date == match.Date &&
                   Lieu == match.Lieu &&
                   ScoreE1 == match.ScoreE1 &&
                   ScoreE2 == match.ScoreE2 &&
                   CodeE1 == match.CodeE1 &&
                   CodeE2 == match.CodeE2;
                   
        }

        public override int GetHashCode()
        {
            int hashCode = 497987354;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CodeM);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lieu);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(ScoreE1);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(ScoreE2);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CodeE1);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CodeE2);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}
