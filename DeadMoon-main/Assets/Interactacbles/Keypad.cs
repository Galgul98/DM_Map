using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactables
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    [SerializeField] private AudioSource doorOpenAudio = null;
    [SerializeField] private float openDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact() //this function is where we will design our interaction using code.
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen",doorOpen);
        doorOpenAudio.PlayDelayed(openDelay);
    }
}
