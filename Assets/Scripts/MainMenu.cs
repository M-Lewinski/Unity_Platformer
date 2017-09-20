using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string startLevel;

    public string optionsScene;

    public string levelSelect;

    public string creditsScene;

    public void NewGame()
    {
        Application.LoadLevel(startLevel);
    }

    public void LevelSelect()
    {
        Application.LoadLevel(levelSelect);
    }

    public void GameOptions()
    {
        Application.LoadLevel(optionsScene);
    }

    public void ShowCredits()
    {
        Application.LoadLevel(creditsScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
