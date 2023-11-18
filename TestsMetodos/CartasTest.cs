using Personajes;
using Excepciones;

namespace TestsMetodos
{
    [TestClass]
    public class CartasTest
    {
        [TestMethod]
        public void TestSeConcectoALaBaseDeDatos()
        {
            // Arrange
            AccesoPersonajes accesoPersonajes = new AccesoPersonajes();

            // Act
            bool valorRetornado = accesoPersonajes.PruebaConexion();

            // Assert
            Assert.IsTrue(valorRetornado);
        }


        [TestMethod]
        public void TestAgregarCazarrecompensas()
        {
            // Arrange
            Cazarrecompensas cartaCazarrecompensas = new Cazarrecompensas("Bobba fett", 2000, 3000, ERarezas.Epica, ECazarrecompensasNivel.Mediano, "Blaster", 1000, "Fett");
            AccesoPersonajes a = new AccesoPersonajes();

            // Act
            bool valorRetornado = a.AgregarCazarrecompensas(cartaCazarrecompensas);

            // Assert
            Assert.IsTrue(valorRetornado);
        }

        [TestMethod]
        public void TestNoSeEliminoPersonaje()
        {
            // Arrange
            AccesoPersonajes accesoPersonajes = new AccesoPersonajes();
            Sith s = new Sith("Personaje que no está en la tabla", 1000, 3000, ERarezas.Rara, "Rango", "Faccion");

            // Act
            bool eliminado = accesoPersonajes.EliminarPersonaje(s);

            Assert.IsFalse(eliminado);
        }



        [TestMethod]
        public void TestTextoASablesJedi()
        {
            // Arrange
            AccesoPersonajes acceso = new AccesoPersonajes();
            string color = "Purpura";
            EJediColoresSables colorEsperado = EJediColoresSables.Purpura;

            // Act
            EJediColoresSables colorRetornado = acceso.TextoASablesJedi(color);

            // Assert
            Assert.AreEqual(colorRetornado, colorEsperado);
        }



        [TestMethod]
        public void TestAgregarPersonajeAlMazo()
        {
            // Arrange
            MazoDeCartas mazo = new MazoDeCartas("");

            Jedi j = new Jedi("Prueba", 1000, 3000, ERarezas.Rara, "Rango", "Faccion");

            // Act
            bool agregado = mazo + j;

            Assert.IsTrue(agregado);
        }


        [TestMethod]
        public void TestNoAgregarPersonajeAlMazo()
        {
            // Arrange
            MazoDeCartas mazo = new MazoDeCartas("");

            Jedi j = new Jedi("Prueba", 1000, 3000, ERarezas.Rara, "Rango", "Faccion");
            Jedi j2 = new Jedi("Prueba", 1000, 3000, ERarezas.Rara, "Rango2", "Faccion2");

            // Act
            bool agregado = mazo + j;
            bool agregado2 = mazo + j2;

            Assert.IsFalse(agregado2);
        }

    }
}