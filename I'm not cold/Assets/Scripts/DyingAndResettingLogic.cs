using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DyingAndResettingLogic : MonoBehaviour
{
    [SerializeField] private int _deathCountdownTimerValue;
    [SerializeField] private TextMeshProUGUI _dyingTimerText;
    private float _timeElapsedInFloat;
    private bool _timerRequested;
    private void Awake()
    {
        _timeElapsedInFloat = _deathCountdownTimerValue;
    }
    public void InitiateDying()
    {
        StartCoroutine(DeathCountdownCouroutine());
    }
    public void CancelDying()
    {
        StopCoroutine(DeathCountdownCouroutine());
        _timerRequested = false;
        _dyingTimerText.text = "";
        _timeElapsedInFloat = _deathCountdownTimerValue;
    }
    private IEnumerator DeathCountdownCouroutine()
    {
        _timerRequested = true;
        yield return new WaitForSeconds(_deathCountdownTimerValue);
        print("died");
    }
    private void Update()
    {
        if (!_timerRequested)
            return;

        _timeElapsedInFloat -= Time.deltaTime;
        _dyingTimerText.text = Mathf.RoundToInt(_timeElapsedInFloat).ToString();
    }
    //fix the energy bar resetting the timer
}
