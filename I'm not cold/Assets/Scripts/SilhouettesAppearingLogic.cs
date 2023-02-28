using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilhouettesAppearingLogic : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _silhouettes;
    [SerializeField] private float _alphaIncreasingRate;
    [SerializeField] private Color _silhouettesColorWithZeroAlpha;
    private Color[] _silhouettesColorsWithCurretnAlpha = new Color[12];
    public bool displaySilhouettes { get; set; }
    public bool playerInsideCabinZone { get; set; }
    private void Awake()
    {
        for(int i = 0; i < _silhouettes.Length - 1; i++)
        {
            _silhouettesColorsWithCurretnAlpha[i] = _silhouettes[i].color;
        }
    }
    private void Update()
    {
        if(displaySilhouettes && playerInsideCabinZone && _silhouettesColorsWithCurretnAlpha[0].a != 1)
        {
            IncreaseSilhouettesAlpha();
        }
    }
    private void IncreaseSilhouettesAlpha()
    {
        for(int i = 0; i < _silhouettes.Length - 1; i++)
        {
            _silhouettesColorsWithCurretnAlpha[i].a += _alphaIncreasingRate;
            _silhouettes[i].color = _silhouettesColorsWithCurretnAlpha[i];
        }
    }
    private void ResetSilhouettesColors()
    {
        for(int i = 0; i < _silhouettesColorsWithCurretnAlpha.Length; i++)
        {
            _silhouettesColorsWithCurretnAlpha[i].a = 0f;
        }
    }
    public void DisableSilhouettes()
    {
        for(int i = 0; i < _silhouettes.Length - 1; i++)
        {
            _silhouettes[i].color = _silhouettesColorWithZeroAlpha;
        }
        ResetSilhouettesColors();
    }
}
