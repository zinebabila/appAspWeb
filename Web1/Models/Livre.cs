using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Models
{
    public class Livre
    {
        public int LivreID { get; set; }
        public string nom { get; set; }
        public Livre()
        {

        }
        public Livre(string nom)
        {
            this.nom = nom;
        }
        public Livre(int id)
        {
            this.LivreID = id;
        }
    }
}
