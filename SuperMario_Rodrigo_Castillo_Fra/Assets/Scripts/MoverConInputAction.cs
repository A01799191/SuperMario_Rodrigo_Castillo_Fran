using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private InputAction accionMover;
    [SerializeField] private InputAction accionSalto;
    [SerializeField] private float velocidadX = 5f;
    [SerializeField] private float velocidadY = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        accionMover.Enable();
        accionSalto.Enable();
    }

    void OnEnable()
    {
        accionSalto.performed += saltar;
    }

    void OnDisable()
    {
        accionSalto.performed -= saltar;
    }

    void saltar(InputAction.CallbackContext context)
    {
        if (GetComponentInChildren<EstadoPersonaje>().estaEnPiso)
        {
            rb.linearVelocityY = velocidadY;
        }
    }

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