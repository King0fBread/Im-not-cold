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
    public bool _isPlayerInside { get; set; }
    [Header("Energy Values")]
    [SerializeField] private float _energyPassiveDecreasingWalkingRate;
    [SerializeField] private float _enegryPassiveDecreasingRunningRate;
    [SerializeField] private float _energyInstantDecreasingJumpingRate;
    [SerializeField] private float _energyInstantIncreasingRate;
    [SerializeField] private float _energyPassiveIncreasingRate;
    public bool isPlayerIdle { get; set; }
    public bool isPlayerRunning { get; set; }
    public bool playerHasJumped { get; set; }
    [Header("Hunger Values")]
    [SerializeField] private float _hungerPassiveDecreasingRate;
    [SerializeField] private float _hungerInstantIncreasingRate;
    [Header("Mental Values")]
    [SerializeField] private float _mentalPassiveDecreasingRate;
    [SerializeField] private float _mentalInstantIncreasingEatingRate;
    [SerializeField] private float _mentalInstantIncreasingPlayingRate;

    private float _heatValue, _energyValue, _hungerValue, _mentalValue;

    private static SurvivalStatesManager _instance;
    public static SurvivalStatesManager instance { get { return _instance; } }
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
        ControlHeat();
        ControlEnergy();
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
        if (_isPlayerInside)
        {
            _heatValue -= _heatPassiveDecreasingInsideRate * Time.deltaTime;
        }
        else if (!_isPlayerInside)
        {
            _heatValue -= _heatPassiveDecreasingOutsideRate * Time.deltaTime;
        }
    }
    private void ControlEnergy()
    {
        _energySlider.value = _energyValue;
        //Idle
        if (isPlayerIdle)
        {
            _energyValue += _energyPassiveIncreasingRate * Time.deltaTime;
        }
        //Walking
        if (!isPlayerRunning)
        {
            _energyValue -= _energyPassiveDecreasingWalkingRate * Time.deltaTime;
        }
        //Running
        else if (isPlayerRunning)
        {
            _energyValue -= _enegryPassiveDecreasingRunningRate * Time.deltaTime;
        }
        //Jumping
        if (playerHasJumped)
        {
            _energyValue -= _energyInstantDecreasingJumpingRate * Time.deltaTime;
            playerHasJumped = false;
        }
    }
    public void IncreaseHungerValueFromEating()
    {
        _hungerValue += _hungerInstantIncreasingRate;
    }
    public void IncreaseEnergyValueFromEating()
    {
        _energyValue += _energyInstantIncreasingRate;
    }
    public void IncreaseMentalValueFromEating()
    {
        _mentalValue += _mentalInstantIncreasingEatingRate;
    }
}
