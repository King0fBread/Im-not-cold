using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DyingAndResettingLogic : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PostProcessingManager _postProcessingManager;
    [SerializeField] private NegativeStatesDisplayer _negativeStatesDisplayer;
    [Header("Dying Logic")]
    [SerializeField] private int _deathCountdownDefaultTimerValue;
    [SerializeField] private TextMeshProUGUI _dyingTimerText;

    private float _timeElapsedInFloatForHeat;
    private float _timeElapsedInFloatForEnergy;
    private float _timeElapsedInFloatForHunger;
    private float _timeElapsedInFloatForMental;
    private void Awake()
    {
        _timeElapsedInFloatForHeat = _deathCountdownDefaultTimerValue;
        _timeElapsedInFloatForEnergy = _deathCountdownDefaultTimerValue;
        _timeElapsedInFloatForHunger = _deathCountdownDefaultTimerValue;
        _timeElapsedInFloatForMental = _deathCountdownDefaultTimerValue;

        _negativeStatesDisplayer.OnHeatSliderZero += BeginDeathCountdownHeat;
        _negativeStatesDisplayer.OnEnergySliderZero += BeginDeathCountdownEnergy;
        _negativeStatesDisplayer.OnHungerSliderZero += BeginDeathCountdownHunger;
        _negativeStatesDisplayer.OnMentalSliderZero += BeginDeathCountdownMental;
    }
    private void Update()
    {
       



        //if (!_timerRequested)
        //    return;

        //_timeElapsedInFloat -= Time.deltaTime;
        //_dyingTimerText.text = Mathf.RoundToInt(_timeElapsedInFloat).ToString();

    }
    private void BeginDeathCountdownHeat(object sender, EventArgs e)
    {

    }
    private void BeginDeathCountdownEnergy(object sender, EventArgs e)
    {
        print("zero energy");
    }
    private void BeginDeathCountdownHunger(object sender, EventArgs e)
    {

    }
    private void BeginDeathCountdownMental(object sender, EventArgs e)
    {

    }
    //observe the sldier values in update
    //every state at zero gets their own decreasing timer value; if one is fixed but other at zero -- that timer remains active
    //show separate timer value near every affected slider
}
