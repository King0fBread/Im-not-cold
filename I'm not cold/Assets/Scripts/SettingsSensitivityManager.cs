using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSensitivityManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    private Slider _sensitivitySlider;
    private float _sensitivityValue;
    private void Awake()
    {
        _sensitivitySlider = GetComponent<Slider>();
        _sensitivityValue = PlayerPrefs.GetFloat("Sensitivity", 3f);
        _sensitivitySlider.value = _sensitivityValue;
        _playerMovement.rotationSensitivity = _sensitivityValue;
    }
    public void ChangeSensitivity()
    {
        _sensitivityValue = _sensitivitySlider.value;
        _playerMovement.rotationSensitivity = _sensitivityValue;
        PlayerPrefs.SetFloat("Sensitivity", _sensitivityValue);
    }
}
