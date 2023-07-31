using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorld : MonoBehaviour
{
    private PlayerTrigger playerTrigger;

    private SpriteRenderer spriteRenderer;

    public GameData gameData;
    [SerializeField] private List<Sprite> worlds=new List<Sprite>();

    private void Start() 
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        playerTrigger=GetComponent<PlayerTrigger>();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUpdateWorld,OnUpdateWorld);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUpdateWorld,OnUpdateWorld);
    }

    private void OnUpdateWorld()
    {
        spriteRenderer.sprite=worlds[playerTrigger.PlayerNumber+gameData.powerLevel];
    }
}
