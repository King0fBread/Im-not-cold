using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScaleOnEnable : MonoBehaviour
{
    private bool _initialScaleCached = false;
    private Vector3 _initialScale;
    private void OnEnable()
    {
        if (!_initialScaleCached)
        {
            _initialScale = transform.localScale;
            _initialScaleCached = true;
        }
        else
        {
            transform.localScale = _initialScale;
        }
    }
}
