# GameOnline
Application console sous Windows développer en C# avec EntityFramework 6.1.1


Cahier de charges

Concevoir une application de gestion de jeux depuis une base de donnée distante
cette application permettra de 
 - d'ajouter un jeu 
 - supprimer un jeu
 - afficher les details d'un jeu
 - afficher les détails de tous les jeux
 - modifier la note d'un jeu
 - modifier le nom de la colonne description en recapitulation
 - afficher en rouge les details d'un jeu si le stock est inferieur ou egale à 10
 - afficher en bleu les details d'un jeu si le stock est superieur à 10 et inferieur à 50
 - afficher en blanc les details d'un jeu si le stock est superieur à 50


Conception
 - Approche codeFirst
 - EntityFrameWork 6.1.1
 - BD : SQL Server Express 2012


Utilisation
 - importer les souces depuis votre IDE (Visual Studio 2015 de preference)
 - regener la base de donnée depuis la ligne de commande Enable-Migrations
 - decommenter les objets crées dans le main et remplisser la base de données
 - regenerer le projet 
 - ouvrer la console et tester les commnandes
 - la commande -help vous donne une description de toutes les commandes utiles
