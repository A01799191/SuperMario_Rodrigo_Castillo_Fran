// Nombre : Rodrigo Castillo Francisco A01799191
// Fecha : 21/03/2026
// En este script se controla el estado del personaje para determinar si esta en el piso o no
using UnityEngine;
// Se declara la clase EstadoPersonaje, que contiene una propiedad booleana estaEnPiso para indicar si el personaje esta en el piso o no. Se usan los metodos OnTriggerEnter2D y OnTriggerExit2D para actualizar el estado de estaEnPiso cuando el personaje entra o sale de un trigger que representa el piso. Esto permite controlar el salto del personaje en otros scripts, verificando si estaEnPiso es verdadero antes de permitir el salto.
public class EstadoPersonaje : MonoBehaviour
{
    public bool estaEnPiso { get; private set; } = false;
    // Se usa el metodo OnTriggerEnter2D para detectar cuando el personaje entra en contacto con un trigger que representa el piso, y se establece estaEnPiso en true. De esta manera, otros scripts pueden verificar si el personaje esta en el piso antes de permitir acciones como el salto.

    void OnTriggerEnter2D(Collider2D collision)
    {
        estaEnPiso = true;
    }
    // Se usa el metodo OnTriggerExit2D para detectar cuando el personaje sale del trigger que representa el piso, y se establece estaEnPiso en false. Esto permite que otros scripts sepan que el personaje ya no esta en el piso y no permita acciones como el salto hasta que vuelva a entrar en contacto con el piso.
    void OnTriggerExit2D(Collider2D collision)
    {
        estaEnPiso = false;
    }
}
