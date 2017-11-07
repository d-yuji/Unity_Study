using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D playerRigidbody2D;
    public float speed = 10;
    private float tempXR,tempXL = 0;
    private float tempYU,tempYD = 0;
    private float waitTime = 0.8f;
    private float playerScale = 2.9f;

    // Use this for initialization
    void Start () {
        playerRigidbody2D = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        float playerX = Input.GetAxisRaw("Horizontal");
        float playerY = Input.GetAxisRaw("Vertical");
        Vector2 pos = transform.position;

        //pos += new Vector2(playerX, playerY) * speed * Time.deltaTime;
        if (playerX > 0)
        {
            tempXR += Time.deltaTime * speed;
            if(tempXR > waitTime)
            {
                pos += Vector2.right;
                Vector3 temp = transform.localScale;
                temp.x = playerScale;
                transform.localScale = temp;
                tempXR = 0;
            }
        }
        else if (playerX < 0)
        {
            tempXL += Time.deltaTime * speed;
            if (tempXL > waitTime)
            {
                pos += Vector2.left;
                Vector3 temp = transform.localScale;
                temp.x = -playerScale;
                transform.localScale = temp;
                tempXL = 0;
            }
        }
        if (playerY > 0)
        {
            tempYU += Time.deltaTime * speed;
            if (tempYU > waitTime)
            {
                pos += Vector2.up;
                tempYU = 0;
            }
        }
        else if (playerY < 0)
        {
            tempYD += Time.deltaTime * speed;
            if (tempYD > waitTime)
            {
                pos += Vector2.down;
                tempYD = 0;
            }
        }
        transform.position = pos;
	}
}
