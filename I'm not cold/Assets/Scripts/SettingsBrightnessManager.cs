using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsBrightnessManager : MonoBehaviour
{
    [SerializeField] private Volume _globalVolume;
    private Slider _brightnessSlider;
    private ColorAdjustments _colorAdjustments;
    private float _brightnessValue;
    private void Awake()
    {
        _globalVolume.profile.TryGet(out _colorAdjustments);

        _brightnessSlider = GetComponent<Slider>();
        _brightnessValue = PlayerPrefs.GetFloat("Brightness", 0f);
        _brightnessSlider.value = _brightnessValue;
    }
    public void ChangeBrightness()
    {
        _brightnessValue = _brightnessSlider.value;
        _colorAdjustments.postExposure.value = _brightnessValue;
        PlayerPrefs.SetFloat("Brightness", _brightnessValue);
    }
}
