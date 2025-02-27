using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SkiaSharp;


namespace PROJ_1Mars_Koscher_Jouhier
{
    internal class Graphe
    {
        List<Noeud> noeuds;
        List<Lien> liens;
        List<List<Noeud>> liste_adjacence;
        int[,] matrice_adjacence;
        

        public Graphe(List<Noeud> noeuds, List<Lien> liens)
        {
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

        public List<Lien> Liens
        {
            get { return liens; }
        }
        public List<Noeud> Noeuds
        {
            get { return noeuds; }
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

        public List<Noeud> DFS(Noeud depart)
        {
            List<Noeud> ordre = new List<Noeud>();
            Stack<Noeud> visite = new Stack<Noeud>();
            return DFS_Rec(depart, visite, ordre);
        }

        public List<Noeud> DFS_Rec(Noeud depart, Stack<Noeud> visite, List<Noeud> ordre)
        {
            if (visite.Contains(depart))
            {
                 return ordre;
            }
            ordre.Add(depart);
            visite.Push(depart);
            List<Noeud> successeurs = liste_adjacence[Convert.ToInt32(depart.Nom)-1];
            foreach (Noeud successeur in successeurs)
            {
                DFS_Rec(successeur, visite, ordre);
            }
            return ordre;
        }

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

        public bool EstConnexe()
        {
            return (DFS(noeuds[0]).Count == noeuds.Count);
        }


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
