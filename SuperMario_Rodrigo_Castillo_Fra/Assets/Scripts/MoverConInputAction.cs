using UnityEngine;
using UnityEngine.InputSystem; 

public class MoverConInputAction : MonoBehaviour 
{ 
    [SerializeField]  
    private InputAction accionMover; 
    [SerializeField] 
    private InputAction accionSalto; 
    [SerializeField]
    private Rigidbody2D rb; 
    [SerializeField]
    private float velocidadY; 
    [SerializeField]
    private float velocidadX; 
    void Start() 
    { 
        rb = GetComponent<Rigidbody2D>(); 
        accionMover.Enable(); 
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
        rb.linearVelocityY = velocidadY; 
    } 
    void Update() 
    { 
        Vector2 movimiento = accionMover.ReadValue<Vector2>(); 
        transform.position = (Vector2)transform.position + Time.deltaTime * velocidadX * movimiento; 
    } 
}