using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceController : MonoBehaviour
{

    public float roofRadius = 0.4f;

    public LayerMask whatIsGround;
    public LayerMask whatIsRoof;
    public LayerMask CollisionLayerMask;
    public Transform roofCheck;

    public bool roof = true;

    public bool launch = false;

    public Vector3 beginPosition;

    public float fallingTime = 0.15f;

    public float raisingTime = 0.1f;

    public float fallY;

    // Use this for initialization
    void Start ()
    {
        beginPosition = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 velocity = Vector3.zero;
	    if (roof)
	    {
	        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, Mathf.Infinity, CollisionLayerMask);
	        Debug.DrawRay(gameObject.transform.position, Vector2.down * Mathf.Infinity, Color.yellow);
	        Debug.Log(hit.collider.name);
            if (hit.collider.name == "Character")
	        {
                roof = false;
	            fallY = hit.collider.gameObject.transform.position.y;
	            launch = true;
	        }
        }
        else if (launch)
	    {
	        transform.position = Vector3.SmoothDamp(transform.position, new Vector2(beginPosition.x, fallY), ref velocity, fallingTime);
        }
        else if
	        (!launch && !roof)
	    {
	        transform.position = Vector3.SmoothDamp(transform.position, beginPosition, ref velocity, raisingTime);
	        roof = Physics2D.OverlapCircle(roofCheck.position, roofRadius, whatIsRoof);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Character")
        {
            launch = false;
        }
    }

}
