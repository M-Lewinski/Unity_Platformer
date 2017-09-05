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

    private Colorbase playerPrevoiusColor;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        colorPlayer = FindObjectOfType<ColorPlayer>();
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
            ChangeState(false,fadeColor,playerChanged);
        }
        else
        {
            ChangeState(true,returnColor,playerChanged);
        }
    }

    private void ChangeState(bool collision,Color changeToColor, bool playerChanged)
    {
        if (playerChanged)
        {
            collider2D.enabled = collision;
            Fadeing(changeToColor);
        }
    }

    public void FindColor()
    {
        foreach (var colorbase in FindObjectOfType<ColorPlayer>().allColors)
        {
            if (colorbase.colorId == colorId)
            {
                SpriteRenderer SpriteRenderer = GetComponent<SpriteRenderer>();
                if (SpriteRenderer != null)
                {
                    SpriteRenderer.color = colorbase.colorBlock;
                }
                else
                {
                    GetComponent<Tilemap>().color = colorbase.colorBlock;
                }
                returnColor = colorbase.colorBlock;
                fadeColor = new Color(colorbase.colorBlock.r, colorbase.colorBlock.g, colorbase.colorBlock.b, colorbase.colorBlock.a * 0.5f);
                break;
            }
        }
    }

    public void Fadeing(Color colorChange)
    {
        SpriteRenderer SpriteRenderer = GetComponent<SpriteRenderer>();
        if (SpriteRenderer != null)
        {
            SpriteRenderer.color = colorChange;
        }
        else
        {
            Tilemap tilemap = GetComponent<Tilemap>();
            tilemap.color = colorChange;
        }
    }
}