using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NegativeStatesDisplayer : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider _heatSlider;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Slider _hungerSlider;
    [SerializeField] private Slider _mentalSlider;
    [Header("States icons")]
    [SerializeField] private GameObject _heatShortageState;
    [SerializeField] private GameObject _energyShortageState;
    [SerializeField] private GameObject _hungerShortageState;
    [SerializeField] private GameObject _mentalShortageState;

    public event EventHandler OnHeatSliderZero;
    public event EventHandler OnEnergySliderZero;
    public event EventHandler OnHungerSliderZero;
    public event EventHandler OnMentalSliderZero;


    private void Update()
    {
        if (_heatSlider.value <= 0)
        {
            OnHeatSliderZero?.Invoke(this, EventArgs.Empty);
        }
        if(_energySlider.value <= 0)
        {
            OnEnergySliderZero?.Invoke(this, EventArgs.Empty);
        }
        if(_hungerSlider.value <= 0)
        {
            OnHungerSliderZero?.Invoke(this, EventArgs.Empty);
        }
        if(_mentalSlider.value <= 0)
        {
            OnMentalSliderZero?.Invoke(this, EventArgs.Empty);
        }
    }
    //private void ObserveSliderAndActivateState(Slider slider, GameObject stateIcon)
    //{
    //    if (slider.value <= 0 && !stateIcon.activeSelf)
    //    {
    //        stateIcon.SetActive(true);
    //        _postProcessingManager.playerCloseToDying = true;
    //    }
    //    else if (slider.value > 0 && stateIcon.activeSelf)
    //    {
    //        stateIcon.SetActive(false);
    //        _postProcessingManager.playerCloseToDying = false;
    //    }
    //}
}
