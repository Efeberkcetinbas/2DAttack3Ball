using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBuff : Interactable
{
    public BuffData buffData;
    [SerializeField] private GameObject explosionParticle;

    internal override void DoAction(PlayerTrigger player)
    {
        buffData.playerIsDestroyer=true;
        EventManager.Broadcast(GameEvent.OnDestroyerActive);
        Instantiate(explosionParticle,transform.position,Quaternion.identity);
        player.DestroyerBuffParticle.Play();
        Destroy(gameObject);
    }
}
