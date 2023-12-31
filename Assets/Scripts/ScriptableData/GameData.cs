using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData", order = 0)]
public class GameData : ScriptableObject 
{

    public int score;
    public int increaseScore;
    public int RequirementMergeNumber;
    public int LevelIndex;
    public int powerLevel;

    //Incrementals
    public int RequirementCoin;
    public int RequirementEarningCoin;

    public bool isGameEnd=false;
}
