using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public Image healthBar;
    private void Start()
    {
        InitVariables();

    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);    
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
    }


}
