using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisableInteractable : MonoBehaviour
{    
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;
    // Cambia InteractionLayerMask por int si interactionLayers no existe
    private int originalLayer;

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        // Usa this.gameObject.layer en vez de interactable.gameObject.layer
        originalLayer = this.gameObject.layer;
    }
    public void Disable()
    {
        // Cambia la capa del objeto a una capa no interactuable (por ejemplo, "Default" o una personalizada)
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public void Enable()
    {
        this.gameObject.layer = originalLayer;
    }
}
