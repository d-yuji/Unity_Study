using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int speed = 10;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        //Destroy(this.gameObject,5);
    }
	
	// Update is called once per frame
	void Update () {
        foreach (Transform child in transform)
        {
            if (!child.gameObject.GetComponent<SpriteRenderer>().isVisible)
            {
                Destroy(this.gameObject);
            }
        }
	}
}
