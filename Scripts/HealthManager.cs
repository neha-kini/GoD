using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHealth;

    public GameObject deathEffect;

    public float invincibleLength = 2f;
    private float invincCounter;
    public SpriteRenderer sr;

    public int shieldPower;
    public int shieldMaxPower = 2;
    public GameObject theShield;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        UIManager.instance.healthBar.maxValue = maxHealth;
        UIManager.instance.healthBar.value = currentHealth;

        UIManager.instance.shieldBar.maxValue = shieldMaxPower;
        UIManager.instance.shieldBar.value = shieldPower;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter >= 0)
        {
            invincCounter -= Time.deltaTime;

            if(invincCounter <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
    }

    public void HurtPlayer()
    {
        if(invincCounter <= 0)
        {
            if(theShield.activeInHierarchy)
            {
                shieldPower--;
                if(shieldPower <= 0)
                {
                    theShield.SetActive(false);
                }
                UIManager.instance.shieldBar.value = shieldPower;
            }
            else
            {
            currentHealth--;
            UIManager.instance.healthBar.value = currentHealth;

                if(currentHealth <= 0)
                {
                    Instantiate(deathEffect, transform.position, transform.rotation);
                    gameObject.SetActive(false);

                    GameManager.instance.KillPlayer();

                    WaveManager.instance.canSpawnWaves = false;
                }
                
                PlayerController.instance.doubleShotActive = false;
            }
        }
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        currentHealth = maxHealth;
        UIManager.instance.healthBar.value = currentHealth;

        invincCounter = invincibleLength;

        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, .5f);
    }


    public void ActivateShield()
    {
        theShield.SetActive(true);
        shieldPower = shieldMaxPower;

        UIManager.instance.shieldBar.value = shieldPower;
    }
}
