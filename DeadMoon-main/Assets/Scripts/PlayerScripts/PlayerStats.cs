using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public Image healthBar;
    public GameObject gameOverMenu;
    private void Start()
    {
        InitVariables();
        gameOverMenu.SetActive(false);

    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;  
        if(health <= 0 )
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
    }


}
