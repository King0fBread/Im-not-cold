using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private DyingAndResettingLogic _dyingAndResettingLogic;
    [SerializeField] private Volume _globalPPVolume;
    [SerializeField] private float _chromaticAberrationChangingRate;
    [SerializeField] private float _lensDistortionChangingRate;
    public bool playerCloseToDying { get; set; }
    private ChromaticAberration _chromaticAberration;
    private LensDistortion _lensDistortion;
    private bool _deathCountdownIsOn = false;
    private void Awake()
    {
        _globalPPVolume.profile.TryGet(out _chromaticAberration);
        _globalPPVolume.profile.TryGet(out _lensDistortion);
    }
    private void Update()
    {
        if (playerCloseToDying && !PostProcessingValuesAtMax())
        {
            _chromaticAberration.intensity.value += _chromaticAberrationChangingRate * Time.deltaTime;
            _lensDistortion.intensity.value -= _lensDistortionChangingRate * Time.deltaTime;
        }
        else if(!playerCloseToDying && !PostProcessingValuesAtMin())
        {
            _chromaticAberration.intensity.value -= _chromaticAberrationChangingRate * Time.deltaTime;
            _lensDistortion.intensity.value += _lensDistortionChangingRate * Time.deltaTime;
        }

        ObserveDyingState();
    }
    private bool PostProcessingValuesAtMax()
    {
        return _chromaticAberration.intensity.value == 1f && _lensDistortion.intensity.value <= -0.5f;
    }
    private bool PostProcessingValuesAtMin()
    {
        return _chromaticAberration.intensity.value == 0f && _lensDistortion.intensity.value >= 0f;
    }
    private void ObserveDyingState()
    {
        if (playerCloseToDying && !_deathCountdownIsOn)
        {
            _dyingAndResettingLogic.InitiateDying();
            _deathCountdownIsOn = true;
        }
        else if (!playerCloseToDying && _deathCountdownIsOn)
        {
            _dyingAndResettingLogic.CancelDying();
            _deathCountdownIsOn = false;
        }
    }
}
