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
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;
    public float amplitudeGain=1;
    public float frequencyGain=1;
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
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnGameOver,GameOver);
    }

    private void OnNextLevel()
    {
        ChangeFieldOfView(5,0.1f);
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
