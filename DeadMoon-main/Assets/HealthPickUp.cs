using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private int healthBuffNumber;
    // Start is called before the first frame update
    void Start()
    {
     //   playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.health += healthBuffNumber;
            Destroy(gameObject);
        }
    }
}
