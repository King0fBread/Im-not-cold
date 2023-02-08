using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLogic : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _mosueInteractionIcon;
    [SerializeField] private PlayerPickAndDropItems _playerPickAndDropItems;
    private float _interactableDistance = 1f;
    private void OnMouseOver()
    {
        if (CheckInteractionConditions())
        {
            _mosueInteractionIcon.SetActive(true);
        }
        else
        {
            _mosueInteractionIcon.SetActive(false);
        }
    }
    private void OnMouseExit()
    {
        _mosueInteractionIcon.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (CheckInteractionConditions())
        {
            _playerPickAndDropItems.DisposeOfGrabbedObject();
            //gen logic
            print("brrrrr");
        }
    }
    private bool CheckInteractionConditions()
    {
        if (InventoryObserver.currentInventoryItem != null)
        {
            if (InventoryObserver.currentInventoryItem.GetComponent<GasCanister>() && CheckDistance())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private bool CheckDistance()
    {
        return Vector3.Distance(transform.position, _playerTransform.position) <= _interactableDistance;
    }
}
