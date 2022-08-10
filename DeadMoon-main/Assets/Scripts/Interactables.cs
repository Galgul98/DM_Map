using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    // message displayed to player when looking at an interaction or collectible
    public string promptMessage;

    //this function will be called from our player
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
       // we wont use any code in this function
       // this is a template function to overridden by our subclasses
    }
}
