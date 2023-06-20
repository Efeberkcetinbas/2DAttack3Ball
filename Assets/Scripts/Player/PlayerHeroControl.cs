using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeroControl : MonoBehaviour
{
    public PlayerData playerData;

    [SerializeField] private int id;

    private void OnEnable() 
    {
        EventManager.AddIdHandler(GameEvent.OnPlayerHero,OnPlayerHero);
    }

    private void OnDisable() 
    {
        EventManager.RemoveIdHandler(GameEvent.OnPlayerHero,OnPlayerHero);
    }

    private void OnPlayerHero(int _id)
    {
        if(_id==id)
        {
            Debug.Log("HERO OLDU");
            StartCoroutine(ResetHero());
        }
    }

    private IEnumerator ResetHero()
    {
        yield return new WaitForSeconds(playerData.backToMainPlayerTime);
        Debug.Log("ESKI HALINE DONDU");
        EventManager.Broadcast(GameEvent.OnPlayerNormal);
    }
}
