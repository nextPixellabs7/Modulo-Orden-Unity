using UnityEngine;

public class ActivityController : MonoBehaviour
{
    public static ActivityController Instance { get; private set; }

    public DragAndDropPhysics[] cubos;    // Scripts DragAndDropPhysics para cubos
    public DragAndDropPhysics[] esferas;  // Scripts DragAndDropPhysics para esferas

    public GameObject grupoCubos;   // Objeto padre de los cubos
    public GameObject grupoEsferas; // Objeto padre de las esferas
    public activityUI activityUI; // Referencia al script de UI

    public SimpleOrbitCamera orbitCamera; // Referencia al script de camara
    public Transform targetCubos; // Target para cubos
    public Transform targetEsferas; // Target para esferas

    private bool cubosCompletados = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // Al iniciar, sólo activamos los cubos y desactivamos las esferas
        SetActiveGroup(cubos, true);
        SetActiveGroup(esferas, false);

        if (orbitCamera != null && targetCubos != null) //para iniciar con la camara en los cubos
            orbitCamera.target = targetCubos;
    }

    private void SetActiveGroup(DragAndDropPhysics[] group, bool active)
    {
        foreach (var pieza in group)
        {
            pieza.gameObject.SetActive(active);
        }
    }

    private void ActivarGrupoYElementos(GameObject grupo, DragAndDropPhysics[] elementos)
    {
        grupo.SetActive(true);
        foreach (DragAndDropPhysics elem in elementos)
        {
            elem.gameObject.SetActive(true);
        }
    }


    private void Update()
    {
        if (!cubosCompletados && CheckAllPlaced(cubos))
        {
                cubosCompletados = true;
                grupoCubos.SetActive(false);
                ActivarGrupoYElementos(grupoEsferas, esferas);

            if (orbitCamera != null && targetEsferas != null) //cambiar la camara a las esferas
                orbitCamera.target = targetEsferas;

            // activityUI.MostrarMensaje("¡Bien hecho! Ahora ordena las esferas.");
            // poner lógica para UI y sonidos

        }
        else
        {
            if (CheckAllPlaced(esferas))
            {
               // activityUI.MostrarMensaje("¡Felicidades! Has completado la actividad.");
               // logica para finalizar la actividad, mostrar mensaje o avanzar escena
            }
        }
    }

    private bool CheckAllPlaced(DragAndDropPhysics[] group)
    {
        foreach (var pieza in group)
        {
            if (!pieza.IsPlacedCorrectly())
                return false;
        }
        return true;
    }
}

