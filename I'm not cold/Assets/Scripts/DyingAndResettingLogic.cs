using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DyingAndResettingLogic : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PostProcessingManager _postProcessingManager;
    [SerializeField] private SlidersEventsManager _sliderEventsManager;
    [SerializeField] private SirenPoleLogic _sirenPoleLogic;
    [SerializeField] private SilhouettesAppearingLogic _silhouettesAppearingLogic;
    [SerializeField] private GameObject _deathScreen;
    [Header("Dying Logic")]
    [SerializeField] private TextMeshProUGUI _heatTimer;
    [SerializeField] private TextMeshProUGUI _energyTimer;
    [SerializeField] private TextMeshProUGUI _hungerTimer;
    [SerializeField] private TextMeshProUGUI _mentalTimer;
    [SerializeField] private int _deathCountdownDefaultTimerValue;

    private float _timeElapsedInFloatForHeat;
    private float _timeElapsedInFloatForEnergy;
    private float _timeElapsedInFloatForHunger;
    private float _timeElapsedInFloatForMental;

    private bool _deathTimerRequestedHeat;
    private bool _deathTimerRequestedEnegry;
    private bool _deathTimerRequestedHunger;
    private bool _deathTimerRequestedMental;
    public bool canObserveAndExecuteDying { get; set; }
    private void Awake()
    {
        canObserveAndExecuteDying = true;

        _heatTimer.text = "";
        _energyTimer.text = "";
        _hungerTimer.text = "";
        _mentalTimer.text = "";

        _timeElapsedInFloatForHeat = _deathCountdownDefaultTimerValue;
        _timeElapsedInFloatForEnergy = _deathCountdownDefaultTimerValue;
        _timeElapsedInFloatForHunger = _deathCountdownDefaultTimerValue;
        _timeElapsedInFloatForMental = _deathCountdownDefaultTimerValue;

        _sliderEventsManager.OnHeatSliderZero += BeginDeathCountdownHeat;
        _sliderEventsManager.OnEnergySliderZero += BeginDeathCountdownEnergy;
        _sliderEventsManager.OnHungerSliderZero += BeginDeathCountdownHunger;
        _sliderEventsManager.OnMentalSliderZero += BeginDeathCountdownMental;

        _sliderEventsManager.OnHeatSliderPositiveValue += CancelDeathCountdownHeat;
        _sliderEventsManager.OnEnergySliderPositiveValue += CancelDeathCountdownEnergy;
        _sliderEventsManager.OnHungerSliderPositiveValue += CancelDeathCountdownHunger;
        _sliderEventsManager.OnMentalSliderPositive += CancelDeathCountdownMental;
    }
    private void Update()
    {
        if (!canObserveAndExecuteDying)
            return;

        _timeElapsedInFloatForHeat = ManageTimerLogic(_deathTimerRequestedHeat, _timeElapsedInFloatForHeat, _heatTimer);
        _timeElapsedInFloatForEnergy = ManageTimerLogic(_deathTimerRequestedEnegry, _timeElapsedInFloatForEnergy, _energyTimer);
        _timeElapsedInFloatForHunger = ManageTimerLogic(_deathTimerRequestedHunger, _timeElapsedInFloatForHunger, _hungerTimer);
        _timeElapsedInFloatForMental = ManageTimerLogic(_deathTimerRequestedMental, _timeElapsedInFloatForMental, _mentalTimer);
    }
    private float ManageTimerLogic(bool isTimerRequested, float elapsedTime, TextMeshProUGUI timerText)
    {
        if (isTimerRequested)
        {
            _postProcessingManager.playerCloseToDying = true;
            _silhouettesAppearingLogic.displaySilhouettes = true;
            return DecreaseTimer(elapsedTime, timerText);
        }
        else if(!isTimerRequested && elapsedTime != _deathCountdownDefaultTimerValue)
        {
            timerText.text = "";
            _postProcessingManager.playerCloseToDying = false;
            _silhouettesAppearingLogic.displaySilhouettes = false;
            _silhouettesAppearingLogic.DisableSilhouettes();
            return _deathCountdownDefaultTimerValue;
        }
        return _deathCountdownDefaultTimerValue;
    }
    private float DecreaseTimer(float timerValue, TextMeshProUGUI timerText)
    {
        timerValue -= Time.deltaTime;
        timerText.text = Mathf.RoundToInt(timerValue).ToString();
        if(timerValue < 0)
        {
            timerValue = 0;
            ShowDeathEndscreen();
        }
        return timerValue;
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
    public void ShowDeathEndscreen()
    {
        //avoiding accidental winning if dead
        _sirenPoleLogic.CancelEndscreenCountdown();

        //initiating dying actions sequence
        _deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        SoundsManager.instance.SilenceAllSounds();
        Time.timeScale = 0;
    }
}
