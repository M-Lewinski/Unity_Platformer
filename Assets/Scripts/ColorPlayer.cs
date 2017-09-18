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

    private Colorbase previousColor = null;

    public bool ableToChange = true;
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
        if (availableColors.Count > 0) changeColor(availableColors[0]);
	    previousColor = currentColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            changeColor(previousColor);
        }
        
    }

    public void changeColor(Colorbase colorbase)
    {
        
        if (ableToChange && currentColor != colorbase)
        {
            previousColor = currentColor;
            currentColor = colorbase;
            sprite.color = currentColor.colorPlayer;
        }
    }

    public void AddAvailableColor(ColorId newColor)
    {
        if (availableColorsId.Contains(newColor)) return;
        availableColorsId.Add(newColor);
        foreach (var colorbase in allColors)
        {
            if (colorbase.colorId == newColor)
            {
                availableColors.Add(colorbase);
            }
        }
    }

    public Colorbase GetColorbase(ColorId colorId)
    {        
        return allColors.Find(x => x.colorId == colorId);
    }



}
