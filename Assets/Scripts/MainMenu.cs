using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string startLevel;

    public string optionsScene;

    public string levelSelect;

    public string creditsScene;

    private GameObject previousMenu;

    public GameObject Options;

    void Start()
    {
        previousMenu = FindObjectOfType<MainMenu>().gameObject;
        previousMenu.SetActive(true);
//        Options = FindObjectOfType<Options>().gameObject;
    }


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
        ChangeSubMenu(Options);
    }

    public void ShowCredits()
    {
        Application.LoadLevel(creditsScene);
    }

    public void ChangeSubMenu(GameObject submenu)
    {
        previousMenu.SetActive(false);
        submenu.SetActive(true);
        previousMenu = submenu;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
