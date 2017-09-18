using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovingPlatform))]
public class MovingPlatformInspector : Editor {

	    public override void OnInspectorGUI()
	    {
	        base.OnInspectorGUI();
	        MovingPlatform movingPlatform = (MovingPlatform) target;
	        if (GUILayout.Button("Register begin position"))
	        {
	            movingPlatform.beginPosition = movingPlatform.transform.position;
	        }
	        else if (GUILayout.Button("Register destination position"))
	        {
	            movingPlatform.destinationPosition = movingPlatform.transform.position;
	        }
            else if (GUILayout.Button("Move to beginning"))
	        {
	            movingPlatform.transform.position = movingPlatform.beginPosition;
            }
	        else if (GUILayout.Button("Move to destination"))
	        {
	            movingPlatform.transform.position = movingPlatform.destinationPosition;
	        }

    }
}
	