using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip GameLoop,BuffMusic;
    //Buff seslerini insan sesi kullan
    public AudioClip GameOverSound,FingerTouchSound,MergeSound,DeadSound,SawExplosionSound,InvicibleBuffSound,DestroyerBuffSound,SuccessSound;

    AudioSource musicSource,effectSource;

    private bool hit;

    private void Start() 
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = GameLoop;
        //musicSource.Play();
        effectSource = gameObject.AddComponent<AudioSource>();
        effectSource.volume=0.4f;
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.AddHandler(GameEvent.OnFingerPress,OnFingerPress);
        EventManager.AddHandler(GameEvent.OnMerge,OnMerge);
        EventManager.AddHandler(GameEvent.OnDead,OnDead);
        EventManager.AddHandler(GameEvent.OnSawDestroy,OnSawDestroy);
        EventManager.AddHandler(GameEvent.OnInvincible,OnInvincible);
        EventManager.AddHandler(GameEvent.OnDestroyerActive,OnDestroyerActive);
        EventManager.AddHandler(GameEvent.OnSuccessUI,OnSuccessUI);
    }
    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.RemoveHandler(GameEvent.OnFingerPress,OnFingerPress);
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
        EventManager.RemoveHandler(GameEvent.OnDead,OnDead);
        EventManager.RemoveHandler(GameEvent.OnSawDestroy,OnSawDestroy);
        EventManager.RemoveHandler(GameEvent.OnInvincible,OnInvincible);
        EventManager.RemoveHandler(GameEvent.OnDestroyerActive,OnDestroyerActive);
        EventManager.RemoveHandler(GameEvent.OnSuccessUI,OnSuccessUI);
    }


    private void OnGameOver()
    {
        effectSource.PlayOneShot(GameOverSound);
    }

    private void OnFingerPress()
    {
        effectSource.PlayOneShot(FingerTouchSound);
    }

    private void OnMerge()
    {
        effectSource.PlayOneShot(MergeSound);
    }

    private void OnDead()
    {
        effectSource.PlayOneShot(DeadSound);
    }

    private void OnSawDestroy()
    {
        effectSource.PlayOneShot(SawExplosionSound);
    }

    private void OnInvincible()
    {
        effectSource.PlayOneShot(InvicibleBuffSound);
    }

    private void OnDestroyerActive()
    {
        effectSource.PlayOneShot(DestroyerBuffSound);
    }

    private void OnSuccessUI()
    {
        effectSource.PlayOneShot(SuccessSound);
    }

}
