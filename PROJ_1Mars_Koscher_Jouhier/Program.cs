// See https://aka.ms/new-console-template for more information
using PROJ_1Mars_Koscher_Jouhier;
using SkiaSharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        #region Tests
        #region 1erMars
        //string[] lignes = File.ReadAllLines("PROJ_Lien_Test.txt");
        //Graphe<int> karate = new Graphe<int>(lignes);
        //karate.toString();
        //Console.WriteLine("");
        //List<Noeud<int>> noeuds_karate = karate.Noeuds;
        //Console.Write("Parcours en profondeur depuis " + noeuds_karate[0].Numero + " : ");
        //foreach (Noeud<int> noeud in karate.DFS(noeuds_karate[0]))
        //{
        //    Console.Write(noeud.Numero + " ");
        //}
        //Console.WriteLine("");
        //Console.Write("Parcours en largeur depuis " + noeuds_karate[6].Numero + " : ");
        //foreach (Noeud<int> noeud in karate.BFS(noeuds_karate[6]))
        //{
        //    Console.Write(noeud.Numero + " ");
        //}
        //Console.WriteLine("");
        //if (karate.EstConnexe())
        //{
        //    Console.WriteLine("Le graphe est connexe");
        //}
        //else
        //{
        //    Console.WriteLine("Le graphe n'est pas connexe");
        //}
        //karate.AfficheGrapheCercle();
        //List<Noeud<int>> circuit = karate.TrouveCircuit();
        //if (circuit != null)
        //{
        //    Console.Write("Un circuit de longueur " + (circuit.Count - 1) + " a été trouvé : ");
        //    foreach (Noeud<int> noeud in circuit)
        //    {
        //        Console.Write(noeud.Numero + " ");
        //    }
        //    Console.WriteLine("");
        //}
        //else
        //{
        //    Console.WriteLine("Ce graphe ne comprte pas de circuit");
        //}
        //Console.WriteLine("Longueur des chemins les plus courts avec Dijkstra depuis " + noeuds_karate[6].Numero + " : ");
        //int[] dijkstra = karate.Dijkstra(noeuds_karate[6]);
        //for (int i = 0; i < dijkstra.Length; i++)
        //{
        //    if (dijkstra[i] == int.MaxValue)
        //    {
        //        Console.WriteLine(i + 1 + " : Non atteint");
        //    }
        //    else
        //    {
        //        Console.WriteLine(i + 1 + " : " + dijkstra[i]);
        //    }
        //}
        //Console.Write("Chemin le plus court avec Dijkstra depuis " + noeuds_karate[2].Numero + " vers " + noeuds_karate[6].Numero + " : ");
        //List<Noeud<int>> pcc_dijkstra = karate.PCC_Dijkstra(noeuds_karate[2], noeuds_karate[6]);
        //if (pcc_dijkstra != null)
        //{
        //    for (int i = 0; i < pcc_dijkstra.Count; i++)
        //    {
        //        Console.Write(pcc_dijkstra[i].Numero + " ");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Il n'y a pas de chemin car le graphe n'est pas connexe");
        //}





        //int[,] W = karate.FloydWarshall();
        //for (int i = 0; i < W.GetLength(0); i++)
        //{
        //    for (int j = 0; j < W.GetLength(1); j++)
        //    {
        //        if (W[i, j] < 10)
        //        {
        //            Console.Write(" " + W[i, j] + " ");

        //        }
        //        else
        //        {
        //            Console.Write(W[i, j] + " ");
        //        }
        //    }
        //    Console.WriteLine("");
        //}
        //OuvrirImage();
        #endregion
        #region 4Avril
        //List<Noeud<Station>> noeuds = new List<Noeud<Station>>();
        //string[] lignesN = File.ReadAllLines("PROJ_Noeud_Station.csv", Encoding.Latin1);
        //for (int i = 1; i < lignesN.Length; i++)
        //{
        //    string[] ligne = lignesN[i].Split(';');
        //    Station station = new Station(ligne[1], ligne[2], float.Parse(ligne[3]), float.Parse(ligne[4]), ligne[5], Int32.Parse(ligne[6]));
        //    Noeud<Station> noeud = new Noeud<Station>(Convert.ToInt32(ligne[0]), station);
        //    noeuds.Add(noeud);
        //}
        //string[] lignes = File.ReadAllLines("PROJ_Lien_Station.txt");
        //List<string> nouveaux_liens = new List<string>();
        //foreach (Noeud<Station> noeudD in noeuds)
        //{
        //    foreach (Noeud<Station> noeudA in noeuds)
        //    {
        //        if (noeudD.Classe.Nom == noeudA.Classe.Nom && noeudD.Numero != noeudA.Numero && !nouveaux_liens.Contains(noeudA.Numero + " " + noeudD.Numero + " " + 2))
        //        {
        //            nouveaux_liens.Add(noeudD.Numero + " " + noeudA.Numero + " " + 2);
        //        }
        //    }
        //}
        //string[] liens = new string[lignes.Length + nouveaux_liens.Count];
        //for (int i = 0; i < liens.Length; i++)
        //{
        //    if (i < lignes.Length)
        //    {
        //        liens[i] = lignes[i];
        //    }
        //    else
        //    {
        //        liens[i] = nouveaux_liens[i - lignes.Length];
        //    }
        //}
        //Graphe<Station> metro = new Graphe<Station>(noeuds, liens);
        //Console.WriteLine(metro.EstConnexe());
        //AfficheMetro(metro, metro.PCC_Dijkstra(metro.Noeuds[97], metro.Noeuds[169]));
        //List<Noeud<Station>> pcc_dijkstra = metro.PCC_Dijkstra(metro.Noeuds[97], metro.Noeuds[169]);
        //if (pcc_dijkstra != null)
        //{
        //    for (int i = 0; i < pcc_dijkstra.Count; i++)
        //    {
        //        Console.Write(pcc_dijkstra[i].Numero + " ");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Il n'y a pas de chemin entre ces noeuds");
        //}
        //OuvrirImage();
        #endregion
        #endregion
        #region Interface

    }

    public static void AfficheMetro(Graphe<Station> metro, List<Noeud<Station>> chemin = null)
    {
        //Counter à l'étalement horizontal : - largeur/longitude * coef
        int width = 2865; //1910*1.5
        int height = 1485; //990*1.5
        List<Noeud<Station>> noeuds_uniques = new List<Noeud<Station>>();
        if (chemin != null)
        {
            foreach (Noeud<Station> noeud in chemin)
            {
                bool contains = false;
                foreach (Noeud<Station> noeud_unique in noeuds_uniques)
                {
                    if (noeud_unique.Classe.Nom == noeud.Classe.Nom)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    noeuds_uniques.Add(noeud);
                }
            }
        }
        for (int i = 0; i < metro.Noeuds.Count; i++)
        {
            bool contains = false;
            foreach (Noeud<Station> noeud in noeuds_uniques)
            {
                if (noeud.Classe.Nom == metro.Noeuds[i].Classe.Nom)
                {
                    contains = true;
                    break;
                }
            }
            if (!contains)
            {
                noeuds_uniques.Add(metro.Noeuds[i]);
            }
            #region Réglages  du format
            metro.Noeuds[i].X = (metro.Noeuds[i].Classe.Longitude - (float)2.252) * 15000;
            metro.Noeuds[i].Y = (metro.Noeuds[i].Classe.Latitude - (float)48.81) * 15000;
            if (metro.Noeuds[i].Numero == 86) { metro.Noeuds[i].Y += 10; }
            if (metro.Noeuds[i].Numero == 88) { metro.Noeuds[i].X -= 10; }
            if (metro.Noeuds[i].Numero == 101 || metro.Noeuds[i].Numero == 102) { metro.Noeuds[i].X += 1; }
            if (metro.Noeuds[i].Numero == 75 || metro.Noeuds[i].Numero == 76 || metro.Noeuds[i].Numero == 91 || metro.Noeuds[i].Numero == 92)
            { metro.Noeuds[i].X -= 2; metro.Noeuds[i].Y -= 1; }
            if (metro.Noeuds[i].Numero == 11 || metro.Noeuds[i].Numero == 12 || metro.Noeuds[i].Numero == 34 || metro.Noeuds[i].Numero == 35 || metro.Noeuds[i].Numero == 223 || metro.Noeuds[i].Numero == 224)
            { metro.Noeuds[i].Y -= (float)1.5; }
            if (metro.Noeuds[i].Numero == 99 || metro.Noeuds[i].Numero == 100 || metro.Noeuds[i].Numero == 262 || metro.Noeuds[i].Numero == 263 || metro.Noeuds[i].Numero == 310)
            { metro.Noeuds[i].Y += (float)1.5; }
            if (metro.Noeuds[i].Numero == 261 || metro.Noeuds[i].Numero == 267) { metro.Noeuds[i].Y -= 15; }
            if (metro.Noeuds[i].Numero >= 193 && metro.Noeuds[i].Numero <= 197 || metro.Noeuds[i].Numero == 104 || metro.Noeuds[i].Numero == 105) { metro.Noeuds[i].Y -= 4; }
            if (metro.Noeuds[i].Numero >= 123 && metro.Noeuds[i].Numero <= 131 || metro.Noeuds[i].Numero == 311 || metro.Noeuds[i].Numero == 265 || metro.Noeuds[i].Numero == 266) { metro.Noeuds[i].Y += 3; }
            #endregion
        }
        using (var bitmap = new SKBitmap(width, height))
        using (var canvas = new SKCanvas(bitmap))
        {
            canvas.Clear(SKColors.White);
            using (var edgePaint = new SKPaint { Color = SKColors.Purple, StrokeWidth = 4, IsAntialias = true, Style = SKPaintStyle.Stroke })
            using (var nodePaint = new SKPaint { Color = SKColors.Black, IsAntialias = true })
            using (var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 15, IsAntialias = true })
            {
                foreach (var lien in metro.Liens)
                {
                    var noeudD = metro.Noeuds.Find(n => n.Equals(lien.Depart));
                    var noeudA = metro.Noeuds.Find(n => n.Equals(lien.Arrivee));
                    string ligne = noeudD.Classe.Ligne;
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
                        default:
                            edgePaint.Color = SKColors.Purple; break;
                    }
                    if (noeudD.Numero == 258)
                    {
                        edgePaint.Color = SKColors.Black;
                    }
                    canvas.DrawLine(noeudD.X, 1485 - noeudD.Y, noeudA.X, 1485 - noeudA.Y, edgePaint);
                    if (lien.Sens)
                    {
                        float midX = (noeudD.X + noeudA.X) / 2;
                        float midY = (noeudD.Y + noeudA.Y) / 2;
                        float tailleFleche = 10; // Taille de la flèche

                        // Calcul de l'angle de l'arête
                        float angle = (float)Math.Atan2(noeudA.Y - noeudD.Y, noeudA.X - noeudD.X);

                        // Calcul des points de la flèche
                        float flecheX1 = midX - tailleFleche * (float)Math.Cos(angle - Math.PI / 6);
                        float flecheY1 = midY - tailleFleche * (float)Math.Sin(angle - Math.PI / 6);

                        float flecheX2 = midX - tailleFleche * (float)Math.Cos(angle + Math.PI / 6);
                        float flecheY2 = midY - tailleFleche * (float)Math.Sin(angle + Math.PI / 6);

                        // Dessiner la flèche
                        canvas.DrawLine(midX, 1485 - midY, flecheX1, 1485 - flecheY1, edgePaint);
                        canvas.DrawLine(midX, 1485 - midY, flecheX2, 1485 - flecheY2, edgePaint);
                    }
                }

                foreach (var noeud in metro.Noeuds)
                {
                    if (noeuds_uniques.Contains(noeud))
                    {
                        if (chemin != null && chemin.Contains(noeud))
                        {
                            nodePaint.Color = SKColors.Black;
                            canvas.DrawCircle(noeud.X, 1485 - noeud.Y, 10, nodePaint);
                            nodePaint.Color = SKColors.Red;
                            canvas.DrawCircle(noeud.X, 1485 - noeud.Y, 7, nodePaint);
                            canvas.DrawText(noeud.Classe.Nom, noeud.X - 14, 1485 - noeud.Y + 21, textPaint);
                        }
                        else
                        {
                            nodePaint.Color = SKColors.Black;
                            canvas.DrawCircle(noeud.X, 1485 - noeud.Y, 10, nodePaint);
                            nodePaint.Color = SKColors.White;
                            canvas.DrawCircle(noeud.X, 1485 - noeud.Y, 7, nodePaint);
                            //canvas.DrawText(Convert.ToString(noeud.Numero), noeud.X - 14, 1485 - noeud.Y + 21, textPaint);
                        }
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
    }

    static void OuvrirImage(string cheminFichier = "graphe.png")
    {
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
