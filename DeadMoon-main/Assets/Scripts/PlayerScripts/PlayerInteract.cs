using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] 
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    

   
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // create a ray at the center of the camera, shooting a ray forward
       Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // variable to store our collision information
        if(Physics.Raycast(ray, out hitInfo, distance,mask))
        {
            if(hitInfo.collider.GetComponent<Interactables>() != null)
            {

                Interactables interactables = hitInfo.collider.GetComponent<Interactables>();
                playerUI.UpdateText(interactables.promptMessage);
                if(inputManager.onFoot.Interact.triggered)
                {
                    interactables.BaseInteract();
                }
            }   
        }


         
    }

    


}
