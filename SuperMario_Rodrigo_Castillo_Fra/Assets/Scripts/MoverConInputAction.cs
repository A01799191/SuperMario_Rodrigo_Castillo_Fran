// Nombre : Rodrigo Castillo Francisco A01799191
// Fecha : 21/03/2026
// En este script se controla el movimiento del personaje usando Input Action con soporte para movimiento horizontal y salto. Se incluyen animaciones para el personaje, y se controla la direccion del sprite segun el movimiento. Tambien se verifica si el personaje esta en el piso para permitir el salto.
using UnityEngine;
using UnityEngine.InputSystem;
// Se declaran las variables necesarias para controlar el movimiento del personaje, incluyendo referencias al Rigidbody2D, SpriteRenderer y Animator, asi como las Input Actions para el movimiento y salto, y las velocidades de movimiento y salto.
public class MoverConInputAction : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private InputAction accionMover;
    [SerializeField] private InputAction accionSalto;
    [SerializeField] private float velocidadX = 5f;
    [SerializeField] private float velocidadY = 10f;

    //  En el metodo Start se inicializan las referencias a los componentes del personaje, y se habilitan las Input Actions para el movimiento y salto. En el metodo OnEnable se asigna el evento para el salto, y en OnDisable se desasigna para evitar errores al desactivar el objeto.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        accionMover.Enable();
        accionSalto.Enable();
    }
    // En el metodo OnEnable se asigna el evento para el salto, y en OnDisable se desasigna para evitar errores al desactivar el objeto.
    void OnEnable()
    {
        accionSalto.performed += saltar;
    }
    // En el metodo saltar se verifica si el personaje esta en el piso usando el componente EstadoPersonaje, y si es asi se aplica una velocidad vertical para realizar el salto. En el metodo Update se lee el valor del movimiento horizontal, se aplica la velocidad correspondiente, y se actualizan las animaciones y la direccion del sprite segun el movimiento.
    void OnDisable()
    {
        accionSalto.performed -= saltar;
    }
    // En el metodo saltar se verifica si el personaje esta en el piso usando el componente EstadoPersonaje, y si es asi se aplica una velocidad vertical para realizar el salto. En el metodo Update se lee el valor del movimiento horizontal, se aplica la velocidad correspondiente, y se actualizan las animaciones y la direccion del sprite segun el movimiento.
    void saltar(InputAction.CallbackContext context)
    {
        if (GetComponentInChildren<EstadoPersonaje>().estaEnPiso)
        {
            rb.linearVelocityY = velocidadY;
        }
    }
    // En el metodo Update se lee el valor del movimiento horizontal, se aplica la velocidad correspondiente, y se actualizan las animaciones y la direccion del sprite segun el movimiento.
    void Update()
    {
        Vector2 movimiento = accionMover.ReadValue<Vector2>();
        rb.linearVelocityX = movimiento.x * velocidadX;

        if (rb.linearVelocityX < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.linearVelocityX > 0.1f)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetFloat("velocidad", Mathf.Abs(rb.linearVelocityX));
        animator.SetBool("enPiso", GetComponentInChildren<EstadoPersonaje>().estaEnPiso);
    }
}
