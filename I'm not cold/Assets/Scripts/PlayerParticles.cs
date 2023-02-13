using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _breathingParticles;
    public bool isPlayerInside { get; set; }
    private void Update()
    {
        if (!isPlayerInside && !_breathingParticles.isPlaying)
        {
            _breathingParticles.Play();
        }
        else if(isPlayerInside && _breathingParticles.isPlaying)
        {
            _breathingParticles.Stop();
        }
    }
}
