using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("Indexes")]
    public int levelIndex;
    
    public List<GameObject> levels;
    public List<GameObject> backgrounds;

    public GameData gameData;
    public PlayerData playerData;

    private void Start()
    {
        LoadLevel();
    }
    private void LoadLevel()
    {

        levelIndex = PlayerPrefs.GetInt("LevelNumber");
        if (levelIndex == levels.Count) levelIndex = 0;
        PlayerPrefs.SetInt("LevelNumber", levelIndex);
       

        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].SetActive(false);
        }
        levels[levelIndex].SetActive(true);
        EventManager.Broadcast(GameEvent.OnUpdateRequirements);
        EventManager.Broadcast(GameEvent.OnUpdateLevelText);
    }

    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("LevelNumber", levelIndex + 1);
        PlayerPrefs.SetInt("RealLevel", PlayerPrefs.GetInt("RealLevel", 0) + 1);
        EventManager.Broadcast(GameEvent.OnNextLevel);
        gameData.LevelIndex=PlayerPrefs.GetInt("RealLevel");
        playerData.canClick=false;
        //EventManager.Broadcast(GameEvent.OnStartGame);
        LoadLevel();
    }

    public void RestartLevel()
    {
        LoadLevel();
    }

    
    
}
