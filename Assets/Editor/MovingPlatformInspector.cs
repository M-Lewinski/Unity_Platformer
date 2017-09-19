using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovingObject))]
public class MovingPlatformInspector : Editor {

	    public override void OnInspectorGUI()
	    {
	        base.OnInspectorGUI();
	        MovingObject movingObject = (MovingObject) target;
	        if (GUILayout.Button("Register new point"))
	        {
                if(movingObject.pointsList == null) movingObject.pointsList = new List<Vector3>();
	            movingObject.pointsList.Add(movingObject.transform.position);
	        }
	        else if (GUILayout.Button("Move to beginning"))
	        {
                if (movingObject.pointsList.Count > 0)
	             movingObject.transform.position = movingObject.pointsList[0];
            }
	        else if (GUILayout.Button("Move to destination"))
	        {
                if (movingObject.pointsList.Count > 0)
	             movingObject.transform.position = movingObject.pointsList[movingObject.pointsList.Count-1];
	        }

    }
}
	