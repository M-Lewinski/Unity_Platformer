using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceController : MonoBehaviour
{
    public float roofRadius = 0.4f;
    public float groundRadius = 0.5f;
    public LayerMask whatIsGround;
    public LayerMask whatIsRoof;
    public LayerMask CollisionLayerMask;
    public Transform roofCheck;
    public Transform groundCheck;

    public bool roof = true;

    public bool launch = false;

    public Vector3 beginPosition;

    public float raisingTime = 0.2f;

    public float fallY;

    private Rigidbody2D physics;

    public float restTime = 1.8f;

    private float waitTime;

    public float distanceFromBeginPosition = 0.2f;
    private Collider2D _collider2D;

    // Use this for initialization
    void Start()
    {
        beginPosition = gameObject.transform.position;
        waitTime = restTime;
        _collider2D = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;
        if (roof && _collider2D.isTrigger == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, Mathf.Infinity,
                CollisionLayerMask);
            if (hit.collider.name == "Character")
            {
                waitTime = restTime;
                roof = false;
                fallY = hit.collider.gameObject.transform.position.y;
                launch = true;
                if (physics) Destroy(physics);
                physics = gameObject.AddComponent<Rigidbody2D>();
                if (physics)
                {
                    physics.freezeRotation = true;
                    physics.gravityScale = 2.0f;
                }
            }
        }
        else if
            (!launch && !roof)
        {
            if (physics) Destroy(physics);
            if (waitTime <= 0.0f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, beginPosition, ref velocity, raisingTime);

            }
        }

    }

    void FixedUpdate()
    {

        if (!launch && !roof && waitTime >= 0.0f) waitTime -= Time.fixedDeltaTime;
        if ((transform.position - beginPosition).magnitude < distanceFromBeginPosition && !launch)
        {
            roof = true;
        }
        else if (!launch) roof = Physics2D.OverlapCircle(roofCheck.position, roofRadius, whatIsRoof);
        if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround))
        {
            launch = false;
            roof = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Character" && !roof )
        {
            launch = false;
        }
    }
}