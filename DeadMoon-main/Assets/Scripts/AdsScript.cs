using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AdsScript : MonoBehaviour
{
    public GameObject gun;
    private PlayerInput playerInput = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(playerInput.OnFoot.Aim.IsPressed())
        {
            gun.GetComponent<Animator>().Play("ADS");
        }
        else
        {
            gun.GetComponent<Animator>().Play("New State");
        }

       
       
       

        
           
        
    }
}
