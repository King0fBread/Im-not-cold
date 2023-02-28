using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSilhouettesOnProximity : MonoBehaviour
{
    [SerializeField] private SilhouettesAppearingLogic _silhouettesAppearingLogic;
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _silhouettesAppearingLogic.displaySilhouettes = false;
            _silhouettesAppearingLogic.playerInsideCabinZone = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _silhouettesAppearingLogic.playerInsideCabinZone = true;
        }
    }
}
