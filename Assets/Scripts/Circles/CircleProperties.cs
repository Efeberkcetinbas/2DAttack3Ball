using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CircleProperties : MonoBehaviour
{
    public TextMeshPro NumberText;

    public int Number;

    private void Start() 
    {
        NumberText.SetText(Number.ToString());
        
    }
}
