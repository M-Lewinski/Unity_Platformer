using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHue : MonoBehaviour
{

    private ColorPlayer colorPlayer;
    private Light light;

	// Use this for initialization
	void Start () {
		colorPlayer = FindObjectOfType<ColorPlayer>();
        light = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    light.color = colorPlayer.currentColor.colorWheel;
	}
}
