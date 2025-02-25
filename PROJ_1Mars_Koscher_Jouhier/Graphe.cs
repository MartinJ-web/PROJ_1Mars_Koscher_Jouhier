using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Graphe
    {
        List<List<Noeud>> liste_adjacence;
        int[,] matrice_adjacence;

        public Graphe()
        {
            string[] lignes = File.ReadAllLines("PROJ_Lien_Karate.txt");
            int max = int.MinValue;
            foreach (string ligne in lignes)
            {
                string[] noeuds = ligne.Split(' ');
                for (int i = 0; i < noeuds.Length; i++)
                {
                    if (Convert.ToInt32(noeuds[i]) > max)
                    {
                        max = Convert.ToInt32(noeuds[i]);
                    }
                }
            }
            List<List<Noeud>> liste_adjacence = new List<List<Noeud>>();
            for (int i = 1; i <= max; i++)
            {
                List<Noeud> adjacence = new List<Noeud>();
                foreach (string ligne in lignes)
                {
                    string[] lien = new string[2];
                    lien = ligne.Split(' ');
                    if (Convert.ToInt32(lien[0]) == i)
                    {
                        Noeud noeud_adjacent = new Noeud(Convert.ToInt32(lien[1]));
                        adjacence.Add(noeud_adjacent);
                    }
                    if (Convert.ToInt32(lien[1]) == i)
                    {
                        Noeud noeud_adjacent = new Noeud(Convert.ToInt32(lien[0]));
                        adjacence.Add(noeud_adjacent);
                    }
                }
                liste_adjacence.Add(adjacence);
            }
            this.liste_adjacence = liste_adjacence;

            int[,] matrice_adjacence = new int[34, 34];
            for (int i = 0; i < liste_adjacence.Count; i++)
            {
                for (int j = 0; j < liste_adjacence[i].Count; j++)
                {
                    matrice_adjacence[i, liste_adjacence[i][j].Numero - 1] = 1;
                }
            }
            this.matrice_adjacence = matrice_adjacence;
        }

        public void ToString()
        {
            Console.WriteLine("Liste d'adjacence :\n");
            for(int i = 0; i < liste_adjacence.Count; i++)
            {
                for(int j = 0; j < liste_adjacence[i].Count; j++)
                {
                    Console.Write(liste_adjacence[i][j].Numero + " ");
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
    }
}
