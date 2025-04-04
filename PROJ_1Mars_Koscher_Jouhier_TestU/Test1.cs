using PROJ_1Mars_Koscher_Jouhier;
namespace PROJ_1Mars_Koscher_Jouhier_TestU

{
    [TestClass]
    public sealed class TestLien
    {
        [TestMethod]
        public void TestEquals()
        {
            Noeud<int> noeud1 = new Noeud<int>(1);
            Noeud<int> noeud2 = new Noeud<int>(2);
            Noeud<int> noeud3 = new Noeud<int>(3);
            Lien<int> lien1 = new Lien<int>(noeud1, noeud2);
            Lien<int> lien2 = new Lien<int>(noeud2, noeud1);
            Lien<int> lien3 = new Lien<int>(noeud1, noeud3);
            Assert.IsTrue(lien1.Equals(lien1));
            Assert.IsTrue(lien1.Equals(lien2));
            Assert.IsFalse(lien1.Equals(lien3));
        }
    }

    [TestClass]
    public sealed class TestGraphe
    {
        [TestMethod]
        public void TestEstConnexe()
        {
            string[] connexe = new string[2];
            connexe[0] = "1 2";
            connexe[1] = "2 3";
            Graphe<int> Gconnexe = new Graphe<int>(connexe);
            string[] non_connexe = new string[2];
            non_connexe[0] = "1 1";
            non_connexe[1] = "2 2";
            Graphe<int> Gnon_connexe = new Graphe<int>(non_connexe);
            Assert.IsTrue(Gconnexe.EstConnexe());
            Assert.IsFalse(Gnon_connexe.EstConnexe());
        }

        [TestMethod]
        public void TestMethodDFS()
        {
            string[] lignes = File.ReadAllLines("Liens_Test.txt");
            Graphe<int> graphe = new Graphe<int>(lignes);
            List<Noeud<int>> DFS = new List<Noeud<int>>();
            Noeud<int> noeud1 = new Noeud<int>(1);
            Noeud<int> noeud2 = new Noeud<int>(6);
            Noeud<int> noeud3 = new Noeud<int>(2);
            Noeud<int> noeud4 = new Noeud<int>(3);
            Noeud<int> noeud5 = new Noeud<int>(7);
            Noeud<int> noeud6 = new Noeud<int>(4);
            Noeud<int> noeud7 = new Noeud<int>(9);
            Noeud<int> noeud8 = new Noeud<int>(8);
            Noeud<int> noeud9 = new Noeud<int>(5);
            DFS.Add(noeud1);
            DFS.Add(noeud2);
            DFS.Add(noeud3);
            DFS.Add(noeud4);
            DFS.Add(noeud5);
            DFS.Add(noeud6);
            DFS.Add(noeud7);
            DFS.Add(noeud8);
            DFS.Add(noeud9);
            for (int i = 0; i < graphe.DFS(graphe.Noeuds[0]).Count; i++)
            {

                Assert.AreEqual(DFS[i].Numero, graphe.DFS(graphe.Noeuds[0])[i].Numero);
            }
        }

        [TestMethod]
        public void TestMethodBFS()
        {
            string[] lignes = File.ReadAllLines("Liens_Test.txt");
            Graphe<int> graphe = new Graphe<int>(lignes);
            List<Noeud<int>> BFS = new List<Noeud<int>>();
            Noeud<int> noeud1 = new Noeud<int>(1);
            Noeud<int> noeud2 = new Noeud<int>(6);
            Noeud<int> noeud3 = new Noeud<int>(2);
            Noeud<int> noeud4 = new Noeud<int>(5);
            Noeud<int> noeud5 = new Noeud<int>(8);
            Noeud<int> noeud6 = new Noeud<int>(3);
            Noeud<int> noeud7 = new Noeud<int>(7);
            Noeud<int> noeud8 = new Noeud<int>(4);
            Noeud<int> noeud9 = new Noeud<int>(9);
            BFS.Add(noeud1);
            BFS.Add(noeud2);
            BFS.Add(noeud3);
            BFS.Add(noeud4);
            BFS.Add(noeud5);
            BFS.Add(noeud6);
            BFS.Add(noeud7);
            BFS.Add(noeud8);
            BFS.Add(noeud9);
            for (int i = 0; i < graphe.BFS(graphe.Noeuds[0]).Count; i++)
            {
                Assert.AreEqual(BFS[i].Numero, graphe.BFS(graphe.Noeuds[0])[i].Numero);
            }
        }

        [TestMethod]
        public void TestMethodCircuit()
        {
            string[] lignes = File.ReadAllLines("Liens_Test.txt");
            Graphe<int> graphe = new Graphe<int>(lignes);
            List<Noeud<int>> circuit = new List<Noeud<int>>();
            Noeud<int> noeud1 = new Noeud<int>(6);
            Noeud<int> noeud2 = new Noeud<int>(8);
            Noeud<int> noeud3 = new Noeud<int>(7);
            Noeud<int> noeud4 = new Noeud<int>(3);
            Noeud<int> noeud5 = new Noeud<int>(2);
            Noeud<int> noeud6 = new Noeud<int>(6);
            circuit.Add(noeud1);
            circuit.Add(noeud2);
            circuit.Add(noeud3);
            circuit.Add(noeud4);
            circuit.Add(noeud5);
            circuit.Add(noeud6);
            for (int i = 0; i < graphe.TrouveCircuit().Count; i++)
            {
                Assert.AreEqual(circuit[i].Numero, graphe.TrouveCircuit()[i].Numero);
            }
        }

        [TestMethod]
        public void TestDijkstra()
        {
            string[] liens = File.ReadAllLines("Liens_Test.txt");
            Graphe<int> graphe = new Graphe<int>(liens);
            Noeud<int> noeud1 = new Noeud<int>(7);
            Noeud<int> noeud2 = new Noeud<int>(3);
            Noeud<int> noeud3 = new Noeud<int>(4);
            Noeud<int> noeud4 = new Noeud<int>(3);
            List<Noeud<int>> LDijkstra = new List<Noeud<int>>();
            LDijkstra.Add(noeud1);
            LDijkstra.Add(noeud2);
            LDijkstra.Add(noeud3);
            LDijkstra.Add(noeud4);
            List<Noeud<int>> pcc_dijkstra = graphe.PCC_Dijkstra(graphe.Noeuds[6], graphe.Noeuds[2]);
            for (int i = 0; i < pcc_dijkstra.Count; i++)
            {
                Assert.AreEqual(pcc_dijkstra[i].Numero, LDijkstra[i].Numero);
            }// TEST PREDECESSEURS


            Assert.AreEqual(graphe.Dijkstra(graphe.Noeuds[2])[3], 2); //TEST CALCUL DISTANCES

        }


        [TestMethod]

        public void TestChemins()
        {
            string[] liens = new string[3];
            liens[0] = "1 2";
            liens[1] = "1 3";
            liens[2] = "4 4";
            Graphe<int> graphe = new Graphe<int>(liens);
            Assert.IsTrue(graphe.Chemin(graphe.Noeuds[1], graphe.Noeuds[2]));
            Assert.IsFalse(graphe.Chemin(graphe.Noeuds[0], graphe.Noeuds[3]));
        }
    }
}
