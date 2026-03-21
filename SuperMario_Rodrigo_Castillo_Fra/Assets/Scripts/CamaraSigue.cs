// Nombre : Rodrigo Castillo Francisco A01799191
// Fecha : 21/03/2026
// En este script se controla la camara para que siga al personaje, pero con limites para que no se salga del escenario.


using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    // Se declaran las variables necesarias para controlar la camara, incluyendo una referencia al objetivo a seguir, y los limites izquierdo y derecho para evitar que la camara se salga del escenario. Se usa Mathf.Clamp para limitar la posicion de la camara entre el limite izquierdo y derecho, y se actualiza en LateUpdate para que se ejecute despues de que el personaje se haya movido.
    [SerializeField]
    public Transform objetivo;
    [SerializeField]
    public float limiteIzquierdo = 0f;
    [SerializeField]
    public float limiteDerecho = 19.2f;
    // Su usa Mathf.Clamp para limitar la posicion de la camara entre el limite izquierdo y derecho, y se actualiza en LateUpdate para que se ejecute despues de que el personaje se haya movido.

    void LateUpdate()
    {
        if (objetivo != null)
        {
            float posicionX = Mathf.Clamp(objetivo.position.x, limiteIzquierdo, limiteDerecho);
            transform.position = new Vector3(posicionX, transform.position.y, transform.position.z);
        }
    }
}