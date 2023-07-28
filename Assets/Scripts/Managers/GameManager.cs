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

    [Header("Open/Close Game End")]
    [SerializeField] private GameObject[] openClose;
    [SerializeField] private GameObject touchToStartText;

    [Header("Game Ending")]
    [SerializeField] private GameObject successPanel;
    [SerializeField] private GameObject failPanel;



    private void Awake() 
    {
        ClearData();
    }

    private void Start() 
    {
        OnNextLevel();
        UpdateUI();
    }
    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnDead,OnDead);
        EventManager.AddHandler(GameEvent.OnSuccess,OnSuccess);
        EventManager.AddHandler(GameEvent.OnUIGameOver,OnUIGameOver);
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.AddHandler(GameEvent.OnIncreaseScore,OnIncreaseScore);
        EventManager.AddHandler(GameEvent.OnUpdateRequirements,OnUpdateRequirements);
        EventManager.AddHandler(GameEvent.OnStartGame,OnStartGame);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnDead,OnDead);
        EventManager.RemoveHandler(GameEvent.OnSuccess,OnSuccess);
        EventManager.RemoveHandler(GameEvent.OnUIGameOver,OnUIGameOver);
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.RemoveHandler(GameEvent.OnIncreaseScore,OnIncreaseScore);
        EventManager.RemoveHandler(GameEvent.OnUpdateRequirements,OnUpdateRequirements);
        EventManager.RemoveHandler(GameEvent.OnStartGame,OnStartGame);
    }
    
    void OnGameOver()
    {
        FailPanel.SetActive(true);
        FailPanel.transform.DOScale(Vector3.one,1f).SetEase(ease);
        playerData.playerCanMove=false;
        gameData.isGameEnd=true;

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

    private void OpenClose(GameObject[] gameObjects,bool canOpen)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(canOpen);
        }
    }
    
    private void OnSuccess()
    {
        successPanel.SetActive(true);
    }

    private void OnStartGame()
    {
        touchToStartText.SetActive(false);
    }

    private void OnNextLevel()
    {
        //gameData.isGameEnd=false;
        OpenClose(openClose,false);
        touchToStartText.SetActive(true);
    }

    private void OnUpdateRequirements()
    {
        gameData.RequirementMergeNumber=FindObjectOfType<LevelRequirementMerge>().LevelRequirementNumber;
    }

    private void OnUIGameOver()
    {
        failPanel.SetActive(true);
    }
    
    void ClearData()
    {
        gameData.isGameEnd=true;
    }

    private void OnDead()
    {
        gameData.isGameEnd=true;
    }

    
}
