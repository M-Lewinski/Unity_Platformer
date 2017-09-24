using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhysics : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.name == "Character")
        {
            if(collision.collider.transform.parent== null)
             collision.collider.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.name == "Character")
        {
            if (collision.collider.transform.parent != null)
                collision.collider.transform.parent = null;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
