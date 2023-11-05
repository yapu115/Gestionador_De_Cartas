using System.Text.Json.Serialization;

/// <summary>
/// Enumerado de rarezas que puede poseer una carta
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ERarezas
{
    Normal,
    Rara,
    Epica,
    Legendaria
}


/// <summary>
/// Enumerado de Color de sable de Jedis
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EJediColoresSables
{
    Azul,
    Verde,
    Purpura,
    Blanco,
    Amarillo
}

/// <summary>
/// Enumerado de Color de sable de Jedis
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ESithColoresSables
{
    Rojo,
    Purpura,
    Naranja,
}

/// <summary>
/// Enumerado de niveles de prestigio de un cazarrecompensas
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ECazarrecompensasNivel
{
    Bajo,
    Mediano,
    Alto,
    Leyenda
}
