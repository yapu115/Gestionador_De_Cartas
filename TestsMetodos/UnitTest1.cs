using Personajes;

namespace TestsMetodos
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSeConcectoALaBaseDeDatos()
        {
            // Arrange
            AccesoPersonajes accesoPersonajes = new AccesoPersonajes();

            // Act
            bool valorRetornado = accesoPersonajes.PruebaConexion();

            // Asser
            Assert.IsTrue(valorRetornado);
        }

        [TestMethod]
        public void TestAgregarCazarrecompensas()
        {
            Cazarrecompensas cartaCazarrecompensas = new Cazarrecompensas("Bobba fett", 2000, 3000, ERarezas.Epica, ECazarrecompensasNivel.Mediano, "Blaster", 1000, "Fett");
            AccesoPersonajes a = new AccesoPersonajes();
            bool valorRetornado = a.AgregarCazarrecompensas(cartaCazarrecompensas);

            Assert.IsTrue(valorRetornado);
        }
    }
}