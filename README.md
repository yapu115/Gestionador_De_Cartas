# Gestionador de cartas de Star Wars 2.0 (Segundo Parcial)

## Sobre mi

<p>Me llamo Franco Yapura, tengo 18 años y soy un Técnico Universitario en Programación.</p>

<p>Elegí hacer el proyecto basandome en cartas de star wars ya que me encantan estos personajes y la tarea quedaba perfecta para resolver algo relacionado con ellos.</p>

## Resumen de la app - Que hace y como se usa

<p>La app se encarga de mantener registro y gestionar los mazos de cartas virtuales de star wars de los usuarios.<br>
Este cometido se logra a través de un CRUD, que funcionará diferente según el perfil de cada usuario:</p>

- Aquel que sea administrador podrá agregar cartas nuevas, eliminar las que ya no tiene o no le sirven y modificar aquellas con las que subió o bajó de nivel.

- Quien sea supervisor podrá ver, agregar y modificar las cartas, prohibiendose la eliminación de estas.

- Quien sea vendedor solo podrá ver las cartas, sin agregar, modificar o eliminarlas.

El mazo se divide a partir de 4 tipos de personajes: Jedis, Siths, Mandalorianos y Cazarrecompensas, cada uno con sus propias características.<br>

<p>Además a esta versión mejorada se le suma un mazo de cartas relacionado, es decir, los usuarios podrán tener un mazo compartido, que (dependiendo de su perfil) podrán controlar y modificar.
Esta adición está disponible con una función presentada en el menú principal, en donde se podrá elegir una de las dos opciones mencionadas.</p>

<p>A grandes rasgos se le sigue permitiendo al usuario tener guardadas sus cartas y poder gestionarlas de una manera cómoda y segura y ahora con amigos o compañeros.</p>

![Menú de cartas](https://github.com/yapu115/Yapura.Franco.SegundoParcial./assets/120744348/72fb34da-6fbb-4ce4-9046-4a8a94a0a3c8)

Imagen del menú principal.

<p>El uso es bastante sencillo, al iniciar la aplicación se pide que el usuario inicie sesión y automáticamente entrará al menú principal en donde podrá navegar entre los mazos de cada tipo de personaje, agregado,
modificando o eliminando cartas, según el tipo de perfil, con sus respectivos botones.<br>
Además, podrá ordenar las cartas a través de los dos criterios principales de las cartas: Vida y Poder.</p>
  
<p>Por último, con la funcionalidad de mazos compartidos y personales se podrá elegir uno de estos dos tipos y a partir de allí realizar las acciones mencionadas.
Pero cuidado, ya que una vez elegido el tipo de mazo y modificado alguno de sus elementos ya no se podrá cambiar de mazo.</p> 

![Carta](https://github.com/yapu115/Yapura.Franco.SegundoParcial./assets/120744348/c0fe122f-c9e5-4468-814e-9a6f8adbf43f)

Imagen de la creación/modificación de una carta.


## Diagrama de clases


Imagen de Diagrama de clases completo

![Imagen de diagrama completo](https://github.com/yapu115/Yapura.Franco.SegundoParcial./assets/120744348/c491b34f-eb3b-41e4-9be5-736554295c09)

Imagen de la clase base Personaje

![Imagen de clase base Personaje](https://github.com/yapu115/Yapura.Franco.SegundoParcial./assets/120744348/fe8b51f2-90b1-466f-a091-d1a8a1138ca7)

Imagen de las clases cazarrecompensas y mandalorianos

![Imagen de cazarrecompensas y mandalorianos](https://github.com/yapu115/Yapura.Franco.SegundoParcial./assets/120744348/80e2e2f4-832b-4057-851c-a31d2e2af5a8)

Imagen de las clases sensibles a la fuerza

![Imagen de sensibles a la fuerza](https://github.com/yapu115/Yapura.Franco.SegundoParcial./assets/120744348/2b9feba4-7af2-4d19-a2f3-3d731321090c)

Imagen de las clases de CRUD y Mazo

![Imagen de las clases de CRUD del mazo](https://github.com/yapu115/Yapura.Franco.SegundoParcial./assets/120744348/5df4bd76-f593-4ad2-bd38-574eb12c3557)

Imagen de delegados

![Imagen de delegados](https://github.com/yapu115/Yapura.Franco.SegundoParcial./assets/120744348/a504012c-e053-4d9e-bb32-936623323a94)
