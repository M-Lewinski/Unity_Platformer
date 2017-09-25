using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private CharacterControllerScript player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<CharacterControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        if (currentCheckpoint != null)
        {
            CheckPointEvent checkPointEvent = currentCheckpoint.GetComponent<CheckPointEvent>();
            if (checkPointEvent != null)
            {
                checkPointEvent.RestartObjects();
            }
            player.transform.position = currentCheckpoint.transform.position;
            player.transform.parent = null;
        }
    }
}
