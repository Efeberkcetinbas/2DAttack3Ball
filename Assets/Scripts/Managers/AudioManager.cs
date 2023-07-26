using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip GameLoop,BuffMusic;
    public AudioClip GameOverSound,FingerTouchSound,MergeSound,DeadSound;

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
    }
    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.RemoveHandler(GameEvent.OnFingerPress,OnFingerPress);
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
        EventManager.RemoveHandler(GameEvent.OnDead,OnDead);
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

}
