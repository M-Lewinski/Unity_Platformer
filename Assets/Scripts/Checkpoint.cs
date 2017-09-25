using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;

    private CheckPointEvent checkPointEvent;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        checkPointEvent = GetComponent<CheckPointEvent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Character")
        {
            if (checkPointEvent != null && levelManager.currentCheckpoint != gameObject)
            {
                CheckPointEvent previousCheckPointEvent = levelManager.currentCheckpoint.GetComponent<CheckPointEvent>();
                if (previousCheckPointEvent != null)
                {
                    //                    previousCheckPointEvent.ClearRunningObjects();
                    checkPointEvent.runningGameObjects.AddRange(previousCheckPointEvent.runningGameObjects);
                }
//                checkPointEvent.RestartObjects();
            }
            levelManager.currentCheckpoint = gameObject;
            Debug.Log("Activated Checkpoint " + transform.position);
        }
    }
}
