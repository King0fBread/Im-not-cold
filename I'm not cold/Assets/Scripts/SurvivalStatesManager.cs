using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalStatesManager : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider _heatSlider, _energySlider, _hungerSlider, _mentalSlider;
    [Header("Heat values")]
    [SerializeField] private float _heatPassiveDecreasingInsideRate;
    [SerializeField] private float _heatPassiveDecreasingOutsideRate;
    [SerializeField] private float _heatPassiveIncreasingRate;
    private bool _isPlayerInside = false;
    [Header("Energy Values")]
    [SerializeField] private float _energyPassiveDecreasingWalkingRate;
    [SerializeField] private float _enegryPassiveDecreasingRunningRate;
    [SerializeField] private float _energyInstantDecreasingJumpingRate;
    [SerializeField] private float _energyInstantIncreasingRate;
    private bool _isPlayerRunning;
    [Header("Hunger Values")]
    [SerializeField] private float _hungerPassiveDecreasingRate;
    [SerializeField] private float _hungerInstantIncreasingRate;
    [Header("Mental Values")]
    [SerializeField] private float _mentalPassiveDecreasingRate;
    [SerializeField] private float _mentalInstantIncreasingRate;

    private float _heatValue, _energyValue, _hungerValue, _mentalValue;

    private SurvivalStatesManager _instance;
    public SurvivalStatesManager instance { get { return _instance; } }
    private void Awake()
    {
        if(_instance !=null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        _heatValue = _heatSlider.value;
        _energyValue = _energySlider.value;
        _hungerValue = _hungerSlider.value;
        _mentalValue = _mentalSlider.value;
    }
    private void Update()
    {
        ControlHunger();
        ControlMental();
    }
    private void ControlHunger()
    {
        _hungerSlider.value = _hungerValue;
        if (_hungerValue > 0)
        {
            _hungerValue -= _hungerPassiveDecreasingRate * Time.deltaTime;
        }
        else if(_hungerValue <= 0)
        {
            //some post processing screen effect (if 2 or more states at 0 - death)
        }
    }
    private void ControlMental()
    {
        _mentalSlider.value = _mentalValue;
        if(_mentalValue > 0)
        {
            _mentalValue -= _mentalPassiveDecreasingRate * Time.deltaTime;
        }
        else if(_mentalValue <= 0)
        {
            //yeah
        }
    }
    private void ControlHeat()
    {
        _heatSlider.value = _heatValue;
    }
}
