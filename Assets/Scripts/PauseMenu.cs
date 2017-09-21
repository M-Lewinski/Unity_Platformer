using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string mainMenu;

    public string levelSelect;

    public string optionsScene;

    public bool isPaused;

    public GameObject pauseMenuCanvas;

    public LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update () {
		if(isPaused)
        {
           Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
		{
		    Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
	}

    public void Resume()
    {
//        Cursor.lockState = CursorLockMode.Confined;
        isPaused = false;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GoToLastCheckpoint()
    {
        levelManager.RespawnPlayer();
        Resume();
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Application.LoadLevel(levelSelect);
    }

    public void Options()
    {
        Debug.Log("Options selected");
        //Application.LoadLevel(optionsScene);
    }

    public void Quit()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenu);
    }
}
