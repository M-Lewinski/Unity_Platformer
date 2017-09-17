using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColorMechanic : MonoBehaviour
{
    [SerializeField] public ColorId colorId;

    private Collider2D collider2D;

    private ColorPlayer colorPlayer;

    private Color fadeColor;

    private Color returnColor;

    private int normalLayer;
    private int fadedLayer = 16;

    private Colorbase playerPrevoiusColor;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        colorPlayer = FindObjectOfType<ColorPlayer>();
        normalLayer = gameObject.layer;
        FindColor();
        CheckPlayerColor();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPlayerColor();
    }

    private void CheckPlayerColor()
    {
        Colorbase currentColor = colorPlayer.currentColor;
        bool playerChanged;
        if ((playerChanged = currentColor != playerPrevoiusColor)) playerPrevoiusColor = currentColor;
        if (colorId == currentColor.colorId)
        {
            ChangeState(true,fadeColor,playerChanged);
        }
        else
        {
            ChangeState(false,returnColor,playerChanged);
        }
    }

    private void ChangeState(bool noCollision,Color changeToColor, bool playerChanged)
    {
        if (playerChanged)
        {
            collider2D.isTrigger = noCollision;
            if (noCollision) gameObject.layer = fadedLayer;
            else gameObject.layer = normalLayer;
            Fadeing(changeToColor);
        }
    }

    public void FindColor()
    {
        foreach (var colorbase in FindObjectOfType<ColorPlayer>().allColors)
        {
            if (colorbase.colorId == colorId)
            {
                gameObject.ChangeRendererColor(colorbase.colorBlock);
                returnColor = colorbase.colorBlock;
                fadeColor = new Color(colorbase.colorBlock.r, colorbase.colorBlock.g, colorbase.colorBlock.b, colorbase.colorBlock.a * 0.5f);
                break;
            }
        }
    }

    public void Fadeing(Color colorChange)
    {
        if (collider2D.enabled == false)
        {
            return;
        }
        gameObject.ChangeRendererColor(colorChange);
    }

  

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Character")
        {
            colorPlayer.ableToChange = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Character")
        {
            colorPlayer.ableToChange = true;
        }
    }
}