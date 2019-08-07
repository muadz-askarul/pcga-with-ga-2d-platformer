using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BetterJump : MonoBehaviour
{
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
    

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.y < 0 /*&& !Input.GetKey(KeyCode.Space)*/)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }

    }
    
}
