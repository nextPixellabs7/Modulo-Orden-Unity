using UnityEngine;

public class BotonSonido : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource sonido;
    public void ReproducirSonido()
    {
        if (sonido != null)
        {
            sonido.Stop();
            sonido.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
