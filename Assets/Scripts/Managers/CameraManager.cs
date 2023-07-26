using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;

    public CinemachineVirtualCamera cm;
    public Transform cmCamera;

    Vector3 cameraInitialPosition;

    [Header("Shake Control")]
    private CinemachineBasicMultiChannelPerlin noise;


    private void Start() 
    {
        noise=cm.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        if(noise == null)
            Debug.LogError("No MultiChannelPerlin on the virtual camera.", this);
        else
            Debug.Log($"Noise Component: {noise}");
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnGameOver,GameOver);
        EventManager.AddHandler(GameEvent.OnMerge,OnMerge);
        EventManager.AddHandler(GameEvent.OnDead,OnDead);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnGameOver,GameOver);
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
        EventManager.RemoveHandler(GameEvent.OnDead,OnDead);
    }

    private void OnNextLevel()
    {
        ChangeFieldOfView(5,0.1f);
    }

    private void OnMerge()
    {
        Noise(1,1,0.3f);
        ChangeFieldOfViewHit(9,10,0.1f);
    }

    private void OnDead()
    {
        Noise(3,3,2);
        ChangeFieldOfView(8,0.3f);
    }

    private void Noise(float amplitudeGain,float frequencyGain,float shakeTime) 
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
        StartCoroutine(ResetNoise(shakeTime));    
    }

    private IEnumerator ResetNoise(float duration)
    {
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;    
    }

    

    

    
    public void ChangeFieldOfView(float fieldOfView, float duration = 1)
    {
        DOTween.To(() => cm.m_Lens.OrthographicSize, x => cm.m_Lens.OrthographicSize = x, fieldOfView, duration);
    }

    

    //Hit Effect
    public void ChangeFieldOfViewHit(float newFieldOfView, float oldFieldOfView, float duration = 1)
    {
        DOTween.To(() => cm.m_Lens.OrthographicSize, x => cm.m_Lens.OrthographicSize = x, newFieldOfView, duration).OnComplete(()=>{
            DOTween.To(() => cm.m_Lens.OrthographicSize, x => cm.m_Lens.OrthographicSize = x, oldFieldOfView, duration);
        });
    }

    
   
    public void ResetCamera()
    {
        cm.m_Priority = 1;
    }

    void GameOver()
    {
        DOTween.To(() => mainCamera.fieldOfView, x => mainCamera.fieldOfView = x, 60, 0.5f).OnComplete(()=>
        {
            EventManager.Broadcast(GameEvent.OnUIGameOver);
        });
        
    }
}
