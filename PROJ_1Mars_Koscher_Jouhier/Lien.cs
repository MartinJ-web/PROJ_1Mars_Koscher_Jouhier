using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    public class Lien<T>
    {
        /// <summary>
        /// Attributs pour la classe lien
        /// </summary>
        Noeud<T> depart;
        Noeud<T> arrivee;
        int poids;
        bool sens;

        /// <summary>
        /// Constructeur naturel pour la classe lien
        /// </summary>
        /// <param name="depart"> Noeud de depart du lien </param>
        /// <param name="arrivee"> Noeud d'arrivee du lien </param>
        public Lien(Noeud<T> depart, Noeud<T> arrivee)
        {
            this.depart = depart;
            this.arrivee = arrivee;
            poids = 1;
            sens = false;
        }
        public Lien(Noeud<T> depart, Noeud<T> arrivee, int poids, bool sens)
        {
            this.depart = depart;
            this.arrivee = arrivee;
            this.poids = poids;
            this.sens = sens;
        }

        /// <summary>
        /// Propriété pour le noeud de départ du lien
        /// </summary>
        public Noeud<T> Depart
        {
            get { return depart; }
        }

        /// <summary>
        /// Propriété pour le noeud d'arrivée du lien
        /// </summary>
        public Noeud<T> Arrivee
        {
            get { return arrivee; }
        }


        public int Poids
        {
            get { return poids; }
        }

        public bool Sens
        {
            get { return sens; }
        }

        /// <summary>
        /// Identifie si deux liens sont egaux
        /// </summary>
        /// <param name="lien"> Lien à comparer avec l'instance actuelle </param>
        /// <returns> True si les liens sont égaux </returns>
        public bool Equals(Lien<T> lien)
        {

            return (this.depart == lien.depart && this.arrivee == lien.arrivee) || (this.depart == lien.arrivee && this.arrivee == lien.depart);
        }
    }

}
