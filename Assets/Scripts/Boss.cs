using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_DLL_RP;

public class Boss : Enemy
{
    public float[] weaponballSpeed = { 2.0f, -2.0f};
    public float distance = 0.35f;
    public Transform[] weaponballs;

    private void Update()
    {
        for (int i = 0; i < weaponballs.Length; i++)
        {
            weaponballs[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * weaponballSpeed[i]) * distance, Mathf.Sin(Time.time * weaponballSpeed[i]) * distance, 0);
        }
    }
}
