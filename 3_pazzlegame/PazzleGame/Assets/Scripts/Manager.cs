using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour {
    public GameObject player;
    public GameObject score;
    public GameObject title;

    public GameObject[] Blocks = new GameObject[5];
    private float createY = 3.5f;
    private float[] createX = new float[] {-3.5f,-2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 3.5f, };

    public float timeOut;
    private float timeElapsed = 0;
    private int [,] blockReachFlag = new int[9,9];
    public GameObject[,] blockArrays = new GameObject[9,9];

    private int chain;

    // Use this for initialization
    void Start () {
        title = GameObject.Find("Title");
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i<9;i++)
        {
            for(int j = 0; j < 9; j++)
            {
                blockReachFlag[i, j] = 0;
            }
        }
        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
        }
        else if(IsPlaying())
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timeOut)
            {
                int chain = 0;
                //生成
                int rand = Random.Range(0, 8);
                int randB = Random.Range(0, 3);
                GameObject block = Instantiate(Blocks[randB], new Vector3(createX[rand], createY, 0), Blocks[randB].transform.rotation);

                // TODO 当たり判定の再帰化
                //全位置調整=>全当たり判定=>スコア加算=>再帰

                int temp = fixBlockPosition(block, rand);
                int count = checkBlock(rand, temp, block);
                //print("count=" + count);

                if (count >= 3)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if(blockReachFlag[i, j] == 2)
                            {
                                Destroy(blockArrays[i, j]);
                            }
                        }
                    }
                }
                chain++;

                //スコア加算
                
                
                timeElapsed = 0.0f;
            }
        }
	}
    void GameStart()
    {
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }
    public void GameOver()
    {
        return;
    }

    private IEnumerator DelayMethond(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    public bool IsPlaying()
    {
        return title.activeSelf == false;
    }

    public bool isBlock(int bx,int by)
    {
        if(blockArrays[bx,by] == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    int checkBlock(int x,int y,GameObject gameObject)
    {
        if(x<0 || y <0 || x > 7 || y > 7)
        {
            return 0;
        }
        else if (blockReachFlag[x, y] > 0)
        {
            return 0;
        }
        else
        {
            blockReachFlag[x, y] = 1;
            if (blockArrays[x,y] != null && blockArrays[x,y].tag == gameObject.tag)
            {
                blockReachFlag[x, y] = 2;
                return 1 + checkBlock(x + 1, y,gameObject) + checkBlock(x - 1, y,gameObject) + checkBlock(x, y + 1,gameObject) + checkBlock(x, y - 1,gameObject);
            }
        }
        return 0;
    }
    int fixBlockPosition(GameObject block,int x)
    {
        int temp = 8;

        //位置調整
        for (int i = 7; i >= 0; i--)
        {
            temp = i;
            if (blockArrays[x, temp] == null)
            {
                blockArrays[x, temp] = block;
                Vector2 tempVec = block.transform.position;
                tempVec.y = 3.5f - i;
                block.transform.position = tempVec;
                break;
            }
        }
        return temp;
    }
    void chainCheck()
    {
        
    }
}
