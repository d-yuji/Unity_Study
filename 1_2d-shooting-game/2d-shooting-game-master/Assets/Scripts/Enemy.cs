using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () {
        spaceship = GetComponent<Spaceship>();
        spaceship.Move(transform.up * -1);

        if (!spaceship.canShot)
        {
            yield break;
        }

        while (true)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);
                spaceship.Shot(shotPosition);
            }

            yield return new WaitForSeconds(spaceship.shotDelay);
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if(layerName != "Bullet(Player)")
        {
            print(layerName);
            return;
        }
        Destroy(collision.gameObject);
        spaceship.Explosion();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
