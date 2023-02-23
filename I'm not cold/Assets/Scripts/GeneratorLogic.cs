using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLogic : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _mosueInteractionIcon;
    [SerializeField] private PlayerPickAndDropItems _playerPickAndDropItems;
    [SerializeField] private SirenPoleLogic _sirenPoleLogic;
    private Animator _animator;
    private float _interactableDistance = 1f;
    private bool _fuelIsInGenerator = false;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnMouseOver()
    {
        if (!CheckDistance())
            return;

        if (CheckIfHoldingFuel() || _fuelIsInGenerator)
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
        if (CheckDistance())
        {
            if (CheckIfHoldingFuel())
            {
                _playerPickAndDropItems.DisposeOfGrabbedObject();
                _fuelIsInGenerator = true;
                SoundsManager.instance.PlaySound(SoundsManager.Sounds.GeneratorAddedFuel);
            }
            else if(_fuelIsInGenerator)
            {
                _animator.Play("GeneratorShaking");
                _sirenPoleLogic.sirenPoleWorking = true;
                SoundsManager.instance.PlaySound(SoundsManager.Sounds.GeneratorButton);
                Destroy(gameObject.GetComponent<GeneratorLogic>());
            }
        }
    }
    private void OnDestroy()
    {
        if(_mosueInteractionIcon != null)
            _mosueInteractionIcon.SetActive(false);
    }
    private bool CheckIfHoldingFuel()
    {
        if (InventoryObserver.currentInventoryItem != null)
        {
            if (InventoryObserver.currentInventoryItem.GetComponent<GasCanister>())
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
