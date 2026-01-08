using System;
using System.IO;

namespace championnat
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DotEnvLoader();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Application());            
        }

        /*
         * Chargement des variables d'environnement
         */
        private static void DotEnvLoader()
        {
            var root = Directory.GetCurrentDirectory();
            var dotenvPath = Path.Combine(root, ".env");
            DotEnv.Load(dotenvPath);
        }
    }
}
