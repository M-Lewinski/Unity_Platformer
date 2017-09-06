using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMechanic : MonoBehaviour
{
    public float force = 400f;

    private float rotation;

    private CharacterControllerScript character;

    private Animator animator;

    private bool launch = false;
	// Use this for initialization
	void Start ()
	{
	    rotation = gameObject.transform.rotation.z;
	    animator = GetComponent<Animator>();
	    character = FindObjectOfType<CharacterControllerScript>();

	}

    void FixedUpdate()
    {
        animator.SetBool("launch",launch);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Character")
        {
            launch = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.name == "Character" && launch)
        {
            character.rigidbody2D.velocity = new Vector3(0.0f,0.0f,0.0f);
            character.ForceUp(new Vector2(0, force));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.name == "Character")
        {
            launch = false;
        }
    }
}
