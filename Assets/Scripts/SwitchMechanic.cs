using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SwitchMechanic : MonoBehaviour
{

    public Sprite OffSprite;

    public Sprite onSprite;

    public bool status = false;

    public delegate void LeverAction();

    public event LeverAction onAction;

    public event LeverAction offAction;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody2D;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        changeState(status);
    }

    private void changeState(bool status)
    {
        if (status) ActionTrigger(onSprite,onAction);
        else ActionTrigger(OffSprite,offAction);
       
    }

    private void ActionTrigger(Sprite sprite, LeverAction action)
    {
        spriteRenderer.sprite = sprite;
        if (action != null) action();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Character")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                status = !status;
                changeState(status);

            }
        }
    }
}
