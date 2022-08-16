using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    private bool escButton;
    private bool pauseButton;
    private bool inventoryButton;
    public GameObject PauseCanvas;
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnPause();
        OnInventory();
        OnEsc();
    }
    public void OnPauseButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseButton = true;


        }
        if (context.canceled)
        {
            pauseButton = false;
        }




    }
    public void OnPause()
    {
        if (pauseButton)
        {
            PauseCanvas.SetActive(true);

            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;

           
        }

    }
    public void OnInventoryButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inventoryButton = true;


        }
        if (context.canceled)
        {
            inventoryButton = false;
        }




    }
    public void OnInventory()
    {
        if (inventoryButton)
        {
            inventory.SetActive(true);

            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;

            Debug.Log("i");
        }

    }
    public void OnEscButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            escButton = true;


        }
        if (context.canceled)
        {
            escButton = false;
        }




    }
    public void OnEsc()
    {
        if (escButton)
        {
            inventory.SetActive(false);
            PauseCanvas.SetActive(false);


            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;

            Debug.Log("esc");
        }

    }



    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
