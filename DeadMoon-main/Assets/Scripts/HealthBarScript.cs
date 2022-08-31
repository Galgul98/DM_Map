using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthbar;
    public float currentHealth ;
    private float maxHealth ;
    
 
    void Start()
    {
        healthbar = GetComponent<Image>();
      
       //    maxHealth = playerController.PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = 
        healthbar.fillAmount = currentHealth / maxHealth; 
    }
}
