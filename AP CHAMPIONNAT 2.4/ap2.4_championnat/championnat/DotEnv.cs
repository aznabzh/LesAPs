using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace championnat
{
    /*
     * Crée des variables d'environnement à partir d'un fichier .env
     * 
     * On crée un fichier .env à la racine, puis on écrit des valeurs nécessaires
     * (mots de passe, adresses de serveurs, etc.) dedans
     * 
     * L'utilisation de variables d'environnement permet de pouvoir modifier 
     * facilement ces valeurs sans avoir à modifier le code
     * 
     * Il faut faire attention à ne pas diffuser le fichier .env, c'est pourquoi on
     * l'a ajouté à la liste .gitignore
     */
    internal static class DotEnv
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=',
                    (char)StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }
}
