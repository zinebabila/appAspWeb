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
        public string image { get; set; }
        public Livre()
        {

        }
        public Livre(string n, int id, string img)
        {
            LivreID = id;
            nom = n;
            image = img;

        }
    }
}
