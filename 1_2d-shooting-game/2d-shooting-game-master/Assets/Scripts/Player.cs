using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Spaceship spaceship;

    IEnumerator Start()
    {
        spaceship = GetComponent<Spaceship>();
        while (true)
        {
            spaceship.Shot(transform);
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

	
	// Update is called once per frame
	void Update () {
        float playerX = Input.GetAxisRaw("Horizontal");
        float playerY = Input.GetAxisRaw("Vertical");
        
        // 移動方向をベクトルとして作成
        Vector2 direction = new Vector2(playerX, playerY).normalized;

        // 移動する向きとスピードを代入する
        spaceship.Move(direction);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        print(collision.gameObject.name);
        spaceship.Explosion();
        Destroy(gameObject);
    }
}
