using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Lien
    {
        Noeud depuis;
        Noeud vers;

        public Lien(Noeud depuis, Noeud vers)
        {
            this.depuis = depuis;
            this.vers = vers;
        }
    }

}
