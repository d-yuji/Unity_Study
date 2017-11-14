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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector2 postemp = gameObject.transform.position;
            Vector3 dir = gameObject.transform.localScale;
            if (dir.x > 0)
            {
                postemp.x += 1;
                if (!canWalk(postemp))
                {
                    int bx = (int)(3.5f + postemp.x);
                    int by = (int)(3.5f - postemp.y);
                    print(bx + "," + by);
                    if (bx >= 0 && by >= 0)
                    {
                        FindObjectOfType<Manager>().removeBlock(bx, by);
                    }
                 }
            }
            else if (dir.x < 0)
            {
                postemp.x -= 1;
                if (!canWalk(postemp))
                {
                    int bx = (int)(3.5f + postemp.x);
                    int by = (int)(3.5f - postemp.y);
                    print(bx + "," + by);
                    if (bx >= 0 && by >= 0)
                    {
                        FindObjectOfType<Manager>().removeBlock(bx, by);
                    }
                }
            }
        }

        //pos += new Vector2(playerX, playerY) * speed * Time.deltaTime;
        if (playerX > 0)
        {
            tempXR += Time.deltaTime * speed;
            if(tempXR > waitTime)
            {
                pos += Vector2.right;
                playerDir(this.gameObject,playerX);
                tempXR = 0;
            }
        }
        else if (playerX < 0)
        {
            tempXL += Time.deltaTime * speed;
            if (tempXL > waitTime)
            {
                pos += Vector2.left;
                playerDir(this.gameObject,playerX);
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


        //移動制限
        pos.x = Mathf.Clamp(pos.x, -3.5f, 3.5f);
        pos.y = Mathf.Clamp(pos.y, -3.5f, 3.5f);
        if (canWalk(pos))
        {
            transform.position = pos;
        }

	}
    void playerDir(GameObject gameObject,float playerX)
    {
        Vector3 temp = gameObject.transform.localScale;
        if (playerX > 0)
        {
            temp.x = playerScale;
        }else if(playerX < 0)
        {
            temp.x = -playerScale;
        }
        gameObject.transform.localScale = temp;
        return;
    }

    bool canWalk(Vector2 pos)
    {
        int bx = (int)(3.5f + pos.x);
        int by = (int)(3.5f - pos.y);
        //print(pos.x+" "+pos.y+","+bx+" "+by);
        return FindObjectOfType<Manager>().isBlock(bx,by);
    }
    public void gameOver()
    {
        Destroy(gameObject);
    }
}
