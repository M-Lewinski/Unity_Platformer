using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {


    public GameObject previousMenu;

    public MainMenu mainMenu;

    void Start()
    {
    }

    public void MainMenu()
    {
        mainMenu.ChangeSubMenu(previousMenu);
    }
}
