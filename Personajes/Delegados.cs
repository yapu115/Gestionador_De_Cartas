using Personajes;

/// <summary>
/// Delegado que permite un string para mostrar un mensaje de error
/// </summary>
public delegate void DelegadoNotificarError(string mensaje);

/// <summary>
/// Delegado que permite un string para identificar el tipo de carta con parametros vacíos a abrir
/// </summary>
public delegate void DelegadoAbrirfrmCartaVacio(string mensaje);

/// <summary>
/// Delegado que permite un enetero para abrir la carta que se pretende eliminar 
/// </summary>
public delegate void DelegadoAbrirFrmCartaEliminar(int indice);

/// <summary>
/// Delegado que permite un entero para abrir la carta que se pretende modificar
/// </summary>
public delegate void DelegadoAbrirFrmCartaModificar(int indice);

/// <summary>
/// Delegado que permite un string que indica el path de una imagen
/// </summary>
public delegate void DelegadoImagenes(string path);

/// <summary>
/// Delegado que permite un Personaje para poder mostrar sus datos
/// </summary>
public delegate void DelegadoVisorPersonajes(Personaje personaje);

/// <summary>
/// Delegado que permite un DateTime para poder determinar un tiempo
/// </summary>
public delegate void DelegadoActualizarTiempo(DateTime tiempoActual);