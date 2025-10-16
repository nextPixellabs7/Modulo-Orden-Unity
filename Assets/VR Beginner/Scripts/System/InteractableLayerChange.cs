using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class InteractableLayerChange : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable TargetInteractable;
    public InteractionLayerMask NewInteractionLayers;

    public void ChangeLayerDynamic(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable)
    {
        interactable.interactionLayers = NewInteractionLayers;
    }

    public void ChangeLayer()
    {
        TargetInteractable.interactionLayers = NewInteractionLayers;
    }
}
