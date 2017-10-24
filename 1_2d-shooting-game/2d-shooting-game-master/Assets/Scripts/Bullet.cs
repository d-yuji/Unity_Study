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
        int ObjCount = this.transform.childCount;
        if (ObjCount == 0)
        {
            DestroyInvisibleObject(this.gameObject);
        }
        else
        {
            foreach (Transform child in transform)
            {
                DestroyInvisibleObject(child.gameObject);
                if (!child.gameObject.GetComponent<SpriteRenderer>().isVisible)
                {
                    Destroy(this.gameObject);
                }//TODO 処理の共通化
            }
        }
	}
    void DestroyInvisibleObject(GameObject obj)
    {
        if (!obj.GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(obj.gameObject);
        }
    }
}
