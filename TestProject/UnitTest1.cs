using TP2KittikhounHugo;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        // Test pour calculer la plus grande valeur
        [TestMethod]
        public void TestMethod1()
        {
            Partie partie_test = new Partie();

            // Variables de Tests
            int[] points = [56, 34, 23];
            int rep = 0;

            // Simulation
            int resultat = partie_test.joueurGagnant(points);

            // Comparer les résultats
            Assert.AreEqual(rep, resultat);
        }
        // Test pour une méthode qui est un bool
        [TestMethod]
        public void TestMethod2()
        {
            Partie partie_test = new Partie();

            // Variables de Tests
            int points = 22;
            bool rep = false;

            // Simulation
            bool resultat = partie_test.enBasDeLaValeur(points);

            // Comparer les résultats
            Assert.AreEqual(rep, resultat);
        }
    }
}