using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclesMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnFingerPress,OnFingerPress);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnFingerPress,OnFingerPress);
    }

    private void OnFingerPress()
    {
        transform.position=player.position;
    }
}
