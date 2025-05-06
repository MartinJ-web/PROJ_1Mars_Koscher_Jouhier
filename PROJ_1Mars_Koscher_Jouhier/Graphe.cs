using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PROJ_1Mars_Koscher_Jouhier;
using SkiaSharp;


namespace PROJ_1Mars_Koscher_Jouhier
{
    public class Graphe<T>
    {
        /// <summary>
        /// Attributs pour la classe graphe
        /// </summary>
        List<Noeud<T>> noeuds;
        List<Lien<T>> liens;
        List<List<Noeud<T>>> liste_adjacence;
        int[,] matrice_adjacence;

        /// <summary>
        /// Constructeur pour la classe graphe un graphe à partir d'une liste de noeuds et d'un tableau de lien 
        /// </summary>
        /// <param name="noeuds"> Liste des noeuds du graphe </param>
        /// <param name="lignes"> Tableau de liens </param>
        public Graphe(List<Noeud<T>> noeuds, string[] lignes)
        {
            this.noeuds = noeuds;
            Tri(noeuds);
            List<Lien<T>> liens = new List<Lien<T>>();
            for (int i = 0; i < lignes.Length; i++)
            {
                string[] ligne = lignes[i].Split(" ");
                if (ligne.Length == 4)
                {
                    Lien<T> lien = new Lien<T>(noeuds[Convert.ToInt32(ligne[0]) - 1], noeuds[Convert.ToInt32(ligne[1]) - 1], Convert.ToInt32(ligne[2]), true);
                    liens.Add(lien);
                }
                else if (ligne.Length == 3)
                {
                    Lien<T> lien = new Lien<T>(noeuds[Convert.ToInt32(ligne[0]) - 1], noeuds[Convert.ToInt32(ligne[1]) - 1], Convert.ToInt32(ligne[2]), false);
                    liens.Add(lien);
                }
                else
                {
                    Lien<T> lien = new Lien<T>(noeuds[Convert.ToInt32(ligne[0]) - 1], noeuds[Convert.ToInt32(ligne[1]) - 1]);
                    liens.Add(lien);
                }
            }

            this.liens = liens;
            List<List<Noeud<T>>> liste_adjacence = new List<List<Noeud<T>>>();
            for (int i = 0; i < noeuds.Count; i++)
            {
                List<Noeud<T>> adjacence = new List<Noeud<T>>();
                foreach (Lien<T> lien in liens)
                {
                    if (lien.Depart.Equals(noeuds[i]))
                    {
                        adjacence.Add(lien.Arrivee);
                    }
                    if (!lien.Sens && lien.Arrivee.Equals(noeuds[i]) && lien.Arrivee != lien.Depart)
                    {
                        adjacence.Add(lien.Depart);
                    }
                }
                Tri(adjacence);
                liste_adjacence.Add(adjacence);
            }
            this.liste_adjacence = liste_adjacence;

            int[,] matrice_adjacence = new int[noeuds.Count, noeuds.Count];
            foreach (Lien<T> lien in liens)
            {
                matrice_adjacence[lien.Depart.Numero - 1, lien.Arrivee.Numero - 1] = lien.Poids;
                if (!lien.Sens)
                {
                    matrice_adjacence[lien.Arrivee.Numero - 1, lien.Depart.Numero - 1] = lien.Poids;
                }

            }
            this.matrice_adjacence = matrice_adjacence;
        }

        /// <summary>
        /// Constructeur pour la classe graphe à partir d'un tableau de liens
        /// La différence par rapport au constructeur précedent est la création des noeuds à partir des liens (pas d'infos supplémentaire que le numéro)
        /// Les parties sur les liste d'adjacence et les matrices d'adjacence sont similaires
        /// </summary>
        /// <param name="lignes"> Tableau de liens </param>
        public Graphe(string[] lignes)
        {
            List<string> nom_noeuds = new List<string>();
            List<Noeud<T>> noeuds = new List<Noeud<T>>();
            List<Lien<T>> liens = new List<Lien<T>>();
            foreach (string ligne in lignes)
            {
                Noeud<T> noeud_depart;
                Noeud<T> noeud_arrivee;
                string[] lien_tab = ligne.Split(" ");
                if (!nom_noeuds.Contains(lien_tab[0]))
                {
                    nom_noeuds.Add(lien_tab[0]);
                    noeud_depart = new Noeud<T>(Convert.ToInt32(lien_tab[0]));
                    noeuds.Add(noeud_depart);
                }
                else
                {
                    int index = -1;
                    for (int i = 0; i < noeuds.Count; i++)
                    {
                        if (noeuds[i].Numero == Convert.ToInt32(lien_tab[0]))
                        {
                            index = i;
                        }
                    }
                    noeud_depart = noeuds[index];
                }
                if (!nom_noeuds.Contains(lien_tab[1]))
                {
                    nom_noeuds.Add(lien_tab[1]);
                    noeud_arrivee = new Noeud<T>(Convert.ToInt32(lien_tab[1]));
                    noeuds.Add(noeud_arrivee);
                }
                else
                {
                    int index = -1;
                    for (int i = 0; i < noeuds.Count; i++)
                    {
                        if (noeuds[i].Numero == Convert.ToInt32(lien_tab[1]))
                        {
                            index = i;
                        }
                    }
                    noeud_arrivee = noeuds[index];
                }
                if (lien_tab.Length == 4)
                {
                    Lien<T> lien = new Lien<T>(noeud_depart, noeud_arrivee, Convert.ToInt32(lien_tab[2]), true);
                    liens.Add(lien);
                }
                else if (lien_tab.Length == 3)
                {
                    Lien<T> lien = new Lien<T>(noeud_depart, noeud_arrivee, Convert.ToInt32(lien_tab[2]), false);
                    liens.Add(lien);
                }
                else
                {
                    Lien<T> lien = new Lien<T>(noeud_depart, noeud_arrivee);
                    liens.Add(lien);
                }
            }
            Tri(noeuds);
            this.noeuds = noeuds;
            this.liens = liens;
            List<List<Noeud<T>>> liste_adjacence = new List<List<Noeud<T>>>();
            for (int i = 0; i < noeuds.Count; i++)
            {
                List<Noeud<T>> adjacence = new List<Noeud<T>>();
                foreach (Lien<T> lien in liens)
                {
                    if (lien.Depart.Equals(noeuds[i]))
                    {
                        adjacence.Add(lien.Arrivee);
                    }
                    if (!lien.Sens && lien.Arrivee.Equals(noeuds[i]) && lien.Arrivee != lien.Depart)
                    {
                        adjacence.Add(lien.Depart);
                    }
                }
                Tri(adjacence);
                liste_adjacence.Add(adjacence);
            }
            this.liste_adjacence = liste_adjacence;

            int[,] matrice_adjacence = new int[noeuds.Count, noeuds.Count];
            Console.WriteLine(noeuds.Count);
            foreach (Lien<T> lien in liens)
            {
                matrice_adjacence[lien.Depart.Numero - 1, lien.Arrivee.Numero - 1] = lien.Poids;
                if (!lien.Sens)
                {
                    matrice_adjacence[lien.Arrivee.Numero - 1, lien.Depart.Numero - 1] = lien.Poids;
                }
            }
            this.matrice_adjacence = matrice_adjacence;
        }

