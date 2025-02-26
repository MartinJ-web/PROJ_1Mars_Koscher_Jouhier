using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Graphe
    {
        List<Noeud> noeuds;
        List<Lien> liens;
        List<List<Noeud>> liste_adjacence;
        int[,] matrice_adjacence;
        

        public Graphe(List<Lien> liens)
        {
            this.liens = liens;
            List<Noeud> noeuds = new List<Noeud>();
            foreach (Lien lien in liens)
            {
                bool depart_existe = false;
                bool arrivee_existe = false;
                foreach(Noeud noeud in noeuds)
                {
                    if(lien.Depart.Equals(noeud))
                    {
                        depart_existe = true;
                    }
                    if(lien.Arrivee.Equals(noeud))
                    {
                        arrivee_existe = true;
                    }
                }
                if(!depart_existe) { noeuds.Add(lien.Depart); }
                if(!arrivee_existe) { noeuds.Add(lien.Arrivee); }
            }
            Tri(noeuds);
            this.noeuds = noeuds;
            List<List<Noeud>> liste_adjacence = new List<List<Noeud>>();
            for (int i = 0; i < noeuds.Count; i++)
            {
                List<Noeud> adjacence = new List<Noeud>();
                foreach (Lien lien in liens)
                {
                    if (lien.Depart.Equals(noeuds[i]))
                    {
                        adjacence.Add(lien.Arrivee);
                    }
                    if (lien.Arrivee.Equals(noeuds[i]))
                    {
                        adjacence.Add(lien.Depart);
                    }
                }
                liste_adjacence.Add(adjacence);
            }
            this.liste_adjacence = liste_adjacence;

            int[,] matrice_adjacence = new int[noeuds.Count, noeuds.Count];
            for (int i = 0; i < liste_adjacence.Count; i++)
            {
                for (int j = 0; j < liste_adjacence[i].Count; j++)
                {
                    int indice = -1;
                    for(int k = 0; k < noeuds.Count; k++)
                    {
                        if (liste_adjacence[i][j].Equals(noeuds[k]))
                        {
                            indice = k;
                            break;
                        }
                    }
                    matrice_adjacence[i, indice] = 1;
               }
            }
            this.matrice_adjacence = matrice_adjacence;
        }

        public void Tri(List<Noeud> noeuds, int debut = int.MaxValue, int fin = int.MinValue)
        {
            if(debut == int.MaxValue && fin == int.MinValue)
            {
                debut = 0;
                fin = noeuds.Count - 1;
            }
            if(debut<fin)
            {
                int milieu = (debut + fin) / 2;
                Tri(noeuds, debut, milieu);
                Tri(noeuds, milieu + 1, fin);
                Fusion(noeuds, debut, milieu, fin);
            }
        }
        public void Fusion(List<Noeud> noeuds, int debut, int milieu, int fin)
        {
            if (debut < fin)
            {
                Noeud[] gauche = new Noeud[milieu - debut + 1];
                Noeud[] droite = new Noeud[fin - milieu];

                int indG = 0;
                int indD = 0;

                for (int i = 0; i < gauche.Length; i++)
                {
                    gauche[i] = noeuds[i + debut];
                }
                for (int i = 0; i < droite.Length; i++)
                {
                    droite[i] = noeuds[i + milieu + 1];
                }
                for (int i = debut; i <= fin; i++)
                {
                    if ((indD < droite.Length) && (indG < gauche.Length))
                    {
                        bool nombres = int.TryParse(noeuds[0].Nom, out int nom);
                        if (nombres)
                        {
                            if (Convert.ToInt32(gauche[indG].Nom) < Convert.ToInt32(droite[indD].Nom))
                            {
                                noeuds[i] = gauche[indG++];
                            }
                            else
                            {
                                noeuds[i] = droite[indD++];
                            }
                        }
                        else
                        {
                            if (gauche[indG].Nom.CompareTo(droite[indD].Nom) < 0)
                            {
                                noeuds[i] = gauche[indG++];
                            }
                            else
                            {
                                noeuds[i] = droite[indD++];
                            }
                        }
                    }
                    else if (indD >= droite.Length) noeuds[i] = gauche[indG++];
                    else if (indG >= gauche.Length) noeuds[i] = droite[indD++];


                }

            }
        }

        public void ToString()
        {
            Console.WriteLine("Liste d'adjacence :\n");
            for(int i = 0; i < liste_adjacence.Count; i++)
            {
                Console.Write(noeuds[i].Nom + " : ");
                for (int j = 0; j < liste_adjacence[i].Count; j++)
                {
                    Console.Write( liste_adjacence[i][j].Nom + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");

            Console.WriteLine("Matrice d'adjacence : \n");
            for (int i = 0; i < matrice_adjacence.GetLength(0); i++)
            {
                for (int j = 0; j < matrice_adjacence.GetLength(1); j++)
                {
                    Console.Write(matrice_adjacence[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        //public List<Noeud> DFS(Noeud depart)
        //{

        //}
    }
}
