using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDamage : Interactable
{
    public BuffData buffData;
    public GameData gameData;

    internal override void DoAction(PlayerTrigger player)
    {
        if(!buffData.playerInvincible && !gameData.isGameEnd)
        {
            Debug.Log("Damage to Planet");
            Instantiate(player.ExplosionParticle,player.transform.position,Quaternion.identity);
            EventManager.Broadcast(GameEvent.OnDead);
            Destroy(player.gameObject);
        }
    }
}