        /// <summary>
        /// Constructeur pour la classe graphe à partir d'une liste de liens
        /// </summary>
        /// <param name="liens"> Liste de liens </param>
        public Graphe(List<Lien<T>> liens)
        {
            this.liens = liens;
            List<Noeud<T>> noeuds = new List<Noeud<T>>();
            foreach (Lien<T> lien in liens)
            {
                if (!noeuds.Contains(lien.Depart))
                {
                    noeuds.Add(lien.Depart);
                }
                if(!noeuds.Contains(lien.Arrivee))
                {
                    noeuds.Add(lien.Arrivee);
                }
            }
            this.noeuds = noeuds;
            List<List<Noeud<T>>> liste_adjacence = new List<List<Noeud<T>>>();
            for (int i = 0; i < noeuds.Count; i++)
            {
                List<Noeud<T>> adjacence = new List<Noeud<T>>();
                foreach (Lien<T> lien in liens)
                {
                    if (lien.Depart.Equals(noeuds[i]))
                    {
                        adjacence.Add(lien.Arrivee);
                    }
                    if (!lien.Sens && lien.Arrivee.Equals(noeuds[i]) && lien.Arrivee != lien.Depart)
                    {
                        adjacence.Add(lien.Depart);
                    }
                }
                Tri(adjacence);
                liste_adjacence.Add(adjacence);
            }
            this.liste_adjacence = liste_adjacence;

            int[,] matrice_adjacence = new int[noeuds.Count, noeuds.Count];
            Console.WriteLine(noeuds.Count);
            foreach (Lien<T> lien in liens)
            {
                matrice_adjacence[lien.Depart.Numero - 1, lien.Arrivee.Numero - 1] = lien.Poids;
                if (!lien.Sens)
                {
                    matrice_adjacence[lien.Arrivee.Numero - 1, lien.Depart.Numero - 1] = lien.Poids;
                }
            }
            this.matrice_adjacence = matrice_adjacence;
        }

        /// <summary>
        /// Propiété pour la liste de noeuds du graphe
        /// </summary>
        public List<Noeud<T>> Noeuds
        {
            get { return noeuds; }
        }

        /// <summary>
        /// Propriété pour la liste de lien du graphe
        /// </summary>
        public List<Lien<T>> Liens
        {
            get { return liens; }
        }

        /// <summary>
        /// Permet de trier la liste de noeuds et la liste d'adjacence numériquement
        /// </summary>
        /// <param name="noeuds"> Liste de noeuds à trier </param>
        /// <param name="debut"> Début de la liste à trier </param>
        /// <param name="fin"> Fin de la liste de noeud à trier </param>
        public void Tri(List<Noeud<T>> noeuds, int debut = int.MaxValue, int fin = int.MinValue)
        {
            if (debut == int.MaxValue && fin == int.MinValue)
            {
                debut = 0;
                fin = noeuds.Count - 1;
            }
            if (debut < fin)
            {
                int milieu = (debut + fin) / 2;
                Tri(noeuds, debut, milieu);
                Tri(noeuds, milieu + 1, fin);
                Fusion(noeuds, debut, milieu, fin);
            }
        }

