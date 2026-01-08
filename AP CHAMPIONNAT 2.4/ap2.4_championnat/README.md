# AP2.4_Championnat

## Configuration
**Dans Visual Studio**
1. Copier-coller le fichier .env.example et le renommer .env
2. Mettre des valeurs correctes dans ce fichier pour la connexion à la BDD
3. Clic-droit sur le fichier, Propriétés > Action de génération : choisir "Copier si plus récent"

## Exécution
1. Lancer un serveur MySQL en local (ex. : Wamp) et importer le script fourni (scriptChampionnat.sql)
2. Le driver ODBC sur vos machines est en 64 bits. Il faut donc obligatoirement choisir l'architecture x64 comme cible de compilation.
3. Lancer l'application Championnat