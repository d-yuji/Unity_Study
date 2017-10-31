using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
            print("test");
        }
	}
}
