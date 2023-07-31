using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CircleProperties : MonoBehaviour
{
    public TextMeshPro NumberText;

    public int Number;

    private int firstNumber;

    public List<Sprite> sprites=new List<Sprite>();
    public List<Color> colors=new List<Color>();
    public Color selectedColor;

    private SpriteRenderer spriteRenderer;

    public GameData gameData;
    private void Start() 
    {
        OnUpdateCircleLevels();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUpdateCircleLevels,OnUpdateCircleLevels);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUpdateCircleLevels,OnUpdateCircleLevels);
    }

    private void OnUpdateCircleLevels()
    {
        
        //Number+=gameData.powerLevel;
        selectedColor=colors[Number+gameData.powerLevel];
        spriteRenderer=GetComponent<SpriteRenderer>();
        NumberText.SetText((Number+gameData.powerLevel).ToString());
        spriteRenderer.sprite=sprites[Number+gameData.powerLevel];
    }
}
