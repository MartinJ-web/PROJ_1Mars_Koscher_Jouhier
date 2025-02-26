using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Lien
    {
        Noeud depart;
        Noeud arrivee;

        public Lien(Noeud depart, Noeud arrivee)
        {
            this.depart = depart;
            this.arrivee = arrivee;
        }

        public Noeud Depart
        {
            get { return depart; }
        }

        public Noeud Arrivee
        {
            get { return arrivee; }
        }
    }

}
