using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;

    [SerializeField] private GameObject FailPanel;
    [SerializeField] private Ease ease;

    public float InitialDifficultyValue;

    public List<GameObject> LinesCol=new List<GameObject>(); 
    public bool canCollide=false;

    private void Awake() 
    {
        ClearData();
    }

    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
    }
    
    void OnGameOver()
    {
        FailPanel.SetActive(true);
        FailPanel.transform.DOScale(Vector3.one,1f).SetEase(ease);
        playerData.playerCanMove=false;
        gameData.isGameEnd=true;

    }

    public void LineOpenControl(int selected)
    {
        for (int i = 0; i < LinesCol.Count; i++)
        {
            LinesCol[i].SetActive(false);
        }

        LinesCol[selected].SetActive(true);
    }

    

    void OnIncreaseScore()
    {
        //gameData.score += 50;
        DOTween.To(GetScore,ChangeScore,gameData.score+gameData.increaseScore,1f).OnUpdate(UpdateUI);
    }

    private int GetScore()
    {
        return gameData.score;
    }

    private void ChangeScore(int value)
    {
        gameData.score=value;
    }

    private void UpdateUI()
    {
        EventManager.Broadcast(GameEvent.OnUIUpdate);
    }

    

    
    void ClearData()
    {

    }

    
}
