using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorIconChanger : MonoBehaviour
{
    [SerializeField] private GameObject _EInteractionIcon;
    [SerializeField] private LayerMask _pickableLayer;
    private bool EInteractionAvailable;
    private void Update()
    {
        EInteractionAvailable = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 1f, _pickableLayer);
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
