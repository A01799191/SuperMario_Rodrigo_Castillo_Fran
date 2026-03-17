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
        direccion *= -1; // Cambia la dirección
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(direccion==1)
        {
            spriteRenderer.flipX = false; // No voltear el sprite
        }
        else
        {
            spriteRenderer.flipX = true; // Voltear el sprite horizontalmente
        }
    }





}
