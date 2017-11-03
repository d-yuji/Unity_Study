using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D playerRigidbody2D;
    //public GameObject mainCamera;
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

        if(transform.position.x > Camera.main.transform.position.x - 5)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            cameraPos.x = transform.position.x + 4;
            Camera.main.transform.position = cameraPos;
        }
        if (isGround)
        {
            if (transform.localEulerAngles.z > 45 || transform.localEulerAngles.z < -45)
            {
                print("test_rotation");
                FindObjectOfType<Manager>().GameOver();
                Destroy(gameObject);
                //Game over
            }
            playerRigidbody2D.AddForce(moveForce * (Vector2.right * playerX * moveSpeed - playerRigidbody2D.velocity));
        }
        if (Input.GetKeyDown("space") && isGround)
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpValue);
            GetComponent<AudioSource>().Play();
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
