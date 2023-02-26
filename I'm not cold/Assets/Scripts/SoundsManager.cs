using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    private AudioClip _clip;
    private AudioSource _source;
    public AudioClipAndSourcePairedToSound[] audioClipsAndSourcePairedToSounds;
    [System.Serializable]
    public class AudioClipAndSourcePairedToSound
    {
        public Sounds sound;
        public AudioClip clip;
        public AudioSource source;
    }

    private static SoundsManager _instance;
    public static SoundsManager instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public enum Sounds
    {
        PlayerJumpingSnow,
        PlayerJumpingWood,
        PlayerPickUpItem,
        PlayerRunningWood,
        PlayerRunningSnow,
        PlayerWalkingSnow,
        PlayerWalkingWood,
        PlayerTouchedWood,
        PlayerTouchedMetal,
        PlayerAteSnack,
        PlayerAteCannedFood,
        FurnaceBurning,
        FurnaceAddedFuel,
        GramophoneMusic,
        GeneratorAddedFuel,
        GeneratorButton,
        GeneratorWorking,
        SirenWorking,
        HelicopterEvacuation,
    }
    public void PlaySound(Sounds sound)
    {
        GetRequestedAudioClipAndAudioSource(sound, out _clip, out _source);
        if (!_source.isPlaying)
        {
            _source.PlayOneShot(_clip);
        }
    }
    public void StopSound(Sounds sound)
    {
        GetRequestedAudioClipAndAudioSource(sound, out _clip, out _source);
        if (_source.isPlaying)
        {
            _source.Stop();
        }
    }
    private void GetRequestedAudioClipAndAudioSource(Sounds soundToFind, out AudioClip clip, out AudioSource source)
    {
        clip = null;
        source = null;

        foreach (AudioClipAndSourcePairedToSound audioClipAndSourcePairedToSound in audioClipsAndSourcePairedToSounds)
        {
            if (audioClipAndSourcePairedToSound.sound == soundToFind)
            {
                clip = audioClipAndSourcePairedToSound.clip;
                source = audioClipAndSourcePairedToSound.source;
            }
        }
    }
    public void SilenceAllSounds()
    {
        _masterMixer.SetFloat("MasterVolume", -60f);
    }
}
