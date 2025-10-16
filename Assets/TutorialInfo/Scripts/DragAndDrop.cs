using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform correctPosition; // Asignar en Inspector la posicion destino del cubo
    public float snapDistance = 0.5f; // Distancia para considerar terminado el arrastre

    private Vector3 startPosition;
    private bool placedCorrectly = false;

    void Start()
    {
        startPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (placedCorrectly) return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (placedCorrectly) return;

        Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
        transform.position = new Vector3(worldPos.x, transform.position.y, worldPos.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Vector3.Distance(transform.position, correctPosition.position) <= snapDistance)
        {
            transform.position = correctPosition.position;
            placedCorrectly = true;
            // Avisar al controlador singleton que este cubo esta en posicion correcta
            Debug.Log(gameObject.name + " colocado correctamente!");
        }
        else
        {
            transform.position = startPosition;
        }
    }

    public bool IsPlacedCorrectly()
    {
        return placedCorrectly;
    }
}

