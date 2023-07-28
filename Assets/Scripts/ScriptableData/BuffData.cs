using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BuffData", menuName = "Data/BuffData", order = 2)]
public class BuffData : ScriptableObject 
{
    public bool playerInvincible=true;
    public bool playerIsDestroyer=true;

    public int time=5;
    
}
