using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	// Use this for initialization

    public Vector3 beginPosition;
    public Vector3 destinationPosition;

    public float speed = 0.1f;

    public bool goingBack = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (goingBack)
	    {
	        goingBack = !move(destinationPosition, beginPosition);
	    }
	    else
	    {
	        goingBack = move(beginPosition, destinationPosition);
	    }
	}

    private bool move(Vector3 begin, Vector3 destination)
    {
        Vector3 moveVector = destination - begin;
        moveVector = moveVector.normalized * speed;
        Vector3 distance = destination - transform.position;
        if (distance.magnitude < moveVector.magnitude)
        {
            transform.position += distance;
        }
        else
        {
            transform.position += moveVector;
        }

        if (transform.position == destination) return true;
        return false;
    }
    
}
