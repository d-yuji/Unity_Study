using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D playerRigidbody2D;
    public float jumpValue = 500;
	// Use this for initialization
	void Start () {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float playerX = Input.GetAxisRaw("Horizontal");
        //float playerY = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(playerX, 0).normalized;
        Vector2 pos = transform.position;
        float speed = 10;
        pos += direction * speed * Time.deltaTime;
        transform.position = pos;
        if (Input.GetKeyDown("space"))
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpValue);
        }
    }
}
