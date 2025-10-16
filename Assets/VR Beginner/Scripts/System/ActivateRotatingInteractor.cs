using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Especificar explícitamente la clase XRBaseInteractable para evitar ambigüedad
[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor))]
public class ActivateRotatingInteractor : MonoBehaviour
{
    public DialInteractable DialToActivate;

    UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor m_Interactor;
    void Start()
    {
        m_Interactor = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>();
        m_Interactor.selectEntered.AddListener(Activated);
    }

    void Activated(SelectEnterEventArgs args)
    {
        // Usar el nombre completo para evitar ambigüedad
        var interactable = args.interactableObject as UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable;

        // Solución: acceder al GameObject a través de 'interactableObject.transform'
        if (interactable != null)
        {
            // Obtener el GameObject usando la propiedad transform
            var interactableTransform = args.interactableObject.transform;
            if (interactableTransform != null)
            {
                DialToActivate.RotatingRigidbody = interactableTransform.GetComponentInChildren<Rigidbody>();
                DialToActivate.gameObject.SetActive(true);

                // interactable.interactionLayers = new InteractionLayerMask { value = 0 };
                // Solución: usar interactableTransform.gameObject en vez de interactable.gameObject
                interactableTransform.gameObject.SetActive(false);
            }
        }
    }
}
