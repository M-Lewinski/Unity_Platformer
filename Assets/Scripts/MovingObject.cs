using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovingObject : MonoBehaviour {

	// Use this for initialization

    public List<Vector3> pointsList = new List<Vector3>();

//    private Vector3 firstPoint;
//    private Vector3 lastPoint;

    public float speed = 2f;

    public bool goingBack = false;

    public bool goingCircles = false;

    private int currentPoint = 0;

	void Start () {
	    if (goingBack)
	    {
	        currentPoint = pointsList.Count - 1;
	    }
	    if (pointsList.Count > 0) transform.position = pointsList[currentPoint];
	}
	
	// Update is called once per frame
	void Update () {
	    if (pointsList.Count > 0)
	    {
	        if (goingBack)
	        {
	            if (move(pointsList[currentPoint - 1]))
	            {
	                if (transform.position == pointsList[0])
	                {
	                    if (!goingCircles)
	                        goingBack = false;
	                    else currentPoint = pointsList.Count+1;
	                }
	                currentPoint -= 1;
	            }
	        }
	        else
	        {
	            if (move(pointsList[currentPoint + 1]))
	            {
	                if (transform.position == pointsList[pointsList.Count - 1])
	                {
                        if (!goingCircles)
                            goingBack = true;
                        else currentPoint = -2;
	                }
	                currentPoint += 1;
	            }
	        }
	    }
	}

    private bool move(Vector3 nextPoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, Time.deltaTime * speed);

        if (transform.position == nextPoint) return true;
        return false;
    }

}
