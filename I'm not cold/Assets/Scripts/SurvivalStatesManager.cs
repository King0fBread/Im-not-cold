using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalStatesManager : MonoBehaviour
{
    public bool canChangeSurvivalStates { get; set; }
    [Header("Sliders")]
    [SerializeField] private Slider _heatSlider;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Slider _hungerSlider;
    [SerializeField] private Slider _mentalSlider;
    [Header("Heat values")]
    [SerializeField] private float _heatPassiveDecreasingInsideRate;
    [SerializeField] private float _heatPassiveDecreasingOutsideRate;
    [SerializeField] private float _heatPassiveIncreasingRate;
    public bool isPlayerInside { get; set; }
    public bool isPlayerNearFurnace { get; set; }
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
    [SerializeField] private float _hungerInstantIncreasingEatingRate;
    [SerializeField] private float _hungerInstanctIncreasingSnackingRate;
    [Header("Mental Values")]
    [SerializeField] private float _mentalPassiveDecreasingRate;
    [SerializeField] private float _mentalInstantIncreasingEatingRate;
    [SerializeField] private float _mentalInstantIncreasingSnackingRate;

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
        if (!canChangeSurvivalStates)
            return;

        ControlHunger();
        ControlMental();
        ControlHeat();
        ControlEnergy();
    }
    private void ControlHunger()
    {
        _hungerSlider.value = _hungerValue;
        _hungerValue -= _hungerPassiveDecreasingRate * Time.deltaTime;
        _hungerValue = ObserveIfValueIsZero(_hungerValue);
    }
    private void ControlMental()
    {
        _mentalSlider.value = _mentalValue;
        _mentalValue -= _mentalPassiveDecreasingRate * Time.deltaTime;
        _mentalValue = ObserveIfValueIsZero(_mentalValue);
    }
    private void ControlHeat()
    {
        _heatSlider.value = _heatValue;
        //Passive decreasing
        if (isPlayerInside)
        {
            _heatValue -= _heatPassiveDecreasingInsideRate * Time.deltaTime;
        }
        else if (!isPlayerInside)
        {
            _heatValue -= _heatPassiveDecreasingOutsideRate * Time.deltaTime;
        }
        _heatValue = ObserveIfValueIsZero(_heatValue);
        TryIncreaseHeatValue();
    }
    private void ControlEnergy()
    {
        _energySlider.value = _energyValue;
        //Idle
        if (isPlayerIdle)
        {
            _energyValue += _energyPassiveIncreasingRate * Time.deltaTime;
            _energyValue = CapSurvivalValueAtMax(_energyValue);
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
        _energyValue = ObserveIfValueIsZero(_energyValue);
    }
    private float ObserveIfValueIsZero(float value)
    {
        if(value < 0)
        {
            return 0;
            //reference dying class and stop the update method
        }
        else
        {
            return value;
        }
    }
    private float CapSurvivalValueAtMax(float value)
    {
        if (value > 1)
        {
            return 1;
        }
        else
        {
            return value;
        }
    }
    private void TryIncreaseHeatValue()
    {
        if (isPlayerNearFurnace)
        {
            _heatValue += _heatPassiveIncreasingRate * Time.deltaTime;
            _heatValue = CapSurvivalValueAtMax(_heatValue);
        }
    }
    public void IncreaseHungerValueFromEating()
    {
        _hungerValue += _hungerInstantIncreasingEatingRate;
        _hungerValue = CapSurvivalValueAtMax(_hungerValue);
    }
    public void IncreaseHungerValueFromSnacking()
    {
        _hungerValue += _hungerInstanctIncreasingSnackingRate;
        _hungerValue = CapSurvivalValueAtMax(_hungerValue);
    }
    public void IncreaseEnergyValueFromEating()
    {
        _energyValue += _energyInstantIncreasingRate;
        _energyValue = CapSurvivalValueAtMax(_energyValue);
    }
    public void IncreaseMentalValueFromEating()
    {
        _mentalValue += _mentalInstantIncreasingEatingRate;
        _mentalValue = CapSurvivalValueAtMax(_mentalValue);
    }
    public void IncreaseMentalValueFromSnacking()
    {
        _mentalValue += _mentalInstantIncreasingSnackingRate;
        _mentalValue = CapSurvivalValueAtMax(_mentalValue);
    }
}
