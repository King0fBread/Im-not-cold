using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsFullscreenManager : MonoBehaviour
{
    private Toggle _fullscreenToggle;
    private int _fullscreenValueInInt;
    private bool _fullscreenValueInBool;
    private void Awake()
    {
        _fullscreenToggle = GetComponent<Toggle>();
        _fullscreenValueInInt = PlayerPrefs.GetInt("FullscreenInt", 1);
        SetBoolToMatchInt();
        _fullscreenToggle.isOn = _fullscreenValueInBool;
    }
    private void SetIntToMatchBool()
    {
        _fullscreenValueInInt = _fullscreenValueInBool == true ? 1 : 2;
    }
    private void SetBoolToMatchInt()
    {
        _fullscreenValueInBool = _fullscreenValueInInt == 1 ? true : false;
    }
    public void ChangeFullscreenValue()
    {
        _fullscreenValueInBool = _fullscreenToggle.isOn;
        Screen.fullScreen = _fullscreenValueInBool;
        SetIntToMatchBool();
        PlayerPrefs.SetInt("FullscreenInt", _fullscreenValueInInt);
    }
}
