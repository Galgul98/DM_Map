using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    
   // public GameObject settingsCanvas;
    public bool settingsButton;
    
   
   
    void Start()
    {
    //   settingsCanvas.SetActive(false);
        settingsButton = false;

        
    }

   

    public void PlayButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void SettingsButton()
    {
        if(settingsButton == true)
        {
           // settingsCanvas.SetActive(true);
            print("settingspressed");
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("quiting");
    }
    public void PlayHolderOff()
    {
     //   playHolder.SetActive(false);
    }
    public void PlayHolderOn()
    {
       // playHolder.SetActive(true);
    }
    public void StoreActive()
    {
     //   Store.SetActive(true);
    }
    public void Storeoff()
    {
      //  Store.SetActive(false);
    }
}
