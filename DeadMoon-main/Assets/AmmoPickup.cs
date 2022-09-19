using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Interactables
{
    [SerializeField] private Gun gun;
    [SerializeField] int ammoPkgSize;
    // Start is called before the first frame update
    void Start()
    {
       // gun = GetComponent<Gun>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gun.maxAmmo += ammoPkgSize;
        }
    }
}
