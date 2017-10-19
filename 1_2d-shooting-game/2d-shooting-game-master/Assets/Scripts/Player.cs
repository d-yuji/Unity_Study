using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed = 5;
    public GameObject bullet;

    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.01f);
        }
    }

	
	// Update is called once per frame
	void Update () {
        float playerX = Input.GetAxisRaw("Horizontal");
        float playerY = Input.GetAxisRaw("Vertical");
        
        // 移動方向をベクトルとして作成
        Vector2 direction = new Vector2(playerX, playerY).normalized;
        
        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().velocity = direction * playerSpeed;
	}
}
