using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceLogic : MonoBehaviour
{
    [SerializeField] private GameObject _selectionIcon;
    [SerializeField] private PlayerPickAndDropItems _playerPickAndDropItems;
    [SerializeField] private Slider _heatSlider;
    [SerializeField] private float _passiveDecreasingValue;
    private BurnableItem _currentItem;
    private float _currentHeatValue = 1f;
    private float _interactableDistance = 1f;
    private bool _canBurnItem;
    private void Update()
    {
        DecreaseHeatMeter();
    }
    private void DecreaseHeatMeter()
    {
        _heatSlider.value = _currentHeatValue;
        if (_currentHeatValue >= 0)
        {
            _currentHeatValue -= _passiveDecreasingValue * Time.deltaTime;
        }
        else
        {
            //pp
        }
    }
    private void OnMouseEnter()
    {
        if(CheckInteractableDistance())
        {
            InventoryObserver.currentInventoryItem.TryGetComponent<BurnableItem>(out _currentItem);
            if(_currentItem != null)
            {
                _selectionIcon.SetActive(true);
                _canBurnItem = true;
            }
        }
    }
    private void OnMouseDown()
    {
        if (CheckInteractableDistance() && _canBurnItem)
        {
            _currentHeatValue += _currentItem.burningValue;
            _playerPickAndDropItems.DisposeOfGrabbedObject();
            _canBurnItem = false;
        }
    }
    private void OnMouseExit()
    {
        _selectionIcon.SetActive(false);
        _currentItem = null;
        _canBurnItem = false;
    }
    private bool CheckInteractableDistance()
    {
        return Vector3.Distance(transform.position, _playerPickAndDropItems.gameObject.transform.position) <= _interactableDistance;
    }
}
