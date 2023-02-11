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
    [SerializeField] private SlidersEventsManager _negativeStatesDisplayer;
    [Header("Dying Logic")]
    [SerializeField] private TextMeshProUGUI _heatTimer;
    [SerializeField] private TextMeshProUGUI _energyTimer;
    [SerializeField] private TextMeshProUGUI _hungerTimer;
    [SerializeField] private TextMeshProUGUI _mentalTimer;

    [SerializeField] private int _deathCountdownDefaultTimerValue;
    [SerializeField] private TextMeshProUGUI _dyingTimerText;

    private float _timeElapsedInFloatForHeat;
    private float _timeElapsedInFloatForEnergy;
    private float _timeElapsedInFloatForHunger;
    private float _timeElapsedInFloatForMental;

    private bool _deathTimerRequestedHeat;
    private bool _deathTimerRequestedEnegry;
    private bool _deathTimerRequestedHunger;
    private bool _deathTimerRequestedMental;
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
        if (!_deathTimerRequestedHeat)
            _deathTimerRequestedHeat = true;
    }
    private void BeginDeathCountdownEnergy(object sender, EventArgs e)
    {
        if (!_deathTimerRequestedEnegry)
            _deathTimerRequestedEnegry = true;
    }
    private void BeginDeathCountdownHunger(object sender, EventArgs e)
    {
        if (!_deathTimerRequestedHunger)
            _deathTimerRequestedHunger = true;
    }
    private void BeginDeathCountdownMental(object sender, EventArgs e)
    {
        if (!_deathTimerRequestedMental)
            _deathTimerRequestedMental = true;
    }
    private void CancelDeathCountdownHeat(object sender, EventArgs e)
    {
        if (_deathTimerRequestedHeat)
            _deathTimerRequestedHeat = false;
    }
    private void CancelDeathCountdownEnergy(object sender, EventArgs e)
    {
        if (_deathTimerRequestedEnegry)
            _deathTimerRequestedEnegry = false;
    }
    private void CancelDeathCountdownHunger(object sender, EventArgs e)
    {
        if (_deathTimerRequestedHunger)
            _deathTimerRequestedHunger = false;
    }
    private void CancelDeathCountdownMental(object sender, EventArgs e)
    {
        if (_deathTimerRequestedMental)
            _deathTimerRequestedMental = false;
    }
    //observe the sldier values in update
    //every state at zero gets their own decreasing timer value; if one is fixed but other at zero -- that timer remains active
    //show separate timer value near every affected slider
}
