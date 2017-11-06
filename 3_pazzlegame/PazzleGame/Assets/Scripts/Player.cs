using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D playerRigidbody2D;

	// Use this for initialization
	void Start () {
        playerRigidbody2D = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        float playerX = Input.GetAxisRaw("Horizontal");
        float playerY = Input.GetAxisRaw("Vertical");
	}
}
