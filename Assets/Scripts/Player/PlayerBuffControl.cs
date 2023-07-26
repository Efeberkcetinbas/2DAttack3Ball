using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffControl : MonoBehaviour
{

    public BuffData buffData;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnInvincible,OnInvincible);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnInvincible,OnInvincible);
    }

    private void OnInvincible()
    {
        StartCoroutine(BackToNonInvincible());
    }


    private IEnumerator BackToNonInvincible()
    {
        yield return new WaitForSeconds(5);
        buffData.playerInvincible=false;
        EventManager.Broadcast(GameEvent.OnNonInvincible);
    }
}
