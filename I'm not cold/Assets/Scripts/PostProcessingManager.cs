using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private Volume _globalPPVolume;
    [SerializeField] private float _chromaticAberrationChangingRate;
    [SerializeField] private float _lensDistortionChangingRate;
    public bool playerCloseToDying { get; set; }
    private ChromaticAberration _chromaticAberration;
    private LensDistortion _lensDistortion;
    private void Awake()
    {
        _globalPPVolume.profile.TryGet(out _chromaticAberration);
        _globalPPVolume.profile.TryGet(out _lensDistortion);
        playerCloseToDying = true;
    }
    private void Update()
    {
        if (playerCloseToDying && !PostProcessingValuesAtMax())
        {
            _chromaticAberration.intensity.value += _chromaticAberrationChangingRate * Time.deltaTime;
            _lensDistortion.intensity.value -= _lensDistortionChangingRate * Time.deltaTime;
        }
        else if(!playerCloseToDying && PostProcessingValuesAtMax())
        {
            _chromaticAberration.intensity.value -= _chromaticAberrationChangingRate * Time.deltaTime;
            _lensDistortion.intensity.value += _lensDistortionChangingRate * Time.deltaTime;
        }
    }
    private bool PostProcessingValuesAtMax()
    {
        return _chromaticAberration.intensity.value == 1f && _lensDistortion.intensity.value <= -0.5f;
    }
}
