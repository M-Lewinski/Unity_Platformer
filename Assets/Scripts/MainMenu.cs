using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string startLevel;
    public string optionsScene;



    public void NewGame()
    {
        Application.LoadLevel(startLevel);
    }

    public void GameOptions()
    {
        Debug.Log("GameOptions selected");
        //Here will be game options
        //Application.LoadLevel(optionsScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
