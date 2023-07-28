using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class PlayerTrigger : MonoBehaviour
{
    public int PlayerNumber;

    public TextMeshPro PlayerNumberText;

    [Header("Particles")]
    public ParticleSystem InvincibleBuffParticle;
    public GameObject ExplosionParticle;
    public ParticleSystem MergeParticle;

    public GameData gameData;


    

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnNonInvincible,OnNonInvincible);
        EventManager.AddHandler(GameEvent.OnMerge,OnMerge);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnNonInvincible,OnNonInvincible);
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
    }

    internal void UpdatePlayerNumberText()
    {
        PlayerNumberText.SetText(PlayerNumber.ToString());
        EventManager.Broadcast(GameEvent.OnUpdateWorld);
    }

    private void OnNonInvincible()
    {
        InvincibleBuffParticle.Stop();
    }

    private void OnMerge()
    {
        MergeParticle.Play();
        transform.DOScale(new Vector3(0.75f,0.75f,0.75f),0.1f).OnComplete(()=>transform.DOScale(new Vector3(0.5f,0.5f,0.5f),0.1f));
        CheckRequirementMergeNumber();
    }

    private void OnNextLevel()
    {
        PlayerNumber=1;
        UpdatePlayerNumberText();
    }

    //Burada requirementi kontrol edebiliriz
    private void CheckRequirementMergeNumber()
    {
        if(gameData.RequirementMergeNumber==PlayerNumber)
        {
            gameData.isGameEnd=true;
            EventManager.Broadcast(GameEvent.OnSuccess);
            Debug.Log("SUCCESS EVENT");
        }
    }
}
