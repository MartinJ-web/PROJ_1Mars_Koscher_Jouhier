using System;
using System.Collections;
using System.Collections.Generic;
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
using SkiaSharp;


namespace PROJ_1Mars_Koscher_Jouhier
{
    public class Graphe
    {
        /// <summary>
        /// Attributs pour la classe graphe
        /// </summary>
        List<Noeud> noeuds;
        List<Lien> liens;
        List<List<Noeud>> liste_adjacence;
        int[,] matrice_adjacence;
        
        /// <summary>
        /// Constructeur pour la classe graphe un graphe à partir d'une liste de noeuds et d'un tableau de lien 
        /// </summary>
        /// <param name="noeuds"> Liste des noeuds du graphe </param>
        /// <param name="lignes"> Tableau de liens </param>
        public Graphe(List<Noeud> noeuds, string[] lignes)
        {
            this.noeuds = noeuds;
            Tri(noeuds);
            List<Lien> liens = new List<Lien>();
            for (int i = 0; i < lignes.Length; i++)
            {
                string[] ligne = lignes[i].Split(" ");
                if (ligne.Length == 3)
                {
                    Lien lien = new Lien(noeuds[Convert.ToInt32(ligne[0]) - 1], noeuds[Convert.ToInt32(ligne[1]) - 1], Convert.ToInt32(ligne[2]));
                    liens.Add(lien);
                }
                else
                {
                    Lien lien = new Lien(noeuds[Convert.ToInt32(ligne[0]) - 1], noeuds[Convert.ToInt32(ligne[1]) - 1]);
                    liens.Add(lien);
                }
            }
            
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
            foreach (Lien lien in liens)
            {
                matrice_adjacence[lien.Depart.Numero - 1, lien.Arrivee.Numero - 1] = lien.Poids;
                matrice_adjacence[lien.Arrivee.Numero - 1, lien.Depart.Numero - 1] = lien.Poids;

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
            List<Noeud> noeuds = new List<Noeud>();
            List<Lien> liens = new List<Lien>();
            foreach (string ligne in lignes)
            {
                Noeud noeud_depart;
                Noeud noeud_arrivee;
                string[] lien_tab = ligne.Split(" ");
                if (!nom_noeuds.Contains(lien_tab[0]))
                {
                    nom_noeuds.Add(lien_tab[0]);
                    noeud_depart = new Noeud(Convert.ToInt32(lien_tab[0]));
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
                    noeud_arrivee = new Noeud(Convert.ToInt32(lien_tab[1]));
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
                if (lien_tab.Length == 3)
                {
                    Lien lien = new Lien(noeud_depart, noeud_arrivee, Convert.ToInt32(lien_tab[2]));
                    liens.Add(lien);
                }
                else
                {
                    Lien lien = new Lien(noeud_depart, noeud_arrivee);
                    liens.Add(lien);
                }
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
            foreach (Lien lien in liens)
            {
                matrice_adjacence[lien.Depart.Numero - 1, lien.Arrivee.Numero - 1] = lien.Poids;
                matrice_adjacence[lien.Arrivee.Numero - 1, lien.Depart.Numero - 1] = lien.Poids;

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
        /// Permet de trier la liste de noeuds et la liste d'adjacence numériquement
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

        public void Dijkstra(List<Noeud> noeuds, List<List<Noeud>> liste_adjacence, Noeud noeud_depart)
        {
            List<Noeud> sommets_visites = new List<Noeud>();
            List<Noeud> sommets_traites = new List<Noeud>();
            SortedList<Noeud, int> distances = new SortedList<Noeud, int>();//distance de noeud par rapport à noeuddepart

            foreach (Noeud noeud in noeuds)
            {
                if (noeud == noeud_depart) { distances.Add(noeud, 0); }
                else { distances.Add(noeud, int.MaxValue); }

              }//initialisation distances


            Noeud noeud_actuel = noeud_depart;//depart

            while (sommets_visites.Count < noeuds.Count)// vérifier condition sur sommets_visites
            {
                sommets_traites.Add(noeud_actuel);
                sommets_visites.Add(noeud_actuel);
                foreach (Noeud noeud in noeuds)
                {
                    if (!sommets_traites.Contains(noeud))
                    {
                        //calculer dist noeud actuel - noeuds ?? où sont les poids des noeuds ? faire l'addition des liens : trouver chemin
                        if (matrice_adjacence[noeud_actuel.Numero - 1, noeud.Numero - 1] > 0)
                        {
                            if (!sommets_visites.Contains(noeud))//s'il n'est pas encore visité
                            {
                                sommets_visites.Add((Noeud)noeud);
                                distances.Add(noeud_actuel, matrice_adjacence[noeud_actuel.Numero - 1, noeud.Numero - 1] + distances.ElementAt(distances.IndexOfKey(noeud_actuel)).Value);
                            }
                            else
                            {
                                if (distances.ElementAt(distances.IndexOfKey(noeud)).Value > matrice_adjacence[noeud_actuel.Numero - 1, noeud.Numero - 1] + distances.ElementAt(distances.IndexOfKey(noeud_actuel)).Value)
                                {
                                    distances.Remove(noeud);
                                    distances.Add(noeud, matrice_adjacence[noeud_actuel.Numero - 1, noeud.Numero - 1] + distances.ElementAt(distances.IndexOfKey(noeud_actuel)).Value);
                                }
                            }
                        }
                    }
                }
                int min = int.MaxValue;
                foreach (Noeud noeud in sommets_visites)
                {
                    if (!sommets_traites.Contains(noeud))
                    {
                        if (distances.ElementAt(distances.IndexOfKey(noeud)).Value < min)
                        {
                            noeud_actuel = noeud;
                            min = distances.ElementAt(distances.IndexOfKey(noeud)).Value;

                        }
                    }
                }
            }
        }

        public void BellmanFord(List<Noeud> noeuds, List<List<Noeud>> liste_adjacence, Noeud noeud_depart)
        {

        }

        /// <summary>
        /// Affiche la liste et la matrice d'adjacence du graphe
        /// </summary>
        public void toString()
        {
            Console.WriteLine("Liste d'adjacence :\n");
            for(int i = 0; i < liste_adjacence.Count; i++)
            {
                Console.Write(noeuds[i].Numero + " : ");
                for (int j = 0; j < liste_adjacence[i].Count; j++)
                {
                    Console.Write( liste_adjacence[i][j].Numero + " ");
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
                List<Noeud> successeurs = liste_adjacence[Convert.ToInt32(depart.Numero) - 1];
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
                List<Noeud> successeurs = liste_adjacence[Convert.ToInt32(suivant.Numero) - 1];
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
                noeud.Pred = -1;
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
                List<Noeud> successeurs = liste_adjacence[Convert.ToInt32(noeud.Numero) - 1];
                foreach (Noeud successeur in successeurs)
                {
                    if (successeur.Numero != noeud.Pred)
                    {
                        visite.Push(successeur);
                        successeur.Pred = noeud.Numero;
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
                List<int> predecesseurs = new List<int>();
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
        public void AfficheGrapheCercle()
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
                        canvas.DrawText(Convert.ToString(noeud.Numero), noeud.X - 8, noeud.Y + 8, textPaint);
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

        public void AfficheGraphe()
        {
            //Counter à l'étalement horizontal : - largeur/longitude * coef
            int width = 2865; //1910*1.5
            int height = 1485; //990*1.5
            for (int i = 0; i < noeuds.Count; i++)
            {
                noeuds[i].X -= (float)2.252;
                noeuds[i].X *= 15000;
                noeuds[i].Y -= (float)48.81;
                noeuds[i].Y *= 15000;
                if (noeuds[i].Numero == 86)
                { noeuds[i].X -= 20; noeuds[i].Y += 30; }
                if (noeuds[i].Numero == 88)
                { noeuds[i].X -= 40; }
                if (noeuds[i].Numero == 91)
                { noeuds[i].X += 3; noeuds[i].Y += 1; }
                if (noeuds[i].Numero == 92)
                { noeuds[i].X += 3; noeuds[i].Y += 1; }
            }
            using (var bitmap = new SKBitmap(width, height))
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);
                using (var edgePaint = new SKPaint { Color = SKColors.Purple, StrokeWidth = 4, IsAntialias = true, Style = SKPaintStyle.Stroke })
                using (var nodePaint = new SKPaint { Color = SKColors.Black, IsAntialias = true })
                using (var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 15, IsAntialias = true })
                {
                    foreach (var lien in liens)
                    {
                        var fromNode = noeuds.Find(n => n.Equals(lien.Depart));
                        var toNode = noeuds.Find(n => n.Equals(lien.Arrivee));
                        if (fromNode != null && toNode != null)
                        {
                            string ligne = fromNode.Nom.Split(", ")[0];
                            switch (ligne)
                            {
                                case "1":
                                    edgePaint.Color = SKColor.Parse("#FFCE00"); break;
                                case "2":
                                    edgePaint.Color = SKColor.Parse("#0064B0"); break;
                                case "3": 
                                    edgePaint.Color = SKColor.Parse("#9F9825"); break;
                                case "4":
                                    edgePaint.Color = SKColor.Parse("#C04191"); break;
                                case "5":
                                    edgePaint.Color = SKColor.Parse("#F28E42"); break;
                                case "6":
                                    edgePaint.Color = SKColor.Parse("#83C491"); break;
                                case "7":
                                    edgePaint.Color = SKColor.Parse("#F3A4BA"); break;
                                case "8":
                                    edgePaint.Color = SKColor.Parse("#CEADD2"); break;
                                case "9":
                                    edgePaint.Color = SKColor.Parse("#D5C900"); break;
                                case "10":
                                    edgePaint.Color = SKColor.Parse("#E3B32A"); break;
                                case "11":
                                    edgePaint.Color = SKColor.Parse("#8D5E2A"); break;
                                case "12":
                                    edgePaint.Color = SKColor.Parse("#00814F"); break;
                                case "13":
                                    edgePaint.Color = SKColor.Parse("#98D4E2"); break;
                                case "14":
                                    edgePaint.Color = SKColor.Parse("#662483"); break;
                                case "3bis":
                                    edgePaint.Color = SKColor.Parse("#98D4E2"); break;
                                case "7bis":
                                    edgePaint.Color = SKColor.Parse("#83C491"); break;
                                default :
                                    edgePaint.Color = SKColors.Purple; break;
                            }
                            canvas.DrawLine(fromNode.X, 1485 - fromNode.Y, toNode.X, 1485 - toNode.Y, edgePaint);
                        }
                    }

                    foreach (var noeud in noeuds)
                    {
                        if (noeud.Numero != 91 && noeud.Numero != 92)
                        {
                            nodePaint.Color = SKColors.Black;
                            canvas.DrawCircle(noeud.X, 1485 - noeud.Y, 10, nodePaint);
                            nodePaint.Color = SKColors.White;
                            canvas.DrawCircle(noeud.X, 1485 - noeud.Y, 7, nodePaint);
                            canvas.DrawText(Convert.ToString(noeud.Numero), noeud.X - 14, 1485 - noeud.Y + 21, textPaint);
                        }
                    }
                }
                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = System.IO.File.OpenWrite("graphe.png"))
                {
                    data.SaveTo(stream);
                }
            }
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
