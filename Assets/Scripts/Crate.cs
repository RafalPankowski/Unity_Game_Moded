using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_DLL_RP;

public class Crate : Fighter
{
    public int pesosAmount = 2;
    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.pesos += pesosAmount;
        GameManager.instance.ShowText("+" + pesosAmount + " monet!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
    }
}
