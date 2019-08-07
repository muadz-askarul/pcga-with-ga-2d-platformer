using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Rigidbody2D rb;

    public GameObject emptyObject;

    bool jumping = false;

    public float runSpeed, jumpForce;
    float speed;
    public PlayerState PState;

    public bool hitGround;

    public Camera mainCamera;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        speed = runSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (PState != PlayerState.Dead) {
            Run(speed);
        }
        if (PState == PlayerState.OnGround )
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            jumping = false;
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && PState == PlayerState.OnGround)
        {
            Jump(jumpForce);
            jumping = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && PState != PlayerState.OnGround) {
            rb.velocity = new Vector2(rb.velocity.x, (Mathf.Abs(rb.velocity.y) + jumpForce) * -1);
        }
    }


    void Run(float speed) {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }


    void Jump(float jumpForce) {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "spike")
        {
            PState = PlayerState.Dead;
            StartCoroutine(RestartLevel());
        }

        if (other.transform.tag == "ground")
        {
            hitGround = true;
        }
        else
        {
            hitGround = false;
        }
        
    }

    void OnCollisionStay2D(Collision2D other)
    {

        if (other.transform.tag == "ground")
        {
            hitGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "ground")
        {
            hitGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "death box")
        {
            //emptyObject.transform.position = new Vector3(transform.position.x, 0, 0);
            PState = PlayerState.Dead;
            StartCoroutine(RestartLevel());
            rb.velocity = Vector2.zero;
        }
    }


    IEnumerator RestartLevel() {
        //yield return new WaitForSeconds(1);
        Debug.Log(transform.position.x);
        mainCamera.GetComponent<CamFollow>().enabled = false;
        

        GetComponent<SpriteRenderer>().enabled = false;
        transform.position = new Vector3(-12, -4.2f, 0);

        FindObjectOfType<RelativePosScript>().enabled = false;
        FindObjectOfType<RelativePosScript>().transform.position = new Vector3(-12, -4.2f, 0);

        speed = 0;
        
        yield return new WaitForSeconds(5);
        rb.velocity = Vector2.zero;
        mainCamera.transform.position = new Vector3(0, 1, -10);
        mainCamera.GetComponent<CamFollow>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        PState = PlayerState.Floating;


        FindObjectOfType<RelativePosScript>().enabled = true;
        speed = runSpeed;

    }

    private void disabling()
    {
       
    }

}
