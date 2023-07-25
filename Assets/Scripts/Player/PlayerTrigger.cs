using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerTrigger : MonoBehaviour
{
    public int PlayerNumber;

    public TextMeshPro PlayerNumberText;

    internal void UpdatePlayerNumberText()
    {
        PlayerNumberText.SetText(PlayerNumber.ToString());
    }
}
