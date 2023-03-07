using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetter : MonoBehaviour
{
    [SerializeField] private GameObject _casualDifficultyExtraObjects;
    private int _difficulty;
    private void Awake()
    {
        _difficulty = DifficultySelector.difficultyIndex;
        if (_difficulty == 0)
            _casualDifficultyExtraObjects.SetActive(true);
    }
}
