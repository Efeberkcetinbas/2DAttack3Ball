using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score,levelText;

    public GameData gameData;
    public PlayerData playerData;

    [Header("Buff Texts")]
    public TextMeshProUGUI BuffText; 

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnUIUpdate, OnUIUpdate);
        EventManager.AddHandler(GameEvent.OnInvincible,OnInvincible);
        EventManager.AddHandler(GameEvent.OnNonInvincible,OnNonInvincible);
        EventManager.AddHandler(GameEvent.OnUpdateLevelText,OnUpdateLevelText);
        EventManager.AddHandler(GameEvent.OnDestroyerActive,OnDestroyerActive);
        EventManager.AddHandler(GameEvent.OnDestroyDeActive,OnDestroyDeActive);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnUIUpdate, OnUIUpdate);
        EventManager.RemoveHandler(GameEvent.OnInvincible,OnInvincible);
        EventManager.RemoveHandler(GameEvent.OnNonInvincible,OnNonInvincible);
        EventManager.RemoveHandler(GameEvent.OnUpdateLevelText,OnUpdateLevelText);
        EventManager.RemoveHandler(GameEvent.OnDestroyerActive,OnDestroyerActive);
        EventManager.RemoveHandler(GameEvent.OnDestroyDeActive,OnDestroyDeActive);
    }

    
    void OnUIUpdate()
    {
        score.SetText(gameData.score.ToString());
        score.transform.DOScale(new Vector3(1.5f,1.5f,1.5f),0.2f).OnComplete(()=>score.transform.DOScale(new Vector3(1,1f,1f),0.2f));
    }

    private void OnInvincible()
    {
        SetBuffText("INVINCIBLE BUFF ACTIVE");
    }

    private void OnNonInvincible()
    {
        SetBuffNon("INVINCIBLE BUFF DENACTIVE");
    }

    private void OnDestroyerActive()
    {
        SetBuffText("DESTROYER BUFF ACTIVE");
    }

    private void OnDestroyDeActive()
    {
        SetBuffNon("DESTROY BUFF DEACTIVE");
    }

    private void OnUpdateLevelText()
    {
        levelText.SetText("Level " + (gameData.LevelIndex+1).ToString());
    }


    private void SetBuffText(string text)
    {
        BuffText.gameObject.SetActive(true);
        BuffText.SetText(text);
        BuffText.gameObject.transform.DOScale(Vector2.one,1f).OnComplete(()=>BuffText.gameObject.SetActive(false));
    }

    private void SetBuffNon(string text)
    {
        BuffText.gameObject.SetActive(true);
        BuffText.SetText(text);
        BuffText.gameObject.transform.DOScale(Vector2.zero,1f).OnComplete(()=>BuffText.gameObject.SetActive(false));
    }

    
}
