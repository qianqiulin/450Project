using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public GameObject mainMenu;
    public GameObject controls;
    void Awake(){
        instance=this;
        Hide();
    }

    public void Show(){
        ShowMainMenu();
        gameObject.SetActive(true);
        Time.timeScale=0;
        ShooterController.instance.isPaused =true;
    }
    public void Hide(){
        gameObject.SetActive(false);
        Time.timeScale=1;
        if(ShooterController.instance!=null){
            ShooterController.instance.isPaused=false;
        }
    }

    void SwitchMenu(GameObject someMenu){
        mainMenu.SetActive(false);
        controls.SetActive(false);
        someMenu.SetActive(true);
    }
    public void ShowMainMenu(){
        SwitchMenu(mainMenu);
    }
    public void ShowControlsMenu(){
        SwitchMenu(controls);
    }
    public void playAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
