using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IncrementalManager : MonoBehaviour
{
    public GameData gameData;

    [SerializeField] private Button powerButton;

    private void Start() 
    {
        EventManager.Broadcast(GameEvent.OnUpdateRequirementMoney);
        CheckInteractable();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnNextLevel,CheckInteractable);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnNextLevel,CheckInteractable);
    }
    public void GainPower()
    {
        
        if(gameData.score>=gameData.RequirementCoin)
        {
            gameData.powerLevel++;
            EventManager.Broadcast(GameEvent.OnUpdateCircleLevels);
            EventManager.Broadcast(GameEvent.OnUpdatePlayerLevel);    
            gameData.score=gameData.score-gameData.RequirementCoin;
            EventManager.Broadcast(GameEvent.OnUIUpdate);
            EventManager.Broadcast(GameEvent.OnUpdateRequirementMoney);
            UpdateRequirementMoneyForPower();
            CheckInteractable();
            return;
        }
        
    }

    private void CheckInteractable()
    {
        if(gameData.score>=gameData.RequirementCoin)
        {
            powerButton.interactable=true;
        }
        else
        {
            powerButton.interactable=false;
        }
    }


    private void UpdateRequirementMoneyForPower()
    {
        gameData.RequirementCoin*=2;
    }
}
