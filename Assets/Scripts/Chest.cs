using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_DLL_RP;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 5;
    protected override void OnCollide(Collider2D coll)
    {
        if (!collected && coll.name == "Player")
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.pesos += pesosAmount;
            GameManager.instance.ShowText("+" + pesosAmount + " monet!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
        }
    }
}
