using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorLogic : MonoBehaviour
{
    private Animator _doorAnimator;
    private bool _doorIsClosed = true;
    private void Awake()
    {
        _doorAnimator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        if (_doorIsClosed)
        {
            _doorAnimator.Play("DoorOpening");
            _doorIsClosed = false;
        }
        else if (!_doorIsClosed)
        {
            _doorAnimator.Play("DoorClosing");
            _doorIsClosed = true;
        }
    }
}
