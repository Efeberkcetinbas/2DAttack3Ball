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
    public ParticleSystem DestroyerBuffParticle;

    public GameData gameData;

    public ParticleSystem RingParticle;


    

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnNonInvincible,OnNonInvincible);
        EventManager.AddHandler(GameEvent.OnMerge,OnMerge);
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.AddHandler(GameEvent.OnDestroyDeActive,OnDestroyDeActive);
        EventManager.AddHandler(GameEvent.OnUpdatePlayerLevel,UpdatePlayerNumberText);

        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnNonInvincible,OnNonInvincible);
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.RemoveHandler(GameEvent.OnDestroyDeActive,OnDestroyDeActive);
        EventManager.RemoveHandler(GameEvent.OnUpdatePlayerLevel,UpdatePlayerNumberText);
    }

    private void Start() 
    {
        UpdatePlayerNumberText();
    }

    internal void UpdatePlayerNumberText()
    {
        PlayerNumberText.SetText((PlayerNumber+gameData.powerLevel).ToString());
        EventManager.Broadcast(GameEvent.OnUpdateWorld);
    }

    private void OnNonInvincible()
    {
        InvincibleBuffParticle.Stop();
    }

    private void OnDestroyDeActive()
    {
        DestroyerBuffParticle.Stop();
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
        if(gameData.RequirementMergeNumber==PlayerNumber+gameData.powerLevel)
        {
            gameData.isGameEnd=true;
            EventManager.Broadcast(GameEvent.OnSuccess);
            Debug.Log("SUCCESS EVENT");
        }
    }
}
