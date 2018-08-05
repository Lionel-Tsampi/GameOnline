using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace GameOnline
{
    public class Game
    {

        public Game(string name, string description, int stock)
        {
            Name = name;
            Description = description;
            Stock = stock;
            Note = 0;
        }

        public Game()
        {
            Name = "";
            Description = "";
            Stock = 0;
            Note = 0;
        }



        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        public String Name { get; set; }

        [Column("Recapitulatif")]  // Modification du nom de la table Description en Recapitulatif
        public String Description { get; set; }
        public int Stock { get; set; }
        public int Note { get; set; }


        public override string ToString()
        {
            return "GameID : " + GameId + " || Name : " + Name + " || Description : " + Description + " || Stock : " + Stock + " || Note : " + Note;
        }


    }
}
