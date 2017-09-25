using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointEvent : MonoBehaviour
{

    public List<GameObject> nativeGameObjects = new List<GameObject>();

    public List<GameObject> runningGameObjects= new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        foreach (var gObject in nativeGameObjects)
        {
            gObject.SetActive(false);
        }
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if(levelManager.currentCheckpoint == gameObject) CreateGameObjectClones();
    }

    private void CreateGameObjectClones()
    {
        foreach (var gObject in nativeGameObjects)
        {
            GameObject newGameObject = Object.Instantiate(gObject);
            newGameObject.SetActive(true);
            runningGameObjects.Add(newGameObject);
        }
    }

    public void RestartObjects()
    {
        ClearRunningObjects();
        CreateGameObjectClones();
    }

    public void ClearRunningObjects()
    {
        foreach (var gObject in runningGameObjects)
        {
            Destroy(gObject);
        }
        runningGameObjects.Clear();
    }

    // Update is called once per frame
	void Update () {
		
	}
}
