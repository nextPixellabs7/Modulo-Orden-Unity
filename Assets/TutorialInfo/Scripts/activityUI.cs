using TMPro;
using UnityEngine;

public class activityUI : MonoBehaviour
{
    public TextMeshProUGUI mensajeTexto; // Referencia al componente de texto para mostrar mensajes

    public void MostrarMensaje(string mensaje)
    {
        mensajeTexto.text = mensaje;
        mensajeTexto.gameObject.SetActive(true);
        // Aqui agregar logica para mostrar el mensaje, como animaciones o temporizadores
    }

    public void OcultarMensaje()
    {
        mensajeTexto.gameObject.SetActive(false);
    }

}
