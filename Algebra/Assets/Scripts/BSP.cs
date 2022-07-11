using UnityEngine;

public class BSP : MonoBehaviour
{
    // Crear habitaciones con planos (4) por habitacion
    // Hacer un algoritmo que encuentre la camara (habitacion x habitacion hasta encontrarla)
    // Para saber si una habitacion contiene a la camara imaginemos la camara como un punto y los planos como un rectangulo (colision punto y rectangulo) 
    // Una vez en la habitacion de la camara tirar rectas a lo ancho del fov, 1 por grado
    // Una vez que la recta choca con una pared, crear puntos a lo largo de esa recta usando una busqueda binaria (16 puntos maximo)
    // Ver en que habitacion esta cada punto (collision de un punto con un rectangulo)
    // Guardar en una lista las habitaciones a las que esta viendo la camara (usando todos los puntos formados de todas las rectas), al igual que la habitacion donde esta la camara
    // Mostrar solo las habitaciones, junto a su contenido, si estan dentro de la lista (el resto permaneceran ocultas)
    // En el siguiente frame evaluar si la camara sigue en la misma habitacion antes del proceso de ver en que habitaciones dibujar
    // Si la camara cambio de lugar volver a hacer la busqueda de la camara, con la diferencia de que una vez encontrada guardar la conexion entre la antigua habitacion y la nueva
    // La proxima vez que la camara cambie de lugar, antes de buscar en todas, se fija si la habitacion antigua tiene conexiones guardadas y si las tiene preguntar primero en esas conexiones
    // Para guardar esas conexiones lo mejor seria un diccionario (cada habitacion) a una lista (habitaciones)


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
