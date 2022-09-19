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
    protected override void Interact()
    {
        if (CompareTag("Player"))
        {
            gun.maxAmmo += ammoPkgSize;
           
        }
        Destroy(gameObject);
    }

   
    //private void OnTriggerEnter(Collider other)
    //{
        //if (other.CompareTag("Player"))
        //{
       //     gun.maxAmmo += ammoPkgSize;
     //   }
   // }
}
