using UnityEngine;

public class WeatherSoundController : MonoBehaviour
{
    [SerializeField] private GroundTypeCheck _groundTypeCheck;
    [SerializeField] private float _outsideWindVolume;
    [SerializeField] private float _insideWindVolume;
    [SerializeField] private AudioSource _windAudioSource;
    private void Update()
    {
        SoundsManager.instance.PlaySound(SoundsManager.Sounds.EnvironmentWind);

        if (_groundTypeCheck.windShouldPlayFully && _windAudioSource.volume < _outsideWindVolume)
        {
            _windAudioSource.volume = _outsideWindVolume;
        }
        else if(!_groundTypeCheck.windShouldPlayFully && _windAudioSource.volume > _insideWindVolume)
        {
            _windAudioSource.volume = _insideWindVolume;
        }
    }
}
