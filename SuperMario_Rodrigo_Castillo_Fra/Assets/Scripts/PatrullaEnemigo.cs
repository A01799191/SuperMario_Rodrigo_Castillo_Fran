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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 

    }

    void Update()
    {
        rb.linearVelocityX = direccion * velocidad; // Mover el enemigo en la dirección actual
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Girar();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Girar();

        
    }
    void Girar()
    {
        if (Time.time > tiempoUltimoGiro + 0.2f) // Evitar giros demasiado rápidos
        {
        direccion *= -1; // Cambiar la dirección
        Vector3 escala = transform.localScale;
        escala.x *= -1; // Voltear el sprite horizontalmente
        transform.localScale = escala;

        tiempoUltimoGiro = Time.time; // Actualizar el tiempo del último giro
        }

    }





}
