using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingAndResettingLogic : MonoBehaviour
{
    [SerializeField] private int _deathCountdownTimerValue;
    public void InitiateDying()
    {
        StartCoroutine(DeathCountdownCouroutine());
    }
    public void CancelDying()
    {
        StopCoroutine(DeathCountdownCouroutine());
    }
    private IEnumerator DeathCountdownCouroutine()
    {
        yield return new WaitForSeconds(_deathCountdownTimerValue);
    }
}
