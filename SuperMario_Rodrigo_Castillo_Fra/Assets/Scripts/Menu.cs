// Rodrigo Castillo Francisco A01799191
// Fecha 19/06/2024
// Código para la interaccion del menu principal del juego 
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _menuPrincipal;

    private VisualElement _pantallaAyuda;
    private Button _botonAbrirAyuda;
    private Button _botonCerrarAyuda;

    void OnEnable()
    {
        _uiDocument = GetComponent<UIDocument>();
        var root = _uiDocument.rootVisualElement;
        // Se busca por el nombbre del elemento en el UI Builder
        _menuPrincipal = root.Q<VisualElement>("Menu");
        _pantallaAyuda = root.Q<VisualElement>("PantallaAyuda");
        _botonAbrirAyuda = root.Q<Button>("Ayuda");
        _botonCerrarAyuda = root.Q<Button>("BotonSalir");

        if (_botonAbrirAyuda != null)
        {
            _botonAbrirAyuda.clicked += () =>
            {
                Debug.Log("Boton de ayuda presionado");
                _menuPrincipal.style.display = DisplayStyle.None;
                _pantallaAyuda.style.display = DisplayStyle.Flex;
            };
        }

        if (_botonCerrarAyuda != null)
        {
            _botonCerrarAyuda.clicked += () =>
            {
                _pantallaAyuda.style.display = DisplayStyle.None;
                _menuPrincipal.style.display = DisplayStyle.Flex;
            };
        }
















    }



}
