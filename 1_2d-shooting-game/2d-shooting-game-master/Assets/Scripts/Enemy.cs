using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Spaceship spaceship;
    public int hp = 1;

	// Use this for initialization
	IEnumerator Start () {
        spaceship = GetComponent<Spaceship>();
        Move(transform.up * -1);

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
    public void Move(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().velocity = dir * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if(layerName != "Bullet(Player)")
        {
            print(layerName);
            return;
        }

        Transform playerBulletTransform = collision.transform.parent;
        Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

        hp = hp - bullet.power;

        Destroy(collision.gameObject);
        if (hp <= 0)
        {
            spaceship.Explosion();
            Destroy(gameObject);
        }
        else
        {
            spaceship.GetAnimator().SetTrigger("Damage");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
