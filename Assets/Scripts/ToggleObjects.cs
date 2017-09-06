using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{

    public bool toggle = false;
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
        switchMechanic.onAction += OnToggleSwitch;
        switchMechanic.offAction += OffToggleSwitch;
    }

    void OnDisable()
    {
        switchMechanic.onAction -= OnToggleSwitch;
        switchMechanic.offAction -= OffToggleSwitch;

    }

    public void OnToggleSwitch()
    {
        collider2D.enabled = true;
        gameObject.ChangeRendererColor(onColor);
    }

    public void OffToggleSwitch()
    {
        collider2D.enabled = false;

        gameObject.ChangeRendererColor(offColor);
    }

    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

}
