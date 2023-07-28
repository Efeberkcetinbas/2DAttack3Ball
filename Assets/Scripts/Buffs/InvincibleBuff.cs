using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleBuff : Interactable
{
    public BuffData buffData;
    [SerializeField] private GameObject explosionParticle;

    internal override void DoAction(PlayerTrigger player)
    {
        buffData.playerInvincible=true;
        EventManager.Broadcast(GameEvent.OnInvincible);
        Instantiate(explosionParticle,transform.position,Quaternion.identity);
        player.InvincibleBuffParticle.Play();
        Destroy(gameObject);
    }
}
