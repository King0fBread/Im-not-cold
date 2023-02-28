using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSilouettesOnProximity : MonoBehaviour
{
    [SerializeField] private SillouetteAppearingLogic _sillouetteAppearingLogic;
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _sillouetteAppearingLogic.displaySilouettes = false;
            _sillouetteAppearingLogic.playerInsideCabinZone = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _sillouetteAppearingLogic.playerInsideCabinZone = true;
        }
    }
}
