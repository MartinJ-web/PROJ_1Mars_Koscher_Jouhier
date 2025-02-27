// See https://aka.ms/new-console-template for more information
using PROJ_1Mars_Koscher_Jouhier;
using System.Collections.Generic;
using System.Security.Cryptography;
internal class Program
{
    private static void Main(string[] args)
    {
        string[] lignes = File.ReadAllLines("Liens_Test.txt");
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
                for(int i = 0; i < noeuds.Count; i++)
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
        Graphe karate = new Graphe(noeuds, liens);
        karate.ToString();
        List<Noeud> noeuds_karate = karate.Noeuds;
        Console.Write("Parcours en profondeur depuis " + noeuds_karate[0].Nom + " : ");
        foreach (Noeud noeud in karate.DFS(noeuds_karate[0]))
        {
            Console.Write(noeud.Nom + " ");
        }
        Console.WriteLine("");
        Console.Write("Parcours en largeur depuis " + noeuds_karate[0].Nom + " : ");
        foreach (Noeud noeud in karate.BFS(noeuds_karate[0]))
        {
            Console.Write(noeud.Nom + " ");
        }
        Console.WriteLine("");
        if(karate.EstConnexe())
        {
            Console.WriteLine("Le graph est connexe");
        }
        else
        {
            Console.WriteLine("Le graphe n'est pas connexe");
        }
        karate.AfficheGraphe();
    }
}