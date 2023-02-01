using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [SerializeField] private GameObject _foodSelectionIcon;
    [SerializeField] private Transform _playerTransform;
    private FoodItem _foodItem;
    private Rigidbody _rb;
    private float _interactableDistance = 0.9f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _foodItem = GetComponent<FoodItem>();
    }
    private void OnMouseOver()
    {
        if (CheckInteractableDistance())
            _foodSelectionIcon.SetActive(true);
    }
    private void OnMouseDown()
    {
        if (CheckInteractableDistance())
        {
            _foodSelectionIcon.SetActive(false);
            SurvivalStatesManager.instance.IncreaseHungerValueFromEating();
            SurvivalStatesManager.instance.IncreaseEnergyValueFromEating();
            SurvivalStatesManager.instance.IncreaseMentalValueFromEating();
            _rb.mass = 0.4f;
            _foodItem.enabled = false;

        }
    }
    private void OnMouseExit()
    {
        _foodSelectionIcon.SetActive(false);
    }
    private bool CheckInteractableDistance()
    {
        return Vector3.Distance(transform.position, _playerTransform.position) <= _interactableDistance;
    }
    private void OnDestroy()
    {
        _foodSelectionIcon.SetActive(false);
    }
}
