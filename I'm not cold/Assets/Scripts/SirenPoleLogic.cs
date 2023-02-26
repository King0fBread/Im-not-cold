using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenPoleLogic : MonoBehaviour
{
    public bool activatedInCorrectTime { get; set; }
    public bool sirenPoleWorking { get; set; }
    [SerializeField] private GameObject _survivalEndscreen;
    [SerializeField] private AudioSource _standaloneEndscreenAudioSource;
    private bool _startedCountdown = false;
    private bool _enoughFuelForSiren = true;
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
        if (sirenPoleWorking && _enoughFuelForSiren)
        {
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.GeneratorWorking);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.SirenWorking);
            if (!_startedCountdown)
            {
                _startedCountdown = true;
                StartCoroutine(CountdownBeforeEndcreenCoroutine());
            }
        }
    }
    private IEnumerator CountdownBeforeEndcreenCoroutine()
    {
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
