using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceHeatEmitter : MonoBehaviour
{
    [SerializeField] private FurnaceLogic _furnaceLogic;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if(_furnaceLogic.GetCurrentHeatValue() > 0)
            {
                SurvivalStatesManager.instance.isPlayerNearFurnace = true;
            }
            else
            {
                SurvivalStatesManager.instance.isPlayerNearFurnace = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            SurvivalStatesManager.instance.isPlayerNearFurnace = false;
        }
    }
}
