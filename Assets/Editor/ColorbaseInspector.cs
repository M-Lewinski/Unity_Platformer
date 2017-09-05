using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[CustomEditor(typeof(ColorMechanic))]
public class ColorbaseInspector : Editor{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Change color"))
        {
            ColorMechanic colorMechanic = (ColorMechanic) target;
            colorMechanic.FindColor();
        }
        
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
