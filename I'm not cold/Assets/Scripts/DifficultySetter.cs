using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetter : MonoBehaviour
{
    private int _difficulty;
    private void Awake()
    {
        _difficulty = DifficultySelector.difficultyIndex;
        print(_difficulty);
    }
}
