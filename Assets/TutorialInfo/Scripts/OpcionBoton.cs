using UnityEngine;
using UnityEngine.UI;

public class OpcionBoton : MonoBehaviour
{
    public bool esCorrecta; // Indica si esta opci�n es la correcta
    private Button boton;
    private EscuchoYEncuentroManager gestor;

    void Start()
    {
        boton = GetComponent<Button>();
        // Buscar el gestor en la escena
        gestor = FindFirstObjectByType<EscuchoYEncuentroManager>();

        // Agregar listener al bot�n
        boton.onClick.AddListener(OnClickOpcion);
    }

    void OnClickOpcion()
    {
        if (esCorrecta)
        {
            // Notificar al gestor que se seleccion� correcta
            gestor.SeleccionarOpcion(true);
        }
        else
        {
            // Bloquear bot�n porque es incorrecta
            boton.interactable = false;

            // Notificar al gestor que fue incorrecta para posible gesti�n (opcional)
            gestor.SeleccionarOpcion(false);
        }
    }
}

