using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;


namespace PROJ_1Mars_Koscher_Jouhier
{
    public class Noeud
    {
        /// <summary>
        /// Attribbuts pour la classe Noeud
        /// </summary>
        int numero;
        string nom;
        int pred;
        float x;
        float y;


        public Noeud(int numero, string nom, float x, float y)
        {
            this.numero = numero;
            this.nom = nom;
            this.x = x;
            this.y = y;
        }



        /// <summary>
        /// Constructeur à partir du numero du lien
        /// </summary>
        /// <param name="numero"> numero du noeud </param>
        public Noeud(int numero)
        {
            this.numero = numero;
        }
        
        /// <summary>
        /// Propriété pour le numero du noeud
        /// </summary>
        public int Numero
        {
            get { return numero; }
        }

        public string Nom
        {
            get { return nom; }
        }

        /// <summary>
        /// Propriétés pour le prédecesseur du noeud
        /// </summary>
        public int Pred
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
        /// Methode ToString pour un noeud
        /// </summary>
        /// <returns> Numero du lien s</returns>
        public string toString()
        {
            return Convert.ToString(numero); 
        }
    }
}