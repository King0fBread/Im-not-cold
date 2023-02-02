using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [SerializeField] private GameObject _foodSelectionIcon;
    [SerializeField] private GameObject _emptyFoodCan;
    [SerializeField] private Transform _playerTransform;
    private float _interactableDistance = 0.9f;
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
            _foodSelectionIcon.SetActive(false);
            SpawnEmptyCan();
            Destroy(gameObject);
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
    private void SpawnEmptyCan()
    {
        Instantiate(_emptyFoodCan, transform.position, Quaternion.identity);
    }
    private void OnDestroy()
    {
        if(_foodSelectionIcon != null)
            _foodSelectionIcon.SetActive(false);
    }
}
