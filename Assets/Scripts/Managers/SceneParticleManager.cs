using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneParticleManager : MonoBehaviour
{
    public List<ParticleSystem> TextParticles=new List<ParticleSystem>();

    private int index;


    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnMerge,OnMerge);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
    }

    private void OnMerge()
    {
        index=Random.Range(0,TextParticles.Count);
        TextParticles[index].Play();
    }
}
