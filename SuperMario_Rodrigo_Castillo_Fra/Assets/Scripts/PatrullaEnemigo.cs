
// Nombre : Rodrigo Castillo Francisco A01799191
// Fecha : 21/03/2026
// En este script se controla la patrulla del enemigo, haciendo que se mueva de un
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

// Referencia bibliografica 
// Technologies, U. (s. f.). Unity - Scripting API: Physics2D.Raycast. https://docs.unity3d.com/ScriptReference/Physics2D.Raycast.html

public class PatrullaEnemigo : MonoBehaviour
{
    [SerializeField]
    private float velocidad = 2f;
    private Rigidbody2D rb;
    private int direccion = -1; // -1 para la direccion a la izquierda y 1 para la direccion a la derecha   
    private float tiempoUltimoGiro = 0f; // Variable para almacenar el tiempo del último giro
                                         // En el metodo Start se inicializa la referencia al Rigidbody2D, y se establece la velocidad inicial del enemigo. En el metodo Update se mueve el enemigo en la direccion actual, y se verifica si ha pasado un tiempo suficiente desde el ultimo giro para permitir otro giro. En los metodos OnCollisionEnter2D y OnTriggerEnter2D se llama al metodo Girar para cambiar la direccion del enemigo cuando colisiona con un objeto o entra en un trigger.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // En el metodo Start se inicializa la referencia al Rigidbody2D, y se establece la velocidad inicial del enemigo. En el metodo Update se mueve el enemigo en la direccion actual, y se verifica si ha pasado un tiempo suficiente desde el ultimo giro para permitir otro giro. En los metodos OnCollisionEnter2D y OnTriggerEnter2D se llama al metodo Girar para cambiar la direccion del enemigo cuando colisiona con un objeto o entra en un trigger.
    void Update()
    {
        rb.linearVelocityX = direccion * velocidad; // Mover el enemigo en la dirección actual
    }
    // En el metodo Start se inicializa la referencia al Rigidbody2D, y se establece la velocidad inicial del enemigo. En el metodo Update se mueve el enemigo en la direccion actual, y se verifica si ha pasado un tiempo suficiente desde el ultimo giro para permitir otro giro. En los metodos OnCollisionEnter2D y OnTriggerEnter2D se llama al metodo Girar para cambiar la direccion del enemigo cuando colisiona con un objeto o entra en un trigger.
    void OnCollisionEnter2D(Collision2D col)
    {
        Girar();

    }
    // En el metodo Start se inicializa la referencia al Rigidbody2D, y se establece la velocidad inicial del enemigo. En el metodo Update se mueve el enemigo en la direccion actual, y se verifica si ha pasado un tiempo suficiente desde el ultimo giro para permitir otro giro. En los metodos OnCollisionEnter2D y OnTriggerEnter2D se llama al metodo Girar para cambiar la direccion del enemigo cuando colisiona con un objeto o entra en un trigger.
    void OnTriggerEnter2D(Collider2D col)
    {
        Girar();


    }
    // En el metodo Start se inicializa la referencia al Rigidbody2D, y se establece la velocidad inicial del enemigo. En el metodo Update se mueve el enemigo en la direccion actual, y se verifica si ha pasado un tiempo suficiente desde el ultimo giro para permitir otro giro. En los metodos OnCollisionEnter2D y OnTriggerEnter2D se llama al metodo Girar para cambiar la direccion del enemigo cuando colisiona con un objeto o entra en un trigger.
    void Girar()
    {
        direccion *= -1; // Cambia la dirección
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (direccion == 1)
        {
            spriteRenderer.flipX = false; // No voltear el sprite
        }
        else
        {
            spriteRenderer.flipX = true; // Voltear el sprite horizontalmente
        }
    }





}
