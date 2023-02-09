using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenPoleLogic : MonoBehaviour
{
    public bool activatedInCorrectTime { get; set; }
    public void ActivateAlarm()
    {
        print("sounds wow");
        if (activatedInCorrectTime)
        {
            //win
            print("winning");
        }
        else
        {
            //lose
            print("losing");
        }
    }
}
