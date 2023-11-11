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
    }
}