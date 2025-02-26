// See https://aka.ms/new-console-template for more information
using PROJ_1Mars_Koscher_Jouhier;
internal class Program
{
    private static void Main(string[] args)
    {
        string[] lignes = File.ReadAllLines("PROJ_Lien_Karate.txt");
        List<Lien> liens = new List<Lien>();
        foreach (string ligne in lignes)
        {
            string[] lien_tab = ligne.Split(' ');
            Noeud noeudD = new Noeud(lien_tab[0]);
            Noeud noeudA = new Noeud(lien_tab[1]);
            Lien lien = new Lien(noeudD, noeudA);
            liens.Add(lien);
        }
        Graphe karate = new Graphe(liens);
        karate.ToString();
    }
}