using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    Animator anim;

    private bool playerInZone;
    public string levelToLoad;

	// Use this for initialization
	void Start () {
        playerInZone = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            Application.LoadLevel(levelToLoad);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Character")
        {
            playerInZone = true;
            anim.SetBool("IsClosed", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            playerInZone = false;
            anim.SetBool("IsClosed", true);
        }
    }
}
