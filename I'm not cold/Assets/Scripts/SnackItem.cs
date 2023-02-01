using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackItem : MonoBehaviour
{
    [SerializeField] private GameObject _snackSelectionIcon;
    [SerializeField] private Transform _playerTransform;
    private float _interactableDistance = 0.8f;

    private void OnMouseOver()
    {
        if (CheckInteractableDistance())
            _snackSelectionIcon.SetActive(true);
    }
    private void OnMouseDown()
    {
        if (CheckInteractableDistance())
        {
            _snackSelectionIcon.SetActive(false);
            SurvivalStatesManager.instance.IncreaseMentalValueFromSnacking();
            SurvivalStatesManager.instance.IncreaseHungerValueFromSnacking();
            Destroy(gameObject);
        }
    }
    private void OnMouseExit()
    {
        _snackSelectionIcon.SetActive(false);
    }
    private void OnDestroy()
    {
        _snackSelectionIcon.SetActive(false);
    }
    private bool CheckInteractableDistance()
    {
        return Vector3.Distance(transform.position, _playerTransform.position) <= _interactableDistance;
    }
}
