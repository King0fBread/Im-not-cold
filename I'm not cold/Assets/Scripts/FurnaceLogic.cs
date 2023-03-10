using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceLogic : MonoBehaviour
{
    [Header("Furnace logic")]
    [SerializeField] private GameObject _selectionIcon;
    [SerializeField] private PlayerPickAndDropItems _playerPickAndDropItems;
    [SerializeField] private ParticleSystem _chimneySmokeParticles;
    [SerializeField] private Slider _heatSlider;
    [SerializeField] private float _passiveDecreasingValue;
    [SerializeField] private float _passiveRapidDecreasingValue;
    [Header("Furnace light emitter")]
    [SerializeField] private Light _workingFurnaceLight;
    [SerializeField] private float _maxIntensity;
    [SerializeField] private float _minIntensity;
    [SerializeField] private float _lightingChangeRate;

    public bool isFrontDoorOpen { get; set; }
    private BurnableItem _currentItem;
    private float _currentHeatValue = 1f;
    private float _interactableDistance = 1.1f;
    private bool _canBurnItem;
    private void Update()
    {
        DecreaseHeatMeter();
        ControlParticles();
    }
    private void DecreaseHeatMeter()
    {
        _heatSlider.value = _currentHeatValue;
        if (_currentHeatValue > 0)
        {
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.FurnaceBurning);
            EmitLight();
            if (isFrontDoorOpen)
            {
                _currentHeatValue -= _passiveRapidDecreasingValue * Time.deltaTime;
            }
            else
            {
                _currentHeatValue -= _passiveDecreasingValue * Time.deltaTime;
            }
        }
        else if(_currentHeatValue <= 0)
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.FurnaceBurning);
            StopLight();
            _currentHeatValue = 0;
        }
    }
    private void EmitLight()
    {
        if(_workingFurnaceLight.intensity < _maxIntensity)
        {
            _workingFurnaceLight.intensity += _lightingChangeRate;
        }
    }
    private void StopLight()
    {
        if(_workingFurnaceLight.intensity > _minIntensity)
        {
            _workingFurnaceLight.intensity -= _lightingChangeRate;
        }
    }
    private void ControlParticles()
    {
        if(!_chimneySmokeParticles.isPlaying && _currentHeatValue > 0)
        {
            _chimneySmokeParticles.Play();
        }
        else if(_chimneySmokeParticles.isPlaying && _currentHeatValue <= 0)
        {
            _chimneySmokeParticles.Stop();
        }
    }
    private void OnMouseOver()
    {
        if (CheckInteractableDistance() && InventoryObserver.currentInventoryItem != null)
        {
            InventoryObserver.currentInventoryItem.TryGetComponent<BurnableItem>(out _currentItem);
            if (_currentItem != null)
            {
                _selectionIcon.SetActive(true);
                _canBurnItem = true;
            }
        }
        else
            _selectionIcon.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (CheckInteractableDistance() && _canBurnItem)
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.FurnaceAddedFuel);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.FurnaceAddedFuel);
            _currentHeatValue += _currentItem.burningValue;
            if (_currentHeatValue > 1)
                _currentHeatValue = 1;

            _playerPickAndDropItems.DisposeOfGrabbedObject();
            _currentItem = null;
            _canBurnItem = false;
            _selectionIcon.SetActive(false);
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
    public float GetCurrentHeatValue()
    {
        return _currentHeatValue;
    }
}
