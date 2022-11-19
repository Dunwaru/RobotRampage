using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{

    [SerializeField] Sprite redReticle;
    [SerializeField] Sprite yellowReticle;
    [SerializeField] Sprite blueReticle;
    [SerializeField] Image reticle;

    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text armorText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text pickupText;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private TMP_Text enemyText;
    [SerializeField] private TMP_Text waveClearText;
    [SerializeField] private TMP_Text newWaveText;
    [SerializeField] Player player;
    public void UpdateReticle()
    {
        switch (GunEquiper.activeWeaponType)
        {
            case Constants.Pistol:
                reticle.sprite = redReticle;
                break;
            case Constants.Shotgun:
                reticle.sprite = yellowReticle;
                break;
            case Constants.AssaultRifle:
                reticle.sprite = blueReticle;
                break;
            default:
                return;
        }
    }
    
    void Start()
    {
        SetArmorText(player.armor);
        SetHealthText(player.health);
    }

    public void SetArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
    }
    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }
    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }
    public void SetWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }
    public void SetEnemyText(int enemies)
    {
        enemyText.text = "Enemies: " + enemies;
    }
   
    public void ShowWaveClearBonus()
    {
        waveClearText.GetComponent<TMP_Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }
    
    IEnumerator hideWaveClearBonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<TMP_Text>().enabled = false;
    }
    
    public void SetPickUpText(string text)
    {
        pickupText.GetComponent<TMP_Text>().enabled = true;
        pickupText.text = text;
      
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }
    
    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<TMP_Text>().enabled = false;
    }
    
    public void ShowNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<TMP_Text>().enabled = true;
    }
   
    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<TMP_Text>().enabled = false;
    }
}
