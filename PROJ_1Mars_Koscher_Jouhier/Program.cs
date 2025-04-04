// See https://aka.ms/new-console-template for more information
using PROJ_1Mars_Koscher_Jouhier;
using SkiaSharp;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Reflection.PortableExecutable;
using Org.BouncyCastle.Asn1.Ocsp;
internal class Program
{
    private static void Main(string[] args)
    {
        #region Tests
        #region 1erMars
        Console.WriteLine("Avant d'accéder au travail sur l'interface, voici un extrait du travail sur les graphes (poids, sens, pcc) (le graphe pris en exemple est celui du TD3 exo1)");
        string[] lignes = File.ReadAllLines("PROJ_Lien_Test.txt");
        Graphe<int> karate = new Graphe<int>(lignes);
        karate.toString();
        Console.WriteLine("");
        List<Noeud<int>> noeuds_karate = karate.Noeuds;
        Console.Write("Parcours en profondeur depuis " + noeuds_karate[0].Numero + " : ");
        foreach (Noeud<int> noeud in karate.DFS(noeuds_karate[0]))
        {
            Console.Write(noeud.Numero + " ");
        }
        Console.WriteLine("");
        Console.Write("Parcours en largeur depuis " + noeuds_karate[6].Numero + " : ");
        foreach (Noeud<int> noeud in karate.BFS(noeuds_karate[6]))
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
        List<Noeud<int>> circuit = karate.TrouveCircuit();
        if (circuit != null)
        {
            Console.Write("Un circuit de longueur " + (circuit.Count - 1) + " a été trouvé : ");
            foreach (Noeud<int> noeud in circuit)
            {
                Console.Write(noeud.Numero + " ");
            }
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Ce graphe ne comprte pas de circuit");
        }
        Console.WriteLine("Longueur des chemins les plus courts avec Dijkstra depuis " + noeuds_karate[6].Numero + " : ");
        int[] dijkstra = karate.Dijkstra(noeuds_karate[6]);
        for (int i = 0; i < dijkstra.Length; i++)
        {
            if (dijkstra[i] == int.MaxValue)
            {
                Console.WriteLine(i + 1 + " : Non atteint");
            }
            else
            {
                Console.WriteLine(i + 1 + " : " + dijkstra[i]);
            }
        }
        Console.Write("Chemin le plus court avec Dijkstra depuis " + noeuds_karate[2].Numero + " vers " + noeuds_karate[6].Numero + " : ");
        List<Noeud<int>> pcc_dijkstra = karate.PCC_Dijkstra(noeuds_karate[2], noeuds_karate[6]);
        if (pcc_dijkstra != null)
        {
            for (int i = 0; i < pcc_dijkstra.Count; i++)
            {
                Console.Write(pcc_dijkstra[i].Numero + " ");
            }
        }
        else
        {
            Console.WriteLine("Il n'y a pas de chemin car le graphe n'est pas connexe");
        }
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
        OuvrirImage();
        Console.ReadKey();
        #endregion
        #region 4Avril
        Console.Clear();
        Console.WriteLine("Comme il n'est pas encore inclus dans l'interface, voici le graphe du metro ou est dessiné en rouge le plus cours chemin d'une station à une autre (aléatoires) avec dijkstra\n");
        List<Noeud<Station>> noeuds = new List<Noeud<Station>>();
        string[] lignesN = File.ReadAllLines("PROJ_Noeud_Station.csv", Encoding.Latin1);
        for (int i = 1; i < lignesN.Length; i++)
        {
            string[] ligne = lignesN[i].Split(';');
            Station station = new Station(ligne[1], ligne[2], float.Parse(ligne[3]), float.Parse(ligne[4]), ligne[5], Int32.Parse(ligne[6]));
            Noeud<Station> noeud = new Noeud<Station>(Convert.ToInt32(ligne[0]), station);
            noeuds.Add(noeud);
        }
        string[] lignes2 = File.ReadAllLines("PROJ_Lien_Station.txt");
        List<string> nouveaux_liens = new List<string>();
        foreach (Noeud<Station> noeudD in noeuds)
        {
            foreach (Noeud<Station> noeudA in noeuds)
            {
                if (noeudD.Classe.Nom == noeudA.Classe.Nom && noeudD.Numero != noeudA.Numero && !nouveaux_liens.Contains(noeudA.Numero + " " + noeudD.Numero + " " + 2))
                {
                    nouveaux_liens.Add(noeudD.Numero + " " + noeudA.Numero + " " + 2);
                }
            }
        }
        string[] liens = new string[lignes2.Length + nouveaux_liens.Count];
        for (int i = 0; i < liens.Length; i++)
        {
            if (i < lignes2.Length)
            {
                liens[i] = lignes2[i];
            }
            else
            {
                liens[i] = nouveaux_liens[i - lignes2.Length];
            }
        }
        Random random = new Random();
        int D = random.Next(0, 331);
        int A = random.Next(0, 331);
        Graphe<Station> metro = new Graphe<Station>(noeuds, liens);
        Console.WriteLine(metro.EstConnexe());
        Console.Write("Chemin le plus court avec Dijkstra depuis " + metro.Noeuds[A].Classe.Nom + " vers " + metro.Noeuds[D].Classe.Nom + " : ");
        AfficheMetro(metro, metro.PCC_Dijkstra(metro.Noeuds[D], metro.Noeuds[A]));
        List<Noeud<Station>> pcc_dijkstrametro = metro.PCC_Dijkstra(metro.Noeuds[D], metro.Noeuds[A]);
        if (pcc_dijkstrametro != null)
        {
            for (int i = 0; i < pcc_dijkstrametro.Count; i++)
            {
                Console.Write(pcc_dijkstrametro[i].Numero + " ");
            }
        }
        else
        {
            Console.WriteLine("Il n'y a pas de chemin entre ces noeuds");
        }
        OuvrirImage();
        Console.WriteLine("\nPour continuer avec l'interface, appuyez sur entrée");
        Console.ReadKey();
        #endregion
        #endregion
        #region Interface
        #region SQL
        MySqlConnection maConnexion = null;
        try
        {
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                     "DATABASE=LivInParis;" +
                                     "UID=root;PASSWORD=root";

            maConnexion = new MySqlConnection(connexionString);
            maConnexion.Open();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(" ErreurConnexion : " + e.ToString());
            return;
        }
        #endregion
        int cpt_cuisiniers = -1;
        string compte_Cu = " SELECT COUNT(*) FROM Cuisinier;";
        MySqlCommand command = maConnexion.CreateCommand();
        command.CommandText = compte_Cu;
        MySqlDataReader reader = command.ExecuteReader();
        command.CommandText = compte_Cu;
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                cpt_cuisiniers = Int32.Parse(reader.GetValue(i).ToString());
            }
        }
        reader.Close();
        int cpt_clients = -1;
        string compte_Cl = " SELECT COUNT(*) FROM Client;";
        MySqlCommand command0 = maConnexion.CreateCommand();
        command0.CommandText = compte_Cl;
        MySqlDataReader reader1 = command0.ExecuteReader();
        command0.CommandText = compte_Cl;
        while (reader1.Read())
        {
            for (int i = 0; i < reader1.FieldCount; i++)
            {
                cpt_clients = Int32.Parse(reader1.GetValue(i).ToString());
            }
        }
        reader1.Close();
        Console.Clear();
        ConsoleKeyInfo cki;
        bool quitter1 = false;
        int nb_proposition1 = 3;
        int proposition1 = 1;
        do
        {
            Console.Clear();
            Console.WriteLine("Bienvenue sur Livin'Paris !\n");
            switch (proposition1)
            {
                case 1:
                    Console.WriteLine("\tSe connecter <\n\tS'inscrire\n\tQuitter");
                    break;
                case 2:
                    Console.WriteLine("\tSe connecter\n\tS'inscrire <\n\tQuitter");
                    break;
                case 3:
                    Console.WriteLine("\tSe connecter\n\tS'inscrire\n\tQuitter <");
                    break;
            }
            Console.WriteLine("\nNaviguez avec les flèches \"haut\" et \"bas\" puis tapez \"entrer\"");
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.UpArrow)
            {
                proposition1--;
                if (proposition1 == 0) { proposition1 = nb_proposition1; }
            }
            if (cki.Key == ConsoleKey.DownArrow)
            {
                proposition1++;
                if (proposition1 > nb_proposition1) { proposition1 = 1; }
            }
            if (cki.Key == ConsoleKey.Enter)
            {
                switch (proposition1)
                {
                    #region Connexion
                    case 1:
                        bool quitter2_1 = false;
                        int nb_proposition2_1 = 3;
                        int proposition2_1 = 1;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Connexion : \n");
                            switch (proposition2_1)
                            {
                                case 1:
                                    Console.WriteLine("\tCuisinier <\n\tClient\n\tRetour");
                                    break;
                                case 2:
                                    Console.WriteLine("\tCuisinier\n\tClient <\n\tRetour");
                                    break;
                                case 3:
                                    Console.WriteLine("\tCuisinier\n\tClient\n\tRetour <");
                                    break;
                            }
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.UpArrow)
                            {
                                proposition2_1--;
                                if (proposition2_1 == 0) { proposition2_1 = nb_proposition2_1; }
                            }
                            if (cki.Key == ConsoleKey.DownArrow)
                            {
                                proposition2_1++;
                                if (proposition2_1 > nb_proposition2_1) { proposition2_1 = 1; }
                            }
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                switch (proposition2_1)
                                {
                                    #region Cusinier
                                    case 1:
                                        Console.Write("\n\tAdresse mail : ");
                                        string mailCu = Console.ReadLine();
                                        Console.Write("\n\tMot de passe : ");
                                        string mdpCu = Console.ReadLine();
                                        //Check appartenance 
                                        bool appartenanceCu = true;
                                        if (appartenanceCu)
                                        {
                                            bool quitter2_1_1 = false;
                                            int nb_proposition2_1_1 = 4;
                                            int proposition2_1_1 = 1;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Vous êtes connecté en tant que cuisinier\n");
                                                switch (proposition2_1_1)
                                                {
                                                    case 1:
                                                        Console.WriteLine("\tProposer un plat <\n\tFaire une livraison\n\tConsulter le profil\n\tDeconnexion");
                                                        break;
                                                    case 2:
                                                        Console.WriteLine("\tProposer un plat\n\tFaire une livraison <\n\tConsulter le profil\n\tDeconnexion");
                                                        break;
                                                    case 3:
                                                        Console.WriteLine("\tProposer un plat\n\tFaire une livraison\n\tConsulter le profil <\n\tDeconnexion");
                                                        break;
                                                    case 4:
                                                        Console.WriteLine("\tProposer un plat\n\tFaire une livraison\n\tConsulter le profil\n\tDeconnexion <");
                                                        break;
                                                }
                                                cki = Console.ReadKey();
                                                if (cki.Key == ConsoleKey.UpArrow)
                                                {
                                                    proposition2_1_1--;
                                                    if (proposition2_1_1 == 0) { proposition2_1_1 = nb_proposition2_1_1; }
                                                }
                                                if (cki.Key == ConsoleKey.DownArrow)
                                                {
                                                    proposition2_1_1++;
                                                    if (proposition2_1_1 > nb_proposition2_1_1) { proposition2_1_1 = 1; }
                                                }
                                                if (cki.Key == ConsoleKey.Enter)
                                                {
                                                    Console.Clear();
                                                    switch (proposition2_1_1)
                                                    {
                                                        case 1:
                                                            bool quitter2_1_1_1 = false;
                                                            int nb_proposition2_1_1_1 = 3;
                                                            int proposition2_1_1_1 = 1;
                                                            string type_plat = "Entrée";
                                                            do
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Quel est le type du plat : \n");
                                                                switch (proposition2_1_1_1)
                                                                {
                                                                    case 1:
                                                                        Console.WriteLine("\tUne entrée <\n\tUn plat\n\tUn dessert");
                                                                        type_plat = "Entrée";
                                                                        break;
                                                                    case 2:
                                                                        Console.WriteLine("\tUne entrée\n\tUn plat <\n\tUn dessert");
                                                                        type_plat = "Plat";
                                                                        break;
                                                                    case 3:
                                                                        Console.WriteLine("\tUne entrée\n\tUn plat\n\tUn dessert <");
                                                                        type_plat = "Dessert";
                                                                        break;
                                                                }
                                                                cki = Console.ReadKey();
                                                                if (cki.Key == ConsoleKey.UpArrow)
                                                                {
                                                                    proposition2_1_1_1--;
                                                                    if (proposition2_1_1_1 == 0) { proposition2_1_1_1 = nb_proposition2_1_1_1; }
                                                                }
                                                                if (cki.Key == ConsoleKey.DownArrow)
                                                                {
                                                                    proposition2_1_1_1++;
                                                                    if (proposition2_1_1_1 > nb_proposition2_1_1_1) { proposition2_1_1_1 = 1; }
                                                                }
                                                                if (cki.Key == ConsoleKey.Enter)
                                                                {
                                                                    quitter2_1_1_1 = true;
                                                                }
                                                            } while (!quitter2_1_1_1);
                                                            Console.Write("Quel est le nom du plat : ");
                                                            string nomPlat = Console.ReadLine();
                                                            Console.Write("\nPour combien de personnes est ce plat : ");
                                                            string quantiteS = Console.ReadLine();
                                                            while (!Int32.TryParse(quantiteS, out int quantite) || quantite <= 0)
                                                            {
                                                                Console.WriteLine("La quantité renseigné n'est pas au bon format");
                                                                Console.Write("Pour combien de personnes est ce plat : ");

                                                                quantiteS = Console.ReadLine();
                                                            }
                                                            Console.Write("\nCombien coûte un part : ");
                                                            string prixS = Console.ReadLine();
                                                            while (!Double.TryParse(prixS, out double prix) || prix <= 0)
                                                            {
                                                                Console.WriteLine("Le prix renseigné n'est pas au bon format");
                                                                Console.Write("Combien coûte un part : ");
                                                                prixS = Console.ReadLine();
                                                            }
                                                            Console.Write("\nAjoutez une description au plat (incluez le régime alimentaire et la nationalité si besoin) :");
                                                            string description = Console.ReadLine();                                                            
                                                            MySqlParameter idPl = new MySqlParameter("@idPl", MySqlDbType.Int32);
                                                            idPl.Value = cpt_clients;
                                                            MySqlParameter typePl = new MySqlParameter("@typePl", MySqlDbType.VarChar);
                                                            typePl.Value = type_plat;
                                                            MySqlParameter qtPl = new MySqlParameter("@qtPl", MySqlDbType.Int32);
                                                            qtPl.Value = quantiteS;
                                                            MySqlParameter prixPl = new MySqlParameter("@prixPl", MySqlDbType.Float);
                                                            prixPl.Value = prixS;
                                                            MySqlParameter descPl = new MySqlParameter("@descPl", MySqlDbType.VarChar);
                                                            descPl.Value = description;                                                                                                         
                                                            string insertPlat = "INSERT INTO Plat (Numero_Plat, Type_Plat, Quantite_Plat, Prix, Description_plat, Identifiant_Cuisinier)" +
                                                                " VALUES (@idPl, @typePl, @qtPl, @prixPl, @descPl, 1)";
                                                            MySqlCommand insertPl = maConnexion.CreateCommand();
                                                            insertPl.Parameters.Add(idPl);
                                                            insertPl.Parameters.Add(qtPl);
                                                            insertPl.Parameters.Add(typePl);
                                                            insertPl.Parameters.Add(prixPl);
                                                            insertPl.Parameters.Add(descPl);                                                           
                                                            insertPl.CommandText = insertPlat;
                                                            try
                                                            {
                                                                insertPl.ExecuteNonQuery();
                                                            }
                                                            catch (MySqlException e)
                                                            {
                                                                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                                                Console.ReadLine();
                                                                return;
                                                            }
                                                            insertPl.Dispose();
                                                            //Amélioration : Ingrédients & Date2Péremption
                                                            break;
                                                        case 2:
                                                            Console.WriteLine("En cours de dévleoppement");
                                                            Console.ReadKey();
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("Voici les informations de votre profil\n(pour l'instant affiche tous les profils existants car le système de connexion n'a pas été mis en place pour éviter d'empecher l'accès à certaines parties de l'interface");
                                                            string requete = " SELECT * FROM Cuisinier ;";
                                                            MySqlCommand command1 = maConnexion.CreateCommand();
                                                            command1.CommandText = requete;

                                                            reader = command1.ExecuteReader();

                                                            string[] valueString = new string[reader.FieldCount];
                                                            while (reader.Read())
                                                            {
                                                                for (int i = 0; i < reader.FieldCount; i++)
                                                                {
                                                                    valueString[i] = reader.GetValue(i).ToString();
                                                                    Console.Write(valueString[i] + " , ");
                                                                }
                                                                Console.WriteLine();
                                                            }
                                                            reader.Close();
                                                            command1.Dispose();
                                                            Console.ReadKey();
                                                            break;
                                                        case 4:
                                                            quitter2_1_1 = true;
                                                            break;
                                                    }
                                                }
                                            } while (!quitter2_1_1);
                                        }
                                        break;
                                    #endregion
                                    #region CLient
                                    case 2:
                                        Console.Write("\n\tAdresse mail : ");
                                        string mailCl = Console.ReadLine();
                                        Console.Write("\n\tMot de passe : ");
                                        string mdpCl = Console.ReadLine();
                                        //Check appartenance 
                                        bool appartenanceCl = true;
                                        if (appartenanceCl)
                                        {
                                            bool quitter2_1_2 = false;
                                            int nb_proposition2_1_2 = 5;
                                            int proposition2_1_2 = 1;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Vous êtes connecté en tant que client\n");
                                                switch (proposition2_1_2)
                                                {
                                                    case 1:
                                                        Console.WriteLine("\tAfficher les plats <\n\tPasser une commande\n\tNoter un cuisinier\n\tConsulter le profil\n\tDeconnexion");
                                                        break;
                                                    case 2:
                                                        Console.WriteLine("\tAfficher les plats\n\tPasser une commande <\n\tNoter un cuisinier\n\tConsulter le profil\n\tDeconnexion");
                                                        break;
                                                    case 3:
                                                        Console.WriteLine("\tAfficher les plats\n\tPasser une commande\n\tNoter un cuisinier <\n\tConsulter le profil\n\tDeconnexion");
                                                        break;
                                                    case 4:
                                                        Console.WriteLine("\tAfficher les plats\n\tPasser une commande\n\tNoter un cuisinier\n\tConsulter le profil <\n\tDeconnexion");
                                                        break;
                                                    case 5:
                                                        Console.WriteLine("\tAfficher les plats\n\tPasser une commande\n\tNoter un cuisinier\n\tConsulter le profil\n\tDeconnexion <");
                                                        break;
                                                }
                                                cki = Console.ReadKey();
                                                if (cki.Key == ConsoleKey.UpArrow)
                                                {
                                                    proposition2_1_2--;
                                                    if (proposition2_1_2 == 0) { proposition2_1_2 = nb_proposition2_1_2; }
                                                }
                                                if (cki.Key == ConsoleKey.DownArrow)
                                                {
                                                    proposition2_1_2++;
                                                    if (proposition2_1_2 > nb_proposition2_1_2) { proposition2_1_2 = 1; }
                                                }
                                                if (cki.Key == ConsoleKey.Enter)
                                                {
                                                    Console.Clear();
                                                    switch (proposition2_1_2)
                                                    {
                                                        case 1:
                                                            //Switch entre "rechercher et filtres de la recherche puis switch des filtres
                                                            Console.WriteLine("\nFiltres en cours de dévelopement\n(tous les plats existants sont affichés pour l'instant : ");
                                                            string requete = " SELECT * FROM Plat ;";
                                                            MySqlCommand command1 = maConnexion.CreateCommand();
                                                            command1.CommandText = requete;

                                                            reader = command1.ExecuteReader();

                                                            string[] valueString = new string[reader.FieldCount];
                                                            while (reader.Read())
                                                            {
                                                                for (int i = 0; i < reader.FieldCount; i++)
                                                                {
                                                                    valueString[i] = reader.GetValue(i).ToString();
                                                                    Console.Write(valueString[i] + " , ");
                                                                }
                                                                Console.WriteLine();
                                                            }
                                                            reader.Close();
                                                            command1.Dispose();
                                                            Console.ReadKey();
                                                            break;
                                                        case 2:
                                                            Console.Write("Quel plat souhaitez vous commander : ");
                                                            string nom_plat = Console.ReadLine();
                                                            //Ajouter dans la commandes
                                                            break;
                                                        case 3:
                                                            Console.Write("Quel cuisinier souhaitez vous noter : ");
                                                            string nom_cuisinier = Console.ReadLine();
                                                            //Check existence et commande
                                                            Console.Write("Quelle note lui attribuez vous (entre 1 et 5) : ");
                                                            Console.ReadLine();
                                                            //Modifier les notes
                                                            break;
                                                        case 4:
                                                            Console.WriteLine("Voici les informations de votre profil\n(pour l'instant affiche tous les profils existants car le système de connexion n'a pas été mis en place pour éviter d'empecher l'accès à certaines parties de l'interface");
                                                            string requete3 = " SELECT * FROM Client ;";
                                                            MySqlCommand command3 = maConnexion.CreateCommand();
                                                            command3.CommandText = requete3;
                                                            reader = command3.ExecuteReader();

                                                            string[] valueString3 = new string[reader.FieldCount];
                                                            while (reader.Read())
                                                            {
                                                                for (int i = 0; i < reader.FieldCount; i++)
                                                                {
                                                                    valueString3[i] = reader.GetValue(i).ToString();
                                                                    Console.Write(valueString3[i] + " , ");
                                                                }
                                                                Console.WriteLine();
                                                            }
                                                            reader.Close();
                                                            command3.Dispose();
                                                            Console.ReadKey();
                                                            break;
                                                        case 5:
                                                            quitter2_1_2 = true;
                                                            break;
                                                    }
                                                }
                                            } while (!quitter2_1_2);
                                        }
                                        break;
                                    #endregion 
                                    case 3:
                                        quitter2_1 = true;
                                        break;
                                }
                            }
                        } while (!quitter2_1);
                        break;
                    #endregion
                    #region Inscription
                    case 2:
                        bool quitter2_2 = false;
                        int nb_proposition2_2 = 3;
                        int proposition2_2 = 1;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Inscription : \n");
                            switch (proposition2_2)
                            {
                                case 1:
                                    Console.WriteLine("\tCuisinier <\n\tClient\n\tRetour");
                                    break;
                                case 2:
                                    Console.WriteLine("\tCuisinier\n\tClient <\n\tRetour");
                                    break;
                                case 3:
                                    Console.WriteLine("\tCuisinier\n\tClient\n\tRetour <");
                                    break;
                            }
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.UpArrow)
                            {
                                proposition2_2--;
                                if (proposition2_2 == 0) { proposition2_2 = nb_proposition2_2; }
                            }
                            if (cki.Key == ConsoleKey.DownArrow)
                            {
                                proposition2_2++;
                                if (proposition2_2 > nb_proposition2_2) { proposition2_2 = 1; }
                            }
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                switch (proposition2_2)
                                {
                                    #region Cuisinier
                                    case 1:
                                        Console.WriteLine("Identifiants : ");
                                        Console.Write("\nSaisissez votre adresse mail : ");
                                        string mail = Console.ReadLine();
                                        int mailexiste = 1;
                                        MySqlParameter mailTst = new MySqlParameter("@mail", MySqlDbType.VarChar);
                                        mailTst.Value = mail;
                                        string existeMail = "SELECT COUNT(*) FROM Cuisinier WHERE Adresse_Mail_Cuisinier = @mail;";
                                        MySqlCommand command2 = maConnexion.CreateCommand();
                                        command2.Parameters.Add(mailTst);
                                        command2.CommandText = existeMail;
                                        MySqlDataReader reader2 = command2.ExecuteReader();
                                        command2.CommandText = existeMail;
                                        while (reader2.Read())
                                        {
                                            for (int i = 0; i < reader2.FieldCount; i++)
                                            {
                                                mailexiste = Int32.Parse(reader2.GetValue(i).ToString());
                                            }
                                        }
                                        Console.WriteLine(mailexiste);
                                        reader2.Close();
                                        while (!mail.Contains('@') || !mail.Contains('.') || (mailexiste > 0))
                                        {
                                            Console.WriteLine(mailexiste);
                                            Console.Write("Cette adresse mail est déjà utilisée ou n'est pas au bon format, veuillez en choisir une autre : ");
                                            mail = Console.ReadLine();
                                            mailTst.Value = mail;
                                            reader2 = command2.ExecuteReader();
                                            command2.CommandText = existeMail;
                                            while (reader2.Read())
                                            {
                                                for (int i = 0; i < reader2.FieldCount; i++)
                                                {
                                                    mailexiste = Int32.Parse(reader2.GetValue(i).ToString());
                                                }
                                            }
                                            reader2.Close();
                                        }
                                        Console.Write("\nChoisissez votre mot de passe : ");
                                        string mdp = Console.ReadLine();
                                        while (mdp.Length < 8)
                                        {
                                            Console.Write("Le mot de passe doit contenir au moins 8 caractères : ");
                                            mdp = Console.ReadLine();
                                        }
                                        Console.Clear();
                                        Console.WriteLine("Informations du profil : ");
                                        Console.Write("\nQuel est votre nom : ");
                                        string nom = Console.ReadLine();
                                        Console.Write("\nQuel est votre prénom : ");
                                        string prenom = Console.ReadLine();
                                        Console.Write("\nQuel est votre numéro de téléphone : ");
                                        string telephone = Console.ReadLine();
                                        long tel;
                                        while (telephone.Length < 10 || telephone[0] != '0' || !Int64.TryParse(telephone, out tel))
                                        {
                                            Console.Write("Le numéro renseigné est incorrect : ");
                                            telephone = Console.ReadLine();
                                        }
                                        Console.WriteLine("\nLe compte cuisinier a bien été créé, vous pouvez retourner à la page d'acceuil et vous connecter !");
                                        Console.ReadKey();
                                        cpt_cuisiniers++;
                                        MySqlParameter idCu = new MySqlParameter("@idCu", MySqlDbType.Int32);
                                        idCu.Value = cpt_cuisiniers;
                                        MySqlParameter mailCu = new MySqlParameter("@mailCu", MySqlDbType.VarChar);
                                        mailCu.Value = mail;
                                        MySqlParameter mdpCu = new MySqlParameter("@mdpCu", MySqlDbType.VarChar);
                                        mdpCu.Value = mdp;
                                        MySqlParameter nomCu = new MySqlParameter("@nomCu", MySqlDbType.VarChar);
                                        nomCu.Value = nom;
                                        MySqlParameter prenomCu = new MySqlParameter("@prenomCu", MySqlDbType.VarChar);
                                        prenomCu.Value = prenom;
                                        MySqlParameter telCu = new MySqlParameter("@telCu", MySqlDbType.Int64);
                                        telCu.Value = tel;
                                        string insertTable = "INSERT INTO Cuisinier (Identifiant_Cuisinier, Mot_De_Passe_Cuisinier, Nom_Cuisinier, Prenom_Cuisinier, Telephone_Cuisinier, Adresse_Mail_Cuisinier) VALUES (@idCu, @mdpCu, @nomCu, @prenomCu, @telCu, @mailCu);";
                                        MySqlCommand insertCu = maConnexion.CreateCommand();
                                        insertCu.Parameters.Add(idCu);
                                        insertCu.Parameters.Add(mailCu);
                                        insertCu.Parameters.Add(mdpCu);
                                        insertCu.Parameters.Add(nomCu);
                                        insertCu.Parameters.Add(prenomCu);
                                        insertCu.Parameters.Add(telCu);
                                        insertCu.CommandText = insertTable;
                                        try
                                        {
                                            insertCu.ExecuteNonQuery();
                                        }
                                        catch (MySqlException e)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                            Console.ReadLine();
                                            return;
                                        }
                                        insertCu.Dispose();
                                        quitter2_2 = true;
                                        break;
                                    #endregion
                                    #region Client
                                    case 2:
                                        bool quitter_2_2_1 = false;
                                        int nb_proposition2_2_1 = 2;
                                        int proposition2_2_1 = 1;
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Êtes-vous une entreprise ou un particulier ?\n");
                                            switch (proposition2_2_1)
                                            {
                                                case 1:
                                                    Console.WriteLine("\tUne entreprise <\n\tUn particulier");
                                                    break;
                                                case 2:
                                                    Console.WriteLine("\tUne entreprise\n\tUn particulier <");
                                                    break;
                                            }
                                            cki = Console.ReadKey();
                                            if (cki.Key == ConsoleKey.UpArrow)
                                            {
                                                proposition2_2_1--;
                                                if (proposition2_2_1 == 0) { proposition2_2_1 = nb_proposition2_2_1; }
                                            }
                                            if (cki.Key == ConsoleKey.DownArrow)
                                            {
                                                proposition2_2_1++;
                                                if (proposition2_2_1 > nb_proposition2_2_1) { proposition2_2_1 = 1; }
                                            }
                                            if (cki.Key == ConsoleKey.Enter)
                                            {
                                                quitter_2_2_1 = true;
                                            }
                                        } while (!quitter_2_2_1);
                                        if (proposition2_2_1 == 1)
                                        {
                                            Console.WriteLine("\nIdentifiants : ");
                                            Console.Write("\nSaisissez une adresse adresse mail pour l'entreprise : ");
                                            string mailE = Console.ReadLine();
                                            int mailexisteE = 1;
                                            MySqlParameter mailTstE = new MySqlParameter("@mail", MySqlDbType.VarChar);
                                            string existeMailE = " SELECT COUNT(*) FROM Client WHERE Adresse_Mail_Client = @mail;";
                                            mailTstE.Value = mailE;
                                            MySqlCommand command2E = maConnexion.CreateCommand();
                                            command2E.Parameters.Add(mailTstE);
                                            command2E.CommandText = existeMailE;
                                            MySqlDataReader reader2E = command2E.ExecuteReader();
                                            command2E.CommandText = existeMailE;
                                            while (reader2E.Read())
                                            {
                                                for (int i = 0; i < reader2E.FieldCount; i++)
                                                {
                                                    mailexisteE = Int32.Parse(reader2E.GetValue(i).ToString());
                                                }
                                            }
                                            reader2E.Close();
                                            while (!mailE.Contains('@') || !mailE.Contains('.') || (mailexisteE > 0))
                                            {
                                                Console.Write("Cette adresse mail est déjà utilisée ou n'est pas au bon format, veuillez en choisir une autre : ");
                                                mailE = Console.ReadLine();
                                                mailTstE.Value = mailE;
                                                reader2 = command2E.ExecuteReader();
                                                command2E.CommandText = existeMailE;
                                                while (reader2E.Read())
                                                {
                                                    for (int i = 0; i < reader2E.FieldCount; i++)
                                                    {
                                                        mailexisteE = Int32.Parse(reader2E.GetValue(i).ToString());
                                                    }
                                                }
                                                reader2E.Close();
                                            }
                                            Console.Write("\nChoisissez un mot de passe : ");
                                            string mdpE = Console.ReadLine();
                                            while (mdpE.Length < 8)
                                            {
                                                Console.Write("Le mot de passe doit contenir au moins 8 caractères : ");
                                                mdpE = Console.ReadLine();
                                            }
                                            Console.Clear();
                                            Console.WriteLine("Informations de l'entreprise : ");
                                            Console.Write("\nQuel est le nom de l'entreprise : ");
                                            string nomE = Console.ReadLine();
                                            Console.Write("\nQuel est le nom du référent : ");
                                            string nomR = Console.ReadLine();
                                            Console.Write("\nQuel est le prénom du référent : ");
                                            string prenomR = Console.ReadLine();
                                            Console.Write("\nSaisissez un numéro de téléphone pour l'entreprise : ");
                                            string telephoneE = Console.ReadLine();
                                            while (telephoneE.Length < 10 || telephoneE[0] != '0' || !Int64.TryParse(telephoneE, out long num_tel))
                                            {
                                                Console.Write("Le numéro renseigné est incorrect : ");
                                                telephoneE = Console.ReadLine();
                                            }
                                            Console.WriteLine("\nLe compte client entreprise a bien été créé, vous pouvez retourner à la page d'acceuil et vous connecter !");
                                            Console.ReadKey();
                                            cpt_clients++;
                                            MySqlParameter idClE = new MySqlParameter("@idClE", MySqlDbType.Int32);
                                            idClE.Value = cpt_clients;
                                            MySqlParameter mailClE = new MySqlParameter("@mailClE", MySqlDbType.VarChar);
                                            mailClE.Value = mailE;
                                            MySqlParameter mdpClE = new MySqlParameter("@mdpClE", MySqlDbType.VarChar);
                                            mdpClE.Value = mdpE;
                                            MySqlParameter nomClE = new MySqlParameter("@nomClE", MySqlDbType.VarChar);
                                            nomClE.Value = nomE;
                                            MySqlParameter nomClR = new MySqlParameter("@nomClR", MySqlDbType.VarChar);
                                            nomClE.Value = nomR;
                                            MySqlParameter prenomClE = new MySqlParameter("@prenomClE", MySqlDbType.VarChar);
                                            prenomClE.Value = prenomR;
                                            MySqlParameter telClE = new MySqlParameter("@telClE", MySqlDbType.Int64);
                                            telClE.Value = telephoneE;
                                            string insertCl = "INSERT INTO Client (Identifiant_Client, type, Mot_De_Passe_Client, Telephone_Client, Adresse_Mail_Client, Nom_Entreprise, Nom_Referent, Prenom_Referent)" +
                                                " VALUES (@idClE, 'Entreprise', @mdpClE, @telClE, @mailClE, @nomClE, @nomClR, @prenomClE)";
                                            MySqlCommand insertClE = maConnexion.CreateCommand();
                                            insertClE.Parameters.Add(idClE);
                                            insertClE.Parameters.Add(mailClE);
                                            insertClE.Parameters.Add(mdpClE);
                                            insertClE.Parameters.Add(nomClE);
                                            insertClE.Parameters.Add(nomClR);
                                            insertClE.Parameters.Add(prenomClE);
                                            insertClE.Parameters.Add(telClE);
                                            insertClE.CommandText = insertCl;
                                            try
                                            {
                                                insertClE.ExecuteNonQuery();
                                            }
                                            catch (MySqlException e)
                                            {
                                                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                                Console.ReadLine();
                                                return;
                                            }
                                            insertClE.Dispose();
                                        }
                                        if (proposition2_2_1 == 2)
                                        {
                                            Console.WriteLine("\nIdentifiants : ");
                                            Console.Write("\nSaisissez votre adresse mail : ");
                                            string mailP = Console.ReadLine();
                                            int mailexisteP = 0;
                                            MySqlParameter mailTstP = new MySqlParameter("@mail", MySqlDbType.VarChar);
                                            string existeMailP = " SELECT COUNT(*) FROM Client WHERE Adresse_Mail_Client = @mail;";
                                            mailTstP.Value = mailP;
                                            MySqlCommand command2P = maConnexion.CreateCommand();
                                            command2P.Parameters.Add(mailTstP);
                                            command2P.CommandText = existeMailP;
                                            MySqlDataReader reader2P = command2P.ExecuteReader();
                                            command2P.CommandText = existeMailP;
                                            while (reader2P.Read())
                                            {
                                                for (int i = 0; i < reader2P.FieldCount; i++)
                                                {
                                                    mailexisteP = Int32.Parse(reader2P.GetValue(i).ToString());
                                                }
                                            }
                                            reader2P.Close();
                                            while (!mailP.Contains('@') || !mailP.Contains('.') || (mailexisteP > 0))
                                            {
                                                Console.Write("Cette adresse mail est déjà utilisée ou n'est pas au bon format, veuillez en choisir une autre : ");
                                                mailP = Console.ReadLine();
                                                mailTstP.Value = mailP;
                                                reader2 = command2P.ExecuteReader();
                                                command2P.CommandText = existeMailP;
                                                while (reader2P.Read())
                                                {
                                                    for (int i = 0; i < reader2P.FieldCount; i++)
                                                    {
                                                        mailexisteP = Int32.Parse(reader2P.GetValue(i).ToString());
                                                    }
                                                }
                                                reader2P.Close();
                                            }
                                            Console.Write("\nChoisissez votre mot de passe : ");
                                            string mdpP = Console.ReadLine();
                                            while (mdpP.Length < 8)
                                            {
                                                Console.Write("Le mot de passe doit contenir au moins 8 caractères : ");
                                                mdpP = Console.ReadLine();
                                            }
                                            Console.Clear();
                                            Console.WriteLine("Informations du profil : ");
                                            Console.Write("\nQuel est votre nom : ");
                                            string nomP = Console.ReadLine();
                                            Console.Write("\nQuel est votre prénom : ");
                                            string prenomP = Console.ReadLine();
                                            Console.Write("\nQuel est votre numéro de téléphone : ");
                                            string telephoneP = Console.ReadLine();
                                            while (telephoneP.Length < 10 || telephoneP[0] != '0' || !Int64.TryParse(telephoneP, out long num_tel))
                                            {
                                                Console.Write("Le numéro renseigné est incorrect : ");
                                                telephoneP = Console.ReadLine();
                                            }
                                            Console.WriteLine("\nLe compte client particulier a bien été créé, vous pouvez retourner à la page d'acceuil et vous connecter !");
                                            Console.ReadKey();
                                            cpt_clients++;
                                            MySqlParameter idCl = new MySqlParameter("@idCl", MySqlDbType.Int32);
                                            idCl.Value = cpt_clients;
                                            MySqlParameter mailCl = new MySqlParameter("@mailCl", MySqlDbType.VarChar);
                                            mailCl.Value = mailP;
                                            MySqlParameter mdpCl = new MySqlParameter("@mdpCl", MySqlDbType.VarChar);
                                            mdpCl.Value = mdpP;
                                            MySqlParameter nomCl = new MySqlParameter("@nomCl", MySqlDbType.VarChar);
                                            nomCl.Value = nomP;
                                            MySqlParameter prenomCl = new MySqlParameter("@prenomCl", MySqlDbType.VarChar);
                                            prenomCl.Value = prenomP;
                                            MySqlParameter telCl = new MySqlParameter("@telCl", MySqlDbType.Int64);
                                            telCl.Value = telephoneP;
                                            string insertClR = "INSERT INTO Client (Identifiant_Client, type, Mot_De_Passe_Client, Telephone_Client, Adresse_Mail_Client, Nom_Particulier, Prenom_Particulier)" +
                                                " VALUES (@idCl, 'Particulier', @mdpCl, @telCl, @mailCl, @nomCl, @prenomCl)";
                                            MySqlCommand insertCl = maConnexion.CreateCommand();
                                            insertCl.Parameters.Add(idCl);
                                            insertCl.Parameters.Add(mailCl);
                                            insertCl.Parameters.Add(mdpCl);
                                            insertCl.Parameters.Add(nomCl);
                                            insertCl.Parameters.Add(prenomCl);
                                            insertCl.Parameters.Add(telCl);
                                            insertCl.CommandText = insertClR;
                                            try
                                            {
                                                insertCl.ExecuteNonQuery();
                                            }
                                            catch (MySqlException e)
                                            {
                                                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                                Console.ReadLine();
                                                return;
                                            }
                                            insertCl.Dispose();
                                        }
                                        quitter2_2 = true;
                                        break;
                                    #endregion
                                    case 3:
                                        quitter2_2 = true;
                                        break;
                                }
                            }
                        } while (!quitter2_2);
                        break;
                    #endregion
                    case 3:
                        quitter1 = true;
                        break;
                }

            }
        } while (!quitter1);
        Console.Clear();
        Console.WriteLine("\nMerci d'avoir utilisé Livin' Paris !!!\nA bientôt !\n");
        #endregion
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

    public static void OuvrirImage(string cheminFichier = "graphe.png")
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
