using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickScript : MonoBehaviour
{
    public int points;
    public int hitPoints;
    public Sprite[] spriteStates;
    public SpriteRenderer spriteRenderer;
    
    public void BreakBrick()
    {
        hitPoints--;
        
        this.spriteRenderer.sprite = this.spriteStates[this.hitPoints - 1];
        GetComponent<SpriteRenderer>().sprite = this.spriteRenderer.sprite;
        
    } 
    
}
