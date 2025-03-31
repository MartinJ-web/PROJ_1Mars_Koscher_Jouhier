// See https://aka.ms/new-console-template for more information
using PROJ_1Mars_Koscher_Jouhier;
using System.Collections.Generic;
using System.Security.Cryptography;
internal class Program
{
    private static void Main(string[] args)
    {
        #region 1erMars
        string[] lignes = File.ReadAllLines("PROJ_Lien_Test.txt");
        Graphe karate = new Graphe(lignes);
        karate.toString();
        Console.WriteLine("");
        List<Noeud> noeuds_karate = karate.Noeuds;
        Console.Write("Parcours en profondeur depuis " + noeuds_karate[0].Numero + " : ");
        foreach (Noeud noeud in karate.DFS(noeuds_karate[0]))
        {
            Console.Write(noeud.Numero + " ");
        }
        Console.WriteLine("");
        Console.Write("Parcours en largeur depuis " + noeuds_karate[0].Numero + " : ");
        foreach (Noeud noeud in karate.BFS(noeuds_karate[0]))
        {
            Console.Write(noeud.Numero + " ");
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
        karate.AfficheGrapheCercle();
        List<Noeud> circuit = karate.TrouveCircuit();
        if (circuit != null)
        {
            Console.Write("un circuit de longueur " + (circuit.Count - 1) + " a été trouvé : ");
            foreach (Noeud noeud in circuit)
            {
                Console.Write(noeud.Numero + " ");
            }
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Ce graphe ne comprte pas de circuit");
        }
        #endregion
        #region 4Avril
        //List<Noeud> noeuds = new List<Noeud>();
        //string[] lignesN = File.ReadAllLines("PROJ_Noeud_Station.csv");
        //for (int i = 1; i < lignesN.Length; i++)
        //{
        //    string[] ligne = lignesN[i].Split(';');
        //    Noeud noeud = new Noeud(Convert.ToInt32(ligne[0]), ligne[1] + ", " + ligne[2] + ", " + ligne[5] + ", " + ligne[6], float.Parse(ligne[3]), float.Parse(ligne[4]));
        //    noeuds.Add(noeud);
        //}
        //string[] liens = File.ReadAllLines("PROJ_Lien_Station.txt");
        //Graphe metro = new Graphe(noeuds, liens);
        //metro.toString();
        //metro.AfficheGraphe();
        #endregion
    }
}
