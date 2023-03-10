using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockCycle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SirenPoleLogic _sirenPoleLogic;
    [Header("Clock logic")]
    [SerializeField] private Transform _hourArrow;
    [SerializeField] private Transform _minuteArrow;
    //7 minutes in seconds
    private const float REAL_SECONDS_TO_GAME_DAY_RATIO = 420f;
    //basic rotation parameters
    private float _possibleRotationInDegreesPerDay = 360f;
    private float _possibleHoursPerDay = 12f;
    //from 0 to 1 the clock makes a full circle back to 12am
    private float _currentDayTime;
    private float _dayNormalized;
    private void Awake()
    {
        //sets the initial arrows rotations, here - to 0.53
        _currentDayTime = 222.6f / REAL_SECONDS_TO_GAME_DAY_RATIO;
    }
    private void Update()
    {
        _dayNormalized = _currentDayTime % 1f;

        _hourArrow.localEulerAngles = new Vector3(90f, 0, _dayNormalized * _possibleRotationInDegreesPerDay);
        _minuteArrow.localEulerAngles = new Vector3(90f, 0, _dayNormalized * _possibleRotationInDegreesPerDay * _possibleHoursPerDay);

        _currentDayTime += Time.deltaTime / REAL_SECONDS_TO_GAME_DAY_RATIO;

        if(_dayNormalized * _possibleHoursPerDay >= 4.5f && _dayNormalized * _possibleHoursPerDay  <= 5f)
        {
            _sirenPoleLogic.activatedInCorrectTime = true;
        }
        else if(_sirenPoleLogic.activatedInCorrectTime == true)
        {
            _sirenPoleLogic.activatedInCorrectTime = false;
        }
    }
}
