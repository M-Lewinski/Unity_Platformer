using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{

    public bool toggleOff = false;
    public GameObject switcher;
    private SwitchMechanic switchMechanic;
    private Collider2D collider2D;


    private Color onColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private Color offColor = new Color(0.4f,0.4f,0.4f,0.3f);

    void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        switchMechanic = switcher.GetComponent<SwitchMechanic>();
    }
    void OnEnable()
    {
        if (!toggleOff)
        {
            switchMechanic.onAction += OnToggleSwitch;
            switchMechanic.offAction += OffToggleSwitch;
        }
        else
        {
            switchMechanic.onAction += OffToggleSwitch;
            switchMechanic.offAction += OnToggleSwitch;
        }
    }

    void OnDisable()
    {
        if (!toggleOff)
        {
            switchMechanic.onAction -= OnToggleSwitch;
            switchMechanic.offAction -= OffToggleSwitch;
        }
        else
        {
            switchMechanic.onAction -= OffToggleSwitch;
            switchMechanic.offAction -= OnToggleSwitch;
        }

    }

    public void OnToggleSwitch()
    {
        collider2D.isTrigger = false;
        gameObject.ChangeRendererColor(onColor);
    }

    public void OffToggleSwitch()
    {
        collider2D.isTrigger = true;

        gameObject.ChangeRendererColor(offColor);
    }

    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

}
