using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffControl : MonoBehaviour
{

    public BuffData buffData;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnInvincible,OnInvincible);
        EventManager.AddHandler(GameEvent.OnDestroyerActive,OnDestroyerActive);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnInvincible,OnInvincible);
        EventManager.RemoveHandler(GameEvent.OnDestroyerActive,OnDestroyerActive);
    }

    private void OnInvincible()
    {
        StartCoroutine(BackToNonInvincible());
    }

    private void OnDestroyerActive()
    {
        StartCoroutine(BackToNonDestroyer());
    }

    private IEnumerator BackToNonDestroyer()
    {
        yield return new WaitForSeconds(buffData.time);
        buffData.playerIsDestroyer=false;
        EventManager.Broadcast(GameEvent.OnDestroyDeActive);
    }


    private IEnumerator BackToNonInvincible()
    {
        yield return new WaitForSeconds(buffData.time);
        buffData.playerInvincible=false;
        EventManager.Broadcast(GameEvent.OnNonInvincible);
    }
}
