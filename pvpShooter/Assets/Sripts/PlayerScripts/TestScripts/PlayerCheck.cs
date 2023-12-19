using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerCheck : MonoBehaviourPunCallbacks
{
    public ContinuousMoveProviderBase moving;
    public ContinuousTurnProviderBase turning;
    public SnapTurnProviderBase snapTurning;
    public Camera cam;
    public XRDirectInteractor interactorLeft;
    public XRDirectInteractor interactorRight;

    public void Start()
    {
        if (!photonView.IsMine)
        {
            moving.enabled = false;
            turning.enabled = false;
            snapTurning.enabled = false;
            cam.enabled = false;
            interactorLeft.enabled = false;
            interactorRight.enabled = false;
        }
    }
}
