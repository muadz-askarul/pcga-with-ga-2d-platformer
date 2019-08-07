using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativePosScript : MonoBehaviour {

    public PlayerScript player;

    float speed;

	// Use this for initialization
	void Start () {
        speed = player.runSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
	}
}
