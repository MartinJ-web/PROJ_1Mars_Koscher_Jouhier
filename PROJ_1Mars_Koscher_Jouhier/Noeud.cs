using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Noeud
    {
        int numero;

        public Noeud(int numero)
        {
            this.numero = numero;
        }

        public int Numero
        {
            get { return numero; }
        }
    }
}
