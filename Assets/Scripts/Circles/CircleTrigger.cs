using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrigger : Interactable
{
    private CircleProperties circleProperties;

    [SerializeField] private GameObject rockEffect;

    [SerializeField] private Color color;

    private void Start() 
    {
        circleProperties=GetComponent<CircleProperties>();
        
    }
    internal override void DoAction(PlayerTrigger player)
    {
        Debug.Log("INTERACTION HAS BEGAN");
        if(player.PlayerNumber==circleProperties.Number)
        {
            player.PlayerNumber+=1;
            player.UpdatePlayerNumberText();
            EventManager.Broadcast(GameEvent.OnMerge);
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
            
            

            GameObject cloneRockEffect=Instantiate(rockEffect,transform.position,Quaternion.identity);
            for (int i = 0; i < 2; i++)
            {
                ParticleSystem.MainModule main=cloneRockEffect.transform.GetChild(i).GetComponent<ParticleSystem>().main;
                main.startColor=color;
            }

            //Carptigimiz gezegen ile ayni renkte yorunge
            //Burayi duzeltmeye calis. Bir oncekini aliyor
            ParticleSystem.MainModule mainRing=player.RingParticle.main;
            mainRing.startColor=color;

            Destroy(gameObject);
        }

        else if(player.PlayerNumber>circleProperties.Number)
        {
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
            GameObject cloneRockEffect=Instantiate(rockEffect,transform.position,Quaternion.identity);
            for (int i = 0; i < 2; i++)
            {
                ParticleSystem.MainModule main=cloneRockEffect.transform.GetChild(i).GetComponent<ParticleSystem>().main;
                main.startColor=color;
            }
            Destroy(gameObject);
        }
        
    }
}
