using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenPoleLogic : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _survivalEndscreen;
    [SerializeField] private AudioSource _standaloneEndscreenAudioSource;
    [SerializeField] private DyingAndResettingLogic _dyingAndResettingLogic;
    private bool _startedCountdown = false;
    private bool _enoughFuelForSiren = true;
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
    public void CancelEndscreenCountdown()
    {
        StopCoroutine(CountdownBeforeEndcreenCoroutine());
    }
    private void Update()
    {
        if (sirenPoleWorking && activatedInCorrectTime)
        {
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.GeneratorWorking);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.SirenWorking);
            if (!_startedCountdown)
            {
                _startedCountdown = true;
                StartCoroutine(CountdownBeforeEndcreenCoroutine());
            }
        }
        else if(sirenPoleWorking && !activatedInCorrectTime && _enoughFuelForSiren)
        {
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.GeneratorWorking);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.SirenWorking);
            if (!_startedCountdown)
            {
                _startedCountdown = true;
                StartCoroutine(CountdownBeforeLosingCoroutine());
            }
        }
    }
    private IEnumerator CountdownBeforeEndcreenCoroutine()
    {
        _dyingAndResettingLogic.canObserveAndExecuteDying = false;

        yield return new WaitForSeconds(10f);
        _standaloneEndscreenAudioSource.Play();
        yield return new WaitForSeconds(5f);
        _survivalEndscreen.SetActive(true);
    }
    private IEnumerator CountdownBeforeLosingCoroutine()
    {
        yield return new WaitForSeconds(15f);
        _enoughFuelForSiren = false;
        SoundsManager.instance.StopSound(SoundsManager.Sounds.GeneratorWorking);
        SoundsManager.instance.StopSound(SoundsManager.Sounds.SirenWorking);
        
    }
}
