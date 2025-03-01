using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SkiaSharp;


namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Graphe
    {
        /// <summary>
        /// Attributs pour la classe graphe
        /// </summary>
        List<Noeud> noeuds;
        List<Lien> liens;
        List<List<Noeud>> liste_adjacence;
        int[,] matrice_adjacence;
        

        /// <summary>
        /// Constructeur pour la classe graphe à partir d'un tableau de liens
        /// </summary>
        /// <param name="lignes"> Tableau de liens </param>
        public Graphe(string[] lignes)
        {
            List<string> nom_noeuds = new List<string>();
            List<Noeud> noeuds = new List<Noeud>();
            List<Lien> liens = new List<Lien>();
            foreach (string ligne in lignes)
            {
                Noeud noeud_depart;
                Noeud noeud_arrivee;
                string[] lien_tab = ligne.Split(' ');
                if (!nom_noeuds.Contains(lien_tab[0]))
                {
                    nom_noeuds.Add(lien_tab[0]);
                    noeud_depart = new Noeud(lien_tab[0]);
                    noeuds.Add(noeud_depart);
                }
                else
                {
                    int index = -1;
                    for (int i = 0; i < noeuds.Count; i++)
                    {
                        if (noeuds[i].Nom == lien_tab[0])
                        {
                            index = i;
                        }
                    }
                    noeud_depart = noeuds[index];
                }
                if (!nom_noeuds.Contains(lien_tab[1]))
                {
                    nom_noeuds.Add(lien_tab[1]);
                    noeud_arrivee = new Noeud(lien_tab[1]);
                    noeuds.Add(noeud_arrivee);
                }
                else
                {
                    int index = -1;
                    for (int i = 0; i < noeuds.Count; i++)
                    {
                        if (noeuds[i].Nom == lien_tab[1])
                        {
                            index = i;
                        }
                    }
                    noeud_arrivee = noeuds[index];
                }
                Lien lien = new Lien(noeud_depart, noeud_arrivee);
                liens.Add(lien);
            }
            Tri(noeuds);
            this.noeuds = noeuds;
            this.liens = liens;
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
                    if (lien.Arrivee.Equals(noeuds[i]) && lien.Arrivee != lien.Depart)
                    {
                        adjacence.Add(lien.Depart);
                    }
                }
                Tri(adjacence);
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

        /// <summary>
        /// Propiété pour la liste de noeuds du graphe
        /// </summary>
        public List<Noeud> Noeuds
        {
            get { return noeuds; }
        }

        /// <summary>
        /// Propriété pour la liste de lien du graphe
        /// </summary>
        public List<Lien> Liens
        {
            get { return liens; }
        }

        /// <summary>
        /// Permet de trier la liste de noeuds et la liste d'adjacence (numériquement ou alphabétiquement)
        /// </summary>
        /// <param name="noeuds"> Liste de noeuds à trier </param>
        /// <param name="debut"> Début de la liste à trier </param>
        /// <param name="fin"> Fin de la liste de noeud à trier </param>
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

        /// <summary>
        /// Partie récursive du tri mentionné précedemment
        /// </summary>
        /// <param name="noeuds"> Liste de noeuds à trier </param>
        /// <param name="debut"> Début de la liste à trier </param>
        /// <param name="milieu"> Milieu de la liste de noeud à trier </param>
        /// <param name="fin"> Fin de la liste de noeud à trier </param>
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

        /// <summary>
        /// Affiche la liste et la matrice d'adjacence du graphe
        /// </summary>
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

        /// <summary>
        /// Parcours le graphe en profondeur d'abord
        /// </summary>
        /// <param name="depart"> Noeud à partir duquel le graphe est parcouru </param>
        /// <returns> Liste de noeuds représentant l'ordre dans lequel les noeuds sont découverts </returns>
        public List<Noeud> DFS(Noeud depart)
        {
            List<Noeud> ordre = new List<Noeud>();
            Stack<Noeud> visite = new Stack<Noeud>();
            return DFS_Rec(depart, visite, ordre);
        }

        /// <summary>
        /// Partie récursive du parcours mentionné précedemment
        /// </summary>
        /// <param name="depart"> Noeud à partir duquel le graphe est parcouru </param>
        /// <param name="visite">Liste de noeuds indiquants si les noeuds sont déjà découvets par le parcours </param>
        /// <param name="ordre"> Liste de noeuds représentant l'ordre dans lequel les noeuds sont découverts </param>
        /// <returns> Liste de noeuds représentant l'ordre dans lequel les noeuds sont découverts </returns>
        public List<Noeud> DFS_Rec(Noeud depart, Stack<Noeud> visite, List<Noeud> ordre)
        {
                if (visite.Contains(depart))
                {
                    return ordre;
                }
                ordre.Add(depart);
                visite.Push(depart);
                List<Noeud> successeurs = liste_adjacence[Convert.ToInt32(depart.Nom) - 1];
                foreach (Noeud successeur in successeurs)
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
        public List<Noeud> BFS(Noeud depart)
        {
            List<Noeud> ordre = new List<Noeud>();
            Queue<Noeud> visite = new Queue<Noeud>();
            visite.Enqueue(depart);
            ordre.Add(depart);
            while (visite.Count > 0)
            {
                Noeud suivant = visite.Dequeue();
                List<Noeud> successeurs = liste_adjacence[Convert.ToInt32(suivant.Nom) - 1];
                foreach (Noeud successeur in successeurs)
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
        public List<Noeud> TrouveCircuit()
        {
            foreach(Noeud noeud in noeuds)
            {
                noeud.Pred = null;
            }
            List<Noeud> circuit = new List<Noeud>();
            Stack<Noeud> visite = new Stack<Noeud>();
            visite.Push(noeuds[0]);
            bool circuit_existe = false;
            while (visite.Count > 0)
            {
                Noeud noeud = visite.Pop();
                if (circuit.Contains(noeud))
                {
                    circuit.Add(noeud);
                    circuit_existe = true;
                    break;
                }
                circuit.Add(noeud);
                List<Noeud> successeurs = liste_adjacence[Convert.ToInt32(noeud.Nom) - 1];
                foreach (Noeud successeur in successeurs)
                {
                    if (successeur.Nom != noeud.Pred)
                    {
                        visite.Push(successeur);
                        successeur.Pred = noeud.Nom;
                    }
                }
            }
            if(circuit_existe)
            {
                int index_depart = circuit.IndexOf(circuit[circuit.Count - 1]);
                List<int> index_a_supprimer = new List<int>();
                for (int i = 0; i < index_depart; i++)
                {
                    index_a_supprimer.Add(i);
                }
                List<string> predecesseurs = new List<string>();
                for(int i = 0; i < circuit.Count; i++)
                {
                    predecesseurs.Add(circuit[i].Pred);
                }
                for (int i = 0; i < predecesseurs.Count - 1; i++)
                {
                   if (predecesseurs.IndexOf(predecesseurs[i]) != i)
                   {
                       for(int j = predecesseurs.IndexOf(predecesseurs[i]); j < i; j++)
                        {
                            if(!index_a_supprimer.Contains(j))
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
        public void AfficheGraphe()
        {
            int width = 1080;
            int height = 1080;
            float centerX = width/2, centerY = height/2;
            float radius = 450;
            for(int i = 0; i < noeuds.Count; i++)
            {
                float angle = (float)(2 * Math.PI * i / noeuds.Count);
                float x = centerX + radius * (float)Math.Cos(angle);
                float y = centerY + radius * (float)Math.Sin(angle);
                noeuds[i].X = x;
                noeuds[i].Y = y;
            }
            using (var bitmap = new SKBitmap(width, height))
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);

                using (var edgePaint = new SKPaint { Color = SKColors.Purple, StrokeWidth = 2, IsAntialias = true, Style = SKPaintStyle.Stroke })
                using (var nodePaint = new SKPaint { Color = SKColors.LightBlue, IsAntialias = true })
                using (var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 20, IsAntialias = true })
                {
                    // Dessiner les arêtes
                    foreach (var lien in liens)
                    {
                        var fromNode = noeuds.Find(n => n.Equals(lien.Depart));
                        var toNode = noeuds.Find(n => n.Equals(lien.Arrivee));
                        if (fromNode != null && toNode != null)
                        {
                            canvas.DrawLine(fromNode.X, fromNode.Y, toNode.X, toNode.Y, edgePaint);
                        }
                    }

                    // Dessiner les nœuds
                    foreach (var noeud in noeuds)
                    {
                        canvas.DrawCircle(noeud.X, noeud.Y, 30, nodePaint);
                        canvas.DrawText(noeud.Nom, noeud.X - 8, noeud.Y + 8, textPaint);
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

            //Ouvir le graphe
            string cheminFichier = "graphe.png";
            string commandeOuvrir;

            if (OperatingSystem.IsWindows())
            {
                commandeOuvrir = cheminFichier;
            }
            else if (OperatingSystem.IsLinux())
            {
                commandeOuvrir = $"xdg-open {cheminFichier}";
            }
            else if (OperatingSystem.IsMacOS())
            {
                commandeOuvrir = $"open {cheminFichier}";
            }
            else
            {
                Console.WriteLine("l'image du graphe à été sauvegardé sous le nom graphe.png dans /bin/Debug/net");
                throw new NotSupportedException("Système d'exploitation non pris en charge.");

            }
            Process.Start(new ProcessStartInfo
            {
                FileName = commandeOuvrir,
                UseShellExecute = true
            });
        }
    }
}
