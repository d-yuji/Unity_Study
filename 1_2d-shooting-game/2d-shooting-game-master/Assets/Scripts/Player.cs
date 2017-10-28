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
            GetComponent<AudioSource>().Play();
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
        Move(direction);
	}
    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;

        pos += direction * spaceship.speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "Bullet (Enemy)")
        {
            // 弾の削除
            Destroy(collision.gameObject);
        }

        // レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
        if (layerName == "Bullet(Enemy)" || layerName == "Enemy")
        {
            // 爆発する
            spaceship.Explosion();
            FindObjectOfType<Manager>().GameOver();
            // プレイヤーを削除
            Destroy(gameObject);
            
        }
    }
}
