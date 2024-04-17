using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameManager : MonoBehaviour
{
    public static BossGameManager instance;
    public bool gameStarted = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        gameStarted = true;
    }
}
