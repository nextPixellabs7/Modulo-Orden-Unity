using UnityEngine;

public class DragAndDropPhysics : MonoBehaviour
{
    public Transform correctPosition;  // destino para hacer snap
    public float snapDistance = 0.5f;  // distancia para activar snap

    private Vector3 mouseOffset;
    private float zCoord;
    private Rigidbody rb;
    private bool placedCorrectly = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (placedCorrectly) return;

        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zCoord));
        mouseOffset = transform.position - worldPoint;

        if (rb != null)
        {
            rb.isKinematic = true;  // desactivar fisica durante drag
        }
    }

    private void OnMouseDrag()
    {
        if (placedCorrectly) return;

        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zCoord);
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePoint) + mouseOffset;

        // mover solo en X e Y, mantener Z
        transform.position = new Vector3(targetPos.x, correctPosition.position.y, targetPos.z);
    }

    private void OnMouseUp()
    {
        if (placedCorrectly) return;

        float distancia = Vector3.Distance(transform.localPosition, correctPosition.localPosition);
        Debug.Log($"Distancia al destino: {distancia} - Snap: {snapDistance}");

        if (Vector3.Distance(transform.position, correctPosition.position) <= snapDistance)
        {
            transform.position = correctPosition.position;
            placedCorrectly = true;

            if (rb != null)
                rb.isKinematic = true;
            GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("¡Snap realizado!");
        }
        else
        {
            if (rb != null)
                rb.isKinematic = false;
        }
    }


    public bool IsPlacedCorrectly() => placedCorrectly;

}