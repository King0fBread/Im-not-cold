using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentObjectScaling : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleChangeValues;
    public void ScaleUp()
    {
        transform.localScale += _scaleChangeValues;
    }
    public void ScaleDown()
    {
        transform.localScale -= _scaleChangeValues;
    }
}
