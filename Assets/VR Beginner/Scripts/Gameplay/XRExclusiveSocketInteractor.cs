using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


/// <summary>
/// Subclass of the classic Socket Interactor from the Interaction toolkit that will only accept object with the right
/// SocketTarget 
/// </summary>
public class XRExclusiveSocketInteractor : XRSocketInteractor
{
    public string AcceptedType;

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        SocketTarget socketTarget = interactable.GetComponent<SocketTarget>();

        if (socketTarget == null)
            return false;

        // Cambia la llamada obsoleta a la versión de interfaz
        return base.CanSelect((IXRSelectInteractable)interactable) && (socketTarget.SocketType == AcceptedType);
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        SocketTarget socketTarget = interactable.GetComponent<SocketTarget>();

        if (socketTarget == null)
            return false;

        // Cambia la llamada obsoleta a la versión de interfaz
        return base.CanSelect((IXRSelectInteractable)interactable) && (socketTarget.SocketType == AcceptedType);
    }
}
