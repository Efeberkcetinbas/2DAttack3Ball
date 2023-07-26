using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleBuff : Interactable
{
    public BuffData buffData;

    internal override void DoAction(PlayerTrigger player)
    {
        buffData.playerInvincible=true;
        EventManager.Broadcast(GameEvent.OnInvincible);
        player.InvincibleBuffParticle.Play();
        Destroy(gameObject);
    }
}
