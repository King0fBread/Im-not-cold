using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenAlphaTransition : MonoBehaviour
{
    [SerializeField] private float _alphaIncreasingRate;
    private Image _image;
    private Color _colorWithCurrentAlpha;
    private void OnEnable()
    {
        _image = GetComponent<Image>();
        _colorWithCurrentAlpha = _image.color;
    }
    private void Update()
    {
        _colorWithCurrentAlpha.a += _alphaIncreasingRate;
        _image.color = _colorWithCurrentAlpha;
    }
}
