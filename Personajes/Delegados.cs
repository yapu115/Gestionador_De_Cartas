using Personajes;

public delegate void DelegadoNotificarError(string mensaje);

public delegate void DelegadoAbrirfrmCartaVacio(string mensaje);

public delegate void DelegadoAbrirFrmCartaEliminar(int indice);

public delegate void DelegadoAbrirFrmCartaModificar(int indice);

public delegate void DelegadoImagenes(string path);

public delegate void DelegadoVisorPersonajes(Personaje personaje);