using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenPoints : Interactable
{
    //Next levelde true olsun
    private bool canPass=true;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnPlayerHero,OnPlayerHero);
        EventManager.AddHandler(GameEvent.OnPlayerNormal,OnPlayerNormal);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnPlayerHero,OnPlayerHero);
        EventManager.RemoveHandler(GameEvent.OnPlayerNormal,OnPlayerNormal);
    }

    internal override void DoAction(PlayerTrigger player)
    {
        Debug.Log("GREEN");
    }
    internal override void InteractionExit(PlayerTrigger player)
    {
        if(canPass)
            EventManager.Broadcast(GameEvent.OnPlayerHero);
    }

    private void OnPlayerNormal()
    {
        canPass=true;
    }

    private void OnPlayerHero()
    {
        canPass=false;
    }
}
