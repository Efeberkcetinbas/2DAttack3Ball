using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CircleProperties : MonoBehaviour
{
    public TextMeshPro NumberText;

    public int Number;

    public List<Sprite> sprites=new List<Sprite>();
    public List<Color> colors=new List<Color>();
    public Color selectedColor;

    private SpriteRenderer spriteRenderer;

    public GameData gameData;
    private void Start() 
    {
        OnUpdateCircleLevels();
    }

    private void OnUpdateCircleLevels()
    {
        Number+=gameData.powerLevel;
        selectedColor=colors[Number];
        spriteRenderer=GetComponent<SpriteRenderer>();
        NumberText.SetText(Number.ToString());
        spriteRenderer.sprite=sprites[Number];
    }
}
