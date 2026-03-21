// Nombre : Rodrigo Castillo Francisco A01799191
// Fecha : 21/03/2026
// En este script se controla el boton para salir del nivel, que al ser presionado carga

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

// En este script se controla el boton para salir del nivel, que al ser presionado carga la escena del menu principal. Se usa un UIDocument para acceder al boton en la UI, y se asigna un evento al boton para cargar la escena del menu cuando se hace clic en el boton. Se puede configurar el nombre de la escena del menu a través del inspector de Unity.
public class BotonSalirNivel : MonoBehaviour
{
    [SerializeField]
    public string nombreEscenaMenu = "EscenaMenu";
    private Button _botonSalir;
    // En el metodo OnEnable se asigna el evento al boton para cargar la escena del menu cuando se hace clic en el boton. Se puede configurar el nombre de la escena del menu a través del inspector de Unity.
    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        _botonSalir = root.Q<Button>("BotonSalirJuego");
        // Se asigna el evento al boton para cargar la escena del menu cuando se hace clic en el boton. Se puede configurar el nombre de la escena del menu a través del inspector de Unity.
        if (_botonSalir != null)
        {
            _botonSalir.clicked += () =>
            {
                SceneManager.LoadScene(nombreEscenaMenu);
            };
        }
    }
}