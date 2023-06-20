using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenPoints : Interactable
{
    //Next levelde true olsun
    private bool canPass=true;

    [SerializeField] private int customId;

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
        //Debug.Log("IT PASSEDDDD");
    }
    internal override void InteractionExit(PlayerTrigger player)
    {
        Debug.Log("NASIL GIRDI");
        if(canPass && customId==player.Playerid)
        {
            EventManager.BroadcastId(GameEvent.OnPlayerHero,customId);
            Debug.Log("THIS TIME");
        }
            
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
