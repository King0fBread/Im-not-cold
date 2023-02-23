using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMasterVolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    private Slider _volumeSlider;
    private float _volumeValue;
    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
        _volumeValue = PlayerPrefs.GetFloat("MasterVolume", 0);
        _masterMixer.SetFloat("MasterVolume", _volumeValue);
        _volumeSlider.value = _volumeValue;
    }
    public void ChangeMasterVolume()
    {
        _volumeValue = _volumeSlider.value;
        PlayerPrefs.SetFloat("MasterVolume", _volumeValue);
        _masterMixer.SetFloat("MasterVolume", _volumeValue);
    }
}
