using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockCycle : MonoBehaviour
{
    [SerializeField] private Transform _hourArrow;
    [SerializeField] private Transform _minuteArrow;
    private const float REAL_SECONDS_TO_GAME_DAY_RATIO = 600f;
    private float _possibleRotationInDegreesPerDay = 360f;
    private float _possibleHoursPerDay = 12f;

    private float _currentDayTime;
    private float _dayNormalized;
    private void Awake()
    {
        //sets the initial arrows rotations
        _currentDayTime = 318f / REAL_SECONDS_TO_GAME_DAY_RATIO;
    }
    private void Update()
    {
        _dayNormalized = _currentDayTime % 1f;

        _hourArrow.localEulerAngles = new Vector3(90f, 0, _dayNormalized * _possibleRotationInDegreesPerDay);
        _minuteArrow.localEulerAngles = new Vector3(90f, 0, _dayNormalized * _possibleRotationInDegreesPerDay * _possibleHoursPerDay);

        _currentDayTime += Time.deltaTime / REAL_SECONDS_TO_GAME_DAY_RATIO;

        if(_dayNormalized * _possibleHoursPerDay >= 5 && _dayNormalized * _possibleHoursPerDay  <= 5.5)
        {
            print("time for generator");
        }
    }
}
