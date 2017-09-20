using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    public string mainMenu;

    public void MainMenu()
    {
        Application.LoadLevel(mainMenu);
    }
}
