using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D playerRigidbody2D;
    public GameObject mainCamera;
    public float jumpValue = 400;
    public float moveForce = 50;
    public float moveSpeed = 8;
    bool isGround = false;

	// Use this for initialization
	void Start () {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float playerX = Input.GetAxisRaw("Horizontal");
        if(transform.position.x > mainCamera.transform.position.x - 5)
        {
            Vector3 cameraPos = mainCamera.transform.position;
            cameraPos.x = transform.position.x + 4;
            mainCamera.transform.position = cameraPos;
        }
        if (isGround)
        {
            playerRigidbody2D.AddForce(moveForce * (Vector2.right * playerX * moveSpeed - playerRigidbody2D.velocity));
        }
        if (Input.GetKeyDown("space") && isGround)
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpValue);
            isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
