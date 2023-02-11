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

    private void Update()
    {
        ObserveSliderAndActivateState(_heatSlider, _heatShortageState);
        ObserveSliderAndActivateState(_energySlider, _energyShortageState);
        ObserveSliderAndActivateState(_hungerSlider, _hungerShortageState);
        ObserveSliderAndActivateState(_mentalSlider, _mentalShortageState);
    }
    private void ObserveSliderAndActivateState(Slider slider, GameObject stateIcon)
    {
        if (slider.value <= 0 && !stateIcon.activeSelf)
        {
            stateIcon.SetActive(true);
        }
        else if (slider.value > 0 && stateIcon.activeSelf)
        {
            stateIcon.SetActive(false);
        }
    }
}