        /// <summary>
        /// Partie récursive du tri mentionné précedemment
        /// </summary>
        /// <param name="noeuds"> Liste de noeuds à trier </param>
        /// <param name="debut"> Début de la liste à trier </param>
        /// <param name="milieu"> Milieu de la liste de noeud à trier </param>
        /// <param name="fin"> Fin de la liste de noeud à trier </param>
        public void Fusion(List<Noeud<T>> noeuds, int debut, int milieu, int fin)
        {
            if (debut < fin)
            {
                Noeud<T>[] gauche = new Noeud<T>[milieu - debut + 1];
                Noeud<T>[] droite = new Noeud<T>[fin - milieu];

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
                        if (Convert.ToInt32(gauche[indG].Numero) < Convert.ToInt32(droite[indD].Numero))
                        {
                            noeuds[i] = gauche[indG++];
                        }
                        else
                        {
                            noeuds[i] = droite[indD++];
                        }
                    }
                    else if (indD >= droite.Length) noeuds[i] = gauche[indG++];
                    else if (indG >= gauche.Length) noeuds[i] = droite[indD++];
                }

            }
        }

        /// <summary>
        /// Donne les plus courts chemins depuis un noeud de départ grace à dijkstra
        /// </summary>
        /// <param name="noeud_depart"> Noeud de départ pour les plus courts chemin </param>
        /// <returns> tableau des plus courtes distances pour chaque noeuds </returns>
        public int[] Dijkstra(Noeud<T> noeud_depart)
        {
            List<Noeud<T>> sommets_visites = new List<Noeud<T>>();
            List<Noeud<T>> sommets_traites = new List<Noeud<T>>();
            int[] distances = new int[noeuds.Count];
            for (int i = 0; i < noeuds.Count; i++)
            {
                if (noeuds[i] == noeud_depart)
                {
                    distances[i] = 0;
                }
                else
                {
                    distances[i] = int.MaxValue;
                }
            }
            Noeud<T> noeud_actuel = noeud_depart;
            sommets_visites.Add(noeud_actuel);
            while (sommets_traites.Count < sommets_visites.Count)
            {
                sommets_traites.Add(noeud_actuel);
                for (int i = 0; i < noeuds.Count; i++)
                {
                    if (!sommets_traites.Contains(noeuds[i]) && matrice_adjacence[noeud_actuel.Numero - 1, noeuds[i].Numero - 1] > 0)
                    {
                        
                        if (!sommets_visites.Contains(noeuds[i]))
                        {
                            sommets_visites.Add(noeuds[i]);
                            distances[i] = matrice_adjacence[noeud_actuel.Numero - 1, noeuds[i].Numero - 1] + distances[noeud_actuel.Numero - 1];
                            noeuds[i].Pred = noeud_actuel.Numero;
                        }
                        else
                        {
                            if (distances[i] > matrice_adjacence[noeud_actuel.Numero - 1, noeuds[i].Numero - 1] + distances[noeud_actuel.Numero - 1])
                            {
                                distances[i] = matrice_adjacence[noeud_actuel.Numero - 1, noeuds[i].Numero - 1] + distances[noeud_actuel.Numero - 1];
                                noeuds[i].Pred = noeud_actuel.Numero;
                            }
                        }
                    }
                }
                int min = int.MaxValue;
                foreach (Noeud<T> noeud in sommets_visites)
                {
                    if (!sommets_traites.Contains(noeud) && distances[noeud.Numero - 1] < min)
                    {
                        noeud_actuel = noeud;
                        min = distances[noeud.Numero - 1];
                    }
                }
            }
            return distances;
        }

        /// <summary>
        /// Donne le pcc trouvé avec dijkstra
        /// </summary>
        /// <param name="noeud_depart"> noeud de départ pour le pcc </param>
        /// <param name="noeud_arrivee"> noeud d'arrivée pour le pcc </param>
        /// <returns> une liste qui correspond au chemin parcouru </returns>
        public List<Noeud<T>> PCC_Dijkstra(Noeud<T> noeud_depart, Noeud<T> noeud_arrivee)
        {
            List<Noeud<T>> predecesseursN = new List<Noeud<T>>();
            if (Chemin(noeud_arrivee, noeud_depart))
            {
                List<int> predecesseurs = new List<int>();
                Dijkstra(noeud_arrivee);
                int predecesseur = noeud_depart.Numero;
                while (predecesseur != noeud_arrivee.Numero)
                {
                    predecesseurs.Add(predecesseur);
                    predecesseur = noeuds[predecesseur - 1].Pred;
                }
                predecesseurs.Add(noeud_arrivee.Numero);
                foreach (int i in predecesseurs)
                {
                    predecesseursN.Add(noeuds[i - 1]);
                }
            }
            else
            {
                predecesseursN = null;
            }
            return predecesseursN;
        }

        /// <summary>
        /// Donne les plus courts chemins depuis un noeud de départ grace à Bellman ford
        /// </summary>
        /// <param name="noeud_depart"> Noeud de départ pour les plus courts chemin </param>
        /// <returns> tableau des plus courtes distances pour chaque noeuds </returns>
        public int[] BellmanFord(Noeud<T> noeud_depart)
        {
            int n = noeuds.Count;
            int[] distances = new int[n];
            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[noeud_depart.Numero - 1] = 0;
            for (int i = 0; i < n - 1; i++)
            {
                foreach (Lien<T> lien in liens)
                {
                    if(lien.Sens == true)
                    {
                        if (distances[lien.Depart.Numero - 1] != int.MaxValue && distances[lien.Depart.Numero - 1] + lien.Poids < distances[lien.Arrivee.Numero - 1])
                        {
                            distances[lien.Arrivee.Numero - 1] = distances[lien.Depart.Numero - 1] + lien.Poids;
                            lien.Arrivee.Pred = lien.Depart.Numero;
                        }
                    }
                    else
                    {
                        if (distances[lien.Depart.Numero - 1] != int.MaxValue && distances[lien.Depart.Numero - 1] + lien.Poids < distances[lien.Arrivee.Numero - 1])
                        {
                            distances[lien.Arrivee.Numero - 1] = distances[lien.Depart.Numero - 1] + lien.Poids;
                            lien.Arrivee.Pred = lien.Depart.Numero;
                        }
                        else if (distances[lien.Arrivee.Numero - 1] != int.MaxValue && distances[lien.Arrivee.Numero - 1] + lien.Poids < distances[lien.Depart.Numero - 1])
                        {
                            distances[lien.Depart.Numero - 1] = distances[lien.Arrivee.Numero - 1] + lien.Poids;
                            lien.Depart.Pred = lien.Arrivee.Numero;
                        }
                    }
                }
            }
            foreach (Lien<T> lien in liens)
            {
                if (lien.Sens == true)
                {
                    if (distances[lien.Depart.Numero - 1] != int.MaxValue && distances[lien.Depart.Numero - 1] + lien.Poids < distances[lien.Arrivee.Numero - 1])
                    {
                        return null;
                    }
                }
                else
                {
                    if (distances[lien.Depart.Numero - 1] != int.MaxValue && distances[lien.Depart.Numero - 1] + lien.Poids < distances[lien.Arrivee.Numero - 1])
                    {
                        return null;
                    }
                    else if (distances[lien.Arrivee.Numero - 1] != int.MaxValue && distances[lien.Arrivee.Numero - 1] + lien.Poids < distances[lien.Depart.Numero - 1])
                    {
                        return null;
                    }
                }
            }
            return distances;
        }

        /// <summary>
        /// Donne le pcc trouvé avec Bellman ford
        /// </summary>
        /// <param name="noeud_depart"> noeud de départ pour le pcc </param>
        /// <param name="noeud_arrivee"> noeud d'arrivée pour le pcc </param>
        /// <returns> une liste qui correspond au chemin parcouru </returns>
        public List<Noeud<T>> PCC_BellmanFord(Noeud<T> noeud_depart, Noeud<T> noeud_arrivee)
        {
            List<Noeud<T>> predecesseursN = new List<Noeud<T>>();
            if (Chemin(noeud_arrivee, noeud_depart) && BellmanFord(noeud_arrivee) != null)
            {
                List<int> predecesseurs = new List<int>();
                int predecesseur = noeud_depart.Numero;
                while (predecesseur != noeud_arrivee.Numero)
                {
                    predecesseurs.Add(predecesseur);
                    predecesseur = noeuds[predecesseur - 1].Pred;
                }
                predecesseurs.Add(noeud_arrivee.Numero);
                foreach (int i in predecesseurs)
                {
                    predecesseursN.Add(noeuds[i - 1]);
                }
            }
            else
            {
                predecesseursN = null;
            }
            return predecesseursN;
        }

        /// <summary>
        /// Donne les plus courts chemins depuis un noeud de départ grace à Floyd Warshall
        /// </summary>
        /// <param name="noeud_depart"> Noeud de départ pour les plus courts chemin </param>
        /// <returns> tableau des plus courtes distances pour chaque noeuds </returns>
        public int[] FloydWarshall(Noeud<T> noeud_depart)
        {
            int n = noeuds.Count();
            int[,] w = new int[n, n];
            int[,] pred = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i != j && matrice_adjacence[i, j] == 0)
                    {
                        w[i, j] = int.MaxValue;
                    }
                    else
                    {
                        w[i, j] = matrice_adjacence[i,j];
                    }
                    if (i != j && matrice_adjacence[i, j] != int.MaxValue)
                    {
                        pred[i, j] = i + 1;
                    }
                }
            }
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (w[i, k] != int.MaxValue && w[k, j] != int.MaxValue)
                        {
                            int distance = w[i, k] + w[k, j];
                            if (distance < w[i, j])
                            {
                                w[i, j] = distance;
                                pred[i, j] = pred[k, j];
                            }
                        }
                    }
                }
            }
            int[] distances = new int[n];
            for (int i = 0; i < n; i++)
            {
                distances[i] = w[noeud_depart.Numero - 1, i];
                noeuds[i].Pred = pred[noeud_depart.Numero - 1, i];
            }

            return distances;
        }

        /// <summary>
        /// Donne le pcc trouvé avec floyd warshall
        /// </summary>
        /// <param name="noeud_depart"> noeud de départ pour le pcc </param>
        /// <param name="noeud_arrivee"> noeud d'arrivée pour le pcc </param>
        /// <returns> une liste qui correspond au chemin parcouru </returns>
        public List<Noeud<T>> PCC_FloydWarshall(Noeud<T> noeud_depart, Noeud<T> noeud_arrivee)
        {
            List<Noeud<T>> predecesseursN = new List<Noeud<T>>();
            if (Chemin(noeud_arrivee, noeud_depart))
            {
                List<int> predecesseurs = new List<int>();
                FloydWarshall(noeud_arrivee);
                int predecesseur = noeud_depart.Numero;
                while (predecesseur != noeud_arrivee.Numero)
                {
                    predecesseurs.Add(predecesseur);
                    predecesseur = noeuds[predecesseur - 1].Pred;
                }
                predecesseurs.Add(noeud_arrivee.Numero);
                foreach (int i in predecesseurs)
                {
                    predecesseursN.Add(noeuds[i - 1]);
                }
            }
            else
            {
                predecesseursN = null;
            }
            return predecesseursN;
        }

        /// <summary>
        /// Coloration de graphe avec Welsh-Powell, attribut un numéro de couleur à chaque noeuds
        /// </summary>
        /// <returns> Tableau des couleurs pour chaque noeuds </returns>
        public int[] CouleursWelshPowell()
        {
            int[] degres_sommets = new int[noeuds.Count()];
            for (int i = 0; i < noeuds.Count; i++)
            {
                int degre = 0;
                for (int j = 0; j < noeuds.Count; j++)
                {
                    degre += matrice_adjacence[i, j];
                }
                degres_sommets[noeuds[i].Numero - 1] = degre;
            }
            List<Noeud<T>> sommets = new List<Noeud<T>>();
            for (int i = 0; i < noeuds.Count; i++)
            {
                sommets.Add(noeuds[i]);
            }
            for (int i = 0; i < sommets.Count - 1; i++)
            {
                for (int j = 0; j < sommets.Count - i - 1; j++)
                {
                    if (degres_sommets[noeuds[j].Numero - 1] < degres_sommets[noeuds[j + 1].Numero - 1])
                    {
                        Noeud<T> temp = sommets[j];
                        sommets[j] = sommets[j + 1];
                        sommets[j + 1] = temp;
                    }
                }
            }
            int couleur = -1;
            int[] couleur_par_noeud = new int[Noeuds.Count()];
            while (sommets.Count > 0)
            {
                couleur++;
                List<Noeud<T>> voisins = new List<Noeud<T>>();
                Noeud<T> x = sommets[0];
                couleur_par_noeud[x.Numero - 1] = couleur;
                sommets.RemoveAt(0);
                voisins = liste_adjacence[x.Numero - 1];
                int i = 0;
                while (i < sommets.Count)
                {
                    Noeud<T> s = sommets[i];
                    bool estVoisin = false;
                    for (int j = 0; j < voisins.Count; j++)
                    {
                        if (voisins[j].Equals(s))
                        {
                            estVoisin = true;
                            break;
                        }
                    }
                    if (!estVoisin)
                    {
                        couleur_par_noeud[s.Numero - 1] = couleur;
                        List<Noeud<T>> voisins_s = liste_adjacence[s.Numero - 1];
                        for (int k = 0; k < voisins_s.Count; k++)
                        {
                            if (!voisins.Contains(voisins_s[k]))
                            {
                                voisins.Add(voisins_s[k]);
                            }
                        }
                        sommets.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return couleur_par_noeud;
        }

        /// <summary>
        /// Colore le graphe avec Welsh-Powell
        /// </summary>
        /// <returns> Nombre de couleurs necessaires pour colorer le graphe </returns>
        public int WelshPowell()
        {
            int[] degres_sommets = new int[noeuds.Count()];
            for (int i = 0; i < noeuds.Count; i++)
            {
                int degre = 0;
                for (int j = 0; j < noeuds.Count; j++)
                {
                    degre += matrice_adjacence[i, j];
                }
                degres_sommets[noeuds[i].Numero - 1] = degre;
            }
            List<Noeud<T>> sommets = new List<Noeud<T>>();
            for (int i = 0; i < noeuds.Count; i++)
            {
                sommets.Add(noeuds[i]);
            }
            for (int i = 0; i < sommets.Count - 1; i++)
            {
                for (int j = 0; j < sommets.Count - i - 1; j++)
                {
                    if (degres_sommets[noeuds[j].Numero - 1] < degres_sommets[noeuds[j + 1].Numero - 1])
                    {
                        Noeud<T> temp = sommets[j];
                        sommets[j] = sommets[j + 1];
                        sommets[j + 1] = temp;
                     }
                }
            }
            int couleur = 0;
            Dictionary<Noeud<T>, int> couleur_par_noeud = new Dictionary<Noeud<T>, int>();
            while (sommets.Count > 0)
            {
                couleur++;

                List<Noeud<T>> voisins = new List<Noeud<T>>();
                Noeud<T> x = sommets[0];
                couleur_par_noeud.Add(x, couleur);
                sommets.RemoveAt(0);
                voisins = liste_adjacence[x.Numero - 1];
                int i = 0;
                while (i < sommets.Count)
                {
                    Noeud<T> s = sommets[i];

                    bool estVoisin = false;
                    for (int j = 0; j < voisins.Count; j++)
                    {
                        if (voisins[j].Equals(s))
                        {
                            estVoisin = true;
                            break;
                        }
                    }
                    if (!estVoisin)
                    {
                        couleur_par_noeud.Add(s, couleur);
                        List<Noeud<T>> voisins_s = liste_adjacence[s.Numero - 1];
                        for (int k = 0; k < voisins_s.Count; k++)
                        {
                            if (!voisins.Contains(voisins_s[k]))
                            {
                                voisins.Add(voisins_s[k]);
                            }
                        }
                        sommets.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return couleur;
        }

        public List<Lien<T>> ChuLiuEdmonds(Noeud<T> racine)
        {
            int[,] matrice_adjacence_2 = new int[matrice_adjacence.GetLength(0), matrice_adjacence.GetLength(1)];
            for (int i = 0; i < matrice_adjacence_2.GetLength(0); i++)
            {
                for (int j = 0; j < matrice_adjacence_2.GetLength(1); j++)
                {
                    if (j == racine.Numero - 1)
                    {
                        matrice_adjacence_2[i, j] = 0;
                    }
                    else
                    {
                        matrice_adjacence_2[i, j] = matrice_adjacence[i, j];
                    }
                }
            }
            List<Lien<T>> P = new List<Lien<T>>();
            foreach (Noeud<T> noeud in noeuds)
            {
                if (noeud == racine)
                    continue;

                Lien<T> arc_minimum = null;
                foreach (Lien<T> lien in Liens)
                {
                    if (lien.Arrivee.Equals(noeud))
                    {
                        if (arc_minimum == null || lien.Poids < arc_minimum.Poids)
                        {
                            arc_minimum = lien;
                        }
                    }
                }

                if (arc_minimum != null)
                P.Add(arc_minimum);
            }
            Graphe<T> G2 = new Graphe<T>(P);
            List<Noeud<T>> circuit = G2.TrouveCircuit();
            if (circuit == null)
            {
                return P;
            }
            else
            {
                List<Noeud<T>> V2 = new List<Noeud<T>>();
                for(int i = 0; i < G2.Noeuds.Count(); i++)
                {
                    V2.Add(G2.Noeuds[i]);
                }
                for(int i = 0)
                foreach (Noeud<T> n in C)
                {
                    V2.Remove(n);
                }

                // Ajout du nouveau sommet vC représentant le cycle contracté
                Noeud<T> vC = new Noeud<T>(-1); // Numéro fictif
                V2.Add(vC);

                // E2 = arcs du graphe contracté
                List<Lien<T>> E2 = new List<Lien<T>>();
                Dictionary<Lien<T>, Lien<T>> correspondance = new Dictionary<Lien<T>, Lien<T>>();

                foreach (Lien<T> e in Liens)
                {
                    bool uInC = C.Contains(e.Depart);
                    bool vInC = C.Contains(e.Arrivee);

                    if (!uInC && !vInC)
                    {
                        // arc extérieur au cycle
                        E2.Add(e);
                        correspondance[e] = e;
                    }
                    else if (!uInC && vInC)
                    {
                        // arc entrant dans le cycle
                        Lien<T> arcMinDestV = P.Find(x => x.Arrivee.Equals(e.Arrivee));
                        int poidsReduit = e.Poids - arcMinDestV.Poids;
                        Lien<T> nouveau = new Lien<T>(e.Depart, vC, poidsReduit);
                        E2.Add(nouveau);
                        correspondance[nouveau] = e;
                    }
                    else if (uInC && !vInC)
                    {
                        // arc sortant du cycle
                        Lien<T> nouveau = new Lien<T>(vC, e.Arrivee, e.Poids);
                        E2.Add(nouveau);
                        correspondance[nouveau] = e;
                    }
                }

                // Création du graphe contracté
                Graphe<T> grapheContracte = new Graphe<T>(V2, E2);

                // Appel récursif sur le graphe contracté
                List<Lien<T>> A2 = grapheContracte.ChuLiuEdmonds(racine.Equals(vC) ? racine : vC);

                // Étape 5 : Reconstruire l'arborescence de G à partir de A2
                List<Lien<T>> A = new List<Lien<T>>();

                // On récupère l’arc de A2 qui arrive sur vC
                Lien<T> arcVersVC = A2.Find(x => x.Arrivee.Equals(vC));
                Lien<T> arcOriginal = correspondance[arcVersVC];
                Noeud<T> sommetDuCycle = arcOriginal.Arrivee;

                // Retirer l’arc (π(v), v) de P qui ferme le cycle
                Lien<T> arcASupprimer = P.Find(x => x.Arrivee.Equals(sommetDuCycle));
                P.Remove(arcASupprimer);

                // Ajouter les arcs du cycle sauf celui retiré
                foreach (Lien<T> l in P)
                {
                    A.Add(l);
                }

                // Ajouter les arcs hors cycle (en les décompressant)
                foreach (Lien<T> l in A2)
                {
                    if (!l.Equals(arcVersVC))
                    {
                        A.Add(correspondance[l]);
                    }
                }

                A.Add(arcOriginal); // Ajouter l’arc remplaçant celui du cycle

                return A;
            }
        }

        /// <summary>
        /// Affiche la liste et la matrice d'adjacence du graphe
        /// </summary>
        public void toString()
        {
            Console.WriteLine("Liste d'adjacence :\n");
            for (int i = 0; i < liste_adjacence.Count; i++)
            {
                Console.Write(noeuds[i].Numero + " : ");
                for (int j = 0; j < liste_adjacence[i].Count - 1; j++)
                {
                    Console.Write(liste_adjacence[i][j].Numero + ", ");
                }
                if (liste_adjacence[i].Count - 1 >= 0)
                {
                    Console.WriteLine(liste_adjacence[i][liste_adjacence[i].Count - 1].Numero);
                }
            }
            Console.WriteLine("");

            Console.WriteLine("Matrice d'adjacence : \n");
            for (int i = 0; i < matrice_adjacence.GetLength(0); i++)
            {
                for (int j = 0; j < matrice_adjacence.GetLength(1); j++)
                {
                    if (matrice_adjacence[i, j] < 10)
                    {
                        Console.Write(" " + matrice_adjacence[i, j] + " ");

                    }
                    else
                    {
                        Console.Write(matrice_adjacence[i, j] + " ");
                    }
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Parcours le graphe en profondeur d'abord
        /// </summary>
        /// <param name="depart"> Noeud à partir duquel le graphe est parcouru </param>
        /// <returns> Liste de noeuds représentant l'ordre dans lequel les noeuds sont découverts </returns>
        public List<Noeud<T>> DFS(Noeud<T> depart)
        {
            List<Noeud<T>> ordre = new List<Noeud<T>>();
            Stack<Noeud<T>> visite = new Stack<Noeud<T>>();
            return DFS_Rec(depart, visite, ordre);
        }

        /// <summary>
        /// Partie récursive du parcours mentionné précedemment
        /// </summary>
        /// <param name="depart"> Noeud à partir duquel le graphe est parcouru </param>
        /// <param name="visite">Liste de noeuds indiquants si les noeuds sont déjà découvets par le parcours </param>
        /// <param name="ordre"> Liste de noeuds représentant l'ordre dans lequel les noeuds sont découverts </param>
        /// <returns> Liste de noeuds représentant l'ordre dans lequel les noeuds sont découverts </returns>
        public List<Noeud<T>> DFS_Rec(Noeud<T> depart, Stack<Noeud<T>> visite, List<Noeud<T>> ordre)
        {
            if (visite.Contains(depart))
            {
                return ordre;
            }
            ordre.Add(depart);
            visite.Push(depart);
            List<Noeud<T>> successeurs = liste_adjacence[Convert.ToInt32(depart.Numero) - 1];
            foreach (Noeud<T> successeur in successeurs)
            {
                DFS_Rec(successeur, visite, ordre);
            }
            return ordre;
        }

        /// <summary>
        /// Parcours le graphe en largeur d'abord
        /// </summary>
        /// <param name="depart"> Noeud à partir duquel le graphe est parcouru </param>
        /// <returns> Liste de noeuds représentant l'ordre dans lequel les noeuds sont découverts </returns>
        public List<Noeud<T>> BFS(Noeud<T> depart)
        {
            List<Noeud<T>> ordre = new List<Noeud<T>>();
            Queue<Noeud<T>> visite = new Queue<Noeud<T>>();
            visite.Enqueue(depart);
            ordre.Add(depart);
            while (visite.Count > 0)
            {
                Noeud<T> suivant = visite.Dequeue();
                List<Noeud<T>> successeurs = liste_adjacence[Convert.ToInt32(suivant.Numero) - 1];
                foreach (Noeud<T> successeur in successeurs)
                {
                    if (!visite.Contains(successeur) && !ordre.Contains(successeur))
                    {
                        visite.Enqueue(successeur);
                    }
                }
                if (!ordre.Contains(suivant))
                {
                    ordre.Add(suivant);
                }
            }
            return ordre;
        }

        /// <summary>
        /// Test si un chemin existe entre deux noeuds
        /// </summary>
        /// <param name="depart"> noeud de départ pour le chemin </param>
        /// <param name="arrivee"> noeud d'arrivé pour le chemin </param>
        /// <returns></returns>
        public bool Chemin(Noeud<T> depart, Noeud<T> arrivee)
        {
            return (BFS(depart).Contains(arrivee));
        }

        /// <summary>
        /// Indique si le graphe est connexe
        /// </summary>
        /// <returns> true si le graphe est connexe </returns>
        public bool EstConnexe()
        {
            return (DFS(noeuds[0]).Count == noeuds.Count);
        }

        /// <summary>
        /// Recherche grce au DFS la présence d'un circuit dans le graphe
        /// </summary>
        /// <returns> Le circuit trouvé ou null si abscence de circuit </returns>
        public List<Noeud<T>> TrouveCircuit()
        {
            foreach (Noeud<T> noeud in noeuds)
            {
                noeud.Pred = -1;
            }
            List<Noeud<T>> circuit = new List<Noeud<T>>();
            Stack<Noeud<T>> visite = new Stack<Noeud<T>>();
            visite.Push(noeuds[0]);
            bool circuit_existe = false;
            while (visite.Count > 0)
            {
                Noeud<T> noeud = visite.Pop();
                if (circuit.Contains(noeud))
                {
                    circuit.Add(noeud);
                    circuit_existe = true;
                    break;
                }
                circuit.Add(noeud);
                List<Noeud<T>> successeurs = liste_adjacence[Convert.ToInt32(noeud.Numero) - 1];
                foreach (Noeud<T> successeur in successeurs)
                {
                    if (successeur.Numero != noeud.Pred)
                    {
                        visite.Push(successeur);
                        successeur.Pred = noeud.Numero;
                    }
                }
            }
            if (circuit_existe)
            {
                int index_depart = circuit.IndexOf(circuit[circuit.Count - 1]);
                List<int> index_a_supprimer = new List<int>();
                for (int i = 0; i < index_depart; i++)
                {
                    index_a_supprimer.Add(i);
                }
                List<int> predecesseurs = new List<int>();
                for (int i = 0; i < circuit.Count; i++)
                {
                    predecesseurs.Add(circuit[i].Pred);
                }
                for (int i = 0; i < predecesseurs.Count - 1; i++)
                {
                    if (predecesseurs.IndexOf(predecesseurs[i]) != i)
                    {
                        for (int j = predecesseurs.IndexOf(predecesseurs[i]); j < i; j++)
                        {
                            if (!index_a_supprimer.Contains(j))
                            {
                                index_a_supprimer.Add(j);
                            }
                        }
                    }
                }
                index_a_supprimer.Sort();
                for (int i = index_a_supprimer.Count - 1; i >= 0; i--)
                {
                    circuit.RemoveAt(index_a_supprimer[i]);
                }
                return circuit;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Génère et ouvre une image représentant le graphe
        /// </summary>
        /// <exception cref="NotSupportedException"> Occure si le système d'exploitation n'est pas reconnu (empêche d'ouvrir l'image) </exception>
        public void AfficheGrapheCercle(bool coloration = false)
        {
            int width = 1080;
            int height = 1080;
            float centerX = width / 2, centerY = height / 2;
            float radius = 450;
            for (int i = 0; i < noeuds.Count; i++)
            {
                float angle = (float)(2 * Math.PI * i / noeuds.Count);
                float x = centerX + radius * (float)Math.Cos(angle);
                float y = centerY + radius * (float)Math.Sin(angle);
                noeuds[i].X = x;
                noeuds[i].Y = y;
            }
            List<SKColor> nodePaints = new List<SKColor>();
            int[] couleurs_noeuds = CouleursWelshPowell();
            if (coloration)
            {
                int nb_couleurs = WelshPowell();
                for (int i = 0; i < nb_couleurs; i++)
                {
                    SKColor color = SKColor.FromHsv(i * 360f / nb_couleurs, 100, 100);
                    nodePaints.Add(color);
                }
            }
            using (var bitmap = new SKBitmap(width, height))
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);

                using (var edgePaint = new SKPaint { Color = SKColors.MediumPurple, StrokeWidth = 3, IsAntialias = true, Style = SKPaintStyle.Stroke })
                using (var nodePaint = new SKPaint { Color = SKColors.LightBlue, IsAntialias = true })
                using (var weightPaint = new SKPaint { Color = SKColors.MediumPurple, IsAntialias = true })
                using (var textPaint2 = new SKPaint { Color = SKColors.Black, TextSize = 16, IsAntialias = true })
                using (var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 20, IsAntialias = true })
                {
                    // Dessiner les arêtes
                    foreach (var lien in liens)
                    {
                        var noeudD = noeuds.Find(n => n.Equals(lien.Depart));
                        var noeudA = noeuds.Find(n => n.Equals(lien.Arrivee));
                        if (noeudD != null && noeudA != null)
                        {
                            canvas.DrawLine(noeudD.X, noeudD.Y, noeudA.X, noeudA.Y, edgePaint);
                        }

                        // Afficher le poids de l'arc
                        float midX = (noeudD.X + noeudA.X) / 2;
                        float midY = (noeudD.Y + noeudA.Y) / 2;
                        float quartX = (noeudD.X + midX) / 2;
                        float quartY = (noeudD.Y + midY) / 2;

                        canvas.DrawRoundRect(quartX - 2, quartY - 19, 22, 22, 4, 4, weightPaint);
                        canvas.DrawText(Convert.ToString(lien.Poids), quartX + 2, quartY - 2, textPaint2);


                        //Afficher le sens de l'arc
                        if (lien.Sens)
                        {
                            float tailleFleche = 10; // Taille de la flèche

                            // Calcul de l'angle de l'arête
                            float angle = (float)Math.Atan2(noeudA.Y - noeudD.Y, noeudA.X - noeudD.X);

                            // Calcul des points de la flèche
                            float flecheX1 = midX - tailleFleche * (float)Math.Cos(angle - Math.PI / 6);
                            float flecheY1 = midY - tailleFleche * (float)Math.Sin(angle - Math.PI / 6);

                            float flecheX2 = midX - tailleFleche * (float)Math.Cos(angle + Math.PI / 6);
                            float flecheY2 = midY - tailleFleche * (float)Math.Sin(angle + Math.PI / 6);

                            // Dessiner la flèche
                            canvas.DrawLine(midX, midY, flecheX1, flecheY1, edgePaint);
                            canvas.DrawLine(midX, midY, flecheX2, flecheY2, edgePaint);
                        }

                    }

                    // Dessiner les nœuds
                    if(coloration)
                    {
                        foreach(var noeud in noeuds)
                        {
                            Console.WriteLine(couleurs_noeuds[noeud.Numero - 1]);
                            nodePaint.Color = nodePaints[couleurs_noeuds[noeud.Numero - 1]];
                            canvas.DrawCircle(noeud.X, noeud.Y, 30, nodePaint);
                            canvas.DrawText(Convert.ToString(noeud.Numero), noeud.X - 4, noeud.Y + 8, textPaint);
                        }
                    }
                    else
                    {
                        foreach (var noeud in noeuds)
                        {
                            canvas.DrawCircle(noeud.X, noeud.Y, 30, nodePaint);
                            canvas.DrawText(Convert.ToString(noeud.Numero), noeud.X - 4, noeud.Y + 8, textPaint);
                        }
                    }   
                }

                // Sauvegarder l'image
                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = System.IO.File.OpenWrite("graphe.png"))
                {
                    data.SaveTo(stream);
                }
            }
        }
    }
}
