using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

    /// Variables related with moving horizontaly
    public float groundSpeedX = 10f;
    public float flyingSpeedX = 0.9f;
    bool facingRight = true;

    /// Variables related with jumping and falling
    public bool grounded = true; // Check if character is on the ground
    public Transform groundCheck; // Where is ground compare to character position
    private float groundRadius = 0.2f; // Circle radius
    public LayerMask whatIsGround; // On which objects our character can land on
    public float jumpForce = 4f;

    Animator anim;
    public Rigidbody2D rigidbody2D;

	void Start () {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            ForceUp(new Vector2(0, jumpForce));
        }

    }

    public void ForceUp(Vector2 force)
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,0.0f);
        rigidbody2D.angularVelocity = 0.0f;
        anim.SetBool("Ground", false);
        rigidbody2D.AddForce(force);
        grounded = false;
    }

    /// <summary>
    /// Update is called once per frame, the time between calles is fixed
    /// </summary>
    void FixedUpdate ()
    {
        MoveY();
        MoveX();

    }

    private void MoveY()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("speedY", rigidbody2D.velocity.y);
    }

    private void MoveX()
    {
        float move = Input.GetAxis("Horizontal"); // Get intputs
        if (!grounded) move *= flyingSpeedX;
        anim.SetFloat("Speed", Mathf.Abs(move));

        rigidbody2D.velocity = new Vector2(move * groundSpeedX, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight) // Check where CharacterTransform face and in which direction it's moving
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    /**
     * 
     */
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

 }
