﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Lien
    {
        /// <summary>
        /// Attributs pour la classe lien
        /// </summary>
        Noeud depart;
        Noeud arrivee;

        /// <summary>
        /// Constructeur naturel pour la classe lien
        /// </summary>
        /// <param name="depart"> Noeud de depart du lien </param>
        /// <param name="arrivee"> Noeud d'arrivee du lien </param>
        public Lien(Noeud depart, Noeud arrivee)
        {
            this.depart = depart;
            this.arrivee = arrivee;
        }

        /// <summary>
        /// Propriété pour le noeud de départ du lien
        /// </summary>
        public Noeud Depart
        {
            get { return depart; }
        }

        /// <summary>
        /// Propriété pour le noeud d'arrivée du lien
        /// </summary>
        public Noeud Arrivee
        {
            get { return arrivee; }
        }

        /// <summary>
        /// Identifie si deux liens sont egaux
        /// </summary>
        /// <param name="lien"> Lien à comparer avec l'instance actuelle </param>
        /// <returns> True si les liens sont égaux </returns>
        public bool Equals(Lien lien)
        {

            return (this.depart == lien.depart && this.arrivee == lien.arrivee) || (this.depart == lien.arrivee && this.arrivee == lien.depart);
        }
    }

}
