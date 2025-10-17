using UnityEngine;
using UnityEngine.UI;

public class EscuchoYEncuentroManager : MonoBehaviour
{
    public GameObject[] panelesPalabras; // Array con los paneles de cada palabra
    public AudioSource audioSource;      // AudioSource para reproducir sonidos
    public AudioClip[] clipsAudio;       // Clips de audio para cada palabra

    private int indiceActual = 0;

    void Start()
    {
        // Mostrar solo el primer panel y ocultar el resto
        for (int i = 0; i < panelesPalabras.Length; i++)
        {
            panelesPalabras[i].SetActive(i == 0);
        }
        ReproducirAudioActual();
    }

    // Método que se llama desde los botones de opciones con el parámetro del índice elegido
    public void SeleccionarOpcion(bool esCorrecta)
    {
        if (esCorrecta)
        {
            // Opción correcta: desactivar panel actual y avanzar al siguiente
            panelesPalabras[indiceActual].SetActive(false);
            indiceActual++;

            if (indiceActual < panelesPalabras.Length)
            {
                panelesPalabras[indiceActual].SetActive(true);
                ReproducirAudioActual();
            }
            else
            {
                // Se terminaron las palabras
                Debug.Log("Actividad finalizada");
                // Aquí puedes poner lógica para mostrar resultados o finalizar actividad
            }
        }
        else
        {
            // Opción incorrecta: bloquear botón (puede ser manejado en cada botón)
            Debug.Log("Opción incorrecta, el botón debe deshabilitarse (handle en UI)");
        }
    }

    // Reproducir el audio de la palabra actual
    private void ReproducirAudioActual()
    {
        if (indiceActual < clipsAudio.Length)
        {
            audioSource.clip = clipsAudio[indiceActual];
            audioSource.Play();
        }
    }
}

