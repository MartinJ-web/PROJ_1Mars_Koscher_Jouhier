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
        /// <summary>
        /// Attribbuts pour la classe Noeud
        /// </summary>
        string nom;
        string pred;
        float x;
        float y;

        /// <summary>
        /// Constructeur à partir du nom du lien
        /// Si besoin, possibilité d'ajouter un attribut numéro (pour avoir un nom et un identifiant au lien)
        /// </summary>
        /// <param name="nom"> Nom du noeud </param>
        public Noeud(string nom)
        {
            this.nom = nom;
        }
        
        /// <summary>
        /// Propriété pour le nom du noeud
        /// </summary>
        public string Nom
        {
            get { return nom; }
        }

        /// <summary>
        /// Propriétés pour le prédecesseur du noeud
        /// </summary>
        public string Pred
        {
            get { return pred; }
            set { pred = value; }
        }
  
        /// <summary>
        /// Propriété pour la coordonnée x du noeud
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Propriété pour la coordonnée y du noeud
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }


        /// <summary>
        /// Methode ToStrong pour un noeud
        /// Possibilité de retourner le numero du lien s'il existe
        /// </summary>
        /// <returns> nom du lien (et numero) s</returns>
        public string ToString()
        {
            return nom; 
        }
    }
}
