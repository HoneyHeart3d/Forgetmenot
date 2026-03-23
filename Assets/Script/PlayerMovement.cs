using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jump;
    public float maxdistance;
    public Vector2 boxsize;
    public LayerMask mask;
    public float maxspeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Groundcheck() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jump);
        }
    }
    void FixedUpdate()
    {
        Playermove();
    }
    void Playermove()
    {
        if (rb.linearVelocity.magnitude < maxspeed)
        {
            rb.AddForce(Input.GetAxis("Horizontal") * Vector2.right * speed);
        }
    }
    public bool Groundcheck()
    {
        if (Physics2D.BoxCast(transform.position, boxsize, 0, -transform.up, maxdistance, mask))
        {
            //Debug.Log("ground");
            return true;
        }
        else
        {
            return false;
        }
    }
}
