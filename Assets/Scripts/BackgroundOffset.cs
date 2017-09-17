using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour {

    public float speed = 0.5f;

    private Renderer backgroundMaterial;
    private Transform playerTransform;
    private Vector3 BeginningPosition;

	// Use this for initialization
	void Start () {
         backgroundMaterial = GetComponent<Renderer>();
        playerTransform = FindObjectOfType<CharacterControllerScript>().gameObject.transform;
        BeginningPosition = playerTransform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = speed * (playerTransform.position - BeginningPosition);

        backgroundMaterial.material.mainTextureOffset = new Vector2(offset.x,0.0f);
	}
}
