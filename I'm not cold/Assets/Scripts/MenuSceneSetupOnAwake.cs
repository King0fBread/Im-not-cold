using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneSetupOnAwake : MonoBehaviour
{
    [SerializeField] private GameObject _settingsObject;
    [SerializeField] private GameObject _difficultyObject;
    private AudioSource _audioSource;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        _audioSource = GetComponent<AudioSource>();
        _settingsObject.SetActive(false);
        _difficultyObject.SetActive(false);
        _audioSource.Play();
    }
}
