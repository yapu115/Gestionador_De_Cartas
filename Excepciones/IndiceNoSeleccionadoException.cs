namespace Excepciones
{
    public class IndiceNoSeleccionadoException: Exception
    {
        public IndiceNoSeleccionadoException(string mensaje): base(mensaje)
        {

        }

        public IndiceNoSeleccionadoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}