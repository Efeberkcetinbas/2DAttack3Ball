using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : Interactable
{
    [SerializeField] private bool playerCanDamage=false;
    [SerializeField] private float health;

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
        if(playerCanDamage)
        {
            health--;
            Debug.Log("ENEMY YARALANDI");
        }

        else
        {
            Debug.Log("FAILLLL");
        }
    }

    internal override void InteractionExit(PlayerTrigger player)
    {
        if(health<=0) Dead();
    }

    private void Dead()
    {

    } 

    private void OnPlayerHero()
    {
        playerCanDamage=true;
    }

    private void OnPlayerNormal()
    {
        playerCanDamage=false;
    }
    
   
}