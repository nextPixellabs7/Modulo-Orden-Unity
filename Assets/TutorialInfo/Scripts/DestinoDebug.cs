using UnityEngine;

public class DestinoDebug : MonoBehaviour
{
    public Transform correctPosition;  // destino para hacer snap

    private void Update()
    {
        if (correctPosition == null)
        {
            Debug.LogWarning("correctPosition no está asignado en DestinoDebug en" + gameObject.name);
            return;

        }

        Vector3 piezaPos = transform.position;
        Vector3 destinoPos = correctPosition.position;

        Debug.Log($"{gameObject.name} posicion: {piezaPos} (padre: {transform.parent?.name ?? "ninguno"})");
        Debug.Log($"{correctPosition.gameObject.name} destino posicion: {destinoPos} (padre: {correctPosition.parent?.name ?? "ninguno"})");

        float distancia = Vector3.Distance(piezaPos, destinoPos);
        Debug.Log($"Distancia entre {gameObject.name} y destino {correctPosition.name}: {distancia}");
    }

}
