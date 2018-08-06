using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int i = 0;

            if (args[i] == "-addGame")
            {
                Game game = new Game();

                Console.Write("Nom du jeu : ");
                game.Name = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Description du jeu : ");
                game.Description = Console.ReadLine();
                Console.WriteLine();


                Console.Write("Stock : ");
                game.Stock = int.Parse(Console.ReadLine());
                Console.WriteLine();


                Console.Write("Note : ");
                game.Note = int.Parse(Console.ReadLine());
                Console.WriteLine();

                AddGame(game);

            }
            else if (args[i] == "-displayAll")
            {
                DisplayALL();
            }
            else if (args[i] == "-deleteGame")
            {
                try
                {
                    int id = int.Parse(args[i + 1]);
                    DeleteGame(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Verifier les paramètres de la ligne de commande");
                }

            }
            else if (args[i] == "-displayGame")
            {
                try
                {
                    int id = int.Parse(args[i + 1]);
                    DisplayGame(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Verifier les paramètres de la ligne de commande");
                }

            }
            else if (args[i] == "-updateNote")
            {
                try
                {
                    int id = int.Parse(args[i + 1]);
                    int note = int.Parse(args[i + 2]);
                    UpdateNote(id, note);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Verifier les paramètres de la ligne de commande");
                }
            }
            else if (args[i] == "-countGame")
            {
                CountGame();
            }
            else if (args[i] == "-help")
            {
                Console.WriteLine("******  Application de Gestion de stock : GameOnline   ********");
                Console.WriteLine("*****************************************************************");

                Console.WriteLine("\n\n\n");

                Console.WriteLine("Cette application vous permet de gerer vos jeux depuis une base de donées distante");
                Console.WriteLine("Elle offre les services suivants");
                Console.WriteLine("- Ajouter un jeu : addGame");
                Console.WriteLine("- Supprimer un jeu : deleteGame");
                Console.WriteLine("- Afficher les détails d'un jeu : displayGame");
                Console.WriteLine("- afficher les détails de tous les jeux : displayAll");
                Console.WriteLine("- Modifier la note d'un jeu : updateNote");
                Console.WriteLine("- afficher le total du stock des jeux");

                Console.WriteLine("*****************************************************************");

                Console.WriteLine("\n\n\n");

                Console.WriteLine("Quelques commandes utiles : ");
                Console.WriteLine("addGame : permet d'ajouter un jeu dans la base de donnée");
                Console.WriteLine("deleteGame : permet de supprimer un jeu de la base de donnée");
                Console.WriteLine("displayGame : permet d'afficher les détails d'un jeu, il faut passer l'identifiant du jeu comme deuxième paramètre");
                Console.WriteLine("displayAll : permet d'afficher les détails de tous les jeux en base");
                Console.WriteLine("updateNote : permet de modifier la note d'un jeu en base de donnée, il faut passer l'identifiant du jeu comme premier paramètre et la note comme deuxième paramètre");
                Console.WriteLine("countGame : permet d'afficher le total du stock de jeu");
            }



            // objets de test pour remplir la base de donées

            //Game g1 = new Game("mario", "jeu d'aventure", 10);
            //Game g2 = new Game("tetris", "jeu de de construction", 10);
            //Game g3 = new Game("Call of Duty", "jeu de guerre", 10);
            //Game g4 = new Game("Fifa 19", "jeu de sport : foot", 10);
            //Game g5 = new Game("PES 19", "jeu de sport : foot", 10);
            //Game g6 = new Game("Street figther", "jeu de combat", 10);
            //Game g7 = new Game("assassin creed", "jeu d'aventure", 10);
            //Game g8 = new Game("assassin creed 2", "jeu d'aventure", 50);
            //Game g9 = new Game("assassin creed 3", "jeu d'aventure", 40);


            //AddGame(g1); AddGame(g2); AddGame(g3); AddGame(g4); AddGame(g5); AddGame(g6); AddGame(g7); AddGame(g8); AddGame(g9);


            //AddNote(10, 4);
            //DisplayALL();

            // DisplayGame(4);

            // DeleteGame(9);
            // CountGame();

           // Console.ReadKey();
        }


        /// <summary>
        /// Methode permettant d'ajouter un jeu
        /// </summary>
        /// <param name="game">nom du jeu</param>
        public static void AddGame(Game game)
        {
            using (var contextGames = new GameModel())
            {
                contextGames.dbGames.Add(game);
                contextGames.SaveChanges();
                DisplayGame(game.GameId);
                Console.WriteLine("Operation reussi");
            }
        }

        /// <summary>
        /// Methode permettant de supprimer un jeu
        /// </summary>
        /// <param name="gameNumber">Identifiant du jeu</param>
        public static void DeleteGame(int gameNumber)
        {
            using (var contextGames = new GameModel())
            {
                try
                {
                    Game game = contextGames.dbGames.Find(gameNumber);
                    contextGames.dbGames.Remove(game);
                    contextGames.SaveChanges();                }
                catch (Exception)
                {
                    Console.WriteLine("Aucune correspondance trouvée......");
                }
                
            }
            
        }


        /// <summary>
        /// Methode permettant d'ajouter un jeu specifique
        /// </summary>
        /// <param name="gameNumber">identifiant du jeu</param>
        public static void DisplayGame(int gameNumber)
        {
            using (var contextGames = new GameModel())
            {

                try
                {
                    Console.WriteLine("GameID\t Name\t Description\t Stock\t Note");
                    foreach (Game game in contextGames.dbGames)
                    {
                        if (game.GameId == gameNumber)
                        {
                            if (game.Stock <= 10)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else if (game.Stock > 10 && game.Stock < 50)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else if (game.Stock >= 50)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.WriteLine(game.GameId + "\t" + game.Name + "\t" + game.Description + "\t" + game.Stock + "\t" + game.Note);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                        
                    }
                }
                catch (Exception )
                { 
                    Console.WriteLine("Aucune correspondance trouvée.....");
                }
                
            }
            
        }

        /// <summary>
        /// Methode permettant d'afficher tous les jeux
        /// </summary>
        public static void DisplayALL()
        {
            using (var contextGames = new GameModel())
            {
                Console.WriteLine("GameID\t Name\t Description\t Stock\t game.Note");
                foreach (Game game in contextGames.dbGames)
                {
                    if (game.Stock <= 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (game.Stock > 10 && game.Stock < 50)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (game.Stock >= 50)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(game.GameId + "\t" + game.Name + "\t" + game.Description + "\t" + game.Stock + "\t" + game.Note);
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            
        }

        /// <summary>
        /// Methode permettant de modifier la note d'un jeu
        /// </summary>
        /// <param name="id">Identifiant</param>
        /// <param name="note">la note a attribuer au jeu</param>
        public static void UpdateNote(int id, int note)
        {
            using (var contextGames = new GameModel())
            {
                try
                {
                    Game game = contextGames.dbGames.Find(id);

                    var GameModify = contextGames.Entry<Game>(game);
                    game.Note = note;
                    contextGames.SaveChanges();
                    
                }
                catch (Exception)
                {

                    Console.WriteLine("Aucune Correspondance trouvée....");
                }
            }
        }

        /// <summary>
        /// Affiche le nombre total de jeu en stock
        /// </summary>
        public static void CountGame()
        {
            int count = 0;
            using (var contextGames = new GameModel())
            {
                foreach (var game in contextGames.dbGames)
                {
                    count += game.Stock;
                }

                Console.WriteLine(count  + " jeux en stock");
            }
        }


    }
}
