using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_DLL_RP;

public class FountainHealth : Collectable
{
    private int hitPointHeal = 5;
    protected override void OnCollide(Collider2D coll)
    {
        if (!collected && coll.name == "Player")
        {
                Healing();
        }
        
    }

    private void Healing()
    {
        if (GameManager.instance.player.hitpoint == GameManager.instance.player.maxHitpoint)
            return;
        while (GameManager.instance.player.hitpoint + hitPointHeal > GameManager.instance.player.maxHitpoint)
        {
            hitPointHeal--;
        }
        collected = true;
        GameManager.instance.player.hitpoint += hitPointHeal;
        GameManager.instance.ShowText("+" + hitPointHeal + " hp!", 25, Color.green, transform.position, Vector3.up * 50, 3.0f);
        //Debug.Log("+ " + hitPointHeal + " hp");
        GameManager.instance.OnHitpointChange();
    }
}
