using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SillouetteAppearingLogic : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _silouettes;
    [SerializeField] private float _alphaIncreasingRate;
    [SerializeField] private float _alphaDecreasingRate;
    private Color[] _silouettesColorsWithCurretnAlpha = new Color[12];
    public bool displaySilouettes { get; set; }
    public bool playerInsideCabinZone { get; set; }
    private void Awake()
    {
        for(int i = 0; i < _silouettes.Length - 1; i++)
        {
            _silouettesColorsWithCurretnAlpha[i] = _silouettes[i].color;
        }
    }
    private void Update()
    {
        if(displaySilouettes && playerInsideCabinZone && _silouettesColorsWithCurretnAlpha[0].a != 1)
        {
            print("increasing alpha");
            IncreaseSilouettesAlpha();
        }
        else if(!displaySilouettes && playerInsideCabinZone && _silouettesColorsWithCurretnAlpha[0].a != 0)
        {
            print("decreasing alpha");
            DecreaseSilouettesAlpha();
        }
    }
    private void IncreaseSilouettesAlpha()
    {
        for(int i = 0; i < _silouettes.Length - 1; i++)
        {
            _silouettesColorsWithCurretnAlpha[i].a += _alphaIncreasingRate;
            _silouettes[i].color = _silouettesColorsWithCurretnAlpha[i];
        }
    }
    private void DecreaseSilouettesAlpha()
    {
        for (int i = 0; i < _silouettes.Length - 1; i++)
        {
            _silouettesColorsWithCurretnAlpha[i].a -= _alphaDecreasingRate;
            _silouettes[i].color = _silouettesColorsWithCurretnAlpha[i];
        }
    }
}
