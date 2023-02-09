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

    public float _heatValue { get; private set; }
    public float _energyValue { get; private set; }
    public float _hungerValue { get; private set; }
    public float _mentalValue { get; private set; }

    private void Update()
    {
        _heatValue = _heatSlider.value;
        _energyValue = _energySlider.value;
        _hungerValue = _hungerSlider.value;
        _mentalValue = _mentalSlider.value;
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
