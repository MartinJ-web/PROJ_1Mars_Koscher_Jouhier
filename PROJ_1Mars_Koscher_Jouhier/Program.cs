// See https://aka.ms/new-console-template for more information
using PROJ_1Mars_Koscher_Jouhier;
using System.Collections.Generic;
using System.Security.Cryptography;
internal class Program
{
    private static void Main(string[] args)
    {
        string[] lignes = File.ReadAllLines("PROJ_Lien_Karate.txt");
        Graphe karate = new Graphe(lignes);
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
        if (karate.EstConnexe())
        {
            Console.WriteLine("Le graphe est connexe");
        }
        else
        {
            Console.WriteLine("Le graphe n'est pas connexe");
        }
        karate.AfficheGraphe();
        List<Noeud> circuit = karate.TrouveCircuit();
        if (circuit != null)
        {
            Console.Write("un circuit de longueur " + (circuit.Count - 1) + " a été trouvé : ");
            foreach (Noeud noeud in circuit)
            {
                Console.Write(noeud.Nom + " ");
            }
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Ce graphe ne comprte pas de circuit");
        }

    }
}