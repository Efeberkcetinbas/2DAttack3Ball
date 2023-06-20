using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeroControl : MonoBehaviour
{
    public PlayerData playerData;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnPlayerHero,OnPlayerHero);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnPlayerHero,OnPlayerHero);
    }

    private void OnPlayerHero()
    {
        Debug.Log("HERO OLDU");
        StartCoroutine(ResetHero());
    }

    private IEnumerator ResetHero()
    {
        yield return new WaitForSeconds(playerData.backToMainPlayerTime);
        Debug.Log("ESKI HALINE DONDU");
        EventManager.Broadcast(GameEvent.OnPlayerNormal);
    }
}
