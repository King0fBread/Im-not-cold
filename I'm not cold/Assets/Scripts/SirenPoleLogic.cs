using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenPoleLogic : MonoBehaviour
{
    public bool activatedInCorrectTime { get; set; }
    public bool sirenPoleWorking { get; set; }
    public void ActivateAlarm()
    {
        //alarm sounds
        if (activatedInCorrectTime)
        {
            //helicopter closing in
            //coroutine for waiting
            
        }
        else
        {
            //lose
            print("losing");
        }
    }
    private void Update()
    {
        if (sirenPoleWorking)
        {
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.GeneratorWorking);
            //siren
        }
    }
}
