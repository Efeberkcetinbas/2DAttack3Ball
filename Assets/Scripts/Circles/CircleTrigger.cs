using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrigger : Interactable
{
    private CircleProperties circleProperties;

    private void Start() 
    {
        circleProperties=GetComponent<CircleProperties>();
        
    }
    internal override void DoAction(PlayerTrigger player)
    {
        Debug.Log("INTERACTION HAS BEGAN");
        if(player.PlayerNumber==circleProperties.Number)
        {
            player.PlayerNumber*=2;
            player.UpdatePlayerNumberText();
            Destroy(gameObject);
        }

        else if(player.PlayerNumber>circleProperties.Number)
        {
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("GAME END");
        }
    }
}
