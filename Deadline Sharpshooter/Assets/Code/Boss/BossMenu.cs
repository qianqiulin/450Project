using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMenu : MonoBehaviour
{
    public static BossMenu instance;

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
        ShooterforBossScene .instance.isPaused =true;
    }
    public void Hide(){
        gameObject.SetActive(false);
        Time.timeScale=1;
        if(ShooterforBossScene .instance!=null){
            ShooterforBossScene .instance.isPaused=false;
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
        SceneManager.LoadScene("boss");
    }
}
