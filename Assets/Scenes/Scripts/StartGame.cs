 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour // CS for start button
{ 
    public GameObject SettingsMenu;
    public GameObject ScoreCounterObj;

    public void StartGameButton()
    {
        ScoreCounterObj.GetComponent<ScoreCounter>().Score_player = 0;
        SettingsMenu.SetActive(false);
        Debug.Log("Game started");

    }

    void Update()
    {
        MenuSettingsActive();
    }

    void MenuSettingsActive()
    {
       
        if (Input.GetKey(KeyCode.M))
        {
            SettingsMenu.SetActive(true);
            ScoreCounterObj.GetComponent<ScoreCounter>().Score_player = 0;
        }
    }
}
