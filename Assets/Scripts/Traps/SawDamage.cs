using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDamage : Interactable
{
    public BuffData buffData;
    public GameData gameData;

    public GameObject SawExplosion;
    internal override void DoAction(PlayerTrigger player)
    {
        if(!buffData.playerInvincible && !buffData.playerIsDestroyer && !gameData.isGameEnd)
        {
            Debug.Log("Damage to Planet");
            Instantiate(player.ExplosionParticle,player.transform.position,Quaternion.identity);
            EventManager.Broadcast(GameEvent.OnDead);
            Destroy(player.gameObject);
        }

        if(buffData.playerIsDestroyer)
        {
            //Kara delik patlama ve ses lazim Event
            Instantiate(SawExplosion,transform.position,Quaternion.identity);
            EventManager.Broadcast(GameEvent.OnSawDestroy);
            Destroy(gameObject);
        }
    }
}
