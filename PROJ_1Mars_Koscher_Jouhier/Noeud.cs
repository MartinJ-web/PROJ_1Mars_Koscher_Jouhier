using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;


namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Noeud
    {
        string nom;
        float x;
        float y;
        public Noeud(string nom)
        {
            this.nom = nom;
        }
        
        public string Nom
        {
            get { return nom; }
        }
         
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public string ToString()
        {
            return nom; 
        }
    }
}
