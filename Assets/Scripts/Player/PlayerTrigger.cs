using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerTrigger : MonoBehaviour
{
    public int PlayerNumber;

    public TextMeshPro PlayerNumberText;

    private void Start() 
    {
        //UpdatePlayerNumberText();
    }
    internal void UpdatePlayerNumberText()
    {
        PlayerNumberText.SetText(PlayerNumber.ToString());
        EventManager.Broadcast(GameEvent.OnUpdateWorld);
    }
}
