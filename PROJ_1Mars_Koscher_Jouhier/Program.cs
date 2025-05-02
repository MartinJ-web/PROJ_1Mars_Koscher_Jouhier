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
using Org.BouncyCastle.Asn1;
using Mysqlx.Crud;
using System.Numerics;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Runtime.ConstrainedExecution;
internal class Program
{
    private static void Main(string[] args)
    {
        #region Tests
        #region 1erMars
        //Console.WriteLine("Avant d'accéder au travail sur l'interface, voici un extrait du travail sur les graphes (poids, sens, pcc) (le graphe pris en exemple est celui du TD3 exo1)");
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
        //OuvrirImage();
        //Console.ReadKey();



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

        #endregion
        #region 4Avril
        //Console.Clear();
        //Console.WriteLine("Comme il n'est pas encore inclus dans l'interface, voici le graphe du metro ou est dessiné en rouge le plus cours chemin d'une station à une autre (aléatoires) avec dijkstra\n");
        //List<Noeud<Station>> noeuds = new List<Noeud<Station>>();
        //string[] lignesN = File.ReadAllLines("PROJ_Noeud_Station.csv", Encoding.Latin1);
        //for (int i = 1; i < lignesN.Length; i++)
        //{
        //    string[] ligne = lignesN[i].Split(';');
        //    Station station = new Station(ligne[1], ligne[2], float.Parse(ligne[3]), float.Parse(ligne[4]), ligne[5], Int32.Parse(ligne[6]));
        //    Noeud<Station> noeud = new Noeud<Station>(Convert.ToInt32(ligne[0]), station);
        //    noeuds.Add(noeud);
        //}
        //string[] lignes2 = File.ReadAllLines("PROJ_Lien_Station.txt");
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
        //string[] liens = new string[lignes2.Length + nouveaux_liens.Count];
        //for (int i = 0; i < liens.Length; i++)
        //{
        //    if (i < lignes2.Length)
        //    {
        //        liens[i] = lignes2[i];
        //    }
        //    else
        //    {
        //        liens[i] = nouveaux_liens[i - lignes2.Length];
        //    }
        //}
        //Random random = new Random();
        //int D = random.Next(0, 331);
        //int A = random.Next(0, 331);
        //Graphe<Station> metro = new Graphe<Station>(noeuds, liens);
        //Console.WriteLine(metro.EstConnexe());
        //Console.Write("Chemin le plus court avec Dijkstra depuis " + metro.Noeuds[A].Classe.Nom + " vers " + metro.Noeuds[D].Classe.Nom + " : ");
        //AfficheMetro(metro, metro.PCC_Dijkstra(metro.Noeuds[D], metro.Noeuds[A]));
        //List<Noeud<Station>> pcc_dijkstrametro = metro.PCC_Dijkstra(metro.Noeuds[D], metro.Noeuds[A]);
        //if (pcc_dijkstrametro != null)
        //{
        //    for (int i = 0; i < pcc_dijkstrametro.Count; i++)
        //    {
        //        Console.Write(pcc_dijkstrametro[i].Numero + " ");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Il n'y a pas de chemin entre ces noeuds");
        //}
        //OuvrirImage();
        //Console.WriteLine("\nPour continuer avec l'interface, appuyez sur entrée");
        //Console.ReadKey();
        #endregion
        #endregion
        #region Interface
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
        Graphe<Station> metro = new Graphe<Station>(noeuds, liens);
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
        MySqlDataReader reader;
        int cpt_cuisiniers = Compte(maConnexion, "Cuisinier");        
        int cpt_clients = Compte(maConnexion, "Client");
        int cpt_plat = Compte(maConnexion, "Plat");
        ConsoleKeyInfo cki;
        bool quitter1 = false;
        int nb_proposition1 = 4;
        int proposition1 = 1;
        do
        {
            Console.Clear();
            Console.WriteLine("Bienvenue sur Livin'Paris !\n");
            switch (proposition1)
            {
                case 1:
                    Console.WriteLine("\tSe connecter <\n\tS'inscrire\n\tEspace admin\n\tQuitter");
                    break;
                case 2:
                    Console.WriteLine("\tSe connecter\n\tS'inscrire <\n\tEspace admin\n\tQuitter");
                    break;
                case 3:
                    Console.WriteLine("\tSe connecter\n\tS'inscrire\n\tEspace admin <\n\tQuitter");
                    break;
                case 4:
                    Console.WriteLine("\tSe connecter\n\tS'inscrire\n\tEspace admin\n\tQuitter <");
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
                                        MySqlParameter paramMailCu = new MySqlParameter("@mailCu", MySqlDbType.VarChar);
                                        paramMailCu.Value = mailCu;
                                        MySqlParameter paramMdpCu = new MySqlParameter("@mdpCu", MySqlDbType.VarChar);
                                        paramMdpCu.Value = mdpCu;
                                        int appartenanceCu = 0;
                                        MySqlCommand command = maConnexion.CreateCommand();
                                        command.Parameters.Add(paramMailCu);
                                        command.Parameters.Add(paramMdpCu);
                                        command.CommandText = "SELECT COUNT(*) FROM Cuisinier WHERE Adresse_Mail_Cuisinier = @mailCu AND Mot_De_Passe_Cuisinier = @mdpCu;";
                                        reader = command.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                appartenanceCu = Int32.Parse(reader.GetValue(i).ToString());
                                            }
                                        }
                                        reader.Close();
                                        int idCu = 0;
                                        command.CommandText = "SELECT Identifiant_Cuisinier FROM Cuisinier WHERE Adresse_Mail_Cuisinier = @mailCu";
                                        reader = command.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                idCu = Int32.Parse(reader.GetValue(i).ToString());
                                            }
                                        }
                                        reader.Close();
                                        if (appartenanceCu > 0)
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
                                                            cpt_plat++;
                                                            CreationPlat(maConnexion, cpt_plat, idCu);
                                                            Console.WriteLine("\nLe plat a bien été ajouté ! Appuyez sur une touche pour revenir sur votre page d'accueil");
                                                            Console.ReadLine();
                                                            break;
                                                        case 2:
                                                            Console.WriteLine("En cours de développement");
                                                            Console.ReadKey();
                                                            break;
                                                        case 3:
                                                            int nb_proposition2_1_1_1 = 3;
                                                            int proposition2_1_1_1 = 1;
                                                            bool quitter2_1_1_1 = false;
                                                            do
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Voici les informations de votre profil");
                                                                string requete = " SELECT * FROM Cuisinier WHERE Adresse_Mail_Cuisinier = @mailCu;";
                                                                MySqlCommand command1 = maConnexion.CreateCommand();
                                                                command1.Parameters.Add(paramMailCu);
                                                                command1.CommandText = requete;
                                                                reader = command1.ExecuteReader();
                                                                Console.WriteLine();
                                                                string[] valueString = new string[reader.FieldCount];
                                                                while (reader.Read())
                                                                {
                                                                    for (int i = 1; i < reader.FieldCount; i++)
                                                                    {
                                                                        valueString[i] = reader.GetValue(i).ToString();
                                                                        switch (i)
                                                                        {
                                                                            case 1:
                                                                                Console.WriteLine("Mot de passe : " + valueString[i]);
                                                                                break;
                                                                            case 2:
                                                                                Console.WriteLine("Nom : " + valueString[i]);
                                                                                break;
                                                                            case 3: 
                                                                                Console.WriteLine("Prenom : " + valueString[i]);
                                                                                break;
                                                                            case 4:
                                                                                Console.WriteLine("Note : " + valueString[i]);
                                                                                break;
                                                                            case 5:
                                                                                Console.WriteLine("Numero de téléphone : 0" + valueString[i]);
                                                                                break;
                                                                            case 6:
                                                                                Console.WriteLine("Adresse mail : " + valueString[i]);
                                                                                break;
                                                                            case 7:
                                                                                Console.WriteLine("Metro le plus proche : " + metro.Noeuds[Convert.ToInt32(valueString[i])].Classe.Nom);
                                                                                break;
                                                                        }
                                                                    }
                                                                    Console.WriteLine();
                                                                }
                                                                reader.Close();
                                                                command1.Dispose();
                                                                switch (proposition2_1_1_1)
                                                                {
                                                                    case 1:
                                                                        Console.WriteLine("\n\tModifier le profil <\n\tSupprimer le profil\n\tRetour");
                                                                        break;
                                                                    case 2:
                                                                        Console.WriteLine("\n\tModifier le profil\n\tSupprimer le profil <\n\tRetour");
                                                                        break;
                                                                    case 3:
                                                                        Console.WriteLine("\n\tModifier le profil\n\tSupprimer le profil\n\tRetour <");
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
                                                                    Console.Clear();
                                                                    switch (proposition2_1_1_1)
                                                                    {
                                                                        case 1:
                                                                            Console.WriteLine("Modification du profil, saisissez vos nouvelles informations :");
                                                                            Console.Write("\nChoisissez un mot de passe : ");
                                                                            string mdp = Console.ReadLine();
                                                                            while (mdp.Length < 8)
                                                                            {
                                                                                Console.Write("Le mot de passe doit contenir au moins 8 caractères : ");
                                                                                mdp = Console.ReadLine();
                                                                            }
                                                                            Console.WriteLine("\nInformations du profil : ");
                                                                            Console.Write("\nQuel est votre nom : ");
                                                                            string nom = Console.ReadLine();
                                                                            Console.Write("\nQuel est votre prénom : ");
                                                                            string prenom = Console.ReadLine();
                                                                            Console.Write("\nQuel est votre numéro de téléphone : ");
                                                                            string telephone = Console.ReadLine();
                                                                            long tel;
                                                                            while (telephone.Length < 10 || telephone[0] != '0' || !Int64.TryParse(telephone, out tel))
                                                                            {
                                                                                Console.Write("Le numéro renseigné n'est pas au bon format : ");
                                                                                telephone = Console.ReadLine();
                                                                            }
                                                                            Console.Write("\nAdresse : quel est le numéro de ligne de la station de metro la plus proche ?\n\nTapez seulement le numéro (même pour les lignes bis) : ");
                                                                            string ligne = Console.ReadLine();
                                                                            int num_ligne = 0;
                                                                            while (!Int32.TryParse(ligne, out num_ligne) || num_ligne < 1 || num_ligne > 14)
                                                                            {
                                                                                Console.Write("Le numéro de ligne renseigné n'est pas au bon format : ");
                                                                                ligne = Console.ReadLine();
                                                                            }
                                                                            ligne = Convert.ToString(num_ligne);
                                                                            int premier = 0;
                                                                            while (metro.Noeuds[premier].Classe.Ligne != ligne && metro.Noeuds[premier].Classe.Ligne != ligne + "bis")
                                                                            {
                                                                                premier++;
                                                                            }
                                                                            int dernier = metro.Noeuds.Count() - 1;
                                                                            while (metro.Noeuds[dernier].Classe.Ligne != ligne && metro.Noeuds[dernier].Classe.Ligne != ligne + "bis")
                                                                            {
                                                                                dernier--;
                                                                            }
                                                                            bool quitter = false;
                                                                            int cpt = premier;
                                                                            int station = premier;
                                                                            do
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine("Choississsez la station la plus proche de chez vous : \n\n---------------------------------------------------");
                                                                                for (int i = 0; i < 5; i++)
                                                                                {
                                                                                    if (cpt + i <= dernier)
                                                                                    {
                                                                                        if (i == 0)
                                                                                        {
                                                                                            Console.WriteLine("(" + metro.Noeuds[cpt + i].Classe.Ligne + ") " + metro.Noeuds[cpt + i].Classe.Nom + " <");
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("(" + metro.Noeuds[cpt + i].Classe.Ligne + ") " + metro.Noeuds[cpt + i].Classe.Nom);
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("");
                                                                                    }
                                                                                }
                                                                                Console.WriteLine("---------------------------------------------------\n");
                                                                                cki = Console.ReadKey();
                                                                                switch (cki.Key)
                                                                                {
                                                                                    case ConsoleKey.UpArrow:
                                                                                        if (cpt - 1 >= premier)
                                                                                        {
                                                                                            cpt--;
                                                                                        }
                                                                                        break;
                                                                                    case ConsoleKey.DownArrow:
                                                                                        if (cpt + 1 <= dernier)
                                                                                        {
                                                                                            cpt++;
                                                                                        }
                                                                                        break;
                                                                                    case ConsoleKey.Enter:
                                                                                        station = cpt;
                                                                                        quitter = true;
                                                                                        break;
                                                                                }
                                                                            } while (!quitter);
                                                                            Console.WriteLine("\nLes informations de votre compte client entreprise ont bien été modifiés, vous allez être déconneté");
                                                                            Console.ReadKey();
                                                                            paramMdpCu.Value = mdp;
                                                                            MySqlParameter nomCu = new MySqlParameter("@nomCu", MySqlDbType.VarChar);
                                                                            nomCu.Value = nom;
                                                                            MySqlParameter prenomCu = new MySqlParameter("@prenomCu", MySqlDbType.VarChar);
                                                                            prenomCu.Value = prenom;
                                                                            MySqlParameter telCu = new MySqlParameter("@telCu", MySqlDbType.Int64);
                                                                            telCu.Value = tel;
                                                                            string insertTable = "UPDATE Cuisinier SET Mot_De_Passe_Cuisinier = @mdpCu, Telephone_Cuisinier = @telCu, Metro_Cuisinier = " + Convert.ToString(station) + ", Nom_Cuisinier = @nomCu, Prenom_Cuisinier = @prenomCu WHERE Identifiant_Cuisinier = " + idCu + ";";
                                                                            MySqlCommand insertCu = maConnexion.CreateCommand();
                                                                            insertCu.Parameters.Add(paramMdpCu);
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
                                                                            quitter2_1_1_1 = true;
                                                                            quitter2_1_1 = true;
                                                                            quitter2_1 = true;
                                                                            break;
                                                                        case 2:
                                                                            int proposition2_1_1_1_1 = 1;
                                                                            int nb_proposition2_1_1_1_1 = 2;
                                                                            bool quitter2_1_1_1_1 = false;
                                                                            do
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine("Êtes-vous sûr de vouloir supprimer le profil ?");
                                                                                switch (proposition2_1_1_1_1)
                                                                                {
                                                                                    case 1:
                                                                                        Console.WriteLine("\n\tOui <\n\tNon");
                                                                                        break;
                                                                                    case 2:
                                                                                        Console.WriteLine("\n\tOui\n\tNon <");
                                                                                        break;
                                                                                }
                                                                                cki = Console.ReadKey();
                                                                                if (cki.Key == ConsoleKey.UpArrow)
                                                                                {
                                                                                    proposition2_1_1_1_1--;
                                                                                    if (proposition2_1_1_1_1 == 0) { proposition2_1_1_1_1 = nb_proposition2_1_1_1_1; }
                                                                                }
                                                                                if (cki.Key == ConsoleKey.DownArrow)
                                                                                {
                                                                                    proposition2_1_1_1_1++;
                                                                                    if (proposition2_1_1_1_1 > nb_proposition2_1_1_1_1) { proposition2_1_1_1_1 = 1; }
                                                                                }
                                                                                if (cki.Key == ConsoleKey.Enter)
                                                                                {
                                                                                    switch (proposition2_1_1_1_1)
                                                                                    {
                                                                                        case 1:
                                                                                            Console.Write("\nEntrez votre mot de passe pour confirmer la suppression du compte : ");
                                                                                            string mdp_suppr = Console.ReadLine();
                                                                                            if (mdp_suppr == mdpCu)
                                                                                            {
                                                                                                MySqlCommand supprimerCompte = maConnexion.CreateCommand();
                                                                                                supprimerCompte.CommandText = "DELETE FROM Cuisinier WHERE Identifiant_Cuisinier = " + idCu + " AND Adresse_Mail_Cuisinier <> \"cuisinier@root.root\";";
                                                                                                try
                                                                                                {
                                                                                                    supprimerCompte.ExecuteNonQuery();
                                                                                                }
                                                                                                catch (MySqlException e)
                                                                                                {
                                                                                                    Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                                                                                    Console.ReadLine();
                                                                                                    return;
                                                                                                }
                                                                                                Console.WriteLine("Le compte a bien été supprimé, vous allez être déconnecté");
                                                                                                Console.ReadKey();
                                                                                                quitter2_1_1_1_1 = true;
                                                                                                quitter2_1_1_1 = true;
                                                                                                quitter2_1_1 = true;
                                                                                                quitter2_1 = true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Console.WriteLine("Mot de passe incorrect");
                                                                                                Console.ReadKey();
                                                                                                quitter2_1_1_1_1 = true;
                                                                                            }
                                                                                            break;
                                                                                        case 2:
                                                                                            quitter2_1_1_1_1 = true;
                                                                                            break;
                                                                                    }
                                                                                }
                                                                            } while (!quitter2_1_1_1_1);
                                                                            break;
                                                                        case 3:
                                                                            quitter2_1_1_1 = true;
                                                                            break;
                                                                    }
                                                                }
                                                            } while (!quitter2_1_1_1) ;
                                                            break;
                                                        case 4:
                                                            quitter2_1_1 = true;
                                                            break;
                                                    }
                                                }
                                            } while (!quitter2_1_1);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nIdentifiant ou mot de passe inccorect");
                                            Console.WriteLine("\n\nAppuyez sur \"entrer\" pour revenir à l'écran de connexion");
                                            Console.ReadLine();
                                        }
                                        break;
                                    #endregion
                                    #region Client
                                    case 2:
                                        Console.Write("\n\tAdresse mail : ");
                                        string mailCl = Console.ReadLine();
                                        Console.Write("\n\tMot de passe : ");
                                        string mdpCl = Console.ReadLine();
                                        MySqlParameter paramMailCl = new MySqlParameter("@mailCl", MySqlDbType.VarChar);
                                        paramMailCl.Value = mailCl;
                                        MySqlParameter paramMdpCl = new MySqlParameter("@mdpCl", MySqlDbType.VarChar);
                                        paramMdpCl.Value = mdpCl;
                                        int appartenanceCl = 0;
                                        command = maConnexion.CreateCommand();
                                        command.Parameters.Add(paramMailCl);
                                        command.Parameters.Add(paramMdpCl);
                                        command.CommandText = "SELECT COUNT(*) FROM Client WHERE Adresse_Mail_Client = @mailCl AND Mot_De_Passe_Client = @mdpCl;";
                                        reader = command.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                appartenanceCl = Int32.Parse(reader.GetValue(i).ToString());
                                            }
                                        }
                                        reader.Close();
                                        int id = 0;
                                        command.CommandText = "SELECT Identifiant_Client FROM Client WHERE Adresse_Mail_Client = @mailCl";
                                        reader = command.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                id = Int32.Parse(reader.GetValue(i).ToString());
                                            }
                                        }
                                        reader.Close();
                                        if (appartenanceCl > 0)
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
                                                            int nb_lignes = Compte(maConnexion, "Plat");
                                                            if (nb_lignes != 0)
                                                            {
                                                                string requete = " SELECT * FROM Plat ;";
                                                                MySqlCommand command1 = maConnexion.CreateCommand();
                                                                command1.CommandText = requete;
                                                                reader = command1.ExecuteReader();
                                                                string[,] plats = new string[nb_lignes, reader.FieldCount];
                                                                string[] valueString = new string[reader.FieldCount];
                                                                int cpt = 0;
                                                                while (reader.Read())
                                                                {
                                                                    for (int i = 0; i < nb_lignes; i++)
                                                                    {
                                                                        plats[cpt, i] = reader.GetValue(i).ToString();
                                                                    }
                                                                    cpt++;
                                                                }
                                                                reader.Close();
                                                                command1.Dispose();
                                                                cpt = 0;
                                                                int choix = cpt;
                                                                int filtre_nb = 1;
                                                                char filtre_type = 'T';
                                                                bool quitter = false;
                                                                do
                                                                {
                                                                    int cinq_lignes_vides = 0;
                                                                    Console.Clear();
                                                                    Console.WriteLine("Voici tous les plats disponibles en ce moment :\n");
                                                                    string filtre = "P";
                                                                    if(filtre_type == 'E')
                                                                    {
                                                                        filtre = "Entrées p";
                                                                    }
                                                                    if(filtre_type == 'P')
                                                                    {
                                                                        filtre = "Plats p";
                                                                    }
                                                                    if(filtre_type == 'D')
                                                                    {
                                                                        filtre = "Desserts p";
                                                                    }
                                                                    if(filtre_type == 'T')
                                                                    {
                                                                        filtre = "p";
                                                                    }
                                                                    Console.WriteLine("\nFiltres : "+ filtre + "our " + filtre_nb + " personne(s) minimum\n---------------------------------------------------\n");
                                                                    for (int i = 0; i < 5; i++)
                                                                    {
                                                                        if (filtre_type != 'T')
                                                                        {
                                                                            while (cpt + i < plats.GetLength(0) && (plats[cpt + i, 2][0] != filtre_type || Convert.ToInt32(plats[cpt + i, 5]) < filtre_nb))
                                                                            {
                                                                                cpt++;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            while (cpt + i < plats.GetLength(0) && Convert.ToInt32(plats[cpt + i, 5]) < filtre_nb)
                                                                            {
                                                                                cpt++;
                                                                            }
                                                                        }
                                                                        if (cpt + i < plats.GetLength(0))
                                                                        {
                                                                            if (i == 0)
                                                                            {
                                                                                Console.WriteLine("(" + plats[cpt + i, 2][0] + ") " + plats[cpt + i, 3] + " <");
                                                                                choix = cpt;
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("(" + plats[cpt + i, 2][0] + ") " + plats[cpt + i, 3]);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("");
                                                                            cinq_lignes_vides++;
                                                                        }
                                                                    }
                                                                    if (cinq_lignes_vides == 5)
                                                                    {
                                                                        choix = -1;
                                                                    }
                                                                    Console.WriteLine("\n---------------------------------------------------\n\n Choix des filtres :\n\tTapez 'E', 'P', 'D' pour n'avoir que les entrées/plats/desserts ou 'T' pour revenir à tous les plats\n\tTapez un chiffre correspondant au nombre minimum de parts souhaité");
                                                                    cki = Console.ReadKey();
                                                                    switch (cki.Key)
                                                                    {
                                                                        case ConsoleKey.E:
                                                                            filtre_type = 'E';
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.P:
                                                                            filtre_type = 'P';
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D:
                                                                            filtre_type = 'D';
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.T:
                                                                            filtre_type = 'T';
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.UpArrow:
                                                                            if (choix != -1)
                                                                            {
                                                                                if (filtre_type != 'T')
                                                                                {
                                                                                    int premier = 0;
                                                                                    while (premier < plats.GetLength(0) && (plats[premier, 2][0] != filtre_type || Convert.ToInt32(plats[premier, 5]) < filtre_nb))
                                                                                    {
                                                                                        premier++;
                                                                                    }
                                                                                    cpt = choix;
                                                                                    if (cpt - 1 >= 0)
                                                                                    {
                                                                                        cpt--;
                                                                                    }
                                                                                    while (cpt - 1 >= premier && (plats[cpt, 2][0] != filtre_type || Convert.ToInt32(plats[cpt, 5]) < filtre_nb))
                                                                                    {
                                                                                        cpt--;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    int premier = 0;
                                                                                    while (premier < plats.GetLength(0) && Convert.ToInt32(plats[premier, 5]) < filtre_nb)
                                                                                    {
                                                                                        premier++;
                                                                                    }
                                                                                    cpt = choix;
                                                                                    if (cpt - 1 >= 0)
                                                                                    {
                                                                                        cpt--;
                                                                                    }
                                                                                    while (cpt - 1 >= premier && Convert.ToInt32(plats[cpt, 5]) < filtre_nb)
                                                                                    {
                                                                                        cpt--;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case ConsoleKey.DownArrow:
                                                                            if (choix != -1)
                                                                            {
                                                                                if (filtre_type != 'T')
                                                                                {
                                                                                    int dernier = plats.GetLength(0) - 1;
                                                                                    while (dernier >= 0 && (plats[dernier, 2][0] != filtre_type || Convert.ToInt32(plats[dernier, 5]) < filtre_nb))
                                                                                    {
                                                                                        dernier--;
                                                                                    }
                                                                                    cpt = choix;
                                                                                    if (cpt + 1 <= dernier)
                                                                                    {
                                                                                        cpt++;
                                                                                    }
                                                                                    while (cpt + 1 <= dernier && (plats[cpt, 2][0] != filtre_type || Convert.ToInt32(plats[dernier, 5]) < filtre_nb))
                                                                                    {
                                                                                        cpt++;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    int dernier = plats.GetLength(0) - 1;
                                                                                    while (dernier >= 0 && Convert.ToInt32(plats[dernier, 5]) < filtre_nb)
                                                                                    {
                                                                                        dernier--;
                                                                                    }
                                                                                    cpt = choix;
                                                                                    if (cpt + 1 <= dernier)
                                                                                    {
                                                                                        cpt++;
                                                                                    }
                                                                                    while (cpt + 1 <= dernier && Convert.ToInt32(plats[dernier, 5]) < filtre_nb)
                                                                                    {
                                                                                        cpt++;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case ConsoleKey.Enter:
                                                                            if (choix != -1)
                                                                            {
                                                                                Console.WriteLine("\nVoici le plat que vous avez sélectionné :\n\n" + plats[choix, 2] + " : " + plats[choix, 3] + "\nPrix : " + Convert.ToString(plats[choix, 6]) + "€\n" + plats[choix, 5] + " part(s) disponibles\nDate de péremption : " + plats[choix, 8] + "\nDescription : " + plats[choix, 4]);
                                                                                //nom cuistot + allergenes
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("\nPas de plats disponible avec ces filtres");
                                                                            }
                                                                            Console.ReadLine();
                                                                            quitter = true;
                                                                            break;
                                                                        case ConsoleKey.D1:
                                                                            filtre_nb = 1;
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D2:
                                                                            filtre_nb = 2;
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D3:
                                                                            filtre_nb = 3;
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D4:
                                                                            filtre_nb = 4;
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D5:
                                                                            filtre_nb = 5;
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D6:
                                                                            filtre_nb = 6;
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D7:
                                                                            filtre_nb = 7;
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D8:
                                                                            filtre_nb = 8;
                                                                            cpt = 0;
                                                                            break;
                                                                        case ConsoleKey.D9:
                                                                            filtre_nb = 9;
                                                                            cpt = 0;
                                                                            break;
                                                                        default:
                                                                            quitter = true;
                                                                            break;
                                                                    }
                                                                } while (!quitter) ;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("\nAucun plat disponible en ce moment");
                                                                Console.ReadKey();
                                                            }
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
                                                            int nb_proposition2_1_2_1 = 3;
                                                            int proposition2_1_2_1 = 1;
                                                            bool quitter2_1_2_1 = false;
                                                            do
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Voici les informations de votre profil\n");
                                                                string requete3 = " SELECT * FROM Client WHERE Adresse_Mail_Client = @mailCl;";
                                                                MySqlCommand command3 = maConnexion.CreateCommand();
                                                                command3.Parameters.Add(paramMailCl);
                                                                command3.CommandText = requete3;
                                                                reader = command3.ExecuteReader();
                                                                string[] valueString3 = new string[reader.FieldCount];
                                                                while (reader.Read())
                                                                {
                                                                    char type = 'e';
                                                                    for (int i = 1; i < reader.FieldCount; i++)
                                                                    {
                                                                        valueString3[i] = reader.GetValue(i).ToString();
                                                                        switch (i)
                                                                        {
                                                                            case 1:
                                                                                Console.WriteLine(valueString3[i]);
                                                                                if (valueString3[i] == "Particulier")
                                                                                {
                                                                                    type = 'p';
                                                                                }
                                                                                break;
                                                                            case 2:
                                                                                Console.WriteLine("Mot de passe : " + valueString3[i]);
                                                                                break;
                                                                            case 3:
                                                                                Console.WriteLine("Numero de téléphone : 0" + valueString3[i]);
                                                                                break;
                                                                            case 4:
                                                                                Console.WriteLine("Adresse mail : " + valueString3[i]);
                                                                                break;
                                                                            case 5:
                                                                                Console.WriteLine("Note : " + valueString3[i]);
                                                                                break;
                                                                            case 6:
                                                                                Console.WriteLine("Metro le plus proche : " + metro.Noeuds[Convert.ToInt32(valueString3[i])].Classe.Nom);
                                                                                break;
                                                                            case 7:
                                                                                if (type == 'p')
                                                                                    Console.WriteLine("Nom : " + valueString3[i]);
                                                                                break;
                                                                            case 8:
                                                                                if (type == 'p')
                                                                                    Console.WriteLine("Prenom : " + valueString3[i]);
                                                                                break;
                                                                            case 9:
                                                                                if (type == 'e')
                                                                                    Console.WriteLine("Nom de l'entreprise : " + valueString3[i]);
                                                                                break;
                                                                            case 10:
                                                                                if (type == 'e')
                                                                                    Console.WriteLine("Nom du référent : " + valueString3[i]);
                                                                                break;
                                                                            case 11:
                                                                                if (type == 'e')
                                                                                    Console.WriteLine("Prenom du référent : " + valueString3[i]);
                                                                                break;
                                                                        }
                                                                    }
                                                                }
                                                                reader.Close();
                                                                command3.Dispose();
                                                                switch (proposition2_1_2_1)
                                                                {
                                                                    case 1:
                                                                        Console.WriteLine("\n\tModifier le profil <\n\tSupprimer le profil\n\tRetour");
                                                                        break;
                                                                    case 2:
                                                                        Console.WriteLine("\n\tModifier le profil\n\tSupprimer le profil <\n\tRetour");
                                                                        break;
                                                                    case 3:
                                                                        Console.WriteLine("\n\tModifier le profil\n\tSupprimer le profil\n\tRetour <");
                                                                        break;
                                                                }
                                                                cki = Console.ReadKey();
                                                                if (cki.Key == ConsoleKey.UpArrow)
                                                                {
                                                                    proposition2_1_2_1--;
                                                                    if (proposition2_1_2_1 == 0) { proposition2_1_2_1 = nb_proposition2_1_2_1; }
                                                                }
                                                                if (cki.Key == ConsoleKey.DownArrow)
                                                                {
                                                                    proposition2_1_2_1++;
                                                                    if (proposition2_1_2_1 > nb_proposition2_1_2_1) { proposition2_1_2_1 = 1; }
                                                                }
                                                                if (cki.Key == ConsoleKey.Enter)
                                                                {
                                                                    Console.Clear();
                                                                    switch (proposition2_1_2_1)
                                                                    {
                                                                        case 1:
                                                                            Console.WriteLine("Modification du profil, saisissez vos nouvelles informations :");
                                                                            command.CommandText = "SELECT Type_Client FROM Client WHERE Adresse_Mail_Client = @mailCl";
                                                                            reader = command.ExecuteReader();
                                                                            string type_modif = "Client";
                                                                            while (reader.Read())
                                                                            {
                                                                                for (int i = 0; i < reader.FieldCount; i++)
                                                                                {
                                                                                    type_modif = reader.GetValue(i).ToString();
                                                                                }
                                                                            }
                                                                            reader.Close();
                                                                            if(type_modif == "Entreprise")
                                                                            {
                                                                                Console.Write("\nChoisissez un mot de passe : ");
                                                                                string mdpE = Console.ReadLine();
                                                                                while (mdpE.Length < 8)
                                                                                {
                                                                                    Console.Write("Le mot de passe doit contenir au moins 8 caractères : ");
                                                                                    mdpE = Console.ReadLine();
                                                                                }
                                                                                Console.WriteLine("\nInformations de l'entreprise : ");
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
                                                                                    Console.Write("Le numéro renseigné n'est pas au bon format : ");
                                                                                    telephoneE = Console.ReadLine();
                                                                                }
                                                                                Console.Write("\nAdresse : quel est le numéro de ligne de la station de metro la plus proche ?\n\nTapez seulement le numéro (même pour les lignes bis) : ");
                                                                                string ligneE = Console.ReadLine();
                                                                                int num_ligneE = 0;
                                                                                while (!Int32.TryParse(ligneE, out num_ligneE) || num_ligneE < 1 || num_ligneE > 14)
                                                                                {
                                                                                    Console.Write("Le numéro de ligne renseigné n'est pas au bon format :");
                                                                                    ligneE = Console.ReadLine();
                                                                                }
                                                                                ligneE = Convert.ToString(num_ligneE);
                                                                                int premierE = 0;
                                                                                while (metro.Noeuds[premierE].Classe.Ligne != ligneE && metro.Noeuds[premierE].Classe.Ligne != ligneE + "bis")
                                                                                {
                                                                                    premierE++;
                                                                                }
                                                                                int dernierE = metro.Noeuds.Count() - 1;
                                                                                while (metro.Noeuds[dernierE].Classe.Ligne != ligneE && metro.Noeuds[dernierE].Classe.Ligne != ligneE + "bis")
                                                                                {
                                                                                    dernierE--;
                                                                                }
                                                                                bool quitterE = false;
                                                                                int cptE = premierE;
                                                                                int stationE = premierE;
                                                                                do
                                                                                {
                                                                                    Console.Clear();
                                                                                    Console.WriteLine("\nChoississsez la station la plus proche de chez vous : \n\n---------------------------------------------------");
                                                                                    for (int i = 0; i < 5; i++)
                                                                                    {
                                                                                        if (cptE + i <= dernierE)
                                                                                        {
                                                                                            if (i == 0)
                                                                                            {
                                                                                                Console.WriteLine("(" + metro.Noeuds[cptE + i].Classe.Ligne + ") " + metro.Noeuds[cptE + i].Classe.Nom + " <");
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Console.WriteLine("(" + metro.Noeuds[cptE + i].Classe.Ligne + ") " + metro.Noeuds[cptE + i].Classe.Nom);
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("");
                                                                                        }
                                                                                    }
                                                                                    Console.WriteLine("---------------------------------------------------\n");
                                                                                    cki = Console.ReadKey();
                                                                                    switch (cki.Key)
                                                                                    {
                                                                                        case ConsoleKey.UpArrow:
                                                                                            if (cptE - 1 >= premierE)
                                                                                            {
                                                                                                cptE--;
                                                                                            }
                                                                                            break;
                                                                                        case ConsoleKey.DownArrow:
                                                                                            if (cptE + 1 <= dernierE)
                                                                                            {
                                                                                                cptE++;
                                                                                            }
                                                                                            break;
                                                                                        case ConsoleKey.Enter:
                                                                                            stationE = cptE;
                                                                                            quitterE = true;
                                                                                            break;
                                                                                    }
                                                                                } while (!quitterE);
                                                                                Console.WriteLine("\nLes informations de votre compte client entreprise ont bien été modifiés, vous allez être déconneté");
                                                                                Console.ReadKey();
                                                                                MySqlParameter mdpClE = new MySqlParameter("@mdpClE", MySqlDbType.VarChar);
                                                                                mdpClE.Value = mdpE;
                                                                                MySqlParameter nomClE = new MySqlParameter("@nomClE", MySqlDbType.VarChar);
                                                                                nomClE.Value = nomE;
                                                                                MySqlParameter nomClR = new MySqlParameter("@nomClR", MySqlDbType.VarChar);
                                                                                nomClR.Value = nomR;
                                                                                MySqlParameter prenomClE = new MySqlParameter("@prenomClE", MySqlDbType.VarChar);
                                                                                prenomClE.Value = prenomR;
                                                                                MySqlParameter telClE = new MySqlParameter("@telClE", MySqlDbType.Int64);
                                                                                telClE.Value = telephoneE;
                                                                                string insertCl = "UPDATE Client SET Mot_De_Passe_Client = @mdpClE, Telephone_Client = @telClE, Metro_Client = " + Convert.ToString(stationE) + ", Nom_Entreprise = @nomClE, Nom_Referent = @nomClR, Prenom_Referent = @prenomClE WHERE Identifiant_Client = " + id + ";";
                                                                                MySqlCommand insertClE = maConnexion.CreateCommand();
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
                                                                            if(type_modif == "Particulier")
                                                                            {
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
                                                                                Console.Write("\nAdresse : quel est le numéro de ligne de la station de metro la plus proche ?\n\nTapez seulement le numéro (même pour les lignes bis) : ");
                                                                                string ligneP = Console.ReadLine();
                                                                                int num_ligneP = 0;
                                                                                while (!Int32.TryParse(ligneP, out num_ligneP) || num_ligneP < 1 || num_ligneP > 14)
                                                                                {
                                                                                    Console.Write("Le numéro de ligne renseigné n'est pas au bon format :");
                                                                                    ligneP = Console.ReadLine();
                                                                                }
                                                                                ligneP = Convert.ToString(num_ligneP);
                                                                                int premierP = 0;
                                                                                while (metro.Noeuds[premierP].Classe.Ligne != ligneP && metro.Noeuds[premierP].Classe.Ligne != ligneP + "bis")
                                                                                {
                                                                                    premierP++;
                                                                                }
                                                                                int dernierP = metro.Noeuds.Count() - 1;
                                                                                while (metro.Noeuds[dernierP].Classe.Ligne != ligneP && metro.Noeuds[dernierP].Classe.Ligne != ligneP + "bis")
                                                                                {
                                                                                    dernierP--;
                                                                                }
                                                                                bool quitterP = false;
                                                                                int cptP = premierP;
                                                                                int stationP = premierP;
                                                                                do
                                                                                {
                                                                                    Console.Clear();
                                                                                    Console.WriteLine("Choississsez la station la plus proche de chez vous : \n\n---------------------------------------------------");
                                                                                    for (int i = 0; i < 5; i++)
                                                                                    {
                                                                                        if (cptP + i <= dernierP)
                                                                                        {
                                                                                            if (i == 0)
                                                                                            {
                                                                                                Console.WriteLine("(" + metro.Noeuds[cptP + i].Classe.Ligne + ") " + metro.Noeuds[cptP + i].Classe.Nom + " <");
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Console.WriteLine("(" + metro.Noeuds[cptP + i].Classe.Ligne + ") " + metro.Noeuds[cptP + i].Classe.Nom);
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("");
                                                                                        }
                                                                                    }
                                                                                    Console.WriteLine("---------------------------------------------------\n");
                                                                                    cki = Console.ReadKey();
                                                                                    switch (cki.Key)
                                                                                    {
                                                                                        case ConsoleKey.UpArrow:
                                                                                            if (cptP - 1 >= premierP)
                                                                                            {
                                                                                                cptP--;
                                                                                            }
                                                                                            break;
                                                                                        case ConsoleKey.DownArrow:
                                                                                            if (cptP + 1 <= dernierP)
                                                                                            {
                                                                                                cptP++;
                                                                                            }
                                                                                            break;
                                                                                        case ConsoleKey.Enter:
                                                                                            stationP = cptP;
                                                                                            quitterP = true;
                                                                                            break;
                                                                                    }
                                                                                } while (!quitterP);
                                                                                Console.WriteLine("\nLes informations de votre compte client entreprise ont bien été modifiés, vous allez être déconnecté");
                                                                                Console.ReadKey();
                                                                                MySqlParameter mdpClP = new MySqlParameter("@mdpCl", MySqlDbType.VarChar);
                                                                                mdpClP.Value = mdpP;
                                                                                MySqlParameter nomCl = new MySqlParameter("@nomCl", MySqlDbType.VarChar);
                                                                                nomCl.Value = nomP;
                                                                                MySqlParameter prenomCl = new MySqlParameter("@prenomCl", MySqlDbType.VarChar);
                                                                                prenomCl.Value = prenomP;
                                                                                MySqlParameter telCl = new MySqlParameter("@telCl", MySqlDbType.Int64);
                                                                                telCl.Value = telephoneP;
                                                                                string insertClR = "UPDATE Client SET Mot_De_Passe_Client = @mdpCl, Telephone_Client = @telCl, Metro_Client = " + Convert.ToString(stationP) + ", Nom_Particulier = @nomCl, Prenom_Particulier = @prenomCl WHERE Identifiant_Client = " + id + ";";
                                                                                MySqlCommand insertCl = maConnexion.CreateCommand();
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
                                                                            quitter2_1_2_1 = true;
                                                                            quitter2_1_2 = true;
                                                                            quitter2_1 = true;
                                                                            break;
                                                                        case 2:
                                                                            int proposition2_1_2_1_1 = 1;
                                                                            int nb_proposition2_1_2_1_1 = 2;
                                                                            bool quitter2_1_2_1_1 = false;
                                                                            do
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine("Êtes-vous sûr de vouloir supprimer le profil ?");
                                                                                switch (proposition2_1_2_1_1)
                                                                                {
                                                                                    case 1:
                                                                                        Console.WriteLine("\n\tOui <\n\tNon");
                                                                                        break;
                                                                                    case 2:
                                                                                        Console.WriteLine("\n\tOui\n\tNon <");
                                                                                        break;
                                                                                }
                                                                                cki = Console.ReadKey();
                                                                                if (cki.Key == ConsoleKey.UpArrow)
                                                                                {
                                                                                    proposition2_1_2_1_1--;
                                                                                    if (proposition2_1_2_1_1 == 0) { proposition2_1_2_1_1 = nb_proposition2_1_2_1_1; }
                                                                                }
                                                                                if (cki.Key == ConsoleKey.DownArrow)
                                                                                {
                                                                                    proposition2_1_2_1_1++;
                                                                                    if (proposition2_1_2_1_1 > nb_proposition2_1_2_1_1) { proposition2_1_2_1_1 = 1; }
                                                                                }
                                                                                if (cki.Key == ConsoleKey.Enter)
                                                                                {
                                                                                    switch(proposition2_1_2_1_1)
                                                                                    {
                                                                                        case 1:
                                                                                            Console.Write("\nEntrez votre mot de passe pour confirmer la suppression du compte : ");
                                                                                            string mdp_suppr = Console.ReadLine();
                                                                                            if(mdp_suppr == mdpCl)
                                                                                            {
                                                                                                MySqlCommand supprimerCompte = maConnexion.CreateCommand();
                                                                                                supprimerCompte.CommandText = "DELETE FROM Client WHERE Identifiant_Client = " + id + " AND Adresse_Mail_Client <> \"client@root.root\";";
                                                                                                try
                                                                                                {
                                                                                                    supprimerCompte.ExecuteNonQuery();
                                                                                                }
                                                                                                catch (MySqlException e)
                                                                                                {
                                                                                                    Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                                                                                    Console.ReadLine();
                                                                                                    return;
                                                                                                }
                                                                                                Console.WriteLine("Le compte a bien été supprimé, vous allez être déconnecté");
                                                                                                Console.ReadKey();
                                                                                                quitter2_1_2_1_1 = true;
                                                                                                quitter2_1_2_1 = true;
                                                                                                quitter2_1_2 = true;
                                                                                                quitter2_1 = true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Console.WriteLine("Mot de passe incorrect");
                                                                                                Console.ReadKey();
                                                                                                quitter2_1_2_1_1 = true;
                                                                                            }
                                                                                            break;
                                                                                        case 2:
                                                                                            quitter2_1_2_1_1 = true;
                                                                                            break;
                                                                                    }
                                                                                }
                                                                            } while (!quitter2_1_2_1_1);
                                                                            break;
                                                                        case 3:
                                                                            quitter2_1_2_1 = true;
                                                                            break;
                                                                    }
                                                                }
                                                            } while (!quitter2_1_2_1);
                                                            break;
                                                        case 5:
                                                            quitter2_1_2 = true;
                                                            break;
                                                    }
                                                }
                                            } while (!quitter2_1_2);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nIdentifiant ou mot de passe inccorect");
                                            Console.WriteLine("\n\nAppuyez sur \"entrer\" pour revenir à l'écran de connexion");
                                            Console.ReadLine();
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
                                        int mailDejaExistant = 1;
                                        MySqlParameter mailATester = new MySqlParameter("@mail", MySqlDbType.VarChar);
                                        mailATester.Value = mail;
                                        string existenceMail = "SELECT COUNT(*) FROM Cuisinier WHERE Adresse_Mail_Cuisinier = @mail;";
                                        MySqlCommand verifExiste = maConnexion.CreateCommand();
                                        verifExiste.Parameters.Add(mailATester);
                                        verifExiste.CommandText = existenceMail;
                                        reader = verifExiste.ExecuteReader();
                                        verifExiste.CommandText = existenceMail;
                                        while (reader.Read())
                                        {
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                mailDejaExistant = Int32.Parse(reader.GetValue(i).ToString());
                                            }
                                        }
                                        reader.Close();
                                        while (!mail.Contains('@') || !mail.Contains('.') || (mailDejaExistant > 0))
                                        {
                                            Console.Write("Cette adresse mail est déjà utilisée ou n'est pas au bon format, veuillez en choisir une autre : ");
                                            mail = Console.ReadLine();
                                            mailATester.Value = mail;
                                            reader = verifExiste.ExecuteReader();
                                            verifExiste.CommandText = existenceMail;
                                            while (reader.Read())
                                            {
                                                for (int i = 0; i < reader.FieldCount; i++)
                                                {
                                                    mailDejaExistant = Int32.Parse(reader.GetValue(i).ToString());
                                                }
                                            }
                                            reader.Close();
                                        }
                                        Console.Write("\nChoisissez votre mot de passe : ");
                                        string mdp = Console.ReadLine();
                                        while (mdp.Length < 8)
                                        {
                                            Console.Write("Le mot de passe doit contenir au moins 8 caractères : ");
                                            mdp = Console.ReadLine();
                                        }
                                        Console.Clear();
                                        Console.WriteLine("\nInformations du profil : ");
                                        Console.Write("\nQuel est votre nom : ");
                                        string nom = Console.ReadLine();
                                        Console.Write("\nQuel est votre prénom : ");
                                        string prenom = Console.ReadLine();
                                        Console.Write("\nQuel est votre numéro de téléphone : ");
                                        string telephone = Console.ReadLine();
                                        long tel;
                                        while (telephone.Length < 10 || telephone[0] != '0' || !Int64.TryParse(telephone, out tel))
                                        {
                                            Console.Write("Le numéro renseigné n'est pas au bon format : ");
                                            telephone = Console.ReadLine();
                                        }
                                        Console.Write("\nAdresse : quel est le numéro de ligne de la station de metro la plus proche ?\n\nTapez seulement le numéro (même pour les lignes bis) : ");
                                        string ligne = Console.ReadLine();
                                        int num_ligne = 0;
                                        while(!Int32.TryParse(ligne, out num_ligne) || num_ligne < 1 || num_ligne > 14)
                                        {
                                            Console.Write("Le numéro de ligne renseigné n'est pas au bon format : ");
                                            ligne = Console.ReadLine();
                                        }
                                        ligne = Convert.ToString(num_ligne);
                                        int premier = 0;
                                        while (metro.Noeuds[premier].Classe.Ligne != ligne && metro.Noeuds[premier].Classe.Ligne != ligne + "bis")
                                        {
                                            premier++;
                                        }
                                        int dernier = metro.Noeuds.Count() - 1;
                                        while(metro.Noeuds[dernier].Classe.Ligne != ligne && metro.Noeuds[dernier].Classe.Ligne != ligne + "bis")
                                        {
                                            dernier--;
                                        }
                                        bool quitter = false;
                                        int cpt = premier;
                                        int station = premier;
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Choississsez la station la plus proche de chez vous : \n\n---------------------------------------------------");
                                            for (int i = 0; i < 5; i++)
                                            {
                                                if (cpt + i <= dernier)
                                                {
                                                    if (i == 0)
                                                    {
                                                        Console.WriteLine("(" + metro.Noeuds[cpt + i].Classe.Ligne + ") " + metro.Noeuds[cpt + i].Classe.Nom + " <");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("(" + metro.Noeuds[cpt + i].Classe.Ligne + ") " + metro.Noeuds[cpt + i].Classe.Nom);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("");
                                                }
                                            }
                                            Console.WriteLine("---------------------------------------------------\n");
                                            cki = Console.ReadKey();
                                            switch (cki.Key)
                                            {
                                                case ConsoleKey.UpArrow:
                                                    if(cpt - 1 >= premier)
                                                    {
                                                        cpt--;
                                                    }
                                                    break;
                                                case ConsoleKey.DownArrow:
                                                    if (cpt + 1 <= dernier)
                                                    {
                                                        cpt++;
                                                    }
                                                    break;
                                                case ConsoleKey.Enter:
                                                    station = cpt;
                                                    quitter = true;
                                                    break;
                                            }
                                        } while (!quitter); 
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
                                        string insertTable = "INSERT INTO Cuisinier (Identifiant_Cuisinier, Mot_De_Passe_Cuisinier, Nom_Cuisinier, Prenom_Cuisinier, Telephone_Cuisinier, Adresse_Mail_Cuisinier, Metro_Cuisinier) VALUES (@idCu, @mdpCu, @nomCu, @prenomCu, @telCu, @mailCu, " + Convert.ToString(station) + " );";
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
                                                reader2E = command2E.ExecuteReader();
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
                                                Console.Write("Le numéro renseigné n'est pas au bon format : ");
                                                telephoneE = Console.ReadLine();
                                            }
                                            Console.Write("\nAdresse : quel est le numéro de ligne de la station de metro la plus proche ?\n\nTapez seulement le numéro (même pour les lignes bis) : ");
                                            string ligneE = Console.ReadLine();
                                            int num_ligneE = 0;
                                            while (!Int32.TryParse(ligneE, out num_ligneE) || num_ligneE < 1 || num_ligneE > 14)
                                            {
                                                Console.Write("Le numéro de ligne renseigné n'est pas au bon format :");
                                                ligneE = Console.ReadLine();
                                            }
                                            ligneE = Convert.ToString(num_ligneE);
                                            int premierE = 0;
                                            while (metro.Noeuds[premierE].Classe.Ligne != ligneE && metro.Noeuds[premierE].Classe.Ligne != ligneE + "bis")
                                            {
                                                premierE++;
                                            }
                                            int dernierE = metro.Noeuds.Count() - 1;
                                            while (metro.Noeuds[dernierE].Classe.Ligne != ligneE && metro.Noeuds[dernierE].Classe.Ligne != ligneE + "bis")
                                            {
                                                dernierE--;
                                            }
                                            bool quitterE = false;
                                            int cptE = premierE;
                                            int stationE = premierE;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Choississsez la station la plus proche de chez vous : \n\n---------------------------------------------------");
                                                for (int i = 0; i < 5; i++)
                                                {
                                                    if (cptE + i <= dernierE)
                                                    {
                                                        if (i == 0)
                                                        {
                                                            Console.WriteLine("(" + metro.Noeuds[cptE + i].Classe.Ligne + ") " + metro.Noeuds[cptE + i].Classe.Nom + " <");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("(" + metro.Noeuds[cptE + i].Classe.Ligne + ") " + metro.Noeuds[cptE + i].Classe.Nom);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("");
                                                    }
                                                }
                                                Console.WriteLine("---------------------------------------------------\n");
                                                cki = Console.ReadKey();
                                                switch (cki.Key)
                                                {
                                                    case ConsoleKey.UpArrow:
                                                        if (cptE - 1 >= premierE)
                                                        {
                                                            cptE--;
                                                        }
                                                        break;
                                                    case ConsoleKey.DownArrow:
                                                        if (cptE + 1 <= dernierE)
                                                        {
                                                            cptE++;
                                                        }
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        stationE = cptE;
                                                        quitterE = true;
                                                        break;
                                                }
                                            } while (!quitterE);
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
                                            nomClR.Value = nomR;
                                            MySqlParameter prenomClE = new MySqlParameter("@prenomClE", MySqlDbType.VarChar);
                                            prenomClE.Value = prenomR;
                                            MySqlParameter telClE = new MySqlParameter("@telClE", MySqlDbType.Int64);
                                            telClE.Value = telephoneE;
                                            string insertCl = "INSERT INTO Client (Identifiant_Client, Type_Client, Mot_De_Passe_Client, Telephone_Client, Adresse_Mail_Client, Metro_Client, Nom_Entreprise, Nom_Referent, Prenom_Referent)" +
                                                " VALUES (@idClE, 'Entreprise', @mdpClE, @telClE, @mailClE, " + Convert.ToString(stationE) + ", @nomClE, @nomClR, @prenomClE);" ;
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
                                            int mailexisteP = 1;
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
                                                reader2P = command2P.ExecuteReader();
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
                                            Console.Write("\nAdresse : quel est le numéro de ligne de la station de metro la plus proche ?\n\nTapez seulement le numéro (même pour les lignes bis) : ");
                                            string ligneP = Console.ReadLine();
                                            int num_ligneP = 0;
                                            while (!Int32.TryParse(ligneP, out num_ligneP) || num_ligneP < 1 || num_ligneP > 14)
                                            {
                                                Console.Write("Le numéro de ligne renseigné n'est pas au bon format :");
                                                ligneP = Console.ReadLine();
                                            }
                                            ligneP = Convert.ToString(num_ligneP);
                                            int premierP = 0;
                                            while (metro.Noeuds[premierP].Classe.Ligne != ligneP && metro.Noeuds[premierP].Classe.Ligne != ligneP + "bis")
                                            {
                                                premierP++;
                                            }
                                            int dernierP = metro.Noeuds.Count() - 1;
                                            while (metro.Noeuds[dernierP].Classe.Ligne != ligneP && metro.Noeuds[dernierP].Classe.Ligne != ligneP + "bis")
                                            {
                                                dernierP--;
                                            }
                                            bool quitterP = false;
                                            int cptP = premierP;
                                            int stationP = premierP;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Choississsez la station la plus proche de chez vous : \n\n---------------------------------------------------");
                                                for (int i = 0; i < 5; i++)
                                                {
                                                    if (cptP + i <= dernierP)
                                                    {
                                                        if (i == 0)
                                                        {
                                                            Console.WriteLine("(" + metro.Noeuds[cptP + i].Classe.Ligne + ") " + metro.Noeuds[cptP + i].Classe.Nom + " <");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("(" + metro.Noeuds[cptP + i].Classe.Ligne + ") " + metro.Noeuds[cptP + i].Classe.Nom);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("");
                                                    }
                                                }
                                                Console.WriteLine("---------------------------------------------------\n");
                                                cki = Console.ReadKey();
                                                switch (cki.Key)
                                                {
                                                    case ConsoleKey.UpArrow:
                                                        if (cptP - 1 >= premierP)
                                                        {
                                                            cptP--;
                                                        }
                                                        break;
                                                    case ConsoleKey.DownArrow:
                                                        if (cptP + 1 <= dernierP)
                                                        {
                                                            cptP++;
                                                        }
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        stationP = cptP;
                                                        quitterP = true;
                                                        break;
                                                }
                                            } while (!quitterP);
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
                                            string insertClR = "INSERT INTO Client (Identifiant_Client, Type_Client, Mot_De_Passe_Client, Telephone_Client, Adresse_Mail_Client, Metro_Client, Nom_Particulier, Prenom_Particulier)" +
                                                " VALUES (@idCl, 'Particulier', @mdpCl, @telCl, @mailCl, " + Convert.ToString(stationP) + ", @nomCl, @prenomCl);";
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
                    #region Admin
                    case 3:

                        break;
                    #endregion
                    case 4:
                        quitter1 = true;
                        break;
                }

            }
        } while (!quitter1);
        Console.Clear();
        Console.WriteLine("\nMerci d'avoir utilisé Livin' Paris !!!\nA bientôt !\n\n\tDéveloppé par Martin Jouhier et Victor Koscher\n\n\n");
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

    public static void Initialisation(MySqlConnection maConnexion)
    {
        MySqlCommand command = maConnexion.CreateCommand();
        command.CommandText = "DELETE FROM Cuisinier WHERE Identifiant_Cuisinier = 0;";
        try
        {
            command.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(" ErreurConnexion : " + e.ToString());
            Console.ReadLine();
            return;
        }
        MySqlParameter rootMailCu = new MySqlParameter("@rootMailCu", MySqlDbType.VarChar);
        rootMailCu.Value = "cuisinier@root.root";
        command.CommandText = "INSERT INTO Cuisinier (Identifiant_Cuisinier, Mot_De_Passe_Cuisinier, Nom_Cuisinier, Prenom_Cuisinier, Telephone_Cuisinier, Adresse_Mail_Cuisinier) VALUES (0, \"root\", \"root\", \"root\", 0123456789, @rootMailCu);";
        command.Parameters.Add(rootMailCu);
        try
        {
            command.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(" ErreurConnexion : " + e.ToString());
            Console.ReadLine();
            return;
        }
        command.CommandText = "DELETE FROM Client WHERE Identifiant_Client = 0;";
        try
        {
            command.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(" ErreurConnexion : " + e.ToString());
            Console.ReadLine();
            return;
        }
        MySqlParameter rootMailCl = new MySqlParameter("@rootMailCl", MySqlDbType.VarChar);
        rootMailCl.Value = "client@root.root";
        MySqlCommand command2 = maConnexion.CreateCommand();
        command2.CommandText = "INSERT INTO Client (Identifiant_Client, Type_Client, Mot_De_Passe_Client, Telephone_Client, Adresse_Mail_Client, Nom_Particulier, Prenom_Particulier) VALUES (0, 'Particulier', \"root\", 0123456789, @rootMailCl, \"root\", \"root\")";
        command2.Parameters.Add(rootMailCl);
        try
        {
            command2.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(" ErreurConnexion : " + e.ToString());
            Console.ReadLine();
            return;
        }
    }

    public static int Compte(MySqlConnection maConnexion, string from)
    {
        int compte = -1;
        string commande = "SELECT COUNT(*) FROM " + from + ";";
        MySqlCommand command = maConnexion.CreateCommand();
        command.CommandText = commande;
        MySqlDataReader reader = command.ExecuteReader();
        command.CommandText = commande;
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                compte = Int32.Parse(reader.GetValue(i).ToString());
            }
        }
        reader.Close();
        return compte;
    }

    public static void CreationPlat(MySqlConnection maConnexion, int cpt_plat, int idCu)
    {
        bool quitter = false;
        bool retour = false;
        int nb_proposition = 4;
        int proposition = 1;
        string type_plat = "Entrée";
        do
        {
            Console.Clear();
            Console.WriteLine("Quel est le type du plat : \n");
            switch (proposition)
            {
                case 1:
                    Console.WriteLine("\tUne entrée <\n\tUn plat\n\tUn dessert\n\t Retour");
                    type_plat = "Entree";
                    break;
                case 2:
                    Console.WriteLine("\tUne entrée\n\tUn plat <\n\tUn dessert\n\t Retour");
                    type_plat = "Plat";
                    break;
                case 3:
                    Console.WriteLine("\tUne entrée\n\tUn plat\n\tUn dessert <\n\t Retour");
                    type_plat = "Dessert";
                    break;
                case 4:
                    Console.WriteLine("\tUne entrée\n\tUn plat\n\tUn dessert\n\t Retour <");
                    retour = true;
                    break;
            }
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.UpArrow)
            {
                proposition--;
                if (proposition == 0) { proposition = nb_proposition; }
            }
            if (cki.Key == ConsoleKey.DownArrow)
            {
                proposition++;
                if (proposition > nb_proposition) { proposition = 1; }
            }
            if (cki.Key == ConsoleKey.Enter)
            {
                quitter = true;
            }
        } while (!quitter);
        if (!retour)
        {
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
            while (description.Length > 50)
            {
                Console.WriteLine("La description est trop longue");
                description = Console.ReadLine();
            }
            MySqlParameter idPl = new MySqlParameter("@idPl", MySqlDbType.Int32);
            idPl.Value = cpt_plat;
            MySqlParameter typePl = new MySqlParameter("@typePl", MySqlDbType.VarChar);
            typePl.Value = type_plat;
            MySqlParameter qtPl = new MySqlParameter("@qtPl", MySqlDbType.Int32);
            qtPl.Value = quantiteS;
            MySqlParameter prixPl = new MySqlParameter("@prixPl", MySqlDbType.Float);
            prixPl.Value = prixS;
            MySqlParameter descPl = new MySqlParameter("@descPl", MySqlDbType.VarChar);
            descPl.Value = description;
            MySqlParameter paramIdCu = new MySqlParameter("@idCu", MySqlDbType.Int32);
            paramIdCu.Value = idCu;
            MySqlParameter nomPl = new MySqlParameter("@nomPl", MySqlDbType.VarChar);
            nomPl.Value = nomPlat;
            string insertPlat = "INSERT INTO Plat (Numero_Plat, Type_Plat, Quantite_Plat, Prix, Description_plat, Identifiant_Cuisinier, Nom_Plat) VALUES (@idPl, @typePl, @qtPl, @prixPl, @descPl, @idCu, @nomPl)";
            MySqlCommand insertPl = maConnexion.CreateCommand();
            insertPl.Parameters.Add(idPl);
            insertPl.Parameters.Add(qtPl);
            insertPl.Parameters.Add(typePl);
            insertPl.Parameters.Add(prixPl);
            insertPl.Parameters.Add(descPl);
            insertPl.Parameters.Add(paramIdCu);
            insertPl.Parameters.Add(nomPl);
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
        }
    }
}
