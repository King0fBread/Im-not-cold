using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramophoneLogic : MonoBehaviour
{
    [SerializeField] private GameObject _mouseSelectionIcon;
    [SerializeField] private Transform _playerTransform;
    private float _interactableValue = 0.7f;
    private bool _gramophoneActive = false;
    private void OnMouseOver()
    {
        if (CheckInteractableDistance())
        {
            _mouseSelectionIcon.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        if (!CheckInteractableDistance())
            return;
        print("music");
    }
    private void OnMouseExit()
    {
        _mouseSelectionIcon.SetActive(false);
    }
    private bool CheckInteractableDistance()
    {
        return Vector3.Distance(transform.position, _playerTransform.gameObject.transform.position) <= _interactableValue;
    }

}
