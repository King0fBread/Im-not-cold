using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorIconChanger : MonoBehaviour
{
    [SerializeField] private GameObject _EInteractionIcon;
    public static bool EInteractionAvailable { get; set; }
    private void Update()
    {
        if(EInteractionAvailable && !_EInteractionIcon.activeSelf)
        {
            _EInteractionIcon.SetActive(true);
        }
        else if(!EInteractionAvailable && _EInteractionIcon.activeSelf)
        {
            _EInteractionIcon.SetActive(false);
        }
    }
}
