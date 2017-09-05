using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ColorPlayer : MonoBehaviour
{
    [SerializeField]
    public Colorbase currentColor;

    public SpriteRenderer sprite;

    public List<ColorId> availableColorsId;

    public List<Colorbase> availableColors;

    public List<Colorbase> allColors;
    // Use this for initialization
	void Start ()
	{
        sprite = GetComponent<SpriteRenderer>();
	    foreach (var colorId in availableColorsId)
	    {
	        foreach (var colorBase in allColors)
	        {
	            if (colorBase.colorId == colorId)
	            {
                    availableColors.Add(colorBase);
                    break;
                }
	        }
	    }
        changeColor(availableColors[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            changeColor(availableColors[0]);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            changeColor(availableColors[1]);
        }
    }

    public void changeColor(Colorbase colorbase)
    {
        if (currentColor != colorbase)
        {
            currentColor = colorbase;
            sprite.color = currentColor.colorPlayer;
        }
    }
}
