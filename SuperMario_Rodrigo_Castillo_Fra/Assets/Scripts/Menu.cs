// Nombre : Rodrigo Castillo Francisco A01799191
// Fecha : 21/03/2026
// En este script se controla el menu principal del juego, con opciones para abrir la pantalla de ayuda, creditos, salir del juego o iniciar el juego. Tambien se incluyen animaciones para el fantasma y la calabaza, y un scroll para los creditos.
// ademas de que se usan botones para navegar entre las diferentes pantallas del menu, y se carga la escena del juego al presionar el boton de jugar.

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Se declaran las variables necesarias para controlar el menu, incluyendo referencias a los elementos de la UI, las animaciones y las velocidades de scroll y animacion.
    private UIDocument _uiDocument;
    private VisualElement _menuPrincipal;
    private VisualElement _pantallaAyuda;
    private VisualElement _pantallaCreditos;
    private Label _textoCreditos;
    private VisualElement _fantasma;
    private VisualElement _calabaza;
    // Se usa _posicionY para controlar la posicion del texto de creditos, y se actualiza en el metodo Update para crear un efecto de scroll.
    private float _posicionY = 0;
    [SerializeField] public float velocidadScroll = 40f;
    [SerializeField] public float velocidadGiroFantasma = 100f;
    [SerializeField] public float velocidadFadeCalabaza = 1f;
    [SerializeField] public string nombreEscenaJuego = "SampleScene";

    // Se declaran las variables para los botones del menu, y se asignan sus eventos en el metodo OnEnable para controlar la navegacion entre las diferentes pantallas del menu y la carga de la escena del juego.
    private Button _botonAbrirAyuda;
    private Button _botonCerrarAyuda;
    private Button _botonAbrirCreditos;
    private Button _botonCerrarCreditos;
    private Button _botonSalirPrincipal;
    private Button _botonJugar;
    // En el metodo OnEnable se asignan los eventos a los botones del menu, para controlar la navegacion entre las diferentes pantallas del menu y la carga de la escena del juego. Tambien se incluyen animaciones para el fantasma y la calabaza, y un scroll para los creditos.

    void OnEnable()
    {
        _uiDocument = GetComponent<UIDocument>();
        VisualElement root = _uiDocument.rootVisualElement;

        _menuPrincipal = root.Q<VisualElement>("Menu");
        _pantallaAyuda = root.Q<VisualElement>("PantallaAyuda");
        _pantallaCreditos = root.Q<VisualElement>("PantallaCreditos");
        _textoCreditos = root.Q<Label>("TextoCreditos");

        _fantasma = root.Q<VisualElement>("FantasmaAnimado");
        _calabaza = root.Q<VisualElement>("CalabazaAnimada");

        _botonAbrirAyuda = root.Q<Button>("Ayuda");
        _botonCerrarAyuda = root.Q<Button>("BotonSalir");
        _botonAbrirCreditos = root.Q<Button>("Creditos");
        _botonCerrarCreditos = root.Q<Button>("SalirCreditos");
        _botonSalirPrincipal = root.Q<Button>("Salir");
        _botonJugar = root.Q<Button>("Jugar");
        // Se asignan los eventos a los botones del menu, para controlar la navegacion entre las diferentes pantallas del menu y la carga de la escena del juego. Tambien se incluyen animaciones para el fantasma y la calabaza, y un scroll para los creditos.

        if (_botonAbrirAyuda != null)
        {
            _botonAbrirAyuda.clicked += () =>
            {
                if (_menuPrincipal != null && _pantallaAyuda != null)
                {
                    _menuPrincipal.style.display = DisplayStyle.None;
                    _pantallaAyuda.style.display = DisplayStyle.Flex;
                }
            };
        }

        if (_botonCerrarAyuda != null)
        {
            _botonCerrarAyuda.clicked += () =>
            {
                if (_menuPrincipal != null && _pantallaAyuda != null)
                {
                    _pantallaAyuda.style.display = DisplayStyle.None;
                    _menuPrincipal.style.display = DisplayStyle.Flex;
                }
            };
        }


        if (_botonAbrirCreditos != null)
        {
            _botonAbrirCreditos.clicked += () =>
            {
                if (_menuPrincipal != null && _pantallaCreditos != null)
                {
                    _menuPrincipal.style.display = DisplayStyle.None;
                    _pantallaCreditos.style.display = DisplayStyle.Flex;
                    _posicionY = 400;
                }
            };
        }

        if (_botonCerrarCreditos != null)
        {
            _botonCerrarCreditos.clicked += () =>
            {
                if (_menuPrincipal != null && _pantallaCreditos != null)
                {
                    _pantallaCreditos.style.display = DisplayStyle.None;
                    _menuPrincipal.style.display = DisplayStyle.Flex;
                }
            };
        }
        // Se asigna el evento al boton de salir del menu principal, para cerrar la aplicacion. Se incluye una condicion para verificar si el boton existe, y se muestra un mensaje de error en caso de que no se encuentre el boton en la UI.
        if (_botonSalirPrincipal != null)
        {
            _botonSalirPrincipal.clicked += () =>
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            };
        }

        if (_botonJugar != null)
        {
            _botonJugar.clicked += () =>
            {
                SceneManager.LoadScene(nombreEscenaJuego);
            };
        }
    }
    // En el metodo Update se actualizan las animaciones del fantasma y la calabaza, y se controla el scroll de los creditos. Se usa Time.time para crear un efecto de animacion continua, y Mathf.PingPong para crear un efecto de fade para la calabaza.

    void Update()
    {
        if (_fantasma != null)
        {
            float rotacionFan = Time.time * velocidadGiroFantasma;
            _fantasma.style.rotate = new StyleRotate(new Rotate(Angle.Degrees(rotacionFan)));
        }

        if (_calabaza != null)
        {
            float fade = Mathf.PingPong(Time.time * velocidadFadeCalabaza, 1f);
            _calabaza.style.opacity = fade;
        }

        if (_pantallaCreditos != null && _pantallaCreditos.style.display == DisplayStyle.Flex)
        {
            if (_textoCreditos != null)
            {
                _posicionY -= velocidadScroll * Time.deltaTime;
                _textoCreditos.style.translate = new Translate(0, _posicionY, 0);

                if (_posicionY < -(_textoCreditos.layout.height + 50))
                {
                    _posicionY = 400;
                }
            }
        }
    }
}