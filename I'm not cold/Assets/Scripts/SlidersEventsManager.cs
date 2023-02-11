using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersEventsManager : MonoBehaviour
{
    [SerializeField] private Slider _heatSlider;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Slider _hungerSlider;
    [SerializeField] private Slider _mentalSlider;

    public event EventHandler OnHeatSliderZero;
    public event EventHandler OnEnergySliderZero;
    public event EventHandler OnHungerSliderZero;
    public event EventHandler OnMentalSliderZero;

    public event EventHandler OnHeatSliderPositiveValue;
    public event EventHandler OnEnergySliderPositiveValue;
    public event EventHandler OnHungerSliderPositiveValue;
    public event EventHandler OnMentalSliderPositive;

    private void Update()
    {
        FireOffSliderEvents();
    }

    private void FireOffSliderEvents()
    {
        if (_heatSlider.value <= 0)
        {
            OnHeatSliderZero?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnHeatSliderPositiveValue?.Invoke(this, EventArgs.Empty);
        }
        if (_energySlider.value <= 0)
        {
            OnEnergySliderZero?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnEnergySliderPositiveValue?.Invoke(this, EventArgs.Empty);
        }
        if (_hungerSlider.value <= 0)
        {
            OnHungerSliderZero?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnHungerSliderPositiveValue?.Invoke(this, EventArgs.Empty);
        }
        if (_mentalSlider.value <= 0)
        {
            OnMentalSliderZero?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnMentalSliderPositive?.Invoke(this, EventArgs.Empty);
        }
    }
}
