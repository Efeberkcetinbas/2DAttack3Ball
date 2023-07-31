using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IncrementalManager : MonoBehaviour
{
    public GameData gameData;

    [SerializeField] private Button powerButton;
    
    [SerializeField] private Button earningButton;

    private void Start() 
    {
        EventManager.Broadcast(GameEvent.OnUpdateRequirementMoney);
        EventManager.Broadcast(GameEvent.OnUpdateEarningMoney);
        CheckInteractableEarning();
        CheckInteractablePower();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnNextLevel,CheckInteractablePower);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnNextLevel,CheckInteractablePower);
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
            UpdateRequirementMoneyForPower();
            CheckInteractablePower();
            CheckInteractableEarning();
            return;
        }
    }

    public void EarningMoney()
    {
        if(gameData.score>=gameData.RequirementEarningCoin)
        {
            gameData.increaseScore++;
            gameData.score=gameData.score-gameData.RequirementEarningCoin;
            EventManager.Broadcast(GameEvent.OnUIUpdate);
            UpdateRequirementFromEarning();
            CheckInteractableEarning();
            CheckInteractablePower();
        }
    }

    private void CheckInteractablePower()
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
    private void CheckInteractableEarning()
    {
        if(gameData.score>=gameData.RequirementEarningCoin)
        {
            earningButton.interactable=true;
        }
        else
        {
            earningButton.interactable=false;
        }
    }


    private void UpdateRequirementMoneyForPower()
    {
        gameData.RequirementCoin*=2;
        EventManager.Broadcast(GameEvent.OnUpdateRequirementMoney);
    }

    private void UpdateRequirementFromEarning()
    {
        gameData.RequirementEarningCoin*=2;
        EventManager.Broadcast(GameEvent.OnUpdateEarningMoney);
    }
}
