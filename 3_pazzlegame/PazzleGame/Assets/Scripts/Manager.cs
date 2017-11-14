using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour {
    public GameObject player;
    public Text score;
    public Text highscore;
    public GameObject title;

    public GameObject[] Blocks = new GameObject[5];
    private float createY = 3.5f;
    private float[] createX = new float[] {-3.5f,-2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 3.5f, };

    public float timeOut;
    private float timeElapsed = 0;
    private int [,] blockReachFlag = new int[9,9];
    public GameObject[,] blockArrays = new GameObject[9,9];

    private int chain;
    private int scoreNum;
    private int highScore;
    private string highScoreKey = "highScore";


    private AudioSource se;

    // Use this for initialization
    void Start () {
        title = GameObject.Find("Title");
        se = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
        }
        else if(IsPlaying())
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timeOut)
            {
                //初期化
                int chain = 2;
                InitializeBlockFlag();

                //生成開始
                int randX = Random.Range(0, 8);
                int randB = Random.Range(0, 5);
                GameObject block = Instantiate(Blocks[randB], new Vector3(createX[randX], createY, 0), Blocks[randB].transform.rotation);
                int temp = fixBlockPosition(block, randX,-1);
                if(temp == -1)
                {
                    Destroy(block);
                    GameOver();
                }
                print("make block"+randX+","+temp);
                // TODO 当たり判定の再帰化
                //全位置調整=>全当たり判定=>スコア加算=>再帰
                int count = checkBlock(randX,temp, blockArrays[randX,temp]);
                if (count >= 3)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (blockReachFlag[i, j] == 2)
                            {
                                Destroy(blockArrays[i, j]);
                                se.Play();
                            }
                        }
                    }
                    AddScore(count, chain);
                }
                /*
                while (checkAllBlock(chain))
                {
                    print(chain);
                    chain++;
                }*/
                timeElapsed = 0.0f;
            }
            fixAllBlock();
        }
	}
    void GameStart()
    {
        scoreNum = 0;
        title.SetActive(false);
        Initialize();
        Instantiate(player, player.transform.position, player.transform.rotation);
    }
    public void GameOver()
    {
        title.SetActive(true);
        FindObjectOfType<Player>().gameOver();
        scoreNum = 0;
        Save();
        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                Destroy(blockArrays[i, j]);
            }
        }
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
    int fixBlockPosition(GameObject block,int x,int y)
    {
        int temp = y;

        //位置調整
        for (int i = 7; i >= 0; i--)
        {
            if (blockArrays[x, i] == null && i > y)
            {
                blockArrays[x, i] = block;
                if (temp > 0)
                {
                    blockArrays[x, temp] = null;
                }
                temp = i;

                Vector2 tempVec = block.transform.position;
                tempVec.y = 3.5f - i;
                block.transform.position = tempVec;

                break;
            }
        }
        return temp;
    }

    void fixAllBlock()
    {
        for (int i = 7; i >= 0; i--)
        {
            for(int j = 7; j >= 0; j--)
            {
                if (blockArrays[i, j] != null)
                {
                    print("fix" + i + "," + j);
                    fixBlockPosition(blockArrays[i, j], i,j);
                }
            }
        }
        return;
    }
    bool checkAllBlock(int chain)
    {
        print("cheackStart");
        bool chainFlag = false;
        for (int a = 0; a < 8; a++)
        {
            for(int b = 0; b < 8; b++)
            {
                fixAllBlock();
                if (blockArrays[a, b] != null)
                {
                    print("a,b"+a+","+b);
                    InitializeBlockFlag();
                    int count = checkBlock(a, b, blockArrays[a, b]);
                    print("checkFin");
                    print("count " + count);
                    if (count >= 3)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (blockReachFlag[i, j] == 2)
                                {
                                    Destroy(blockArrays[i, j]);
                                    se.Play();
                                }
                            }
                        }
                        AddScore(count, chain);
                        chainFlag = true;
                    }
                }
            }
        }
        return chainFlag;
    }
    void InitializeBlockFlag()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                blockReachFlag[i, j] = 0;
            }
        }
        return;
    }
    void AddScore(int count,int chain)
    {
        scoreNum += (100 * count) * chain;
        if (highScore < scoreNum)
        {
            highScore = scoreNum;
        }
        if(scoreNum >= 20000)
        {
            timeOut = 0.3f;
        }else if(scoreNum >= 2000)
        {
            timeOut = 0.5f;
        }else if(scoreNum >= 500)
        {
            timeOut = 1f;
        }
        score.text = "SCORE:" + scoreNum.ToString();
        highscore.text = "BEST:" + highScore.ToString();
        return;
    }
    public void removeBlock(int x, int y)
    {
        
        if (blockArrays[x, y] != null)
        {
            se.Play();
            Destroy(blockArrays[x, y]);
            AddScore(1, 1);
        }
        return;
    }

    private void Initialize()
    {
        // スコアを0に戻す
        scoreNum = 0;

        // ハイスコアを取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }
    public void Save()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Initialize();
    }
}
