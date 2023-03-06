using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelector : MonoBehaviour
{
    //0 for casual; 1 for challenging
    public static int difficultyIndex;
    public void SelectCasualDifficulty()
    {
        difficultyIndex = 0;
    }
    public void SelectChallengingDifficulty()
    {
        difficultyIndex = 1;
    }
}
