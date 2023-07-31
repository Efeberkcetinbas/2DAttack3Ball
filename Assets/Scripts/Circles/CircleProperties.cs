using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CircleProperties : MonoBehaviour
{
    public TextMeshPro NumberText;

    public int Number;

    public List<Sprite> sprites=new List<Sprite>();

    private SpriteRenderer spriteRenderer;

    public GameData gameData;
    private void Start() 
    {
        //Oyun Basi merge mekanigi olacaksa ayri gelistirme icin seviyemiz kadar arttirabilirz
        Number+=gameData.powerLevel;
        spriteRenderer=GetComponent<SpriteRenderer>();
        NumberText.SetText(Number.ToString());
        spriteRenderer.sprite=sprites[Number];
        
    }
}
