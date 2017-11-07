using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            print(gameObject.name);
            //Destroy(gameObject);
        }
	}
}
