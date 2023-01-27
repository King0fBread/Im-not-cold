using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private Volume _globalPPVolume;
    [SerializeField] private float _chromaticAberrationChangingRate;
    public bool playerCloseToDying { get; set; }
    private ChromaticAberration _chromaticAberration;
    private void Awake()
    {
        _globalPPVolume.profile.TryGet(out _chromaticAberration);
    }
    private void Update()
    {
        if (playerCloseToDying && _chromaticAberration.intensity.value != 1f)
        {
            _chromaticAberration.intensity.value += _chromaticAberrationChangingRate * Time.deltaTime;
        }
        else if(!playerCloseToDying && _chromaticAberration.intensity.value != 0f)
        {
            _chromaticAberration.intensity.value -= _chromaticAberrationChangingRate * Time.deltaTime;
        }
    }
}
