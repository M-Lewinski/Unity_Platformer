using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ColorPickup : MonoBehaviour
{

    public ColorId color;

    private ColorPlayer colorPlayer;

	// Use this for initialization
	void Start () {
		colorPlayer = FindObjectOfType<ColorPlayer>();
	    GetComponent<SpriteRenderer>().color = colorPlayer.GetColorbase(color).colorWheel;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Character")
        {
            Debug.Log("DIsappear");
            colorPlayer.AddAvailableColor(color);
            this.gameObject.SetActive(false);
        }
    }

}
