# Client_Serveur_Backend
Projet à rendre à Monsieur Boumaza Rachid.

Installation du projet : 

- Télécharger le .zip ou git clonner à partir de la branch master.
- Ensuite décompresser le dossier.
- Ouvir le fichier BackEnd MVC.sln se trouvant à l'intérieur du dossier BackEnd MVC.
- Lancer la solution. Enjoy ! 


Annexe du projet : 

Vidéo de démo du projet : 



MCD : 

https://zupimages.net/viewer.php?id=22/18/05mg.png


Script SQL  : 

CREATE TABLE Client(
   IdClient INT,
   Nom VARCHAR(50) ,
   Prenom VARCHAR(50) ,
   Adresse VARCHAR(50) ,
   PRIMARY KEY(IdClient)
);

CREATE TABLE Compte(
   IdCompte INT,
   Libelle VARCHAR(50) ,
   PRIMARY KEY(IdCompte)
);

CREATE TABLE Transaction_Operation(
   IdTransaction INT,
   Type VARCHAR(50) ,
   DateTransaction DATE,
   Montant VARCHAR(50) ,
   IdCompte INT NOT NULL,
   PRIMARY KEY(IdTransaction),
   FOREIGN KEY(IdCompte) REFERENCES Compte(IdCompte)
);

CREATE TABLE CompteClient(
   IdClient INT,
   IdCompte INT,
   PRIMARY KEY(IdClient, IdCompte),
   FOREIGN KEY(IdClient) REFERENCES Client(IdClient),
   FOREIGN KEY(IdCompte) REFERENCES Compte(IdCompte)
);
