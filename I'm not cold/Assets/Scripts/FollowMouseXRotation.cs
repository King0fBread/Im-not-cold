using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseXRotation : MonoBehaviour
{
    private float _mouseRotationAlongX;
    private float _rotationY;
    private void Update()
    {
        _mouseRotationAlongX = Input.GetAxis("Mouse X");
        _rotationY += _mouseRotationAlongX;
        transform.rotation = Quaternion.Euler(0f, _rotationY, 0f);
    }
}
