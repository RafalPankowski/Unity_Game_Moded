using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game_DLL_RP;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public Text levelText, hitpointText, pesosText, upgradeCostText, xpText;

    //Logic
    public Image weaponSprite;
    public RectTransform xpBar;

    //Weapon Upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    //Upgrade the characcter Information
    public void UpdateMenu()
    {
        //Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];

        if(GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
        upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        //Meta
        hitpointText.text = GameManager.instance.player.hitpoint.ToString() + " / " + GameManager.instance.player.maxHitpoint;
        pesosText.text = GameManager.instance.pesos.ToString();
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();

        //xp Bar
        int currLevel = GameManager.instance.GetCurrentLevel();
        if(currLevel == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + " suma zebranych xp"; //Display total xp
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currLevel - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currLevel);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
        }
    }


}
