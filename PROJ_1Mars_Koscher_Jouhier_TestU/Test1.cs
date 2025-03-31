using PROJ_1Mars_Koscher_Jouhier;
namespace PROJ_1Mars_Koscher_Jouhier_TestU

{
    [TestClass]
    public sealed class TestLien
    {
        [TestMethod]
        public void TestEquals()
        {
            Noeud noeud1 = new Noeud(1);
            Noeud noeud2 = new Noeud(2);
            Noeud noeud3 = new Noeud(3);
            Lien lien1 = new Lien(noeud1, noeud2);
            Lien lien2 = new Lien(noeud2, noeud1);
            Lien lien3 = new Lien(noeud1, noeud3);
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
            Graphe Gconnexe = new Graphe(connexe);
            string[] non_connexe = new string[2];
            non_connexe[0] = "1 1";
            non_connexe[1] = "2 2";
            Graphe Gnon_connexe = new Graphe(non_connexe);
            Assert.IsTrue(Gconnexe.EstConnexe());
            Assert.IsFalse(Gnon_connexe.EstConnexe());
        }

        [TestMethod]
        public void TestMethodDFS()
        {
            string[] lignes = File.ReadAllLines("Liens_Test.txt");
            Graphe graphe = new Graphe(lignes);
            List<Noeud> DFS = new List<Noeud>();
            Noeud noeud1 = new Noeud(1);
            Noeud noeud2 = new Noeud(6);
            Noeud noeud3 = new Noeud(2);
            Noeud noeud4 = new Noeud(3);
            Noeud noeud5 = new Noeud(7);
            Noeud noeud6 = new Noeud(4);
            Noeud noeud7 = new Noeud(9);
            Noeud noeud8 = new Noeud(8);
            Noeud noeud9 = new Noeud(5);
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
            Graphe graphe = new Graphe(lignes);
            List<Noeud> BFS = new List<Noeud>();
            Noeud noeud1 = new Noeud(1);
            Noeud noeud2 = new Noeud(6);
            Noeud noeud3 = new Noeud(2);
            Noeud noeud4 = new Noeud(5);
            Noeud noeud5 = new Noeud(8);
            Noeud noeud6 = new Noeud(3);
            Noeud noeud7 = new Noeud(7);
            Noeud noeud8 = new Noeud(4);
            Noeud noeud9 = new Noeud(9);
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
            Graphe graphe = new Graphe(lignes);
            List<Noeud> circuit = new List<Noeud>();
            Noeud noeud1 = new Noeud(6);
            Noeud noeud2 = new Noeud(8);
            Noeud noeud3 = new Noeud(7);
            Noeud noeud4 = new Noeud(3);
            Noeud noeud5 = new Noeud(2);
            Noeud noeud6 = new Noeud(6);
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
    }
}
