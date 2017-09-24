using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{

    public float speed = 0.1f;
    Renderer backgroundMaterial;

	// Use this for initialization
	void Start () {
	    backgroundMaterial = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    Vector2 offset = Time.time * speed * Vector2.right;
	    backgroundMaterial.material.mainTextureOffset = offset;
	}
}
