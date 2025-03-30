using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Noeud
    {
        string nom;

        public Noeud(string nom)
        {
            this.nom = nom; 
        }

        public string Nom
        {
            get { return nom; }
        }

        public bool Equals(Noeud noeud)
        {
            return (this.nom == noeud.nom);
        }

        public string ToString()
        {
            return this.nom;
        }
    }
}