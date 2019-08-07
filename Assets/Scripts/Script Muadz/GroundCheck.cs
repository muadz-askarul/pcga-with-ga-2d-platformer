using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	public LayerMask whatIsGround;
	public Transform groundCheck1, groundCheck2, groundCheck3;
	public float groundCheckRadius;

	PlayerScript player;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		player.PState = player.hitGround == true && Physics2D.OverlapCircle (groundCheck1.position, groundCheckRadius, whatIsGround) ||
            player.hitGround == true && Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, whatIsGround) ||
            player.hitGround == true && Physics2D.OverlapCircle(groundCheck3.position, groundCheckRadius, whatIsGround)
            ? PlayerState.OnGround : PlayerState.Floating;

	}
}
